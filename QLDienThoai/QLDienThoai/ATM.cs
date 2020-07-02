using System;
using System.Collections.Generic;
using System.Text;

namespace QLDienThoai
{
    class ATM
    {
        private string soTaiKhoan = "Unknow";
        private string nganHang = "Unknow";

        public ATM(string soTaiKhoan, string nganHang)
        {
            SoTaiKhoan = soTaiKhoan;
            NganHang = nganHang;
        }

        public ATM()
        {
        }

        public string SoTaiKhoan { get => soTaiKhoan; set { if (value != null && value != "") { soTaiKhoan = value; } } }
        public string NganHang { get => nganHang; set { if (value != null && value != "") { nganHang = value; } } }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
