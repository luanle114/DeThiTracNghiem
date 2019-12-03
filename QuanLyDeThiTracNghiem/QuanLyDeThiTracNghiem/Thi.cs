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
    public partial class Thi : Form
    {
        string maso;
        string mamh;
        int lanthi;
        int socauthi;
        int thoigianthi;
        int[] cauhoi;
        char[] luachon;
        char[] dapan;
        float tongdiem;
        public Thi(String maso, int socauthi, int thoigianthi, string mamh, int lanthi)
        {
            InitializeComponent();
            this.maso = maso;
            this.socauthi = socauthi;
            this.thoigianthi = thoigianthi * 60;
            this.mamh = mamh;
            this.lanthi = lanthi;
            this.tongdiem = 0.0F;
            this.cauhoi = new int[this.socauthi];
        }
        int checkCauHoiExist(int macauhoi)
        {
            String Stringcon = @"Data Source=localhost;Initial Catalog=THI_TN;Integrated Security=True";
            SqlConnection con = new SqlConnection(Stringcon);
            con.Open();
            int ch = 0;
            String sql = "Select CAUHOI from BoDe where CAUHOI = @cauhoi";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@cauhoi", macauhoi);
            Object check = cmd.ExecuteScalar();
            if(check != null)
            {
                ch = Int32.Parse(check.ToString()); 
            }
            con.Close();
            return ch;
        }
        char getDapAn(int macauhoi)
        {
            String Stringcon = @"Data Source=localhost;Initial Catalog=THI_TN;Integrated Security=True";
            SqlConnection con = new SqlConnection(Stringcon);
            con.Open();

            char dapan = 'E';
            String sql = "Select DAPAN from BoDe where CAUHOI = @cauhoi";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@cauhoi", macauhoi);
            dapan = char.Parse(cmd.ExecuteScalar().ToString());
            con.Close();
            return dapan;
        }
        int[] getMinAndMax()
        {
            String Stringcon = @"Data Source=localhost;Initial Catalog=THI_TN;Integrated Security=True";
            SqlConnection con = new SqlConnection(Stringcon);
            con.Open();
            int[] range = { 0, 0 };
            string sql = "Select min(CAUHOI), max(CAUHOI) from BoDe where MAMH = @mamh";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@mamh", this.mamh);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                range[0] = reader.GetInt32(0);
                range[1] = reader.GetInt32(1);
            }
            con.Close();
            return range;
        }
        void loadQA(int cauhoi)
        {
            String Stringcon = @"Data Source=localhost;Initial Catalog=THI_TN;Integrated Security=True";
            SqlConnection con = new SqlConnection(Stringcon);
            con.Open();
            String sql = "Select NOIDUNG, A, B, C, D from BoDe where CAUHOI = @cauhoi";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@cauhoi", cauhoi);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read()) {
                cauhoiTxt.Text = reader.GetString(0);
                aTxt.Text = reader.GetString(1);
                bTxt.Text = reader.GetString(2);
                cTxt.Text = reader.GetString(3);
                dTxt.Text = reader.GetString(4);
            }
            cmd.Parameters.Clear();
            con.Close();
        }

        private void Thi_Load(object sender, EventArgs e)
        {
            //load number of questions
            masoLB.Text = this.maso.ToString();
            thoigianLB.Text = this.thoigianthi.ToString();
            monhocLB.Text = this.mamh.ToString();
            lanthiLB.Text = this.lanthi.ToString();
            socauLB.Text = this.socauthi.ToString();
            //load option for each question
            string[] cau = new string[this.socauthi];
            for (int i = 0; i < this.socauthi; i++)
            {
                cau[i] = (i + 1).ToString();
            }
            cbCau.Items.AddRange(cau);
            cbCau.SelectedIndex = 0;
            luachon = new char[this.socauthi];
            //load time
            timer1.Enabled = true;
            //load answer
            this.dapan = new char[this.socauthi];
            //load content of the test
            this.cauhoi = new int[this.socauthi];
            int[] range = getMinAndMax();
            int j = 0;
            while (j < this.socauthi)
            {
                Random random = new Random();
                int mch = random.Next(range[0], range[1]);
                if (!(checkCauHoiExist(mch) <= 0) & Array.IndexOf(cauhoi, mch) == -1)
                {
                    this.cauhoi[j] = mch;
                    this.dapan[j] = getDapAn(mch);
                    j++;
                }
            }
            //load question and options
            loadQA(this.cauhoi[cbCau.SelectedIndex]);
        }

        private void CbCau_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Int32.Parse(cbCau.SelectedIndex.ToString());
            if(index >= 0)
            {
                loadQA(this.cauhoi[index]);
            }
        }
        void luuBaiThi()
        {
            //Collect Q&A
            string baithi = "";
            for (int i = 0; i < this.socauthi; i++)
            {
                baithi += "Ma cau hoi: " + cauhoi[i] + " - Chon: " + luachon[i] + " - Dap An: " + dapan[i] + " |\n";
            }
            //Caculate Score
            int socaudung = 0;
            for (int i = 0; i < this.socauthi; i++)
            {
                if (luachon[i] == dapan[i])
                {
                    socaudung++;
                }
            }
            float diem = (float)socaudung / (float)this.socauthi;
            this.tongdiem = diem * 10.0F;

            //Insert into BangDiem
            String Stringcon = @"Data Source=localhost;Initial Catalog=THI_TN;Integrated Security=True";
            SqlConnection con = new SqlConnection(Stringcon);
            con.Open();

            string sql = "Insert into BangDiem(MASV,MAMH,LAN,NGAYTHI,DIEM,BAITHI) " +
                "values (@mssv,@mamh,@lan,@ngaythi,@diem,@baithi)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@mssv", this.maso);
            cmd.Parameters.AddWithValue("@mamh", this.mamh);
            cmd.Parameters.AddWithValue("@lan", this.lanthi);
            cmd.Parameters.AddWithValue("@ngaythi", DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@diem", tongdiem);
            cmd.Parameters.AddWithValue("@baithi", baithi);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        void getOpt()
        {
            if (aRdioBtn.Checked)
            {
                luachon[cbCau.SelectedIndex] = 'A';
            }
            else if (bRdioBtn.Checked)
            {
                luachon[cbCau.SelectedIndex] = 'B';
            }
            else if (cRdioBtn.Checked)
            {
                luachon[cbCau.SelectedIndex] = 'C';
            }
            else if (dRdioBtn.Checked)
            {
                luachon[cbCau.SelectedIndex] = 'D';
            }
            else
            {
                luachon[cbCau.SelectedIndex] = 'E';
            }
        }
        void refreshOpt()
        {
            aRdioBtn.Checked = false;
            bRdioBtn.Checked = false;
            cRdioBtn.Checked = false;
            dRdioBtn.Checked = false;
        }
        void loadOpt()
        {
            if (luachon[cbCau.SelectedIndex] == 'A')
            {
                aRdioBtn.Checked = true;
            }
            else if (luachon[cbCau.SelectedIndex] == 'B')
            {
                bRdioBtn.Checked = true;
            }
            else if (luachon[cbCau.SelectedIndex] == 'C')
            {
                cRdioBtn.Checked = true;
            }
            else if (luachon[cbCau.SelectedIndex] == 'D')
            {
                dRdioBtn.Checked = true;
            }
        }
        void nopBai()
        {
            timer1.Stop();
            getOpt();
            luuBaiThi();
            MessageBox.Show("Đã nộp bài!");
            Ketqua kq = new Ketqua(this.maso, this.mamh, this.lanthi, this.cauhoi, this.luachon, this.dapan, this.tongdiem.ToString());
            kq.Show();
            this.Close();
        }

        private void NopbaiBtn_Click(object sender, EventArgs e)
        {
            nopBai();
        }

        private void LuiBtn_Click(object sender, EventArgs e)
        {
            if (cbCau.SelectedIndex > 0)
            {
                getOpt();
                --cbCau.SelectedIndex;
                refreshOpt();
                loadQA(this.cauhoi[cbCau.SelectedIndex]);
                loadOpt();
            }
        }

        private void TiepBtn_Click(object sender, EventArgs e)
        {
            if (cbCau.SelectedIndex < this.socauthi - 1)
            {
                getOpt();
                ++cbCau.SelectedIndex;
                refreshOpt();
                loadQA(this.cauhoi[cbCau.SelectedIndex]);
                loadOpt();
            }
            else if (cbCau.SelectedIndex == this.socauthi - 1)
            {
                getOpt();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (thoigianthi > 0)
            {
                thoigianthi--;
                thoigianTxt.Text = (thoigianthi / 60).ToString() + ":" + ((thoigianthi % 60) >= 10 ? (thoigianthi % 60).ToString() : "0" + (thoigianthi % 60));
            }
            else
            {
                nopBai();
            }
        }
    }
}
