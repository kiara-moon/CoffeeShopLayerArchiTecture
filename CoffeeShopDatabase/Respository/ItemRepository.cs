﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CoffeeShopDatabase.Model;

namespace CoffeeShopDatabase.Respository
{
    class ItemRepository
    {
        public bool Add(Item item)
        {
            bool isAdded = false;
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-LO8RRRJ; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"INSERT INTO Items (Name, Price) Values ('" + item.Name + "', "+item.Price+" )";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();
                //Insert
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    isAdded = true;
                }

                //if (!isNameExists(nameTextBox.Text))
                //{
                //    //Insert
                //    int isExecuted = sqlCommand.ExecuteNonQuery();
                //    if (isExecuted > 0)
                //    {
                //        isAdded = true;
                //    }

                //}
                //else
                //{
                //    MessageBox.Show(nameTextBox.Text + "Already Exists!");
                //}


                //Close
                sqlConnection.Close();


            }
            catch (Exception exeption)
            {
                //MessageBox.Show(exeption.Message);
            }

            return isAdded;
        }

        public bool IsNameExists(string name)
        {
            bool exists = false;
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-LO8RRRJ; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"SELECT * FROM Items WHERE Name='" + name + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();
                //Show
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    exists = true;
                }
                //Close
                sqlConnection.Close();

            }
            catch (Exception exception)
            {
                //MessageBox.Show(exeption.Message);
            }

            return exists;
        }


        public bool Update(string Name, double Price, int ItemId)
        {
            try
            {
                //Connection
                string connectionString = @"Server= DESKTOP-LO8RRRJ; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //UPDATE Items SET Name =  'Hot' , Price = 130 WHERE ID = 1
                string commandString = @"UPDATE Items SET Name =  '" + Name + "' , Price = " + Price + " WHERE ID = " + ItemId + "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Insert
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    return true;
                }
                //Close
                sqlConnection.Close();


            }
            catch (Exception exeption)
            {
                //MessageBox.Show(exeption.Message);
            }
            return false;
        }

        public DataTable Display()
        {

            DataTable dataTable = new DataTable();
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-LO8RRRJ; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"SELECT * FROM Items";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Show
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                sqlDataAdapter.Fill(dataTable);
                //if (dataTable.Rows.Count > 0)
                //{
                //    showDataGridView.DataSource = dataTable;
                //}
                //else
                //{
                //    MessageBox.Show("No Data Found");
                //}

                //Close
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {
                //MessageBox.Show(exeption.Message);
            }
            return dataTable;




        }

        public bool Delete(int ItemId)
        {
            try
            {
                //Connection
                string connectionString = @"Server= DESKTOP-LO8RRRJ; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //DELETE FROM Items WHERE ID = 3
                string commandString = @"DELETE FROM Items WHERE ID = " + ItemId + "";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Delete
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    return true;
                }
                //Close
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {
                //MessageBox.Show(exeption.Message);
            }

            return false;
        }




        public DataTable Search(string name)
        {
            DataTable dataTable = new DataTable();
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-LO8RRRJ; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"SELECT * FROM Items WHERE Name='" + name + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Show
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                sqlDataAdapter.Fill(dataTable);
                //if (dataTable.Rows.Count > 0)
                //{

                //    //showDataGridView.DataSource = dataTable;
                //}
                //else
                //{
                //    MessageBox.Show("No Data Found");
                //}

                //Close
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {
                //MessageBox.Show(exeption.Message);
            }
            return dataTable;
        }

        public DataTable ItemCombobox()
        {
            DataTable dataTable = new DataTable();
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-LO8RRRJ; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"SELECT ID, Name FROM Items";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Show
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                sqlDataAdapter.Fill(dataTable);


                //Close
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {
                //MessageBox.Show(exeption.Message);
            }
            return dataTable;
        }

        public DataTable CustomerComboBox()
        {
            DataTable dataTable = new DataTable();
            try
            {
                //Connection
                string connectionString = @"Server=DESKTOP-LO8RRRJ; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //Command 
                //INSERT INTO Items (Name, Price) Values ('Black', 120)
                string commandString = @"SELECT ID, Name FROM Customers";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                //Open
                sqlConnection.Open();

                //Show
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                sqlDataAdapter.Fill(dataTable);


                //Close
                sqlConnection.Close();

            }
            catch (Exception exeption)
            {
                //MessageBox.Show(exeption.Message);
            }
            return dataTable;
        }
    }

}
