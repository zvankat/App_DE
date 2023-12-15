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
    public partial class Login : Form
    {
        private readonly Food_db dbContext;
        public Login()
        {
            InitializeComponent();
            dbContext = new Food_db();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;

            User user = dbContext.Users.FirstOrDefault(u => u.login == login && u.password == password);

            if (user != null)
            {
                MainA mainA = new MainA();
                mainA.Show();
                this.Close();

            } else
            {
                MessageBox.Show("Неверный логин или пароль!");
                this.Close();
            }
        }
    }
}
