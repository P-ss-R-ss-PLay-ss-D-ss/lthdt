/**
 * Nguyễn Lê Trọng Tiền
 * Lớp CD19TT9
 * Ngày : 2/7/2020
 * class khách hàng chứa các thông tin như thẻ ATM , thông tin chung,thông tin liên hệ,mã khách hàng
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Emit;
using System.Text;

namespace QLDienThoai
{
    class Customer : GeneralInfo
    {
        //fields
        private string codeCustomer = "Unknow";
        /// <summary>
        /// constructor không tham số
        /// </summary>
        public Customer() : base("", "", new Address("", "", "", ""))
        {
        }
        /// <summary>
        /// constructor đầy đủ tham số
        /// </summary>
        /// <param name="maKhachHang"></param>
        /// <param name="thongTinChung"></param>
        /// <param name="thongTinLienHe"></param>
        public Customer(string maKhachHang, GeneralInfo thongTinChung) : base(thongTinChung.Name, thongTinChung.SoCMND, thongTinChung.Address)
        {
            CodeCustomer = maKhachHang;
        }
        public Customer(string tenKH) : base("", "", new Address("", "", "", ""))
        {
            Random rd = new Random();
            CodeCustomer = "19211" + rd.Next(1000, 9999);
        }
        //properties
        public string CodeCustomer
        {
            get { return codeCustomer; }
            set
            {
                if (value != null && value != "")
                {
                    codeCustomer = value;
                }
            }
        }
        /// <summary>
        /// form ghi vao file
        /// ngay : 9/7/2020
        /// </summary>
        /// <returns></returns>
        public string nhapFileKhachHang()
        {
            return $"{CodeCustomer}+{base.nhapFileThongTinChung()}";
        }

        public static Customer xuatFileKhachHang(string customer)
        {
            string[] s = customer.Split('+');
            GeneralInfo ttc = GeneralInfo.xuatFileThongTinChung(s[1]);
            return new Customer(s[0], ttc);
        }

        /// <summary>
        /// xuất thông tin khách hàng
        /// ngày : 2/7/2020
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }
        ~Customer() { }
    }
}
