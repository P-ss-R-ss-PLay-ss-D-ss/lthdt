﻿/**
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
        private LinkedList<Product> products = new LinkedList<Product>();
        private string codeBill = "Unknow";
        private DateTime dateOfPurchase = new DateTime(1900, 1, 1);
        private Staff staff = new Staff();
        /// <summary>
        /// constructor đầy đủ tham số
        /// ngày : 2/7/2020
        /// </summary>
        /// <param name="maHoaDon"></param>
        /// <param name="ngayMua"></param>
        /// <param name="khachHang"></param>
        /// <param name="sanPhams"></param>
        /// 
        public Bill(string maHoaDon, DateTime ngayMua, Customer khachHang, LinkedList<Product> sanPhams, Staff staff) : base(khachHang)
        {
            CodeBill = maHoaDon;
            DateOfPurchase = ngayMua;
            Products = sanPhams;
            Staff = staff;
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
        internal LinkedList<Product> Products
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
        internal Staff Staff { get { return staff; } set { if (value != null) { staff = value; } } }

        /// <summary>
        /// form ghi vao file
        /// ngay : 9/7/2020
        /// </summary>
        /// <returns></returns>
        public string nhapFileHoaDon()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{codeBill}-{DateOfPurchase.ToString("yyyy/MM/dd")}-");

            for (int i = 0; i < Products.Count; i++)
            {
                if (i == products.Count - 1)
                {
                    sb.Append($"{Products.ElementAt(i).CodeProduct}");
                    break;
                }
                sb.Append($"{Products.ElementAt(i).CodeProduct}*");
            }

            sb.Append($"-{base.CodeCustomer}");

            sb.Append("-" + Staff.CodeStaff);

            return sb.ToString();
        }

        public static Bill xuatFileHoaDon(string bill)
        {
            string[] bills = bill.Split('-');

            LinkedList<Product> l = new LinkedList<Product>();
            string[] product = bills[2].Split('*');
            for (int i = 0; i < product.Length / 5; i++)
            {
                l.Append(Product.xuatFileSanPhamBangMaSP(product[i]));
            }

            Customer kh = Customer.xuatFileKhachHangBangMaKH(bills[3]);
            Staff nv = Staff.xuatFileNhanVienBangMaSP(bills[4]);
            return new Bill(bills[0], Convert.ToDateTime(bills[1]), kh, l, nv);
        }

        public static Bill xuatFileHoaDonBangMaHoaDon(string code)
        {
            string data;
            if ((data = IOFile.docFileBangMa(code, test.fileBill)) != null)
            {
                return Bill.xuatFileHoaDon(data);
            }
            return null;
        }

        /// <summary>
        /// in hoá đơn
        /// ngày : 2/7/2020
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"true" /*{base.GeneralInfo.Name},*/;
        }
    }
}