using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeThiTracNghiem
{
    class KQObj
    {
        int macauhoi;
        char chon;
        char dapan;

        public KQObj(int cauhoi, char dachon, char dapan)
        {
            this.macauhoi = cauhoi;
            this.chon = dachon;
            this.dapan = dapan;
        }

        public int Macauhoi { get => macauhoi; set => macauhoi = value; }
        public char Chon { get => chon; set => chon = value; }
        public char Dapan { get => dapan; set => dapan = value; }
    }
}
