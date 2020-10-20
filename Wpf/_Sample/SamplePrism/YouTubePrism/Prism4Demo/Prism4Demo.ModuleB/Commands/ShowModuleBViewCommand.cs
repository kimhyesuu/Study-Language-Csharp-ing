using System;
using System.Windows.Input;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Prism4Demo.Common.Events;

namespace Prism4Demo.ModuleB.Commands
{
    public class ShowModuleBViewCommand : ICommand
    {
        #region Fields

        // Member variables
        private ModuleBTaskButtonViewModel m_ViewModel;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ShowModuleBViewCommand(ModuleBTaskButtonViewModel viewModel)
        {
            m_ViewModel = viewModel;
        }

        #endregion

        #region ICommand Members

        /// <summary>
        /// Whether the ShowModuleBViewCommand is enabled.
        /// </summary>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Actions to take when CanExecute() changes.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Executes the ShowModuleBViewCommand
        /// </summary>
        public void Execute(object parameter)
        {
            // Initialize
            var regionManager = (RegionManager)ServiceLocator.Current.GetInstance<IRegionManager>();

            // Show Ribbon Tab
            var moduleBRibbonTab = new Uri("ModuleBRibbonTab", UriKind.Relative);
            regionManager.RequestNavigate("RibbonRegion", moduleBRibbonTab);

            // Show Navigator
            var moduleBNavigator = new Uri("ModuleBNavigator", UriKind.Relative);
            regionManager.RequestNavigate("NavigatorRegion", moduleBNavigator);

            /* We invoke the NavigationCompleted() callback method in the next  
             * navigation request since it is the last request we have to make. */

            // Show Workspace
            var moduleBWorkspace = new Uri("ModuleBWorkspace", UriKind.Relative);
            regionManager.RequestNavigate("WorkspaceRegion", moduleBWorkspace, NavigationCompleted);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Callback method invoked when navigation has completed.
        /// </summary>
        /// <param name="result">Provides information about the result of the navigation.</param>
        private void NavigationCompleted(NavigationResult result)
        {
            // Exit if navigation was not successful
            if (result.Result != true) return;

            // Publish ViewRequestedEvent
            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            var navigationCompletedEvent = eventAggregator.GetEvent<NavigationCompletedEvent>();
            navigationCompletedEvent.Publish("ModuleB");
        }

        #endregion
    }
}
