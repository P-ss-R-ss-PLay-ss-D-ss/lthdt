using System;
using System.Collections.Generic;
using System.Text;

namespace QLDienThoai
{
    class ThongTinLienHe
    {
        private string email = "Unknow";
        private string sDT = "Unknow";
        private DiaChi diaChi = new DiaChi();

        public ThongTinLienHe(string email, string sDT, DiaChi diaChi)
        {
            Email = email;
            SDT = sDT;
            DiaChi = diaChi;
        }

        public ThongTinLienHe()
        {
        }

        public string Email { get => email; set { if (value != null && value != "") { email = value; } } }
        public string SDT { get => sDT; set { if (value != null && value != "") { SDT = value; } } }
        internal DiaChi DiaChi { get => diaChi; set { if (value != null ) { diaChi = value; } } }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
