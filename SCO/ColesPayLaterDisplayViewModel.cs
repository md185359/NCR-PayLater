namespace ColesViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SSCOUIModels;
    using SSCOUIViewModels;
    using SSCOUIViewModels.Helpers;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    using RPSWNET;
    using System.Globalization;
    using SSCOUIModels.Helpers;
    public class ColesPayLaterDisplayViewModel : StoreModeWithImageVideoViewModel
    {
        /// <summary>
        /// Initializes a new instance of the CustomCustomPopupViewModel class.
        /// </summary>
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreModeWithVideoViewModel" /> class.
        /// </summary>
        public ColesPayLaterDisplayViewModel()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreModeWithVideoViewModel" /> class.
        /// </summary>
        /// <param name="mainViewModel">The main ViewModel.</param>
        protected ColesPayLaterDisplayViewModel(IMainViewModel mainViewModel)
            : base(mainViewModel)
        {

        }


        /// <summary>
        /// Public 'factory' method that constructs a new instance and invokes after-construction initialization.
        /// </summary>
        /// <param name="mainViewModel">The main ViewModel object.</param>
        /// <returns>The new StoreModeWithImageVideoViewModel object.</returns>
        public static ColesPayLaterDisplayViewModel GetColesPayLaterDisplayViewModel(IMainViewModel mainViewModel)
        {
            var storeModeWithVideoViewModel = new ColesPayLaterDisplayViewModel(mainViewModel);
            storeModeWithVideoViewModel.InitializeAfterConstructor();

            return storeModeWithVideoViewModel;
        }

        public event EventHandler UpdatePromoBitmapImage;

        protected virtual void OnUpdatePromoBitmapImage(IMainViewModel mainViewModel)
        {
            if (UpdatePromoBitmapImage != null)
            {
                UpdatePromoBitmapImage(this, EventArgs.Empty);
            }
        }

        public override void InitializeAfterConstructor()
        {
            base.InitializeAfterConstructor();
        }
    }
}
