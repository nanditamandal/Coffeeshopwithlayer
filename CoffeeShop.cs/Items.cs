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
    public partial class Items : Form
    {
        ItemsManager _itemsManager = new ItemsManager();
        public Items()
        {
            InitializeComponent();
        }

        private void Items_Load(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (_itemsManager.IsNameExists(nameTextBox.Text))
            {
                MessageBox.Show(nameTextBox.Text + "Already Exists!");
                return;
            }

            
            if (String.IsNullOrEmpty(priceTextBox.Text))
            {
                MessageBox.Show("Price Can not be Empty!!!");
                return;
            }

            bool added = _itemsManager.Additem(nameTextBox.Text, Convert.ToInt32(priceTextBox.Text));

            if (added)
            {
                MessageBox.Show("Saved");
              
            }
            else
            {
                MessageBox.Show("Not Saved");
            }

            _itemsManager.Showitem();
           
           

        }
        

        private void showButton_Click(object sender, EventArgs e)
        {
            DataTable showitem = _itemsManager.Showitem();

            if (showitem.Rows.Count > 0)
            {
                showdataGridView.DataSource = showitem;
            }
            else
            {
                MessageBox.Show("can not show item..");
            }
        }
        
        private void deleteButton_Click(object sender, EventArgs e)
        {
           
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }
            if (_itemsManager.Deleteitem(Convert.ToInt32(idTextBox.Text)))
            {
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }
            _itemsManager.Showitem();
            
        }
       


        private void updateButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }
            //Set Price as Mandatory
            if (String.IsNullOrEmpty(priceTextBox.Text))
            {
                MessageBox.Show("Price Can not be Empty!!!");
                return;
            }
            if (_itemsManager.Modifyitem(nameTextBox.Text, Convert.ToInt32(priceTextBox.Text), Convert.ToInt32(idTextBox.Text)))
            {
                MessageBox.Show("Updated");
                _itemsManager.Showitem();
            }
            else
            {
                MessageBox.Show("Not Updated");
            }
            
        }
       


        private void searchButton_Click(object sender, EventArgs e)
        {
            DataTable dataTable = _itemsManager.Searchitem(nameTextBox.Text);

            if (dataTable.Rows.Count>0)
            {
                showdataGridView.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("no data found");
            }
        }
        
        
     
      
        

        private void priceTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
