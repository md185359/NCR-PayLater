// <copyright file="PayLaterDisplayPlugin.cs" company="NCR">
//     Copyright 2017-2018 NCR Corporation. All rights reserved.
// </copyright>
namespace SSCOUIViews.ViewsPluginContracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using SSCOUIModels;
    using SSCOUIViews.Views;
    using SSCOUIViewsPluginContracts;

	/// ccpid context

    /// <summary>
    /// Plugin implementation for the CustomClearableIntervention View.
    /// </summary>
    public class PayLaterDisplayPlugin : ViewPluginBase, IViewPlugin, IViewPluginOneOneTwo
    {
        /// <summary>
        /// Gets the Plugin ID of the CustomClearableIntervention View.
        /// </summary>
        public override string ViewName
        {
            get
            {
                return "PayLaterDisplay";
            }
        }

        /// <summary>
        /// Implements IViewPluginOneOneTwo member IsPopupView.
        /// Gets a value indicating whether the view is a popup view.
        /// </summary>
        public override bool IsPopupView
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Creates the CustomClearableIntervention View.
        /// </summary>
        /// <param name="viewModel">The ViewModel</param>
        /// <returns>The CustomClearableIntervention View.</returns>
        public override object CreateView(IMainViewModel viewModel)
        {
            base.CreateView(viewModel);
            return new PayLaterDisplay(viewModel);
        }
    }
}
