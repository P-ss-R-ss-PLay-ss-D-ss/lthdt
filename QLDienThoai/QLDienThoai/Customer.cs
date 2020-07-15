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
        private string sDT = "Unknow";
        private string mail = "Unknow";

        /// <summary>
        /// constructor đầy đủ tham số
        /// </summary>
        /// <param name="maKhachHang"></param>
        /// <param name="thongTinChung"></param>
        /// <param name="thongTinLienHe"></param>
        public Customer(string maKhachHang, string sDT, string mail, GeneralInfo thongTinChung) : base(thongTinChung)
        {
            CodeCustomer = maKhachHang;
            SDT = sDT;
            Mail = mail;
        }
        public Customer(Customer customer) : base(customer.Name, customer.SoCMND, customer.Address)
        {
            CodeCustomer = customer.codeCustomer;
            SDT = customer.sDT;
            Mail = customer.Mail;
        }
        public Customer() : base()
        {

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
        public string SDT
        {
            get { return sDT; }
            set
            {
                if (value != null && value != "")
                {
                    sDT = value;
                }
            }
        }
        public string Mail
        {
            get { return mail; }
            set
            {
                if (value != null && value != "" && !checkMail(value))
                {
                    mail = value;
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
            return $"{CodeCustomer}+{SDT}+{Mail}+{nhapFileThongTinChung()}";
        }

        public static Customer xuatFileKhachHang(string customer)
        {
            string[] s = customer.Split('+');
            GeneralInfo ttc = GeneralInfo.xuatFileThongTinChung(s[3]);
            return new Customer(s[0], s[1], s[2], ttc);
        }

        public static Customer xuatFileKhachHangBangMaKH(string code)
        {
            string data;
            if ((data = IOFile.docFileBangMa(code, test.fileCustomer)) != null)
            {
                return Customer.xuatFileKhachHang(data);
            }
            return null;
        }

        public static bool checkMail(string mail)
        {
            return checkSoKyTuACong(mail) != 1 || mail.Contains(' ');
        }
        private static int checkSoKyTuACong(string mail)
        {
            int result = 0;
            foreach (var k in mail)
            {
                if (k == '@')
                {
                    result++;
                }
            }
            return result;
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
