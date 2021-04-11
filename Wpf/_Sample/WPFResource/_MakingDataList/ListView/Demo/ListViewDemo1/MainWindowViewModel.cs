using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewDemo1
{
    public class Item
    {
        public Item(string name, string matches)
        {
            Name = name;
            Matches = matches;
        }

        public string Name { get; set; }
        public string Matches { get; set; }
    }

    public class ItemHandler
    {
        public ItemHandler()
        {
            Items = new List<Item>();
        }

        public List<Item> Items { get; private set; }

        public void Add(Item item)
        {
            Items.Add(item);
        }
    }


    public class MainWindowViewModel
    {
        private readonly ItemHandler _itemHandler;

        public MainWindowViewModel()
        {
            _itemHandler = new ItemHandler();
            _itemHandler.Add(new Item("John Doe", "12"));
            _itemHandler.Add(new Item("Jane Doe", "133"));
            _itemHandler.Add(new Item("Sammy Doe", "45"));
        }

		// 이렇게 잡는 것
        public List<Item> Items
        {
            get { return _itemHandler.Items; }
        }
    }
}
