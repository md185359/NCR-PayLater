// <copyright file="CustomClearableIntervention.xaml.cs" company="NCR Corporation">
//     Copyright 2016-2018 NCR Corporation. All rights reserved.
// </copyright>
namespace SSCOUIViews.Views
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Timers;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media.Animation;
    using System.Windows.Media.Imaging;
    using LibVLCSharp.Shared;
    using RPSWNET;
    using SSCOControls;
    using SSCOUIModels;
    using SSCOUIModels.Controls;
    using SSCOUIViewModels;
    using SSCOUIViewModels.Helpers;
    using ColesViewModels;
    using System.Collections.Generic;
    using System.Globalization;
    using SSCOUIViewModels.EventArguments;
	
	/// ccpid context

    /// <summary>
    /// Interaction logic for CustomClearableIntervention.xaml.
    /// This class has handling for store mode contexts "SMDataEntryWithVideoControl".
    /// </summary>
    public partial class PayLaterDisplay : PopupView
    {

        /// <summary>
        /// The CustomClearableIntervention ViewModel object.
        /// </summary>
        private ColesPayLaterDisplayViewModel _storeModeWithImageVideoViewModel = null;

        /// <summary>
        /// Initializes a new instance of the StoreModeWithImageVideo class.
        /// </summary>
        /// <param name="mainViewModel">Parameter that inherits the interface of MainViewModel.</param>
        public PayLaterDisplay(IMainViewModel mainViewModel)
            : base(mainViewModel)
        {
            _storeModeWithImageVideoViewModel = ColesPayLaterDisplayViewModel.GetColesPayLaterDisplayViewModel(mainViewModel);
            InitializeComponent();
            DataContext = _storeModeWithImageVideoViewModel;
            SubscribesToStoreModeWithImageVideoViewModelEvents();

            Logger.Instance.Info("kumar PayLaterDisplay");
        }

        /// <summary>
        /// OnStateParamChanged that accepts param that is set in app.config.
        /// </summary>
        /// <param name="param">String type of parameter.</param>
        public override void OnStateParamChanged(string param)
        {
            Logger.Instance.Info("kumar OnStateParamChanged");
            _storeModeWithImageVideoViewModel.HandleStateParamChanged(param);

            Logger.Instance.Info("kumar OnStateParamChanged {0}", param);
            if (param.Equals("PayLaterDisplay"))
            {
                SetCtrlImage("C:/LocalApp/Coles/Media/Images/PromptNew.png");
            }
            
        }

        /// <summary>
        /// Accepts a property change as configured in app.config.
        /// </summary>
        /// <param name="name">Name of changed property.</param>
        /// <param name="value">Value of changed property.</param>
        public override void OnPropertyChanged(string name, object value)
        {
            Logger.Instance.Info("kumar OnPropertyChanged");
            _storeModeWithImageVideoViewModel.HandlePropertyChanged(name, value);
        }

        /// <summary>
        /// Subscribe to the StoreModeWithImageVideo ViewModel events.
        /// </summary>
        private void SubscribesToStoreModeWithImageVideoViewModelEvents()
        {
            if (_storeModeWithImageVideoViewModel == null)
            {
                Logger.Instance.Info("kumar SubscribesToStoreModeWithImageVideoViewModelEvents null");
                return;
            }

            Logger.Instance.Info("kumar SubscribesToStoreModeWithImageVideoViewModelEvents not-null");

            _storeModeWithImageVideoViewModel.VideoWidthChanged += StoreModeWithImageVideoViewModel_VideoWidthChanged;
            _storeModeWithImageVideoViewModel.ImageItemCodeTextChanged += StoreModeWithImageVideoViewModel_ImageItemCodeTextChanged;
            _storeModeWithImageVideoViewModel.ImageWidthChanged += StoreModeWithImageVideoViewModel_ImageWidthChanged;
            _storeModeWithImageVideoViewModel.TextHorizontalAlignmentChanged += StoreModeWithImageVideoViewModel_TextHorizontalAlignmentChanged;
            _storeModeWithImageVideoViewModel.SetDataEntryImageCtrl += StoreModeWithImageVideoViewModel_SetDataEntryImageCtrl;
          //  _storeModeWithImageVideoViewModel.SetDataEntryImageCtrl += StoreModeWithImageVideoViewModel_SetDataEntryImageCtrlTwo;
            //_storeModeWithImageVideoViewModel.UpdatePromoBitmapImage += StoreModeWithImageVideoViewModel_UpdatePromoBitmapImage;
        }



        /// <summary>
        /// Event handler for showing an image.
        /// </summary>
        /// <param name="sender">The sending object.</param>
        /// <param name="e">The event arguments.</param>
        private void StoreModeWithImageVideoViewModel_SetDataEntryImageCtrl(object sender, PathEventArgs e)
        {
            Logger.Instance.Info("kumar SetDataEntryImageCtrl null");
            SetCtrlImage(e.ImageSourcePath);
        }

        /// <summary>
        /// Event handler for SMLine text horizontal alignment changed.
        /// </summary>
        /// <param name="sender">The sending object.</param>
        /// <param name="e">The event arguments.</param>
        private void StoreModeWithImageVideoViewModel_TextHorizontalAlignmentChanged(object sender, HorizontalAlignmentEventArgs e)
        {
            SMLineText.HorizontalAlignment = e.IsHorizontalAlignmentCenter
                ? HorizontalAlignment.Center : HorizontalAlignment.Stretch;
        }

        /// <summary>
        /// Event handler for image width changed.
        /// </summary>
        /// <param name="sender">The sending object.</param>
        /// <param name="e">The event arguments.</param>
        private void StoreModeWithImageVideoViewModel_ImageWidthChanged(object sender, StyleEventArgs e)
        {
            ImageVideoGrid.Width = (double)FindResource(e.Style);
           // ImageCcpid.Width = (double)FindResource(e.Style);
        }

        /// <summary>
        /// Event handler for image item code text changed.
        /// </summary>
        /// <param name="sender">The sending object.</param>
        /// <param name="e">The event arguments.</param>
        private void StoreModeWithImageVideoViewModel_ImageItemCodeTextChanged(object sender, BindResourceEventArgs e)
        {
            ImageItemCodeText.Property(MeasureTextBlock.TextProperty).SetResourceValue(e.ResourceKey);
            ImageItemCodeText.Text += ViewModel.CurrentItem.ItemCode;
        }

        /// <summary>
        /// Event handler for video width changed.
        /// </summary>
        /// <param name="sender">The sending object.</param>
        /// <param name="e">The event arguments.</param>
        private void StoreModeWithImageVideoViewModel_VideoWidthChanged(object sender, StyleEventArgs e)
        {
            ImageVideoGrid.Width = (double)FindResource(e.Style);
          //  ImageCcpid.Width = (double)FindResource(e.Style);
        }

        /// <summary>
        /// Set the image for the control.
        /// </summary>
        /// <param name="strImagePath">File path for the image</param>
        private void SetCtrlImage(string strImagePath)
        {
            Logger.Instance.Info("Bhaskar");
            try
            {
                Logger.Instance.Info("Bhaskar SetCtrlImage() : " + strImagePath);
                if (!System.IO.File.Exists(strImagePath))
                {
                    Logger.Instance.Warn("Unable to find the Image File: {0}", strImagePath);
                    return;
                }

                strImagePath = "C:/LocalApp/Coles/Media/Images/PromptNew.png";

                CmDataCapture.CaptureFormat(CmDataCapture.MaskInfo, "-PromoBitmapImage :{0} = ", strImagePath);
                BitmapImage image = new BitmapImage();
           //     image.Freeze();
              //  image.UriSource
          //      Uri lol = image.BaseUri;
         //       string ab = lol.AbsolutePath;
                image.BeginInit();
                image.UriSource = new Uri(string.Format(CultureInfo.CurrentCulture, strImagePath.ToString()), UriKind.Absolute);
                image.EndInit();
                PromoImage.Source = image;
                
               // PromoImage.Width = 240;
             //   PromoImage.Height = 240;
                //temp_image_path = ViewModel.GetStringPropertyValue(string.Empty);
                strImagePath = null;
             //   PromoImage.Visibility = Visibility.Visible;
                
            }
            catch (ArgumentNullException e)
            {
                Logger.Instance.Error(
                    "SSCOUIViews.Views.SystemMessage.SetCtrlImage ArgumentNullException: {0}", e.Message);
            }
            catch (ArgumentException e)
            {
                Logger.Instance.Error(
                    "SSCOUIViews.Views.SystemMessage.SetCtrlImage ArgumentException: {0}", e.Message);
            }
            catch (InvalidOperationException e)
            {
                Logger.Instance.Error(
                    "SSCOUIViews.Views.SystemMessage.SetCtrlImage InvalidOperationException: {0}", e.Message);
            }
        }

        /// <param name="sender">Sending object.</param>
        /// <param name="e">Event arguments.</param>
        private void PopupView_Loaded(object sender, RoutedEventArgs e)
        {
            FocusInitialButton(CustomPopupMainGrid1);
        }
    }
}
