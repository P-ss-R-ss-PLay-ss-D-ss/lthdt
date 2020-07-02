/**
 * Nguyễn Lê Trọng Tiền
 * Lớp CD19TT9
 * Ngày : 2/7/2020
 * class thông tin chung chứa các thông tin như ho tên ngày sinh số CMND
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace QLDienThoai
{
    class GeneralInfo : Address
    {
        //fields
        private string hoTen = "Unknow";
        private DateTime ngaySinh = new DateTime(1900, 1, 1);
        private string soCMND = "Unknow";
        /// <summary>
        /// constructor đầy đủ tham số
        /// ngày : 2/7/2020
        /// </summary>
        /// <param name="hoTen"></param>
        /// <param name="ngaySinh"></param>
        /// <param name="soCMND"></param>
        /// <param name="diaChi"></param>
        public GeneralInfo(string hoTen, DateTime ngaySinh, string soCMND, Address diaChi) : base(diaChi.ApartmentNum, diaChi.Street, diaChi.District, diaChi.City)
        {
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            SoCMND = soCMND;
        }
        /// <summary>
        /// constructor thiếu ngày sinh
        /// ngày : 2/7/2020
        /// </summary>
        /// <param name="hoTen"></param>
        /// <param name="soCMND"></param>
        /// <param name="diaChi"></param>
        public GeneralInfo(string hoTen, string soCMND, Address diaChi) : base(diaChi.ApartmentNum, diaChi.Street, diaChi.District, diaChi.City)
        {
            HoTen = hoTen;
            SoCMND = soCMND;
        }
        /// <summary>
        /// constructor đầy đủ tham số
        /// ngày : 2/7/2020
        /// </summary>
        /// <param name="hoTen"></param>
        /// <param name="soCMND"></param>
        /// <param name="apartmentNum"></param>
        /// <param name="street"></param>
        /// <param name="district"></param>
        /// <param name="city"></param>
        public GeneralInfo(string hoTen, string soCMND, string apartmentNum, string street, string district, string city) : base(apartmentNum, street, district, city)
        {
            HoTen = hoTen;
            SoCMND = soCMND;
        }
        //properties
        public string HoTen { get => hoTen; set { if (value != null && value != "") { hoTen = value; } } }
        public DateTime NgaySinh { get => ngaySinh; set { if (value != null && value != new DateTime()) { ngaySinh = value; } } }
        public string SoCMND { get => soCMND; set => soCMND = value; }
        /// <summary>
        /// in địa chỉ
        /// ngày : 2/7/2020
        /// </summary>
        /// <returns></returns>
        public String printAddress()
        {
            return base.ToString();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
