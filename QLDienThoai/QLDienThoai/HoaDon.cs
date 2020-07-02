using System;
using System.Collections.Generic;
using System.Text;

namespace QLDienThoai
{
    class HoaDon
    {
        private KhachHang khachHang = new KhachHang();
        private SanPham[] sanPhams = new SanPham[0];
        private string maHoaDon = "Unknow";
        private DateTime ngayMua = new DateTime();

        public HoaDon(string maHoaDon, DateTime ngayMua, KhachHang khachHang, SanPham[] sanPhams)
        {
            MaHoaDon = maHoaDon;
            NgayMua = ngayMua;
            KhachHang = khachHang;
            SanPhams = sanPhams;
        }

        public HoaDon()
        {
        }

        public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public DateTime NgayMua { get => ngayMua; set => ngayMua = value; }
        internal KhachHang KhachHang { get => khachHang; set => khachHang = value; }
        internal SanPham[] SanPhams { get => sanPhams; set => sanPhams = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
