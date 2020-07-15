using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;

namespace QLDienThoai
{
    class test
    {

        public static string fileBill = @"..\Bill.txt";
        public static string fileProduct = @"..\Product.txt";
        public static string fileCustomer = @"..\Customer.txt";
        public static string fileStaff = @"..\Staff.txt";
        static void Main(string[] args)
        {

            Product p = new Product(CreataCode.createCodeProduct(fileProduct), 1, 123, "my", "dt1");
            #region comment
            // #region create bill
            // Bill bill = new Bill(
            //    createCodeBill(fileBill),
            //    new DateTime(2001, 10, 30),
            //    new Customer
            //    (
            //        createCodeCustomer(fileCustomer),
            //        new GeneralInfo
            //        (
            //            "nguyentien",
            //            "342090200",
            //            new Address
            //            (
            //                "025",
            //                "thien ho duong",
            //                "thu duc",
            //                "tphcm"
            //            )
            //         )
            //        ),
            //    l,
            //    new Staff
            //    (
            //        createCodeStaff(fileStaff),
            //        new GeneralInfo
            //        (
            //            "nguyentien",
            //            "342090200",
            //            new Address
            //            (
            //                "025",
            //                "thien ho duong",
            //                "thu duc",
            //                "tphcm"
            //            )
            //         )
            //    )
            //);
            // #endregion
            //Console.WriteLine(IOFile.Add(createCodeProduct(fileCodeProduct), p.nhapFileSanPham(), fileCodeProduct, fileProduct));
            //Console.WriteLine(bill);
            //IOFile.ghiFile(fileProduct, p3.nhapFileSanPham());
            //Console.WriteLine(Bill.xuatFileHoaDon(docFile(fileHoaDon)[0]));
            //Console.WriteLine(IOFile.Delete("SP001", fileCodeProduct, fileProduct));
            //string s = "";
            //while (!checkExit(s))
            //{
            //    s = Console.ReadLine();
            //}
            #endregion
            IOFile.Add(CreataCode.createCodeCustomer(fileCustomer), addCustomer().nhapFileKhachHang(), fileCustomer);
            //Console.WriteLine(Staff.xuatFileNhanVienBangMaSP("NV001"));
            //Console.WriteLine(addGeneralInfo());
        }

        #region nhap thong tin
        static Bill addBill()
        {
            DateTime birthday;
            string c;
            string s;
            LinkedList<Product> l = new LinkedList<Product>();
            int soSP = 0;

            lap:
            try
            {
                Console.Write("  -  Nhap ngay mua[yyyy/MM/dd]: ");
                birthday = Convert.ToDateTime(Read());
            }
            catch (Exception)
            {
                goto lap;
            }

            Console.Write("-  Nhap ma khach hang: ");
            c = Read();

            Console.Write("-  Nhap ma nhan vien: ");
            s = Read();

            Console.Write("Nhap so san pham: ");
            int.TryParse(Read(), out soSP);

            string code;
            for (int i = 0; i < soSP; i++)
            {
                Console.Write("-  Nhap ma san pham thu {0}: ",i);
                if ((code = Read())!=""&& Product.xuatFileSanPhamBangMaSP(code)!=null)
                {
                    l.AddLast(Product.xuatFileSanPhamBangMaSP(code));
                }
            }

            if (Customer.xuatFileKhachHangBangMaKH(c)==null&& Staff.xuatFileNhanVienBangMaSP(s)==null)
            {
                return new Bill(CreataCode.createCodeProduct(fileBill), birthday, new Customer(), l, new Staff());
            }
            else if(Customer.xuatFileKhachHangBangMaKH(c) == null)
            {
                return new Bill(CreataCode.createCodeProduct(fileBill), birthday, new Customer(), l, Staff.xuatFileNhanVienBangMaSP(s));
            }
            else if (Staff.xuatFileNhanVienBangMaSP(s) == null)
            {
                return new Bill(CreataCode.createCodeProduct(fileBill), birthday, Customer.xuatFileKhachHangBangMaKH(c), l,new Staff());
            }
            else
            {
                return new Bill(CreataCode.createCodeProduct(fileBill), birthday, Customer.xuatFileKhachHangBangMaKH(c), l, Staff.xuatFileNhanVienBangMaSP(s));
            }
        }
        static Product addProduct()
        {
            double gia;
            int soLuong;
            string name;
            string xuatXu;

            Console.Write("Nhap xuat xu san pham: ");
            xuatXu = Read();

            Console.Write("Nhap ten san pham: ");
            name = Read();

            Console.Write("Nhap gia: ");
            double.TryParse(Read(), out gia);

            Console.Write("Nhap so luong: ");
            int.TryParse(Read(), out soLuong);

            return new Product(CreataCode.createCodeProduct(fileProduct), soLuong, gia, xuatXu, name);
        }
        static Customer addCustomer()
        {
            string sDT;
            string mail;
            GeneralInfo g;

            Console.Write("  -  Nhap SDT khach hang: ");
            sDT = Read();

            Console.Write("  -  Nhap mail khach hang: ");
            mail = Read();

            Console.WriteLine("-  Nhap thong tin chung: ");
            g = addGeneralInfo();

            return new Customer(CreataCode.createCodeStaff(fileStaff), sDT, mail, g);

        }
        static GeneralInfo addGeneralInfo()
        {
            Address dc;
            string name;
            string soCMND;
            DateTime birthday;

            lap:
            try
            {
                Console.Write("  -  Nhap ngay sinh nhan vien[yyyy/MM/dd]: ");
                birthday = Convert.ToDateTime(Read());
            }
            catch (Exception)
            {
                goto lap;
            }

            Console.Write("  -  Nhap ten nhan vien: ");
            name = Read();

            Console.Write("  -  Nhap so CMND: ");
            soCMND = Read();

            Console.WriteLine("-  Nhap dia chi: ");
            dc = addAddress();

            return new GeneralInfo(name, birthday, soCMND, dc);
        }
        static Staff addStaff()
        {
            string sDT;
            string mail;
            GeneralInfo g;

            Console.Write("  -  Nhap SDT nhan vien: ");
            sDT = Read();

            Console.Write("  -  Nhap mail nhan vien: ");
            mail = Read();

            Console.WriteLine("- Nhap thong tin chung");
            g = addGeneralInfo();

            return new Staff(CreataCode.createCodeStaff(fileStaff), sDT, mail, g);
        }
        static Address addAddress()
        {
            string soNha;
            string duong;
            string quan;
            string thanhPho;

            Console.Write("  -  Nhap so nha: ");
            soNha = Read();
             
            Console.Write("  -  Nhap duong: ");
            duong = Read();

            Console.Write("  -  Nhap quan: ");
            quan = Read();

            Console.Write("  -  Nhap thanh pho: ");
            thanhPho = Read();

            return new Address(soNha, duong, quan, thanhPho);
        }
        #endregion

        static string Read()
        {
            string s = Console.ReadLine();

            if (s.Equals("exit"))
            {
                Environment.Exit(0);
            }

            if (s.Equals("clear"))
            {
                Console.Clear();
            }

            return s;
        }
    }
}
