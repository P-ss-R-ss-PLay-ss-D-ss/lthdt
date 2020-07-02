using System;
using System.Collections.Generic;
using System.Text;

namespace QLDienThoai
{
    class ThongTinChung
    {
        private string hoTen = "Unknow";
        private string ngaySinh = "Unknow";
        private DiaChi diaChi = new DiaChi();
        private string soCMND = "Unknow";

        public ThongTinChung(string hoTen, string ngaySinh, string soCMND, DiaChi diaChi)
        {
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            SoCMND = soCMND;
            DiaChi = diaChi;
        }

        public ThongTinChung()
        {
        }

        public string HoTen { get => hoTen; set => hoTen = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string SoCMND { get => soCMND; set => soCMND = value; }
        internal DiaChi DiaChi { get => diaChi; set => diaChi = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
