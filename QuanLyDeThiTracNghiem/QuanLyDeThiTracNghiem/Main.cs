using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDeThiTracNghiem
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DangNhap dangnhap = new DangNhap();
            dangnhap.Show();
            this.Hide();
        }

        private void QzBtn_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
            this.Hide();
        }

        private void SvBtn_Click(object sender, EventArgs e)
        {
            Quanlysinhvien qlsv = new Quanlysinhvien();
            qlsv.ShowDialog();
            this.Hide();
        }

        private void GvBtn_Click(object sender, EventArgs e)
        {
            Quanlygiangvien GV = new Quanlygiangvien();
            GV.Show();
            this.Hide();
        }

        private void DBtn_Click(object sender, EventArgs e)
        {

        }

        private void TestBtn_Click(object sender, EventArgs e)
        {
            Quanlymonhoc monhoc = new Quanlymonhoc();
            monhoc.Show();
            this.Hide();
        }

        private void SignBtn_Click(object sender, EventArgs e)
        {
            GVDangKi dangki = new GVDangKi();
            dangki.Show();
            this.Hide();
        }
    }
}
