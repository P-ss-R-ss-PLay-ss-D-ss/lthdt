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

        public string SoNha { get => soNha; set => soNha = value; }
        public string Duong { get => duong; set => duong = value; }
        public string Quan { get => quan; set => quan = value; }
        public string ThanhPho { get => thanhPho; set => thanhPho = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
