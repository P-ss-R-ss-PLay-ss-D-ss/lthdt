/**
 * Nguyễn Lê Trọng Tiền
 * Lớp CD19TT9
 * Ngày : 2/7/2020
 * class thông tin sản phẩm gờm mã điện thoại , số lượng, giá,xuất sứ,tên đt
 */
using System;

namespace QLDienThoai
{
    class Product
    {
        //fields
        private String maDT = "Unknow";
        private string tenDT = "Unknow";
        private int soLuong = 1;
        private double gia = 0;
        private string xuatXu = "Unknow";
        /// <summary>
        /// constructor mặc đinh
        /// ngày : 2/7/2020
        /// </summary>
        public Product()
        {
        }
        /// <summary>
        /// constructor đầy đủ tham số
        /// ngày : 2/7/2020
        /// </summary>
        /// <param name="maDT"></param>
        /// <param name="soLuong"></param>
        /// <param name="gia"></param>
        /// <param name="xuatXu"></param>
        /// <param name="tenDT"></param>
        public Product(string maDT, int soLuong, double gia, string xuatXu, string tenDT)
        {
            MaDT = maDT;
            SoLuong = soLuong;
            Gia = gia;
            XuatXu = xuatXu;
            TenDT = tenDT;
        }
        //properties
        public string MaDT { get => maDT; set { if (value != null && value != "") { maDT = value; } } }
        public int SoLuong { get => soLuong; set { if (value > 0) { soLuong = value; } } }
        public double Gia { get => gia; set { if (value >0) { gia = value; } } }
        public string XuatXu { get => xuatXu; set { if (value != null && value != "") { xuatXu = value; } } }
        public string TenDT { get => tenDT; set => tenDT = value; }
        /// <summary>
        /// in thông tin sản phầm
        /// ngày : 2/7/2020
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
