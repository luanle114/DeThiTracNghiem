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

namespace QuanLyDeThiTracNghiem
{
    public partial class Quanlydiem : Form
    {
        private SqlConnection connection = new SqlConnection();
        public Quanlydiem()
        {
            InitializeComponent();
            connection.ConnectionString = @"Data Source=localhost;Initial Catalog=THI_TN;Integrated Security=True";
        }

        public void HienThi()
        {
            SqlCommand com = new SqlCommand();
            com.Connection = connection;
            string query = "SELECT *  FROM BangDiem";
            com.CommandText = query;

            SqlDataAdapter data = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            data.Fill(dt);
            bangdiemDVG.DataSource = dt;

            connection.Close();
        }
        private void Quanlydiem_Load(object sender, EventArgs e)
        {

        }

        private void FindBtn_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=localhost;Initial Catalog=THI_TN;Integrated Security=True");
            connection.Open();
            string query = String.Format("Select * from BangDiem where MASV LIKE N'%{0}%' OR MAMH LIKE N'%{0}%' OR LANTHI LIKE N'%{0}%' OR NGAYTHI LIKE N'%{0}%' OR DIEM LIKE N'%{0}%' OR BAITHI LIKE N'%{0}%' ", findTxT.Text);
            SqlDataAdapter da = new SqlDataAdapter();
            da = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);

            bangdiemDVG.DataSource = dt;
        }
    }
}
