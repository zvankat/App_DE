using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOOFood
{
    public partial class MainA : Form
    {
        private readonly Food_db dbContext;
        public MainA()
        {
            InitializeComponent();
            dbContext = new Food_db();
            LoadProducts();
        }

        private void MainA_Load(object sender, EventArgs e)
        {

        }

        private void LoadProducts()
        {
            var products = dbContext.Product.ToList();

            dataGridView1.DataSource = products;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Product newProduct = new Product();
            newProduct.name = name.Text;
            newProduct.price = Convert.ToDecimal(price.Text);
            newProduct.discount = Convert.ToInt32(discount.Text);
            newProduct.description = description.Text;
            newProduct.category = Convert.ToInt32(category.Text);

            dbContext.Product.Add(newProduct);
            dbContext.SaveChanges();

            LoadProducts();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int productId = (int)dataGridView1.Rows[selectedRowIndex].Cells["product_id"].Value;

                var product = dbContext.Product.Find(productId);
                if (product != null)
                {
                    dbContext.Product.Remove(product);
                    dbContext.SaveChanges();
                    LoadProducts();
                }
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Selected = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Main main = new Main();
            main.Show();
        }
    }
}