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
    public partial class Order : Form
    {
        OrderManagement _orderManagement = new OrderManagement();

        public Order()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(customerNameTextBox.Text))
            {
                MessageBox.Show("name Can not be Empty!!!");
                return;
            }
            if (String.IsNullOrEmpty(itemNameTextBox.Text))
            {
                MessageBox.Show("item name Can not be Empty!!!");
                return;
            }
            if (String.IsNullOrEmpty(quantityTextBox.Text))
            {
                MessageBox.Show("quantity Can not be Empty!!!");
                return;
            }
            if (_orderManagement.Addorder(customerNameTextBox.Text, itemNameTextBox.Text, Convert.ToInt32( quantityTextBox.Text)))
            {
                MessageBox.Show("order added..");
            }
            else
            {
                MessageBox.Show("order can not added..");
            }
            
        }
        private void showButton_Click(object sender, EventArgs e)
        {
            DataTable showorder = _orderManagement.Showorder();
            if (showorder.Rows.Count > 0)
            {
                showdataGridView.DataSource = showorder;
            }
            else
            {
                MessageBox.Show("no data found");
            }

        }
        private void updateButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("id Can not be Empty!!!");
                return;
            }
            if (String.IsNullOrEmpty(customerNameTextBox.Text))
            {
                MessageBox.Show("name Can not be Empty!!!");
                return;
            }
            if (String.IsNullOrEmpty(itemNameTextBox.Text))
            {
                MessageBox.Show("item name Can not be Empty!!!");
                return;
            }
            if (String.IsNullOrEmpty(quantityTextBox.Text))
            {
                MessageBox.Show("quantity Can not be Empty!!!");
                return;
            }
            if (_orderManagement.Updateorder(customerNameTextBox.Text, itemNameTextBox.Text, Convert.ToInt32(quantityTextBox.Text), Convert.ToInt32(idTextBox.Text)))
            {
                MessageBox.Show("order updatede..");
            }
            else
            {
                MessageBox.Show("order can not updatede..");
            }

        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("id Can not be Empty!!!");
                return;
            }
            if (_orderManagement.Deleteorder(Convert.ToInt32(idTextBox.Text)))
            { MessageBox.Show("delete successfull .."); }
            else { MessageBox.Show("id can not delete .."); }




        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(customerNameTextBox.Text))
            {
                MessageBox.Show("name Can not be Empty!!!");
                return;
            }
            DataTable dataTable = _orderManagement.Searchorder(customerNameTextBox.Text);
            if (dataTable.Rows.Count > 0)
            { showdataGridView.DataSource = dataTable; }
            else { MessageBox.Show("no data found"); }
        }

        

        private void quantityTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void idTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
