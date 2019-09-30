using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.cs.Repository
{
    public class ItemsRepository
    {
        public bool IsNameExists(string name)
        {
            bool exists = false;
            try
            {

                string connectionString = @"NANDITA; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);


                string commandString = @"SELECT * FROM Items WHERE Name='" + name + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);


                sqlConnection.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    exists = true;
                }

                sqlConnection.Close();

            }
            catch (Exception exeption)
            {
                //MessageBox.Show(exeption.Message);
            }

            return exists;
        }
        public bool Additem(string name, int price)
        {
            bool added = false;
            try
            {
                string connectionString = @"Server=NANDITA;DataBase=CoffeeShop;Integrated Security=true";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                string CommandString = @"INSERT INTO Items (ItemName, Price) VALUES('" + name + "'," + price + ")";

                SqlCommand sqlCommand = new SqlCommand(CommandString, sqlConnection);
                sqlConnection.Open();
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    return added = true;
                }

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("please fill the name and price");
            }
            return added;
        }

        public DataTable Showitem()
        {


            string connectionString = @"Server=NANDITA;DataBase=CoffeeShop;Integrated Security=true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string CommandString = @"SELECT *FROM Items";

            SqlCommand sqlCommand = new SqlCommand(CommandString, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                //showdataGridView.DataSource = dataTable;
                return dataTable;
            }
            else
            {
               // MessageBox.Show("no data for show..");
            }
            sqlConnection.Close();

            return dataTable;
        }

        public bool Deleteitem(int id)
        {
            try
            {
                string connection = @"Server=NANDITA;DataBase=CoffeeShop;Integrated Security=True";
                SqlConnection sqlconnection = new SqlConnection(connection);
                string delete = @"DELETE FROM Items WHERE ID='" + id + "'";
                SqlCommand command = new SqlCommand(delete, sqlconnection);

                sqlconnection.Open();
                int isExecuted = command.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    return true;
                    //MessageBox.Show("delete successfull ..");
                }
                else
                {
                   
                }
                sqlconnection.Close();
            }
            catch (Exception e)
            {
               
            }
            return false;

        }

        public bool Modifyitem(string name, int price, int id)
        {
            try
            {
                string connection = @"Server=NANDITA;DataBase=CoffeeShop;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connection);

                string modifi = @"UPDATE Items SET ItemName='" + name + "', Price=" + price + " WHERE ID='" + id + "'";
                SqlCommand command = new SqlCommand(modifi, sqlConnection);

                sqlConnection.Open();

                int isExecuted = command.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    return true;
                }

                sqlConnection.Close();
            }
            catch (Exception e)
            {
                
            }
            return false;

        }

        public DataTable Searchitem(string name)
        {

            string connectionString = @"Server=NANDITA;DataBase=CoffeeShop;Integrated Security=true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string CommandString = @"SELECT * FROM Items WHERE ItemName='" + name + "'";

            SqlCommand sqlCommand = new SqlCommand(CommandString, sqlConnection);
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                return dataTable;
                //showdataGridView.DataSource = dataTable;
            }

            sqlConnection.Close();
            return dataTable;

        }

    }
}
