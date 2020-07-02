using System;
using System.Collections.Generic;
using System.Text;

namespace QLDienThoai
{
    public class ATM
    {
        private string soTaiKhoan = "Unknow";
        private string nganHang = "Unknow";

        public ATM(string soTaiKhoan, string nganHang)
        {
            SoTaiKhoan = soTaiKhoan;
            NganHang = nganHang;
        }

        public string SoTaiKhoan { get => soTaiKhoan; set { if (value != null && value != "") { soTaiKhoan = value; } } }
        public string NganHang { get => nganHang; set { if (value != null && value != "") { nganHang = value; } } }

        public override string ToString()
        {
            return $"-  Ngan hang: {NganHang}\n-  So tai khoan: {SoTaiKhoan}";
        }
    }
}
