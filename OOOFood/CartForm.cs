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
    public partial class CartForm : Form
    {
        private List<Product> selectedProducts;
        private decimal totalPrice;
        private Label totalLabel;
        private Panel productListPanel;
        private int labelTop;

        public List<Product> GetSelectedProducts()
        {
            return selectedProducts;
        }

        public CartForm(List<Product> products, Label mainTotalLabel, Label mainQuantityLabel)
        {
            InitializeComponent();
            selectedProducts = products;
            totalPrice = selectedProducts.Sum(p => p.price);
            totalLabel = new Label();
            totalLabel.Text = $"Итог: {totalPrice} ₽";
            totalLabel.Location = new Point(20, 20);
            totalLabel.AutoSize = true;
            Controls.Add(totalLabel);

            productListPanel = new Panel();
            productListPanel.AutoScroll = true;
            productListPanel.Location = new Point(20, 50);
            productListPanel.Size = new Size(460, 300);
            Controls.Add(productListPanel);

            labelTop = 0;
            DisplaySelectedProducts();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void CartForm_Load(object sender, EventArgs e)
        {
        }

        private void DisplaySelectedProducts()
        {
            foreach (Product product in selectedProducts)
            {
                Label nameLabel = new Label();
                nameLabel.Text = product.name;
                nameLabel.Location = new Point(0, labelTop);
                nameLabel.AutoSize = true;
                productListPanel.Controls.Add(nameLabel);

                Label descriptionLabel = new Label();
                descriptionLabel.Text = product.description;
                descriptionLabel.Location = new Point(120, labelTop);
                descriptionLabel.AutoSize = true;
                productListPanel.Controls.Add(descriptionLabel);

                Button removeButton = new Button();
                removeButton.Text = "Удалить";
                removeButton.Location = new Point(340, labelTop);
                removeButton.AutoSize = true;
                productListPanel.Controls.Add(removeButton);

                removeButton.Click += (s, args) =>
                {
                    selectedProducts.Remove(product);
                    productListPanel.Controls.Remove(nameLabel);
                    productListPanel.Controls.Remove(descriptionLabel);
                    productListPanel.Controls.Remove(removeButton);
                    totalPrice -= product.price;
                    totalLabel.Text = $"Итог: {totalPrice} ₽";
                };

                labelTop += 30;
            }
        }
    }
}