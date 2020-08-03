/**
 * Nguyễn Lê Trọng Tiền
 * Lớp CD19TT9
 * Ngày : 2/7/2020
 * class SanPham gồm các thông tin như mã sản phẩm ,tên sản phẩm, số lượng, giá,xuất xứ
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace QLDienThoai
{
    class SanPham : INhapXuatFile,IGetID
    {
        //fields
        private string maSP;
        private string tenSP;
        private int soLuong;
        private double gia;
        private string xuatXu;
        /// <summary>
        /// constructor mặc đinh
        /// ngày : 2/7/2020
        /// </summary>
        public SanPham()
        {
            maSP = "Unknow";
            tenSP = "Unknow";
            soLuong = 0;
            gia = 0;
            xuatXu = "Unknow";
        }
        /// <summary>
        /// constructor đầy đủ tham số
        /// ngày : 2/7/2020
        /// </summary>
        /// <param name="maSP"></param>
        /// <param name="soLuong"></param>
        /// <param name="gia"></param>
        /// <param name="xuatXu"></param>
        /// <param name="tenSP"></param>
        public SanPham(string maSP, int soLuong, double gia, string xuatXu, string tenSP)
        {
            Gia = gia;
            XuatXu = xuatXu;
            TenSP = tenSP;
            SoLuong = soLuong;
            MaSP = maSP;
        }
        public double Gia
        {
            get
            {
                return gia;
            }
            set
            {
                if (value > 0) { gia = value; }

            }
        }
        public string XuatXu
        {
            get
            {
                return xuatXu;
            }
            set
            {
                if (value != null && value != "")
                {
                    xuatXu = value;
                }
            }
        }
        public string TenSP
        {
            get
            {
                return tenSP;
            }
            set
            {
                if (value != null && value != "")
                {
                    tenSP = value;
                }
            }
        }
        public string MaSP
        {
            get { return maSP; }
            set
            {
                if (value != null && value != "")
                {
                    maSP = value;
                }
            }
        }
        public int SoLuong { get { return soLuong; } set { soLuong = value; } }
        /// <summary>
        /// Định dạng chuỗi được in ra file
        /// Ngày: 3/7/2020
        /// </summary>
        /// <returns></returns>
        public string WriteFile()
        {
            return $"{MaSP},{SoLuong},{TenSP},{Gia},{XuatXu}";
        }
        /// <summary>
        /// Đọc dữ liệu từ file
        /// Ngày : 3/7/2020
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public object GetFile(string filePath)
        {
            string[] s = filePath.Split(',');
            return new SanPham(s[0], Convert.ToInt32(s[1]), Convert.ToDouble(s[3]), s[4], s[2]);
        }
        /// <summary>
        /// Đọc dữ liệu từ file bằng mã
        /// Ngày : 3/7/2020
        /// </summary>
        /// <param name="iD"></param>
        /// <returns></returns>
        public object GetFileByID(string iD)
        {
            string data;
            if ((data = IOFile.readFileByID(iD, ChucNang.fileSP)) != null)
            {
                SanPham sp = new SanPham();
                return sp.GetFile(data);
            }
            return null;
        }
        /// <summary>
        /// in thông tin sản phầm
        /// ngày : 2/7/2020
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("+-----------------------------------------------+\n");
            sb.Append($"{"|",-14}{"THONG TIN SAN PHAM",-34}|\n");
            sb.Append("+-----------------------------------------------+\n");
            sb.Append($"{"|",-8}{"- Ma SP:",-22}{this.MaSP,-18}|\n");
            sb.Append($"{"|",-8}{"- Ten SP:",-22}{this.TenSP,-18}|\n");
            sb.Append($"{"|",-8}{"- Gia:",-22}{this.Gia,-18}|\n");
            sb.Append($"{"|",-8}{"- Xuat xu:",-22}{this.XuatXu,-18}|\n");
            sb.Append("+-----------------------------------------------+\n");

            return sb.ToString();
        }
        /// <summary>
        /// Phuong thuc huy 
        /// </summary>
        ~SanPham() { }
    }
}
