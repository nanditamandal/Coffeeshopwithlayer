using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeShop.cs.BLL;

namespace CoffeeShop.cs
{
    public partial class Customer : Form
    {
        CustomerManager _customerManager = new CustomerManager();

        public Customer()
        {
            InitializeComponent();
        }

        public void AddButton_Click(object sender, EventArgs e)
        {

            bool isExit = _customerManager.Exitname(NametextBox.Text);
            if (isExit)
            {
                MessageBox.Show(NametextBox.Text + "\t all ready exit...");
                return;
            }
            if (String.IsNullOrEmpty(NametextBox.Text))
            {
                MessageBox.Show("name Can not be Empty!!!");
                return;
            }
            if (String.IsNullOrEmpty(AddresstextBox.Text))
            {
                MessageBox.Show("address Can not be Empty!!!");
                return;
            }
            if (String.IsNullOrEmpty(contactTextBox.Text))
            {
                MessageBox.Show("contact Can not be Empty!!!");
                return;
            }
            bool add =_customerManager .Addcustomer(NametextBox.Text, AddresstextBox.Text, contactTextBox.Text);
            if (add)
            {
                MessageBox.Show("add successfull..");

            }
            else
            {
                MessageBox.Show("add false..");
            }
           // _customerManager.Showcustomer();

        }
        public void showButton_Click(object sender, EventArgs e)
        {

            showdataGridView.DataSource = _customerManager.Showcustomer();


        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }
            bool isdelete =_customerManager .Deletecustomer(Convert.ToInt32(idTextBox.Text));
            if (isdelete)
            {
                MessageBox.Show(idTextBox.Text + "\tdelete successfull");
                
            }
            else
            {
                MessageBox.Show(idTextBox.Text + "\tdelete faild");

            }
           // _customerManager.Showcustomer();
         // Deletecustomer();

        }
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("id Can not be Empty!!!");
                return;
            }
            bool update =_customerManager .Modificustomer(NametextBox.Text, AddresstextBox.Text, contactTextBox.Text, Convert.ToInt32(idTextBox.Text));
            if (update)
            {
                MessageBox.Show(idTextBox.Text + "update is ok..");
                return;
            }
            else
            {
                MessageBox.Show(idTextBox.Text + "no data found..");
            }
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            _customerManager.Searchcustomer(NametextBox.Text);

        }

       


       
    

        
        
        
       

        private void idTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void contactTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
