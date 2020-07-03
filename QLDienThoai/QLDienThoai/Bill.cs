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
        private List<Product> products = new List<Product>();
        private string codeBill = "Unknow";
        private DateTime dateOfPurchase = new DateTime(1900,1,1);
        /// <summary>
        /// constructor đầy đủ tham số
        /// ngày : 2/7/2020
        /// </summary>
        /// <param name="maHoaDon"></param>
        /// <param name="ngayMua"></param>
        /// <param name="khachHang"></param>
        /// <param name="sanPhams"></param>
        public Bill(string maHoaDon, DateTime ngayMua, Customer khachHang, List<Product> sanPhams) : base(khachHang.CodeCustomer, khachHang.GeneralInfo, khachHang.ContactInfo)
        {
            CodeBill = maHoaDon;
            DateOfPurchase = ngayMua;
            Products = sanPhams;
        }

        public Bill()
        {
        }
        //properties
        public string CodeBill { get => codeBill; set { if (value != null && value != "") { codeBill = value; } } }
        public DateTime DateOfPurchase { get => dateOfPurchase; set { if (value != new DateTime() && value != null) { dateOfPurchase = value; } } }
        internal List<Product> Products { get => products; set => products = value; }
        /// <summary>
        /// in hoá đơn
        /// ngày : 2/7/2020
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"ho ten: {base.GeneralInfo.Name},";
        }
    }
}
