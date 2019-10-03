using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CoffeeShopDatabase.BLL;
using CoffeeShopDatabase.Model;

namespace CoffeeShopDatabase
{
    public partial class CoffeeShopDatabase : Form
    {
        ItemManager _itemManager = new ItemManager();
        Item _item = new Item();

        public CoffeeShopDatabase()
        {
            InitializeComponent();
        }


        private void addButton_Click(object sender, EventArgs e)
        {
            _item.Name = itemNameTextBox.Text;
            //Check UNIQUE
            if (_itemManager.IsNameExists(_item.Name))
            {
                MessageBox.Show(itemNameTextBox.Text + "Already Exists!");
                return;
            }

            //Set Price as Mandatory
            if (String.IsNullOrEmpty(priceTextBox.Text))
            {
                MessageBox.Show("Price Can not be Empty!!!");
                return;
            }

            _item.Price = Convert.ToDouble(priceTextBox.Text);

            //Add/Insert Item
            bool isAdded = _itemManager.Add(_item);

            if (isAdded)
            {
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Not Saved");
            }

            //showDataGridView.DataSource = dataTable;

            showDataGridView.DataSource = _itemManager.Display();
            itemNameTextBox.Clear();
            priceTextBox.Clear();
            itemIdTextBox.Clear();
            

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //Set Id as Mandatory
            if (String.IsNullOrEmpty(itemIdTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }

            //Delete
            if (_itemManager.Delete(Convert.ToInt32(itemIdTextBox.Text)))
            {
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }

            showDataGridView.DataSource = _itemManager.Display();
            itemNameTextBox.Clear();
            priceTextBox.Clear();
            itemIdTextBox.Clear();
        }

        private void updatButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(itemIdTextBox.Text))
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
            _item.Name = itemNameTextBox.Text;
            _item.Price = Convert.ToDouble(priceTextBox.Text);
            _item.ID = Convert.ToInt32(itemIdTextBox.Text);
            if (_itemManager.Update(_item.Name, _item.Price, _item.ID))
            {
                MessageBox.Show("Updated");
                showDataGridView.DataSource = _itemManager.Display();
            }
            else
            {
                MessageBox.Show("Not Updated");
            }

        }

        private void showButton_Click(object sender, EventArgs e)
        {

            showDataGridView.DataSource = _itemManager.Display();
            itemNameTextBox.Clear();
            priceTextBox.Clear();
            itemIdTextBox.Clear();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(itemNameTextBox.Text))
            {
                MessageBox.Show("Field is Empty!");
                return;
            }

            showDataGridView.DataSource =_itemManager.Search(itemNameTextBox.Text);
            itemNameTextBox.Clear();
            priceTextBox.Clear();
            itemIdTextBox.Clear();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }


        private void CoffeeShopDatabase_Load(object sender, EventArgs e)
        {
            orderComboBox.DataSource = _itemManager.ItemCombobox();
            customerNameComboBox.DataSource = _itemManager.CustomerComboBox();
        }



        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void quantityTextBox_Leave(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(quantityTextBox.Text))
            //{
            //    Item _item = new Item();
            //    _item.ID = Convert.ToInt32(orderComboBox.SelectedValue);
            //    DataTable item= 
            //}
        }
    }
}
