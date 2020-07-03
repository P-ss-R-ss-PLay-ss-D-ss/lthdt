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
        private String codeProduct = "Unknow";
        private string nameProduct = "Unknow";
        private int amount = 1;
        private double price = 0;
        private string makeIn = "Unknow";
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
        /// <param name="maSP"></param>
        /// <param name="soLuong"></param>
        /// <param name="gia"></param>
        /// <param name="xuatXu"></param>
        /// <param name="temSP"></param>
        public Product(string maSP, int soLuong, double gia, string xuatXu, string temSP)
        {
            CodeProduct = maSP;
            Amount = soLuong;
            Price = gia;
            MakeIn = xuatXu;
            NameProduct = temSP;
        }
        //properties
        public string CodeProduct { get => codeProduct; set { if (value != null && value != "") { codeProduct = value; } } }
        public int Amount { get => amount; set { if (value > 0) { amount = value; } } }
        public double Price { get => price; set { if (value >0) { price = value; } } }
        public string MakeIn { get => makeIn; set { if (value != null && value != "") { makeIn = value; } } }
        public string NameProduct { get => nameProduct; set => nameProduct = value; }
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
