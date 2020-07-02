/**
 * Nguyễn Lê Trọng Tiền
 * Lớp CD19TT9
 * Ngày : 2/7/2020
 * class Thông tin liên hệ chứa thông tin địa chỉ số đt liên hệ email liên hệ
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace QLDienThoai
{
    class ContactInfo : Address
    {
        //fields
        private string email = "Unknow";
        private string sDT = "Unknow";
        /// <summary>
        /// constructor đầy đủ tham số
        /// </summary>
        /// <param name="email"></param>
        /// <param name="sDT"></param>
        /// <param name="diaChi"></param>
        public ContactInfo(string email, string sDT, Address diaChi) : base(diaChi.ApartmentNum, diaChi.Street, diaChi.District, diaChi.City)
        {
            Email = email;
            SDT = sDT;
        }
        /// <summary>
        /// cóntructor đầy đủ tham số
        /// </summary>
        /// <param name="email"></param>
        /// <param name="sDT"></param>
        /// <param name="apartmentNum"></param>
        /// <param name="street"></param>
        /// <param name="district"></param>
        /// <param name="city"></param>
        public ContactInfo(string email, string sDT, string apartmentNum, string street, string district, string city) : base(apartmentNum, street, district, city)
        {
            Email = email;
            SDT = sDT;
        }
        //properties
        public string Email { get => email; set { if (value != null && value != "") { email = value; } } }
        public string SDT { get => sDT; set { if (value != null && value != "") { SDT = value; } } }
        /// <summary>
        /// in địa chỉ
        /// Ngày : 2/7/2020
        /// </summary>
        /// <returns></returns>
        public String printAddress()
        {
            return base.ToString();
        }
        /// <summary>
        /// xuất thông tin liên hệ
        /// Ngày : 2/7/2020
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
