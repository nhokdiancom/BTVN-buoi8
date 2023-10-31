using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        string str = @"Data Source=LAPTOP-43GIIM0U ; Initial Catalog=HUHU; Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        KetNoi kn = new KetNoi();
        SqlCommand command;
        SqlConnection connsql;
        DataTable table = new DataTable();
        void loaddate() {
            command = connsql.CreateCommand();
            command.CommandText = "select * from THONGTIN";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        public class KetNoi {
            public SqlConnection connect;
            public KetNoi() {
                connect = new SqlConnection("Data Source=LAPTOP-43GIIM0U ; Initial Catalog=HUHU; Integrated Security=True");
            }
            public KetNoi(String strcn) {
                connect = new SqlConnection(strcn);
            }
        }
        public Form1()
        {
            InitializeComponent();
            connsql = kn.connect;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Ban co muon thoat ?", "Thoat", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
        public Boolean exedata(string cmd) {
            connsql.Open();
            Boolean check = false;
            try
            {
                SqlCommand sc = new SqlCommand(cmd, connsql);
                sc.ExecuteNonQuery();
                check = true;
            }
            catch (Exception)
            {
                check = false;
            }
            connsql.Close();
            return check;
        }
        public DataTable readdata(string cmd) {
            connsql.Open();
            DataTable da = new DataTable();
            try
            {
                SqlCommand sc = new SqlCommand(cmd, connsql);
                SqlDataAdapter sda = new SqlDataAdapter(sc);
                sda.Fill(da);
            }
            catch (Exception)
            {
                da = null;
            }
            connsql.Close();
            return da;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (connsql.State == ConnectionState.Closed)
                {
                    connsql.Open();
                }
                if (connsql.State == ConnectionState.Open)
                {
                    connsql.Close();
                }
                MessageBox.Show("Thanh Cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show("That bai");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (connsql.State == ConnectionState.Closed) {
                connsql.Open();
            }
            MessageBox.Show("Da ket Noi");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (connsql.State == ConnectionState.Open)
            {
                connsql.Close();
            }
            MessageBox.Show("Da ngat ket Noi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connsql.Open();
            string strsql = "select * from THONGTIN";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connsql = new SqlConnection(str);
            connsql.Open();
            loaddate();
        }
    }
}
