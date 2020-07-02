using System;
using System.Collections.Generic;
using System.Text;

namespace QLDienThoai
{
    class DiaChi
    {
        private string soNha = "Unknow";
        private string duong = "Unknow";
        private string quan = "Unknow";
        private string thanhPho = "Unknow";

        public DiaChi(string soNha, string duong, string quan, string thanhPho)
        {
            SoNha = soNha;
            Duong = duong;
            Quan = quan;
            ThanhPho = thanhPho;
        }

        public DiaChi()
        {
        }

        public string SoNha { get => soNha; set { if (value != null && value != "") { soNha = value; } } }
        public string Duong { get => duong; set { if (value != null && value != "") { duong = value; } } }
        public string Quan { get => quan; set { if (value != null && value != "") { quan = value; } } }
        public string ThanhPho { get => thanhPho; set { if (value != null && value != "") { thanhPho = value; } } }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
