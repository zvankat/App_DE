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
    public partial class BuyForm : Form
    {
        private decimal totalPrice;

        private int totalQuantity;

        public BuyForm(decimal totalPrice, int totalQuantity)
        {
            InitializeComponent();
            button1.Text = $"Оплатить {totalPrice} рублей";
            this.totalPrice = totalPrice;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Оплата в размере {totalPrice} рублей прошла успешно!");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            totalQuantity = 0;
            totalPrice = 0;
        }
    }
}
