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
using System.Reflection;

namespace QuanLyDeThiTracNghiem
{
    public partial class Ketqua : Form
    {
        string maso;
        string mamh;
        int lanthi;
        int[] macauhoi;
        char[] luachon;
        char[] dapan;
        string diem;
        public Ketqua(string maso, string mamh, int lanthi, int[] macauhoi, char[] luachon, char[]dapan, string diem)
        {
            InitializeComponent();
            this.maso = maso;
            this.mamh = mamh;
            this.lanthi = lanthi;
            this.macauhoi = macauhoi;
            this.luachon = luachon;
            this.dapan = dapan;
            this.diem = diem;
        }
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ketqua_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=localhost;Initial Catalog=THI_TN;Integrated Security=True";
            con.Open();
            String query = "SELECT HO, TEN, MALOP FROM SinhVien where MASV = @MASV";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@MASV", this.maso);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string ho = reader.GetString(0);
            string ten = reader.GetString(1);
            string malop = reader.GetString(2);
            con.Close();
            hotenLB.Text += ho + " " + ten;
            lopLB.Text += malop;
            monhocLB.Text += this.mamh;
            ngaythiLB.Text += DateTime.Now.ToString();
            lanthiLB.Text += this.lanthi;
            diemLB.Text += this.diem;
            loadDataGridView();
        }
        public void loadDataGridView()
        {
            List<KQObj> listkq = new List<KQObj>();
            for (int i = 0; i < this.macauhoi.Length; i++)
            {
                KQObj kq = new KQObj(this.macauhoi[i], this.luachon[i], this.dapan[i]);
                listkq.Add(kq);
            }
            DataTable dt = new DataTable();
            dt = ToDataTable(listkq);
            dataGridView1.DataSource = dt;
        }
        
    }
}
