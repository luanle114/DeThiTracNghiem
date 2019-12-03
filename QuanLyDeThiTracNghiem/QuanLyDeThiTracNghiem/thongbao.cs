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
    public partial class Thongbao : Form
    {
        string masv;
        string hoten;
        string malop;

        public Thongbao(string masv)
        {
            InitializeComponent();
            this.masv = masv;
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //check lop, mon, lan thi, ngay thi
            String Stringcon = @"Data Source=localhost;Initial Catalog=THI_TN;Integrated Security=True";
            SqlConnection con = new SqlConnection(Stringcon);
            con.Open();
            int socauthi = 0;
            int thoigianthi = 0;
            //Lấy mã môn học từ tên môn học
            String sql = "Select MAMH from MONHOC where TENMH = @tenmh";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@tenmh", cbMon.SelectedItem);
            String mamh = cmd.ExecuteScalar().ToString();
            cmd.Parameters.Clear();
            //Kiểm tra đã làm bài thi hay chưa
            sql = "Select DIEM from BangDiem where MASV = @mssv and MAMH = @mamh and LAN = @lan";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@mssv", this.masv);
            cmd.Parameters.AddWithValue("@mamh", mamh);
            cmd.Parameters.AddWithValue("@lan", Int32.Parse(cbLanThi.SelectedItem.ToString()));
            double diem = -1;
            Object check = cmd.ExecuteScalar();
            if (check != null)
            {
                diem = Double.Parse(check.ToString());
            }
            cmd.Parameters.Clear();
            if (diem >= 0)
            {
                MessageBox.Show("Bạn đã làm bài thi!");
                return;
            }
            
            //Lấy số câu thi và thời gian
            sql = "Select SOCAUTHI, THOIGIAN from GiaoVien_DangKy where MALOP = @malop and MAMH = @mamh and LAN = @lanthi";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@malop", this.malop);
            cmd.Parameters.AddWithValue("@mamh", mamh);
            cmd.Parameters.AddWithValue("@lanthi", Int32.Parse(cbLanThi.SelectedItem.ToString()));
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            if (!reader.IsDBNull(0))
            {
                socauthi = reader.GetInt16(0);
            }
            if (!reader.IsDBNull(1))
            {
                thoigianthi = reader.GetInt16(1);
            }
            con.Close();
            //chuyển qua frmThi
            if (socauthi > 0 & thoigianthi > 0)
            {
                Thi thi = new Thi(this.masv, socauthi, thoigianthi, mamh, Int32.Parse(cbLanThi.SelectedItem.ToString()));
                thi.Show();
            }
            else
            {
                MessageBox.Show("Bài thi không tồn tại");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String Stringcon = @"Data Source=localhost;Initial Catalog=THI_TN;Integrated Security=True";
            SqlConnection con = new SqlConnection(Stringcon);
            con.Open();

            //Load dữ liệu Sinh viên
            String sql = "Select HO, TEN, MALOP from SinhVien where MASV = @mssv";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@mssv", this.masv);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                String ho = reader.GetString(0);
                String ten = reader.GetString(1);
                this.hoten = ho + " " + ten;
                this.malop = reader.GetString(2);
            }
            label2.Text = hoten;
            label4.Text = malop;
            reader.Close();

            //Load dữ liệu lần thi
            String[] lanthi = { "1", "2" };
            List<String> monhoc = new List<string>();
            cbLanThi.Items.AddRange(lanthi);
            cbLanThi.SelectedIndex = 0;
            //Load dữ liệu môn học
            sql = "Select TENMH from MonHoc";
            cmd = new SqlCommand(sql, con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                String tenmh = reader.GetString(0);
                monhoc.Add(tenmh);
            }
            cbMon.Items.AddRange(monhoc.ToArray());
            cbMon.SelectedIndex = 0;

            con.Close();
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
