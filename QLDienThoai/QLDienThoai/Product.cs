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
        public string CodeProduct
        {
            get
            {
                return codeProduct;
            }
            set
            {
                if (value != null && value != "")
                {
                    codeProduct = value;
                }
            }
        }
        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                if (value > 0)
                {
                    amount = value;
                }
            }
        }
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value > 0) { price = value; }

            }
        }
        public string MakeIn
        {
            get
            {
                return makeIn;
            }
            set
            {
                if (value != null && value != "")
                {
                    makeIn = value;
                }
            }
        }
        public string NameProduct
        {
            get
            {
                return nameProduct;
            }
            set
            {
                if (value != null && value != "")
                {
                    nameProduct = value;
                }
            }
        }

        /// <summary>
        /// form ghi vao file
        /// ngay : 9/7/2020
        /// </summary>
        /// <returns></returns>
        public string nhapFileSanPham()
        {
            return $"{CodeProduct},{NameProduct},{Amount},{Price},{MakeIn}";
        }

        public static Product nhapFileSanPham(string product)
        {
            string[] s = product.Split(',');
            return new Product(s[0], Convert.ToInt32(s[2]), Convert.ToDouble(s[3]), s[1], s[4]);
        }

        /// <summary>
        /// in thông tin sản phầm
        /// ngày : 2/7/2020
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }
        ~Product() { }
    }
}
