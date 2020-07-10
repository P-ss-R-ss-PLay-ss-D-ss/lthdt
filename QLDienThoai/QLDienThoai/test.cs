using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace QLDienThoai
{
    class test
    {
        static void Main(string[] args)
        {
            string fileBill = @"..\Bill.txt";
            string fileProduct = @"..\Product.txt";
            string fileCustomer = @"..\Customer.txt";
            string fileStaff = @"..\Staff.txt";
            Product p = new Product(createCodeProduct(fileProduct), 1, 123, "my", "dt1");
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
            Console.WriteLine(IOFile.Clear(fileBill));
        }

        #region create code
        static string createCodeBill(string file)
        {
            return $"HD{chechSoMa(file) + 1:000}";
        }
        static string createCodeCustomer(string file)
        {
            return $"KH{chechSoMa(file) + 1:000}";
        }
        static string createCodeProduct(string file)
        {
            return $"SP{chechSoMa(file) + 1:000}";
        }
        static string createCodeStaff(string file)
        {
            return $"NV{chechSoMa(file) + 1:000}";
        }
        static int chechSoMa(string file)
        {
            StreamReader sr = new StreamReader(file);
            int a = 0;
            while (sr.ReadLine() != null)
            {
                a++;
            }
            sr.Close();
            return a;
        }
        #endregion

        #region nhap thong tin
        static Bill addBill()
        {

        }
        static Address addProduct()
        {

        }

        static Address addCustomer()
        {

        }
        static Address addGeneralInfo()
        {

        }
        static Address addStaff()
        {

        }
        static Address addAddress()
        {
            string soNha;
            string duong;
            string quan;
            string thanhPho;

            Console.Write("-  Nhap so nha: ");
            soNha = Read();

            Console.Write("-  Nhap duong: ");
            duong = Read();

            Console.Write("-  Nhap quan: ");
            quan = Read();

            Console.Write("-  Nhap thanh pho: ");
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
