using System;
using System.Collections.Generic;
using System.Text;

namespace QLDienThoai
{
    class ThongTinLienHe
    {
        private string email = "Unknow";
        private string SDT = "Unknow";
        private DiaChi diaChi = new DiaChi();

        public ThongTinLienHe(string email, string sDT1, DiaChi diaChi)
        {
            Email = email;
            SDT1 = sDT1;
            DiaChi = diaChi;
        }

        public ThongTinLienHe()
        {
        }

        public string Email { get => email; set => email = value; }
        public string SDT1 { get => SDT; set => SDT = value; }
        internal DiaChi DiaChi { get => diaChi; set => diaChi = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
