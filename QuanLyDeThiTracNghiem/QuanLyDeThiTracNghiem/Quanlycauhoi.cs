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
    public partial class Form4 : Form
    {
        private SqlConnection connection = new SqlConnection();
        public Form4()
        {
            InitializeComponent();
            connection.ConnectionString = @"Data Source=localhost;Initial Catalog=THI_TN;Integrated Security=True";
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Main form1 = new Main();
            form1.Show();
            this.Hide();
        }

        public void HienThi()
        {
            SqlCommand com = new SqlCommand();
            com.Connection = connection;
            string query = "SELECT *  FROM BoDe";
            com.CommandText = query;

            SqlDataAdapter data = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;

            connection.Close();
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        //Cập nhật dữ liệu
        private void Button4_Click(object sender, EventArgs e)
        {
            
        }
        
        //Thêm dữ liệu
        private void Button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            string addCH = "insert into BoDe (MAMH, CAUHOI, TRINHDO, NOIDUNG, A, B, C, D, DAPAN, MAGV) values(@MAMH, @CAUHOI, @TRINHDO, @NOIDUNG, @A, @B, @C, @D, @DAPAN, @MAGV)";
            SqlCommand cmd2 = new SqlCommand(addCH, connection);
            cmd2.Parameters.Add(new SqlParameter("@MAMH", textBox1.Text));
            cmd2.Parameters.Add(new SqlParameter("@CAUHOI", textBox2.Text));
            cmd2.Parameters.Add(new SqlParameter("@TRINHDO", comboBox2.Text));
            cmd2.Parameters.Add(new SqlParameter("@NOIDUNG", textBox3.Text));
            cmd2.Parameters.Add(new SqlParameter("@MAGV", textBox4.Text));
            cmd2.Parameters.Add(new SqlParameter("@A", textBox5.Text));
            cmd2.Parameters.Add(new SqlParameter("@B", textBox6.Text));
            cmd2.Parameters.Add(new SqlParameter("@C", textBox7.Text));
            cmd2.Parameters.Add(new SqlParameter("@D", textBox8.Text));
            cmd2.Parameters.Add(new SqlParameter("@DAPAN", comboBox1.Text));
            if(textBox2.Text != null)
            {
                string check = "SELECT COUNT(*) FROM BoDe WHERE CAUHOI LIKE '" +textBox2.Text+ "'";
                SqlCommand cmd = new SqlCommand(check, connection);
                int chk = Convert.ToInt32(cmd.ExecuteScalar());
                if(chk == 0)
                {
                    cmd2.ExecuteNonQuery();
                    HienThi();
                    MessageBox.Show("Thêm câu hỏi thành công");
                }
                else
                {
                    MessageBox.Show("Mã câu hỏi này đã tồn tại");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập lại!!!");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            string delDA = "DELETE FROM BoDe WHERE CAUHOI = @CAUHOI";
            SqlCommand cmd2 = new SqlCommand(delDA, connection);
            cmd2.Parameters.Add(new SqlParameter("@CAUHOI", dataGridView1.CurrentRow.Cells[1].Value.ToString()));
            cmd2.ExecuteNonQuery();
            HienThi();
            MessageBox.Show("Xóa câu hỏi thành công");
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            String upBD = "UPDATE BoDe SET MAMH = @MAMH, TRINHDO = @TRINHDO, NOIDUNG = @NOIDUNG, A = @A, B = @B, C = @C, D = @D, DAPAN = @DAPAN, MAGV = @MAGV  WHERE CAUHOI = @CAUHOI ";
            SqlCommand cmd2 = new SqlCommand(upBD, connection);
            cmd2.Parameters.Add(new SqlParameter("@MAMH", textBox1.Text));
            cmd2.Parameters.Add(new SqlParameter("@CAUHOI", textBox2.Text));
            cmd2.Parameters.Add(new SqlParameter("@TRINHDO", comboBox2.Text));
            cmd2.Parameters.Add(new SqlParameter("@NOIDUNG", textBox3.Text));
            cmd2.Parameters.Add(new SqlParameter("@MAGV", textBox4.Text));
            cmd2.Parameters.Add(new SqlParameter("@A", textBox5.Text));
            cmd2.Parameters.Add(new SqlParameter("@B", textBox6.Text));
            cmd2.Parameters.Add(new SqlParameter("@C", textBox7.Text));
            cmd2.Parameters.Add(new SqlParameter("@D", textBox8.Text));
            cmd2.Parameters.Add(new SqlParameter("@DAPAN", comboBox1.Text));
            cmd2.ExecuteNonQuery();
            HienThi();
            MessageBox.Show("Sửa câu hỏi thành công");
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void findQZ_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=localhost;Initial Catalog=THI_TN;Integrated Security=True");
            connection.Open();
            string query = String.Format("Select * from BoDe where MAMH LIKE N'%{0}%' OR CAUHOI LIKE N'%{0}%' OR TRINHDO LIKE N'%{0}%' OR NOIDUNG LIKE N'%{0}%' OR A LIKE N'%{0}%' OR B LIKE N'%{0}%' OR C LIKE N'%{0}%' OR D LIKE N'%{0}%' OR DAPAN LIKE N'%{0}%' OR MAGV LIKE N'%{0}%' ", TimKiem.Text);
            SqlDataAdapter da = new SqlDataAdapter();
            da = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void Find_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
