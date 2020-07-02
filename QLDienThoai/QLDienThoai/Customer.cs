/**
 * Nguyễn Lê Trọng Tiền
 * Lớp CD19TT9
 * Ngày : 2/7/2020
 * class khách hàng chứa các thông tin như thẻ ATM , thông tin chung,thông tin liên hệ,mã khách hàng
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace QLDienThoai
{
    class Customer
    {
        //fields
        private ATM aTM = new ATM("", "");
        private GeneralInfo thongTinChung = new GeneralInfo("", "", new Address("", "", "", ""));
        private ContactInfo thongTinLienHe = new ContactInfo("", "", new Address("", "", "", ""));
        private string maKhachHang = "Unknow";
        /// <summary>
        /// constructor không tham số
        /// </summary>
        public Customer()
        {
        }
        /// <summary>
        /// constructor đầy đủ tham số
        /// </summary>
        /// <param name="maKhachHang"></param>
        /// <param name="aTM"></param>
        /// <param name="thongTinChung"></param>
        /// <param name="thongTinLienHe"></param>
        public Customer(string maKhachHang, ATM aTM, GeneralInfo thongTinChung, ContactInfo thongTinLienHe)
        {
            MaKhachHang = maKhachHang;
            ATM = aTM;
            ThongTinChung = thongTinChung;
            ThongTinLienHe = thongTinLienHe;
        }
        //properties
        public string MaKhachHang { get => maKhachHang; set { if (value != null && value != "") { maKhachHang = value; } } }
        internal ATM ATM { get => aTM; set { if (value != null) { aTM = value; } } }
        internal GeneralInfo ThongTinChung { get => thongTinChung; set { if (value != null) { thongTinChung = value; } } }
        internal ContactInfo ThongTinLienHe { get => thongTinLienHe; set { if (value != null) { thongTinLienHe = value; } } }
        /// <summary>
        /// xuất thông tin khách hàng
        /// ngày : 2/7/2020
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
