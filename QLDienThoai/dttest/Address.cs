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

        //public
        public static Address docFileDiaChi(string diachi)
        {
            Address dc = new Address("", "", "", "");

            string[] dcs = new string[4];

            dcs = diachi.Split('-');

            dc.ApartmentNum = dcs[0];
            dc.Street = dcs[1];
            dc.District = dcs[2];
            dc.City = dcs[3];

            return dc;
        }

        public string xuatFileDiaChi()
        {
            return $"{ApartmentNum}-{Street}-{District}-{City}";
        }

        public void ghiFileDiaChi(string file)
        {
            FileStream f = new FileStream(file, FileMode.Open);
            StreamWriter sr = new StreamWriter(f, Encoding.UTF8);
            Address a = new Address(this.ApartmentNum, this.Street,District,City);

            sr.Write(a.xuatFileDiaChi());

            sr.Close();
            f.Close();
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
