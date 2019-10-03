using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShopDatabase.Respository;
using System.Data;

using CoffeeShopDatabase.Model;

namespace CoffeeShopDatabase.BLL
{
    class ItemManager
    {
        ItemRepository _itemRepository = new ItemRepository();

        public bool Add(Item item)
        {
            return _itemRepository.Add(item);
        }

        public bool Delete(int ItemId)
        {
            return _itemRepository.Delete(ItemId);
        }
        public bool IsNameExists(string name)
        {
            return _itemRepository.IsNameExists(name);
        }
        public bool Update(string Name, double Price, int ItemId)
        {
            return _itemRepository.Update(Name,Price,ItemId);
        }
        public DataTable Display()
        {
            return _itemRepository.Display();
        }
        public DataTable Search(string name)
        {
            return _itemRepository.Search(name);
        }
        public DataTable ItemCombobox()
        {
            return _itemRepository.ItemCombobox();
        }
        public DataTable CustomerComboBox()
        {
            return _itemRepository.CustomerComboBox();
        }
    }
}
