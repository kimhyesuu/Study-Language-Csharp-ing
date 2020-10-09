using System.Windows.Input;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Prism4Demo.Common.BaseClasses;
using Prism4Demo.Common.Events;
using Prism4Demo.ModuleA.Commands;

namespace Prism4Demo.ModuleA.ViewModels
{
    public class ModuleATaskButtonViewModel : ViewModelBase, INavigationAware
    {
        #region Fields

        // Property variables
        private bool? p_IsChecked;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ModuleATaskButtonViewModel()
        {
            this.Initialize();
        }

        #endregion

        #region INavigationAware Members

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            throw new System.NotImplementedException();
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            throw new System.NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Command Properties

        /// <summary>
        /// Loads the view for Module A.
        /// </summary>
        public ICommand ShowModuleAView { get; set; }   

        #endregion

        #region Administrative Properties

        /// <summary>
        /// Whether the button is checked (selected).
        /// </summary>
        public bool? IsChecked
        {
            get { return p_IsChecked; }

            set
            {
                base.RaisePropertyChangingEvent("IsChecked");
                p_IsChecked = value;
                base.RaisePropertyChangedEvent("IsChecked");
            }
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Sets the IsChecked state of the Task Button when navigation is completed.
        /// </summary>
        /// <param name="publisher">The publisher of the event.</param>
        private void OnNavigationCompleted(string publisher)
        {
            // Exit if this module published the event
            if (publisher == "ModuleA") return;

            // Otherwise, uncheck this button
            this.IsChecked = false;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initializes the view model.
        /// </summary>
        private void Initialize()
        {
            // Initialize command properties
            this.ShowModuleAView = new ShowModuleAViewCommand(this);

            // Initialize administrative properties
            this.IsChecked = false;

            // Subscribe to Composite Presentation Events
            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            var navigationCompletedEvent = eventAggregator.GetEvent<NavigationCompletedEvent>();
            navigationCompletedEvent.Subscribe(OnNavigationCompleted, ThreadOption.UIThread);
        }

        #endregion
    }
}