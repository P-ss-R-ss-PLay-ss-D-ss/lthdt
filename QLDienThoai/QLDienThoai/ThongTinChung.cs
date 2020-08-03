/**
 * Nguyễn Lê Trọng Tiền
 * Lớp CD19TT9
 * Ngày : 2/7/2020
 * class ThongTinChung chứa các thông tin như ho tên ngày sinh số CMND
 */
using System;

namespace QLDienThoai
{
    class ThongTinChung : INhapXuatFile
    {
        //fields
        private string hoTen;
        private DateTime ngaySinh;
        private DiaChi diaChi;
        private string soCMND;
        /// <summary>
        /// constructor đầy đủ tham số
        /// ngày : 2/7/2020
        /// </summary>
        /// <param name="hoTen"></param>
        /// <param name="ngaySinh"></param>
        /// <param name="soCMND"></param>
        /// <param name="diaChi"></param>
        public ThongTinChung(string hoTen, DateTime ngaySinh, string soCMND, DiaChi diaChi)
        {
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            SoCMND = soCMND;
            DiaChi = diaChi;
        }
        ///// <summary>
        ///// constructor thiếu ngày sinh
        ///// ngày : 2/7/2020
        ///// </summary>
        ///// <param name="hoTen"></param>
        ///// <param name="soCMND"></param>
        ///// <param name="diaChi"></param>
        //public ThongTinChung(string hoTen, string soCMND, DiaChi diaChi)
        //{
        //    HoTen = hoTen;
        //    SoCMND = soCMND;
        //    DiaChi = this.diaChi;
        //}
        /// <summary>
        /// constructor đầy đủ tham số
        /// ngày : 2/7/2020
        /// </summary>
        /// <param name="hoTen"></param>
        /// <param name="soCMND"></param>
        /// <param name="soNha"></param>
        /// <param name="duong"></param>
        /// <param name="quan"></param>
        /// <param name="thanhPho"></param>
        public ThongTinChung(string hoTen, string soCMND, string soNha, string duong, string quan, string thanhPho)
        {
            HoTen = hoTen;
            SoCMND = soCMND;
            DiaChi = new DiaChi(soNha, duong, quan, thanhPho);
        }
        /// <summary>
        /// constructor copy
        /// </summary>
        /// <param name="generalInfo"></param>
        public ThongTinChung(ThongTinChung generalInfo)
        {
            this.HoTen = generalInfo.hoTen;
            this.SoCMND = generalInfo.SoCMND;
            this.DiaChi = generalInfo.diaChi;
            this.NgaySinh = generalInfo.ngaySinh;
        }
        /// <summary>
        /// constructor mac dinh
        /// </summary>
        public ThongTinChung()
        {
            hoTen = "Unknow";
            ngaySinh = new DateTime(1900, 1, 1);
            diaChi = new DiaChi("", "", "", "");
            soCMND = "Unknow";
        }

        //properties
        public string HoTen
        {
            get
            {
                return hoTen;
            }
            set
            {
                if (value != null && value != "")
                {
                    hoTen = value;
                }
            }
        }
        public DateTime NgaySinh
        {
            get
            {
                return ngaySinh;
            }
            set
            {
                if (value != null)
                {
                    ngaySinh = value;
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
                if (KhachHang.checkString(value) && checkSoCMND(value))
                {
                    soCMND = value;
                }
            }
        }
        internal DiaChi DiaChi
        {
            get { return diaChi; }
            set
            {
                if (value != null)
                {
                    diaChi = value;
                }
            }
        }

        /// <summary>
        /// check so cmnd
        /// Ngày: 2/7/2020
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool checkSoCMND(string value)
        {
            return value.Length == 9 || value.Length == 12;
        }
        /// <summary>
        /// Định dạng chuỗi được in ra file
        /// Ngày: 2/7/2020
        /// </summary>
        /// <returns></returns>
        public virtual string WriteFile()
        {
            return $"{HoTen}.{NgaySinh.ToString("yyyy/MM/dd")}.{DiaChi.WriteFile()}.{SoCMND}";
        }

        /// <summary>
        /// Đọc dữ liệu từ file
        /// Ngày : 2/7/2020
        /// </summary>
        /// <param name="thongTinChung"></param>
        /// <returns></returns>
        public virtual object GetFile(string thongTinChung)
        {
            string[] s = thongTinChung.Split('.');
            DiaChi dc = (DiaChi)DiaChi.GetFile(s[2]);
            return new ThongTinChung(s[0], Convert.ToDateTime(s[1]), s[3], dc);
        }

        /// <summary>
        /// in thông tin chung
        /// ngày sửa: 2/7/2020
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.HoTen}{this.NgaySinh}{this.SoCMND}{this.DiaChi}";
        }
        /// <summary>
        /// phuong thuc huy
        /// </summary>
        ~ThongTinChung() { }

    }
}
