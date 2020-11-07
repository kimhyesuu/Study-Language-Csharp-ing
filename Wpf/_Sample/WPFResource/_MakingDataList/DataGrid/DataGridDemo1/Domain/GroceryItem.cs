using DataGridDemo1.UtilityClasses;

namespace DataGridDemo1.Domain
{
    public class GroceryItem : ObservableObject, ISequencedObject
    {
        #region Fields

        // Property variables
        private int p_SequenceNumber;
        private string p_Name;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public GroceryItem()
        {
        }

        /// <summary>
        /// Paramterized constructor.
        /// </summary>
        /// <param name="itemName">The name of the grocery item.</param>
        public GroceryItem(string itemName)
        {
            p_Name = itemName;
        }

        /// <summary>
        /// Paramterized constructor.
        /// </summary>
        /// <param name="itemName">The name of the grocery item.</param>
        /// <param name="itemIndex">The sequential position of the item in a grocery list.</param>
        public GroceryItem(string itemName, int itemIndex)
        {
            p_Name = itemName;
            p_SequenceNumber = itemIndex;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The sequential position of this item in a list of items.
        /// </summary>
        public int SequenceNumber
        {
            get { return p_SequenceNumber; }

            set
            {
                p_SequenceNumber = value;
                base.RaisePropertyChangedEvent("SequenceNumber");
            }
        }

        /// <summary>
        /// The name of the grocery item.
        /// </summary>
        public string Name
        {
            get { return p_Name; }

            set
            {
                p_Name = value;
                base.RaisePropertyChangedEvent("Text");
            }
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Sets the item name as its ToString() value.
        /// </summary>
        /// <returns>The name of the item.</returns>
        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}
