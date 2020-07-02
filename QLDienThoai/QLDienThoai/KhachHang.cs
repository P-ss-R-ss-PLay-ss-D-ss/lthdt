using System;
using System.Collections.Generic;
using System.Text;

namespace QLDienThoai
{
    class KhachHang
    {
        private ATM aTM = new ATM();
        private ThongTinChung thongTinChung = new ThongTinChung();
        private ThongTinLienHe thongTinLienHe = new ThongTinLienHe();
        private string maKhachHang = "Unknow";

        public KhachHang()
        {
        }

        public KhachHang(string maKhachHang, ATM aTM, ThongTinChung thongTinChung, ThongTinLienHe thongTinLienHe)
        {
            MaKhachHang = maKhachHang;
            ATM = aTM;
            ThongTinChung = thongTinChung;
            ThongTinLienHe = thongTinLienHe;
        }

        public string MaKhachHang { get => maKhachHang; set { if (value != null && value != "") { maKhachHang = value; } } }
        internal ATM ATM { get => aTM; set { if (value != null ) { aTM = value; } } }
        internal ThongTinChung ThongTinChung { get => thongTinChung; set { if (value != null ) { thongTinChung = value; } } }
        internal ThongTinLienHe ThongTinLienHe { get => thongTinLienHe; set { if (value != null) { thongTinLienHe = value; } } }
    
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
