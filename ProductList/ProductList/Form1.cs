using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductList
{
    public partial class Form1 : Form
    {
      
        List<User> Users = new List<User>();
        public Form1()
        {
            InitializeComponent();
            Users.Add(new User(1, "Ferid", "Memmedov","1","farid.me93@gmail.com","1"));
        }

        // Click login button
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            foreach(User user in Users)
            {
                if(user.Username == username && user.password == password)
                {
                    Form3 frm3 = new Form3();
                    this.Hide();
                    frm3.Show();
                }
                else
                {
                    errorTxT.Text = "Username or Password is incorrect \nif you are new pleace register";
                }
            }
        }

        // Open next form
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form2 = new Form2();
            Hide();
            form2.Show();
        }


        // Form settings (Move,Close, Minimize)
        bool TogMove;
        int MValX;
        int MValY;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = true;
            MValX = e.X;
            MValY = e.Y;
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
