/**
 * Nguyễn Lê Trọng Tiền
 * Lớp CD19TT9
 * Ngày : 2/7/2020
 * class hoá đơn lưu thông tin khách hàng mua hàng và danh sach sản phẩm
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDienThoai
{
    class Bill : Customer
    {
        //fields
        private List<Product> products = new List<Product>();
        private string codeBill = "Unknow";
        private DateTime dateOfPurchase = new DateTime(1900, 1, 1);
        /// <summary>
        /// constructor đầy đủ tham số
        /// ngày : 2/7/2020
        /// </summary>
        /// <param name="maHoaDon"></param>
        /// <param name="ngayMua"></param>
        /// <param name="khachHang"></param>
        /// <param name="sanPhams"></param>
        public Bill(string maHoaDon, DateTime ngayMua, Customer khachHang, List<Product> sanPhams) : base(khachHang.CodeCustomer, khachHang.GeneralInfo)
        {
            CodeBill = maHoaDon;
            DateOfPurchase = ngayMua;
            Products = sanPhams;
        }

        public Bill()
        {
        }
        //properties
        public string CodeBill
        {
            get
            {
                return codeBill;
            }
            set
            {
                if (value != null && value != "")
                {
                    codeBill = value;
                }
            }
        }
        public DateTime DateOfPurchase
        {
            get
            {
                return dateOfPurchase;
            }
            set
            {
                if (value != new DateTime() && value != null)
                {
                    dateOfPurchase = value;
                }
            }
        }
        internal List<Product> Products
        {
            get
            {
                return products;
            }
            set
            {
                if (value != null)
                {
                    products = value;
                }
            }
        }

        /// <summary>
        /// form ghi vao file
        /// ngay : 9/7/2020
        /// </summary>
        /// <returns></returns>
        public string nhapFileHoaDon()
        {
            string s = "";

            s += $"{codeBill}-{DateOfPurchase.ToString("dd/MM/yyyy")}-";

            for (int i = 0; i < Products.Count; i++)
            {
                if (i == products.Count - 1)
                {
                    s += $"{Products[i].nhapFileSanPham()}";
                    break;
                }
                s += $"{Products[i].nhapFileSanPham()}*";
            }

            s += $"-{base.nhapFileKhachHang()}";

            return s;
        }

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
