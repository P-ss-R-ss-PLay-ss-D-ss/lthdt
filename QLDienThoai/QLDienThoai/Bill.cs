/**
 * Nguyễn Lê Trọng Tiền
 * Lớp CD19TT9
 * Ngày : 2/7/2020
 * class hoá đơn lưu thông tin khách hàng mua hàng và danh sach sản phẩm
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace QLDienThoai
{
    class Bill : Customer
    {
        //fields
        private List<Product> sanPhams = new List<Product>();
        private string maHoaDon = "Unknow";
        private DateTime ngayMua = new DateTime(1900,1,1);
        /// <summary>
        /// constructor đầy đủ tham số
        /// ngày : 2/7/2020
        /// </summary>
        /// <param name="maHoaDon"></param>
        /// <param name="ngayMua"></param>
        /// <param name="khachHang"></param>
        /// <param name="sanPhams"></param>
        public Bill(string maHoaDon, DateTime ngayMua, Customer khachHang, List<Product> sanPhams) : base(khachHang.MaKhachHang, khachHang.ThongTinChung, khachHang.ThongTinLienHe)
        {
            MaHoaDon = maHoaDon;
            NgayMua = ngayMua;
            SanPhams = sanPhams;
        }

        public Bill()
        {
        }
        //properties
        public string MaHoaDon { get => maHoaDon; set { if (value != null && value != "") { maHoaDon = value; } } }
        public DateTime NgayMua { get => ngayMua; set { if (value != new DateTime() && value != null) { ngayMua = value; } } }
        internal List<Product> SanPhams { get => sanPhams; set => sanPhams = value; }
        /// <summary>
        /// in hoá đơn
        /// ngày : 2/7/2020
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
