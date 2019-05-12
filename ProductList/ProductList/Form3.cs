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
    public partial class Form3 : Form
    {
        Validation validation = new Validation();
        List<Product> products = new List<Product>();
        int productID = 0;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                try
                {
                    productID++;
                    products.Add(new Product(
                                     productID,
                                     textBox1.Text,
                                     Convert.ToDouble(textBox2.Text),
                                     comboBox1.Text,
                                     textBox4.Text,
                                     textBox5.Text,
                                     Convert.ToInt32(textBox3.Text),
                                     Convert.ToInt32(textBox6.Text)));
                    RefreshGrid();
                    ClearInputs();
                }
                catch (Exception exp) { MessageBox.Show(exp.Message); }
            }
        }

        // Writing List to grid
        private void RefreshGrid()
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < products.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = products[i].Name;
                row.Cells[1].Value = products[i].Price;
                row.Cells[2].Value = products[i].Category;
                row.Cells[3].Value = products[i].Brand;
                row.Cells[4].Value = products[i].Color;
                row.Cells[5].Value = products[i].Barcode;
                row.Cells[6].Value = products[i].Stock;
                dataGridView1.Rows.Add(row);

            }
        }
        // Form validation method
        public bool isValid()
        {
            int valid = 0;
            int inputCount = 0;
            foreach (Control con in this.Controls)
            {
                if (con is TextBox || con is ComboBox)
                {
                    inputCount++;
                    if (validation.CheckInput(con.AccessibleName, con.Text, con.AccessibleDescription) == "ok")
                    {
                        valid++;
                    }
                    else
                    {
                        ToolTip toolTip = new ToolTip();
                        toolTip.IsBalloon = true;
                        toolTip.Show(validation.CheckInput(con.AccessibleName, con.Text, con.AccessibleDescription), con, 90, -35, 2000);
                    }
                }
            }

            if (valid == inputCount) { return true; }
            else { return false; }
        }
        // clear inputs
        public void ClearInputs()
        {
            foreach (Control con in Controls)
            {
                if(con is TextBox)
                {
                    con.Text = string.Empty;
                }
            }
        }
        // readonly textbox takes combobox text when its changing text (for readonly)
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            textBox7.Text = comboBox1.Text;
          
        }
        // Close all hidding forms when closing
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }

}
