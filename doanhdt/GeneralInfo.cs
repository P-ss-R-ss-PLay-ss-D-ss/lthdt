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

        public GeneralInfo(GeneralInfo generalInfo)
        {
            this.Name = generalInfo.name;
            this.SoCMND = generalInfo.SoCMND;
            this.Address = generalInfo.address;
            this.BirdDay = generalInfo.birdDay;
        }

        public GeneralInfo()
        {
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
                if (value != null)
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
                if (Customer.checkString(value)&&checkSoCMND(value))
                {
                    soCMND = value;
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
                    address = value;
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
            return $"{Name}.{BirdDay.ToString("yyyy/MM/dd")}.{Address.nhapFileDiaChi()}.{SoCMND}";
        }
        public static GeneralInfo xuatFileThongTinChung(string thongTinChung)
        {
            string[] s = thongTinChung.Split('.');
            Address dc = Address.xuatFileDiaChi(s[2]);
            return new GeneralInfo(s[0], Convert.ToDateTime(s[1]), s[3], dc);
        }

        public static bool checkSoCMND(string value)
        {
            return value.Length == 9 || value.Length == 12;
        }

        /// <summary>
        /// in thông tin chung của khách hang
        /// ngày : 2/7/2020
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.Address}{this.BirdDay}{this.Name}{this.SoCMND}";
        }
    }
}
