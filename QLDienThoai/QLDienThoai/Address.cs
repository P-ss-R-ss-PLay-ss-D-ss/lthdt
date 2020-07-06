/**
 * Nguyễn Lê Trọng Tiền
 * Lớp CD19TT9
 * Ngày : 2/7/2020
 * class địa chỉ chứa các thông tin địa chỉ nhà như số nhà đường quận thành phố
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QLDienThoai
{
    class Address
    {
        //fields
        private string apartmentNum = "Unknow";
        private string street = "Unknow";
        private string district = "Unknow";
        private string city = "Unknow";
        /// <summary>
        /// consrtuctor đầy đủ tham số
        /// Ngày : 2/7/2020
        /// </summary>
        /// <param name="apartmentNum"></param>
        /// <param name="street"></param>
        /// <param name="district"></param>
        /// <param name="city"></param>
        public Address(string apartmentNum, string street, string district, string city)
        {
            ApartmentNum = apartmentNum;
            Street = street;
            District = district;
            City = city;
        }
        //properties
        public string ApartmentNum { get => apartmentNum; set { if (value != null && value != "") { apartmentNum = value; } } }
        public string Street { get => street; set { if (value != null && value != "") { street = value; } } }
        public string District { get => district; set { if (value != null && value != "") { district = value; } } }
        public string City { get => city; set { if (value != null && value != "") { city = value; } } }
        /// <summary>
        /// form ghi vao file
        /// ngay : 6/7/2020
        /// </summary>
        /// <returns></returns>
        public string nhapFileDiaChi()
        {
            return $"{ApartmentNum},{Street},{District},{City}";
        }
        /// <summary>
        /// in địa chỉ
        /// Ngày : 2/7/2020
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"-  so {ApartmentNum}, duong {Street}, quan {District}, thanh pho {City}.";
        }
    }
}
