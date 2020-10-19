using DataGridDemo1.Domain;
using DataGridDemo1.UtilityClasses;
using DataGridDemo1.ViewModels.Commands;
using DataGridDemo1.ViewModels.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataGridDemo1.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields

        // Property variables
        private ObservableCollection<GroceryItem> _groceryList;
        private int _itemCount;

        #endregion

        #region Constructor

        public MainWindowViewModel()
        {
            this.Initialize();
        }

        #endregion

        #region Command Properties

        /// <summary>
        /// Deletes the currently-selected item from the Grocery List.
        /// </summary>
        public ICommand DeleteItem { get; private set; }

        #endregion

        #region Data Properties

        /// <summary>
        /// A grocery list.
        /// </summary>
        public ObservableCollection<GroceryItem> GroceryList
        {
            get { return _groceryList; }

            set
            {
                _groceryList = value;
                base.RaisePropertyChangedEvent(nameof(GroceryList));
            }
        }

        /// <summary>
        /// The currently-selected grocery item.
        /// </summary>
        public GroceryItem SelectedItem { get; set; }

        /// <summary>
        /// The number of items in the grocery list.
        /// </summary>

        public int ItemCount
        {
            get { return _itemCount; }

            set
            {
                _itemCount = value;
                base.RaisePropertyChangedEvent("ItemCount");
            }
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Updates the ItemCount Property when the GroceryList collection changes.
        /// </summary>
        void OnGroceryListChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // Update item count
            this.ItemCount = this.GroceryList.Count;

            // Resequence list
            SequencingService.SetCollectionSequence(this.GroceryList);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initializes this application.
        /// </summary>
        private void Initialize()
        {
            // Initialize commands
            this.DeleteItem = new DeleteItemCommand(this);

            // Create grocery list
            _groceryList = new ObservableCollection<GroceryItem>();

            // Subscribe to CollectionChanged event
            _groceryList.CollectionChanged += OnGroceryListChanged;

            // Add items to the list
            _groceryList.Add(new GroceryItem("Macaroni"));
            _groceryList.Add(new GroceryItem("Shredded Wheat"));
            _groceryList.Add(new GroceryItem("Fish Filets"));
            _groceryList.Add(new GroceryItem("Hamburger Buns"));
            _groceryList.Add(new GroceryItem("Whipped Cream"));
            _groceryList.Add(new GroceryItem("Soft Drinks"));
            _groceryList.Add(new GroceryItem("Bread"));
            _groceryList.Add(new GroceryItem("Ice Cream"));
            _groceryList.Add(new GroceryItem("Chocolate Pudding"));
            _groceryList.Add(new GroceryItem("Sliced Turkey"));
            _groceryList.Add(new GroceryItem("Turkey Dressing"));
            _groceryList.Add(new GroceryItem("Cranberry Sauce"));
            _groceryList.Add(new GroceryItem("Swiss Cheese"));
            _groceryList.Add(new GroceryItem("Mushrooms"));
            _groceryList.Add(new GroceryItem("Butter"));
            _groceryList.Add(new GroceryItem("Eggs"));
            _groceryList.Add(new GroceryItem("Potatoes"));
            _groceryList.Add(new GroceryItem("Onion"));

            // Initialize list index
            this.GroceryList = SequencingService.SetCollectionSequence(this.GroceryList);

            // Update bindings
            base.RaisePropertyChangedEvent("GroceryList");
        }

        #endregion
    }
}
