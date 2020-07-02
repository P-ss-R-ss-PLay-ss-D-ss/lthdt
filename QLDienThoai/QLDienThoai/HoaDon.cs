using System;
using System.Collections.Generic;
using System.Text;

namespace QLDienThoai
{
    class HoaDon : KhachHang
    {
        private SanPham[] sanPhams = new SanPham[0];
        private string maHoaDon = "Unknow";
        private DateTime ngayMua = new DateTime(1900,1,1);

        public HoaDon(string maHoaDon,
                      DateTime ngayMua,
                      KhachHang khachHang,
                      SanPham[] sanPhams) : base(khachHang.MaKhachHang, khachHang.ATM, khachHang.ThongTinChung, khachHang.ThongTinLienHe)
        {
            MaHoaDon = maHoaDon;
            NgayMua = ngayMua;
            SanPhams = sanPhams;
        }

        public HoaDon()
        {
        }

        public string MaHoaDon { get => maHoaDon; set { if (value != null && value != "") { maHoaDon = value; } } }
        public DateTime NgayMua { get => ngayMua; set { if (value != new DateTime() && value != null) { ngayMua = value; } } }
        internal SanPham[] SanPhams { get => sanPhams; set { if (value != null ) { sanPhams = value; } } }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
