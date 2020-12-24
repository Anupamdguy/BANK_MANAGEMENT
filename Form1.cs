using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BANK_MANAGEMENT
{
	public partial class LOGIN : Form
	{
		public LOGIN()
		{
			InitializeComponent();
		}

		int count;
        private void button1_Click(object sender, EventArgs e)
        {
			string user, pass;
			
			user = textBox1.Text;
			pass = textBox2.Text;
			count = count + 1;
			if(count > 3)
            {
				MessageBox.Show("System has been blocked.......");
				Application.Exit();
            }
			if (user == "" && pass == "")
			{
				label3.Text = "Blank username and password not allowed";
			}
			else if (user.Length > 10 && pass.Length > 10)
			{
				label3.Text = "Only 10 chharacters allowed";
			}
			else
			{
				if (user == "Admin" && pass == "Admin")
				{
					//label3.Text = "Logged in successfully";
					Form2 pr = new Form2();
					this.Hide();
					pr.Show();
				}
				else
				{
					label3.Text = "Incorrect USERNAME or PASSWORD";
					textBox1.Clear();
					textBox2.Clear();
					textBox1.Focus();
				}
			}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
			label3.Text = "";

		}

        private void button2_Click(object sender, EventArgs e)
        {
			Application.Exit();
        }
    }
}
