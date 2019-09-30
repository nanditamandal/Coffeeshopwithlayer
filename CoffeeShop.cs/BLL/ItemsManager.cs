using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using CoffeeShop.cs.Repository;

namespace CoffeeShop.cs.BLL
{
    public class ItemsManager
    {
        ItemsRepository _itemsRepository = new ItemsRepository();

            public bool IsNameExists(string name)
            {
                return _itemsRepository.IsNameExists(name);
            }
             public bool Additem(string name, int price)
            {
                return _itemsRepository.Additem(name, price);
            }
            public DataTable Showitem()
            {
                return _itemsRepository.Showitem();
            }
            public bool Deleteitem(int id)
            {
                return _itemsRepository.Deleteitem(id);
            }
            public bool Modifyitem(string name, int price, int id)
            {
                return _itemsRepository.Modifyitem(name, price, id);
            }
            public DataTable Searchitem(string name)
            {
                return _itemsRepository.Searchitem(name);
            }

    }
}
