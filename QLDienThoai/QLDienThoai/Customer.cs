/**
 * Nguyễn Lê Trọng Tiền
 * Lớp CD19TT9
 * Ngày : 2/7/2020
 * class khách hàng chứa các thông tin như thẻ ATM , thông tin chung,thông tin liên hệ,mã khách hàng
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QLDienThoai
{
    class Customer
    {
        //fields
        private GeneralInfo generalInfo = new GeneralInfo("", "", new Address("", "", "", ""));
        private string codeCustomer = "Unknow";
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
        /// <param name="thongTinChung"></param>
        /// <param name="thongTinLienHe"></param>
        public Customer(string maKhachHang, GeneralInfo thongTinChung)
        {
            CodeCustomer = maKhachHang;
            GeneralInfo = thongTinChung;
        }
        public Customer(string tenKH)
        {
            GeneralInfo.Name = tenKH;
            Random rd = new Random();
            CodeCustomer = "19211" + rd.Next(1000, 9999);
        }
        //properties
        public string CodeCustomer
        {
            get
            {
                return codeCustomer;
            }
            set
            {
                if (value != null && value != "")
                {
                    codeCustomer = value;
                }
            }
        }
        internal GeneralInfo GeneralInfo
        {
            get
            {
                return generalInfo;
            }
            set
            {
                if (value != null)
                {
                    generalInfo = value;
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
            return $"{CodeCustomer}+{GeneralInfo.nhapFileThongTinChung()}";
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
