using System;
using System.Collections.Generic;
using System.Text;

namespace QLDienThoai
{
    class ThongTinChung
    {
        private string hoTen = "Unknow";
        private DateTime ngaySinh = new DateTime(1900,1,1);
        private DiaChi diaChi = new DiaChi();
        private string soCMND = "Unknow";

        public ThongTinChung(string hoTen, DateTime ngaySinh, string soCMND, DiaChi diaChi)
        {
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            SoCMND = soCMND;
            DiaChi = diaChi;
        }

        public ThongTinChung()
        {
        }

        public string HoTen { get => hoTen; set { if (value != null && value != "") { hoTen = value; } } }
        public DateTime NgaySinh { get => ngaySinh; set { if (value != null && value != new DateTime()) { ngaySinh = value; } } }
        public string SoCMND { get => soCMND; set => soCMND = value; }
        internal DiaChi DiaChi { get => diaChi; set => diaChi = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
