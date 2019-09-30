using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CoffeeShop.cs.Repository;
using System.Threading.Tasks;

namespace CoffeeShop.cs.BLL
{
    public class OrderManagement
    {
        OrderRepository _orderRepository = new OrderRepository();

        public bool Addorder(string name, string item, int quantity)
        {
            return _orderRepository.Addorder(name, item, quantity);

        }
        public DataTable Showorder()
        {
            return _orderRepository.Showorder();

        }

        public bool Updateorder(string name, string item, int quantity, int id)
        {
            return _orderRepository.Updateorder(name, item, quantity, id);

        }
        public bool Deleteorder(int id)
        {
            return _orderRepository.Deleteorder(id);

        }

        public DataTable Searchorder(string name)
        {
            return _orderRepository.Searchorder(name);

        }
    }
}
