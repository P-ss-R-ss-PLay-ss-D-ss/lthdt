using System;

namespace QLDienThoai
{
    class SanPham
    {
        private String maDT = "Unknow";
        private int soLuong = 1;
        private double gia = 0;
        private string xuatXu = "Unknow";

        public SanPham()
        {
        }

        public SanPham(string maDT, int soLuong, double gia, string xuatXu)
        {
            MaDT = maDT;
            SoLuong = soLuong;
            Gia = gia;
            XuatXu = xuatXu;
        }


        public string MaDT { get => maDT; set => maDT = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public double Gia { get => gia; set => gia = value; }
        public string XuatXu { get => xuatXu; set => xuatXu = value; }
       
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
