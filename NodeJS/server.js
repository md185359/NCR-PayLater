const express = require('express');
const morgan = require('morgan');

// express app
const app = express();

// listen for requests
app.listen(3000);

// register view engine
app.set('view engine', 'ejs');

const customer = {Name : 'Mr.XYZ', Cid : '10258', Eligibilty : 'Yes', AmountDue : '$550'}

// middleware & static files
app.use(express.static('public'));

app.use((req, res, next) => {
  console.log('new request made:');
  console.log('host: ', req.hostname);
  console.log('path: ', req.path);
  console.log('method: ', req.method);
  next();
});

app.use((req, res, next) => {
  console.log('in the next middleware');
  next();
});

app.use(morgan('dev'));

app.use((req, res, next) => {
  res.locals.path = req.path;
  next();
});

app.get('/', (req, res) => {
  const blogs = [
    {title: 'ABC Bank Ltd', snippet: 'Relationship beyond banking'},
  ];
  res.render('index', { title: 'Home', blogs });
});

app.get('/about', (req, res) => {
  res.render('about', { title: 'About' });
});

app.get('/blogs/create', (req, res) => {
  res.render('create', { title: 'Create a new blog' });
  console.log('Name :',customer.Name,' CustomerID :',' Eligibilty :',customer.Eligibilty,' AmountDue : ',customer.AmountDue);
});

// 404 page
app.use((req, res) => {
  res.status(404).render('404', { title: '404' });
});