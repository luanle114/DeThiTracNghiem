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
    public partial class Quanlymonhoc : Form
    {
        private SqlConnection connection = new SqlConnection();
        public Quanlymonhoc()
        {
            InitializeComponent();
            connection.ConnectionString = @"Data Source=localhost;Initial Catalog=THI_TN;Integrated Security=True";
        }

        private void Quanlymonhoc_Load(object sender, EventArgs e)
        {
            HienThi();
        }
        public void HienThi()
        {
            SqlCommand com = new SqlCommand();
            com.Connection = connection;
            string query = "SELECT *  FROM MonHoc";
            com.CommandText = query;

            SqlDataAdapter data = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;

            connection.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            String addMH = "INSERT INTO MonHoc(MAMH, TENMH) VALUES(@MAMH, @TENMH)";
            SqlCommand cmd = new SqlCommand(addMH, connection);
            cmd.Parameters.Add(new SqlParameter("MAMH", textBox1.Text));
            cmd.Parameters.Add(new SqlParameter("TENMH", textBox2.Text));
            if(textBox1.Text != null)
            {
                string check = "SELECT COUNT(*) FROM MonHoc WHERE MAMH LIKE '" + textBox1.Text + "'";
                SqlCommand cmd1 = new SqlCommand(check, connection);
                int chk = Convert.ToInt32(cmd1.ExecuteScalar());
                if(chk == 0)
                {
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    HienThi();
                    MessageBox.Show("Thêm môn học thành công");
                }
                else
                {
                    MessageBox.Show("Mã môn học này đã tồn tại!!!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập lại");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            String addMH = "UPDATE MonHoc SET TENMH = @TENMH WHERE MAMH = @MAMH ";
            SqlCommand cmd = new SqlCommand(addMH, connection);
            cmd.Parameters.Add(new SqlParameter("@MAMH", textBox1.Text));
            cmd.Parameters.Add(new SqlParameter("@TENMH", textBox2.Text));
            cmd.ExecuteNonQuery();
            connection.Close();
            HienThi();
            MessageBox.Show("Sửa môn học thành công");
        }
    }
}
