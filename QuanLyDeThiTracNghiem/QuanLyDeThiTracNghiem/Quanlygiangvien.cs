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
    public partial class Quanlygiangvien : Form
    {
        private SqlConnection connection = new SqlConnection();
        public Quanlygiangvien()
        {
            InitializeComponent();
            connection.ConnectionString = @"Data Source=localhost;Initial Catalog=THI_TN;Integrated Security=True";
        }

        private void Quanlygiangvien_Load(object sender, EventArgs e)
        {
            HienThi();
        }
        public void HienThi()
        {

            SqlCommand com = new SqlCommand();
            com.Connection = connection;
            string query = "SELECT *  FROM GiaoVien";
            com.CommandText = query;

            SqlDataAdapter data = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;

            connection.Close();
        }
        String MAGV;
        private void Button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            String addMH = "INSERT INTO GiaoVien(MAGV, HO, TEN, HOCVI, MAKH) VALUES(@MAGV, @HO, @TEN, @HOCVI, @MAKH)";
            SqlCommand cmd = new SqlCommand(addMH, connection);
            cmd.Parameters.Add(new SqlParameter("@MAGV", textBox1.Text));
            cmd.Parameters.Add(new SqlParameter("@HO", textBox2.Text));
            cmd.Parameters.Add(new SqlParameter("@TEN", textBox3.Text));
            cmd.Parameters.Add(new SqlParameter("@HOCVI", textBox4.Text));
            cmd.Parameters.Add(new SqlParameter("@MAKH", textBox5.Text));
            MAGV = textBox1.Text;
            if (MAGV != null)
            {
                string check = "SELECT COUNT(*) FROM GiaoVien WHERE MAGV LIKE '" + textBox1.Text + "'";
                SqlCommand CMD = new SqlCommand(check, connection);
                int chk = Convert.ToInt32(CMD.ExecuteScalar());
                if (chk == 0)
                {
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    HienThi();
                    MessageBox.Show("Thêm giảng viên thành công");
                }
                else
                {
                    MessageBox.Show("Đã tồn tại mã giảng viên này!!!");
                }
            }
            else
            {
                MessageBox.Show("Vui long nhap thong tin");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            String upBD = "UPDATE GiaoVien SET HO = @HO, TEN = @TEN, HOCVI = @HOCVI, MAKH = @MAKH WHERE MAGV = @MAGV ";
            SqlCommand cmd2 = new SqlCommand(upBD, connection);
            cmd2.Parameters.Add(new SqlParameter("@MAGV", textBox1.Text));
            cmd2.Parameters.Add(new SqlParameter("@HO", textBox2.Text));
            cmd2.Parameters.Add(new SqlParameter("@TEN", textBox3.Text));
            cmd2.Parameters.Add(new SqlParameter("@HOCVI", textBox4.Text));
            cmd2.Parameters.Add(new SqlParameter("@MAKH", textBox5.Text));
            cmd2.ExecuteNonQuery();
            connection.Close();
            HienThi();
            MessageBox.Show("Sửa giảng viên thành công");
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            connection.Open();
            string delGV = "delete from GiaoVien where MAGV = @MAGV ";
            SqlCommand cmd = new SqlCommand(delGV, connection);
            cmd.Parameters.Add(new SqlParameter("@MAGV", dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            cmd.ExecuteNonQuery();
            HienThi();
        }
    }
}
