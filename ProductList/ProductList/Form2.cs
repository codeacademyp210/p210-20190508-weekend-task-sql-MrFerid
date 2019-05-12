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
    public partial class Form2 : Form
    {
        List<User> users = new List<User>();
        Validation validation = new Validation();
        int personID;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                personID++;
                try
                {
                    users.Add(new User(personID, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text));
                    Form3 form3 = new Form3();
                    this.Hide();
                    form3.Show();
                }
                catch (Exception exp) { MessageBox.Show(exp.Message); }
            }            
        }

        // Form validation method
        public bool isValid()
        {
            int valid = 0;
            int inputCount = 0;
            errorTXT.Text = "";
            foreach(Control con in panel2.Controls)
            {
                if(con is TextBox)
                {
                   inputCount++;
                   if(validation.CheckInput(con.AccessibleName,con.Text,con.AccessibleDescription) == "ok")
                    {
                        valid++;
                    }
                    else
                    {
                        ToolTip toolTip = new ToolTip();
                        toolTip.IsBalloon = true;
                        toolTip.Show(validation.CheckInput(con.AccessibleName, con.Text, con.AccessibleDescription), con, 120, -40, 2000);
                    }
                }
            }
            if(valid == inputCount) { return true; }
            else { return false; }
        }


        // Form settings (Moving)
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
    }
}
