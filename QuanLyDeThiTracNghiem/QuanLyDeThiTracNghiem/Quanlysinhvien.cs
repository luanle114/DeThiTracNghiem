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
    public partial class Quanlysinhvien : Form
    {
        private SqlConnection connection = new SqlConnection();
        public Quanlysinhvien()
        {
            InitializeComponent();
            connection.ConnectionString = @"Data Source=localhost;Initial Catalog=THI_TN;Integrated Security=True";
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            //Main form1 = new Main();
            //form1.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            HienThi();
        }
        public void HienThi()
        {
            
            SqlCommand com = new SqlCommand();
            com.Connection = connection;
            string query = "select * from SinhVien ";
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
            string addSV = "insert into SinhVien (MASV, HO, TEN, NGAYSINH, DIACHI, MALOP) values(@MASV, @HO, @TEN, @NGAYSINH, @DIACHI, @MALOP)";
            SqlCommand cmd = new SqlCommand(addSV, connection);
            cmd.Parameters.AddWithValue("@MASV", textBox1.Text);
            cmd.Parameters.AddWithValue("@HO", textBox2.Text);
            cmd.Parameters.AddWithValue("@TEN", textBox3.Text);
            cmd.Parameters.AddWithValue("@NGAYSINH", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@DIACHI", textBox4.Text);
            cmd.Parameters.AddWithValue("@MALOP", textBox5.Text);
            if(textBox1.Text != null)
            {
                string check = "SELECT COUNT(*) FROM SinhVien WHERE MASV LIKE '" + textBox1.Text + "'";
                SqlCommand cmd1 = new SqlCommand(check, connection);
                int chk = Convert.ToInt32(cmd1.ExecuteScalar());
                if(chk == 0)
                {
                    cmd.ExecuteNonQuery();
                    HienThi();
                    MessageBox.Show("Thêm sinh viên thành công!!!");
                }
                else
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại!!!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập lại!!!");
            }
              
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            string fixSV = "UPDATE SinhVien SET HO = @HO, TEN = @TEN, NGAYSINH = @NGAYSINH, DIACHI = @DIACHI, MALOP = @MALOP  where MASV = @MASV ";
            SqlCommand cmd = new SqlCommand(fixSV, connection);
            cmd.Parameters.Add(new SqlParameter("@MASV", textBox1.Text));
            cmd.Parameters.Add(new SqlParameter("@HO", textBox2.Text));
            cmd.Parameters.Add(new SqlParameter("@TEN", textBox3.Text));
            cmd.Parameters.Add(new SqlParameter("@NGAYSINH", dateTimePicker1.Value.Date));
            cmd.Parameters.Add(new SqlParameter("@DIACHI", textBox4.Text));
            cmd.Parameters.Add(new SqlParameter("@MALOP", textBox5.Text));
            cmd.ExecuteNonQuery();
            HienThi();
            MessageBox.Show("Sửa thông tin thành công!!!");
        }
        
        private void Button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            string delSV = "delete from SinhVien where MASV = @MASV ";
            SqlCommand cmd = new SqlCommand(delSV, connection);
            cmd.Parameters.Add(new SqlParameter("@MASV", dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            cmd.ExecuteNonQuery();
            HienThi();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=localhost;Initial Catalog=THI_TN;Integrated Security=True");
            connection.Open();
            string query = String.Format("Select * from SinhVien where MASV LIKE N'%{0}%' OR HO LIKE N'%{0}%'OR TEN LIKE N'%{0}%' OR DIACHI LIKE N'%{0}%' OR MALOP LIKE N'%{0}%' ", FindSV.Text);
            SqlDataAdapter da = new SqlDataAdapter();
            da = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void DataGridView1_Click(object sender, EventArgs e)
        {
            
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Quanlysinhvien_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
