/**
 * Nguyễn Lê Trọng Tiền
 * Lớp CD19TT9
 * Ngày : 2/7/2020
 * class hoá đơn lưu thông tin khách hàng mua hàng và danh sach sản phẩm
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDienThoai
{
    class Bill : Customer
    {
        //fields
        private LinkedList<Product> products = new LinkedList<Product>();
        private string codeBill = "Unknow";
        private DateTime dateOfPurchase = new DateTime(1900, 1, 1);
        private Staff staff = new Staff();
        /// <summary>
        /// constructor đầy đủ tham số
        /// ngày : 2/7/2020
        /// </summary>
        /// <param name="maHoaDon"></param>
        /// <param name="ngayMua"></param>
        /// <param name="khachHang"></param>
        /// <param name="sanPhams"></param>
        /// 
        public Bill(string maHoaDon, DateTime ngayMua, Customer khachHang, LinkedList<Product> sanPhams, Staff staff) : base(khachHang)
        {
            CodeBill = maHoaDon;
            DateOfPurchase = ngayMua;
            Products = sanPhams;
            Staff = staff;
        }
        //properties
        public string CodeBill
        {
            get
            {
                return codeBill;
            }
            set
            {
                if (value != null && value != "")
                {
                    codeBill = value;
                }
            }
        }
        public DateTime DateOfPurchase
        {
            get
            {
                return dateOfPurchase;
            }
            set
            {
                if (value != new DateTime() && value != null)
                {
                    dateOfPurchase = value;
                }
            }
        }
        internal LinkedList<Product> Products
        {
            get
            {
                return products;
            }
            set
            {
                if (value != null)
                {
                    products = value;
                }
            }
        }
        internal Staff Staff { get { return staff; } set { if (value != null) { staff = value; } } }
        /// <summary>
        /// form ghi vao file
        /// ngay : 9/7/2020
        /// </summary>
        /// <returns></returns>
        public string nhapFileHoaDon()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{codeBill}-{DateOfPurchase.ToString("yyyy/MM/dd")}-");

            for (int i = 0; i < Products.Count; i++)
            {
                if (i == products.Count - 1)
                {
                    sb.Append($"{Products.ElementAt(i).CodeProduct}");
                    break;
                }
                sb.Append($"{Products.ElementAt(i).CodeProduct}*");
            }

            sb.Append($"-{base.CodeCustomer}");

            sb.Append("-" + Staff.CodeStaff);

            return sb.ToString();
        }
        /// <summary>
        /// Đọc hóa đơn từ file Bill 
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
        public static Bill getBill(string bill)
        {
            string[] bills = bill.Split('-');

            LinkedList<Product> l = new LinkedList<Product>();
            string[] product = bills[2].Split('*');
            for (int i = 0; i < product.Length / 5; i++)
            {
                l.AddLast(Product.getProductByID(product[i]));
            }

            Customer kh = Customer.getCustomerByID(bills[3]);
            Staff nv = Staff.getStaffById(bills[4]);
            return new Bill(bills[0], Convert.ToDateTime(bills[1]), kh, l, nv);
        }
        /// <summary>
        /// Ghi mã hóa đơn ra file CodeBill
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static Bill getBillByID(string code)
        {
            string data;
            if ((data = IOFile.docFileBangMa(code, test.fileBill)) != null)
            {
                return Bill.getBill(data);
            }
            return null;
        }

        public double getTongTien()
        {
            double result = 0;
            LinkedListNode<Product> a = products.First;
            do
            {
                result += a.Value.Price;
            } while ((a = a.Next)!=null);

            return result;
        }

        /// <summary>
        /// in hoá đơn
        /// ngày : 2/7/2020
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string s = "+-----------------------------------------------------------------------------------------------------+";
            s += $"{"|",-20}{"HOA DON BAN HANG",-15}|";
            s += "+-----------------------------------------------------------------------------------------------------+";
            return null;
        }
    }
}
