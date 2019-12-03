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
    public partial class DangNhap : Form
    {
        public static bool KetQuaOk = false;
        public DangNhap()
        {
            InitializeComponent();
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Login();
        }
        
        public void Login()
        {
                try
            {  
                        String Stringcon = @"Data Source=localhost;Initial Catalog=THI_TN;Integrated Security=True";
                // Chuỗi kết Nối Tới Databse THITRACNGHIEM  CREATE 24/3/2018 (TOOLS => Connect To databse => Chọn NameSever =>> Test ok )

                         SqlConnection con = new SqlConnection(Stringcon);
                         con.Open();
                if(radioGV.Checked == true) {
                    SqlCommand comand = new SqlCommand("Select MATKHAU From GiaoVien WHERE MAGV ='" + textBox1.Text.Trim() + "' ", con);

                    SqlDataReader r = comand.ExecuteReader();
                    r.Read();

                    if (textBox1.Text == "" || textBox2.Text == "")
                    {
                        MessageBox.Show("Vui Lòng Xem lại Tài Khoản Mật Khẩu !");

                    }
                    else if (textBox2.Text.Trim() == r.GetString(0).Trim())
                    {
                            this.Hide();
                            r.Close();
                            con.Close();
                            KetQuaOk = true;
                            Main m = new Main();
                            m.Show();
                    }
                    else
                    {
                        MessageBox.Show("Sai Mật Khẩu Hoặc Tài Khoản!");
                    }
                    r.Close();
                    con.Close();
                }
                else if(radioSV.Checked == true)
                {
                    SqlCommand comand = new SqlCommand("Select MATKHAU From SinhVien WHERE MASV ='" + textBox1.Text.Trim() + "' ", con);

                    SqlDataReader r = comand.ExecuteReader();
                    r.Read();

                    if (textBox1.Text == "" || textBox2.Text == "")
                    {
                        MessageBox.Show("Vui Lòng Xem lại Tài Khoản Mật Khẩu !");

                    }
                    else if (textBox2.Text.Trim() == r.GetString(0).Trim())
                    {

                        this.Hide();
                        r.Close();
                        con.Close();
                        KetQuaOk = true;
                        Thongbao m = new Thongbao(textBox1.Text);
                        m.Show();
                    }
                    else
                    {
                        MessageBox.Show("Sai Mật Khẩu Hoặc Tài Khoản!");
                    }
                    r.Close();
                    con.Close();
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Tài khoản này không tồn tại!");

            }
        }


        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
