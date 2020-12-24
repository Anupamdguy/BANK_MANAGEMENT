using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Data.Sqlite;

namespace BANK_MANAGEMENT
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        SqliteConnection con = new SqliteConnection("Data Source = C:\\Users\\Anupam Chetia\\source\\repos\\BANK_MANAGEMENT\\CSB_BANK.db");


        public void custid()
        {
            con.Open();
            string query = "select max(cust_id) from customer ";
            SqliteCommand cmd = new SqliteCommand(query, con);
            SqliteDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string val = dr[0].ToString();
                if (val == "")
                {
                    label15.Text = "10000";
                }
                else
                {
                    int a;
                    a = int.Parse(dr[0].ToString());
                    a = a + 1;
                    label15.Text = a.ToString();
                }
                con.Close();
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
                custid();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cid, fname, lname, street, city, state, phone, date, email, acno, acctype, des, bal;
            cid = label15.Text;
            fname = textBox1.Text;
            lname = textBox2.Text;
            street = textBox3.Text;
            city = textBox4.Text;
            state = textBox5.Text;
            phone = textBox6.Text;
            date = dateTimePicker1.Text;
            email= textBox7.Text;
            acno = textBox10.Text;
            acctype = comboBox1.Text;
            des = textBox9.Text;
            bal = textBox8.Text;

            con.Open();
            SqliteCommand cmd = new SqliteCommand();
            SqliteTransaction trans;
            trans = con.BeginTransaction();
            cmd.Connection = con;
            cmd.Transaction = trans;

            try
            {
                cmd.CommandText = "insert into customer (cust_id,fname,lname,street,city,st,phone,dob,email) values('" + cid + "','" + fname + "','" + lname + "','" + street + "','" + city + "','" + state + "','" + phone + "','" + date + "','" + email + "')";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "insert into account (account_id,cust_id,acctype,descp,balance) values('" + acno + "','" + cid + "','" + acctype + "','" + des + "','" + bal + "')";
                cmd.ExecuteNonQuery();
                trans.Commit();
                MessageBox.Show("Record added......");
            }
            catch(Exception ex)
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
