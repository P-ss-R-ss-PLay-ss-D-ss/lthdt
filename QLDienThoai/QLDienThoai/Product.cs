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
        private string productID = "Unknow";
        private int amoust = 0;
        private string nameProduct = "Unknow";
        private double price = 0;
        private string madeIn = "Unknow";
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
        /// <param name="tenSP"></param>
        public Product(string maSP, int soLuong, double gia, string xuatXu, string tenSP)
        {
            Price = gia;
            MadeIn = xuatXu;
            NameProduct = tenSP;
            Amoust = soLuong;
            ProductID = maSP;
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
        public string MadeIn
        {
            get
            {
                return madeIn;
            }
            set
            {
                if (value != null && value != "")
                {
                    madeIn = value;
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

        public string ProductID
        {
            get { return productID; }
            set
            {
                if (value != null && value != "")
                {
                    productID = value;
                }
            }
        }
        public int Amoust { get { return amoust; } set { amoust = value; } }

        /// <summary>
        /// form ghi vao file
        /// ngay : 9/7/2020
        /// </summary>
        /// <returns></returns>
        public string nhapFileSanPham()
        {
            return $"{ProductID},{Amoust},{NameProduct},{Price},{MadeIn}";
        }
        /// <summary>
        /// lay doi tuong bang tu file
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static Product getProduct(string product)
        {
            string[] s = product.Split(',');
            return new Product(s[0], Convert.ToInt32(s[1]), Convert.ToDouble(s[3]), s[4], s[2]);
        }
        /// <summary>
        /// lay doi tuong tu file bang ma
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static Product getProductByID(string code)
        {
            string fileSP = @"..\Product.txt";
            string data;
            if ((data = IOFile.docFileBangMa(code, fileSP)) != null)
            {
                return Product.getProduct(data);
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
            return null;
        }
    }
}
