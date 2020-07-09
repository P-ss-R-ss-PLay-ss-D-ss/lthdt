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
    class GeneralInfo
    {
        //fields
        private string name = "Unknow";
        private DateTime birdDay = new DateTime(1900, 1, 1);
        private Address address = new Address("", "", "", "");
        private string soCMND = "Unknow";
        /// <summary>
        /// constructor đầy đủ tham số
        /// ngày : 2/7/2020
        /// </summary>
        /// <param name="hoTen"></param>
        /// <param name="ngaySinh"></param>
        /// <param name="soCMND"></param>
        /// <param name="diaChi"></param>
        public GeneralInfo(string hoTen, DateTime ngaySinh, string soCMND, Address address)
        {
            Name = hoTen;
            BirdDay = ngaySinh;
            SoCMND = soCMND;
            Address = address;
        }
        /// <summary>
        /// constructor thiếu ngày sinh
        /// ngày : 2/7/2020
        /// </summary>
        /// <param name="hoTen"></param>
        /// <param name="soCMND"></param>
        /// <param name="diaChi"></param>
        public GeneralInfo(string hoTen, string soCMND, Address diaChi)
        {
            Name = hoTen;
            SoCMND = soCMND;
            Address = address;
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
        public GeneralInfo(string hoTen, string soCMND, string apartmentNum, string street, string district, string city)
        {
            Name = hoTen;
            SoCMND = soCMND;
            Address = new Address(apartmentNum, street, district, city);
        }
        //properties
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != null && value != "")
                {
                    name = value;
                }
            }
        }
        public DateTime BirdDay
        {
            get
            {
                return birdDay;
            }
            set
            {
                if (value != null && value != new DateTime())
                {
                    birdDay = value;
                }
            }
        }
        public string SoCMND
        {
            get
            {
                return soCMND;
            }
            set
            {
                if (value != "" && value != null)
                {
                    value = soCMND;
                }
            }
        }
        internal Address Address
        {
            get { return address; }
            set
            {
                if (value != null)
                {
                    value = address;
                }
            }
        }

        /// <summary>
        /// in địa chỉ
        /// ngày : 2/7/2020
        /// </summary>
        /// <returns></returns>
        public String nhapFileThongTinChung()
        {
            return $"{Name}.{BirdDay.ToString("dd/MM/yyyy")}.{Address.nhapFileDiaChi()}.{SoCMND}";
        }
        /// <summary>
        /// in thông tin chung của khách hang
        /// ngày : 2/7/2020
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
