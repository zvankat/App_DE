using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace OOOFood
{
    public partial class Main : Form
    {
        private readonly Food_db dbContext;
        private List<Product> selectedProducts;
        private int totalQuantity = 0;
        private decimal totalPrice = 0;
        private Label totalQuantityLabel;
        private Label totalPriceLabel;
        private CartForm cartForm;
        private BuyForm buyForm;

        public Main()
        {
            InitializeComponent();
            dbContext = new Food_db();
            selectedProducts = new List<Product>();
            totalQuantityLabel = new Label();
            totalPriceLabel = new Label();
            totalQuantityLabel.Text = $"{totalQuantity} шт.";
            totalPriceLabel.Text = $"Итог: {totalPrice} ₽";
            totalQuantityLabel.Location = new Point(20, 20);
            totalPriceLabel.Location = new Point(20, 50);
            totalQuantityLabel.AutoSize = true;
            totalPriceLabel.AutoSize = true;
            Controls.Add(totalQuantityLabel);
            Controls.Add(totalPriceLabel);
            Main_Load(this, EventArgs.Empty);
            this.totalPrice = totalPrice;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            List<Category> categories = dbContext.Category.ToList();

            int panelTop = 20;

            foreach (Category category in categories)
            {
                if (tabControl1.TabPages.Cast<TabPage>().Any(tab => tab.Text == category.category_name))
                    continue;

                Panel panel = new Panel();
                panel.AutoScroll = true;
                panel.Top = panelTop;
                panel.Left = 20;
                panel.Width = tabControl1.Width - 40;
                panel.Height = tabControl1.Height - panelTop - 40;
                tabControl1.TabPages.Add(category.category_name, category.category_name);
                tabControl1.TabPages[category.category_name].Controls.Add(panel);

                List<Product> products = dbContext.Product.Where(p => p.category == category.category_id).ToList();

                int labelTop = 20;

                foreach (Product product in products)
                {
                    Control imageControl;

                    string customImagePath = "C:\\Users\\vankatov\\source\\repos\\OOOFood\\OOOFood\\Images\\w.png";

                    PictureBox imageBox = new PictureBox();
                    imageBox.Image = Image.FromFile(customImagePath);
                    imageBox.SizeMode = PictureBoxSizeMode.Zoom;
                    imageBox.Location = new Point(20, labelTop);
                    imageBox.Width = 100;
                    imageBox.Height = 100;
                    imageControl = imageBox;
                    panel.Controls.Add(imageControl);

                    Label nameLabel = new Label();
                    nameLabel.Text = product.name;
                    nameLabel.Location = new Point(140, labelTop);
                    nameLabel.AutoSize = true;
                    nameLabel.Font = new Font(nameLabel.Font.FontFamily, 14, FontStyle.Bold);
                    panel.Controls.Add(nameLabel);

                    Label descriptionLabel = new Label();
                    descriptionLabel.Text = product.description.Length > 20 ? product.description.Substring(0, 20) + "\n" + product.description.Substring(20) : product.description;
                    descriptionLabel.Location = new Point(140, labelTop + 20);
                    descriptionLabel.AutoSize = true;
                    descriptionLabel.Font = new Font(descriptionLabel.Font.FontFamily, 10);
                    panel.Controls.Add(descriptionLabel);

                    Button priceButton = new Button();
                    if (product.discount > 0)
                    {
                        decimal discountedPrice = product.price - (product.price * product.discount / 100);
                        priceButton.Text = $"{discountedPrice} ₽ ({product.discount}%) | {product.price} ₽";
                        priceButton.Font = new Font(nameLabel.Font.FontFamily, 12, FontStyle.Bold);
                    }
                    else
                    {
                        priceButton.Text = $"{product.price} ₽";
                        priceButton.Font = new Font(nameLabel.Font.FontFamily, 12, FontStyle.Bold);
                    }
                    priceButton.Location = new Point(140, labelTop + 70);
                    priceButton.AutoSize = true;
                    panel.Controls.Add(priceButton);

                    labelTop += 130;

                    priceButton.Click += (s, args) =>
                    {
                        totalQuantity++;
                        mainQuantityLabel.Text = $"{totalQuantity} шт.";

                        if (product.discount > 0)
                        {
                            decimal discountedPrice = product.price - (product.price * product.discount / 100);
                            totalPrice += discountedPrice;
                        }
                        else
                        {
                            totalPrice += product.price;
                        }
                        mainTotalLabel.Text = $"Итог: {totalPrice} ₽";

                        selectedProducts.Add(new Product { name = product.name, price = product.price, description = product.description });
                    };
                }

                panelTop += 100;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cartForm == null || cartForm.IsDisposed)
            {
                cartForm = new CartForm(selectedProducts, totalPriceLabel, totalQuantityLabel);
                cartForm.FormClosed += (s, args) =>
                {
                    totalQuantity = selectedProducts.Count;
                    totalQuantityLabel.Text = $"{totalQuantity} шт.";

                    totalPrice = selectedProducts.Sum(p => p.price);
                    totalPriceLabel.Text = $"Итог: {totalPrice} ₽";

                    selectedProducts = cartForm.GetSelectedProducts();
                };
                cartForm.Show();
            }
            else
            {
                cartForm.BringToFront();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (buyForm == null || buyForm.IsDisposed)
            {
                buyForm = new BuyForm(totalPrice, totalQuantity);
                buyForm.Show();
            }
            else
            {
                buyForm.BringToFront();
            }
        }
    }
}