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
    public partial class GVDangKi : Form
    {
        private SqlConnection con = new SqlConnection();
        public GVDangKi()
        {
            InitializeComponent();
            con.ConnectionString = @"Data Source=localhost;Initial Catalog=THI_TN;Integrated Security=True";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        public void HienThi()
        {
            
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            string query = "SELECT *  FROM GiaoVien_DangKy";
            com.CommandText = query;

            SqlDataAdapter data = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dangkiDGV.DataSource = dt;

            con.Close();
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "INSERT INTO GiaoVien_DangKy (MAGV, MALOP, MAMH, TRINHDO, NGAYTHI, LAN, SOCAUTHI, THOIGIAN) values(@MAGV, @MALOP, @MAMH, @TRINHDO, @NGAYTHI, @LAN, @SOCAUTHI, @THOIGIAN)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("@MAGV", magvTxt.Text));
                cmd.Parameters.Add(new SqlParameter("@MALOP", malopTxt.Text));
                cmd.Parameters.Add(new SqlParameter("@MAMH", monhocTxt.Text));
                cmd.Parameters.Add(new SqlParameter("@TRINHDO", cbTD.Text));
                cmd.Parameters.Add(new SqlParameter("@NGAYTHI", ngaythiPick.Value.Date));
                cmd.Parameters.Add(new SqlParameter("@LAN", cbLanThi.Text));
                cmd.Parameters.Add(new SqlParameter("@SOCAUTHI", cauhoiTxt.Text));
                cmd.Parameters.Add(new SqlParameter("@THOIGIAN", timeTxt.Text));

                if (cbLanThi.Text != null)
                {
                    string check = "SELECT NGAYTHI FROM GiaoVien_DangKy WHERE MALOP LIKE '" + malopTxt.Text + "' AND MAMH LIKE '" + monhocTxt.Text + "' AND LAN LIKE '" + cbLanThi.Text + "'";
                    SqlCommand cmd1 = new SqlCommand(check, con);
                    int chk = Convert.ToInt32(cmd1.ExecuteScalar());
                    if (chk == 0)
                    {
                        cmd.ExecuteNonQuery();
                        HienThi();
                        MessageBox.Show("Đăng kí thành công");
                    }
                    else
                    {
                        MessageBox.Show("Lần thi này đã đăng kí");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập lại thông tin!!!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpBtn_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "UPDATE GiaoVien_DangKy SET TRINHDO = @TRINHDO, NGAYTHI = @NGAYTHI, THOIGIAN = @THOIGIAN, SOCAUTHI - @SOCAUTHI WHERE MAMH = @MAMH AND MALOP = @MALOP AND LAN = @LAN ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TRINHDO", cbTD.SelectedItem);
                cmd.Parameters.AddWithValue("@NGAYTHI", ngaythiPick.Value.Date);
                cmd.Parameters.AddWithValue("THOIGIAN", Int32.Parse(timeTxt.Text));
                cmd.Parameters.AddWithValue("@SOCAU", Int32.Parse(cauhoiTxt.Text));
                cmd.Parameters.AddWithValue("@MAMH", monhocTxt.Text);
                cmd.Parameters.AddWithValue("@MALOP", malopTxt.Text);
                cmd.Parameters.AddWithValue("@LAN", Int32.Parse(cbLanThi.SelectedItem.ToString()));

                cmd.ExecuteNonQuery();
                HienThi();
                con.Close();
                MessageBox.Show("Sửa dữ liệu thành công!!!");
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi sửa dữ liệu!!!");
            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "DELETE FROM GiaoVien_DangKy WHERE MAMH = @MAMH AND MALOP = @MALOP AND LAN = @LAN";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("@MAMH", dangkiDGV.CurrentRow.Cells[1].Value.ToString()));
                cmd.Parameters.Add(new SqlParameter("@MALOP", dangkiDGV.CurrentRow.Cells[2].Value.ToString()));
                cmd.Parameters.Add(new SqlParameter("@LANTHI", dangkiDGV.CurrentRow.Cells[5].Value.ToString()));

                cmd.ExecuteNonQuery();
                HienThi();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xóa dữ liệu!!!");
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }
    }
}
