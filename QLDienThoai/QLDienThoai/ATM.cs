/**
 * Nguyễn Lê Trọng Tiền
 * Lớp CD19TT9
 * Ngày : 2/7/2020
 * class ATM chứa các thông tin chư số tài khoản ngân hàng để chuyển nhận tiền
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace QLDienThoai
{
    public class ATM
    {
        //fields
        private string soTaiKhoan = "Unknow";
        private string nganHang = "Unknow";
        /// <summary>
        /// constructor đầy đủ tham số
        /// Ngày : 2/7/2020
        /// </summary>
        /// <param name="nganHang"></param>
        /// <param name="soTaiKhoan"></param>
        public ATM(string nganHang, string soTaiKhoan)
        {
            SoTaiKhoan = soTaiKhoan;
            NganHang = nganHang;
        }
        //properties
        public string SoTaiKhoan { get => soTaiKhoan; set { if (value != null && value != "") { soTaiKhoan = value; } } }
        public string NganHang { get => nganHang; set { if (value != null && value != "") { nganHang = value; } } }
        /// <summary>
        /// in thông tin nơi chuyển nhận tiền
        /// Ngày : 2/7/2020
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"-  Ngan hang: {NganHang}\n-  So tai khoan: {SoTaiKhoan}";
        }
    }
}
