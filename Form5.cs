using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace BANK_MANAGEMENT
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        SqliteConnection con = new SqliteConnection("Data Source = C:\\Users\\Anupam Chetia\\source\\repos\\BANK_MANAGEMENT\\CSB_BANK.db");

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string str = "select * from account where account_id = '" + textBox3.Text + "'";
                SqliteCommand cmd = new SqliteCommand(str, con);
                SqliteDataReader rd = cmd.ExecuteReader();
                while(rd.Read())
                {
                    textBox2.Text = rd[4].ToString();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string acno, date;
            double bal, deposit;
            acno = textBox3.Text;
            date = dateTimePicker1.Text;
            bal = double.Parse(textBox2.Text);
            deposit = double.Parse(textBox1.Text);

            con.Open();
            SqliteCommand cmd = new SqliteCommand();
            SqliteTransaction trans;
            trans = con.BeginTransaction();
            cmd.Connection = con;
            cmd.Transaction = trans;

            try
            {
                cmd.CommandText = "update account set balance = balance + '" + deposit + "' where account_id = '" + acno + "'";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "insert into transaction (account_id,date,bal,deposit) values('" + acno + "','" + date + "','" + bal + "','" + deposit + "')";
                cmd.ExecuteNonQuery();
                trans.Commit();
                MessageBox.Show("Transaction successful");
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }
    }
}
