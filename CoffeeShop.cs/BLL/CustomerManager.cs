using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using CoffeeShop.cs.Repository;

namespace CoffeeShop.cs.BLL
{
    public class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();

        public bool Addcustomer(string name, string address, string contact)
        {
           return _customerRepository.Addcustomer(name, address, contact);
        }

        public bool Exitname(string name)
        {
            return _customerRepository.Exitname(name);

        }
        public bool Deletecustomer(int id)
        {
            return _customerRepository.Deletecustomer(id);

        }
       public bool Modificustomer(string name, string address, string contact, int id)

        {
            return _customerRepository.Modificustomer(name, address, contact, id);
        }
        public DataTable Showcustomer()
        {
            return _customerRepository.Showcustomer();
        }
        public DataTable Searchcustomer(string name)
        {
            return _customerRepository.Searchcustomer(name);
        }
    }
}
