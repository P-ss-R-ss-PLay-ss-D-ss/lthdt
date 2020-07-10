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
            string fileHoaDon = @"..\Bill.txt";
            string fileSanPham = @"..\Product.txt";
            string fileKhachHang = @"..\Customer.txt";
            string fileNhanVien = @"..\Staff.txt";
            Product p1 = new Product(createCodeProduct(fileSanPham), 1, 123, "my", "dt1");
            Product p2 = new Product(createCodeProduct(fileSanPham), 1, 123, "my", "dt2");
            Product p3 = new Product(createCodeProduct(fileSanPham), 1, 123, "my", "dt3");
            Product p4 = new Product(createCodeProduct(fileSanPham), 1, 123, "my", "dt4");
            LinkedList<Product> l = new LinkedList<Product>();
            l.Append(p1);
            l.Append(p2);
            l.Append(p3);
            l.Append(p4);
            Bill bill = new Bill(
                createCodeBill(fileHoaDon),
                new DateTime(2001, 10, 30),
                new Customer
                (
                    createCodeCustomer(fileKhachHang),
                    new GeneralInfo
                    (
                        "nguyentien",
                        "342090200",
                        new Address
                        (
                            "025",
                            "thien ho duong",
                            "thu duc",
                            "tphcm"
                        )
                     )
                    ),
                l,
                new Staff
                (
                    createCodeStaff(fileNhanVien),
                    new GeneralInfo
                    (
                        "nguyentien",
                        "342090200",
                        new Address
                        (
                            "025",
                            "thien ho duong",
                            "thu duc",
                            "tphcm"
                        )
                     )
                ));
            Console.WriteLine(bill);
            //ghiFileDiaChi(file, bill.nhapFileHoaDon());
            //Console.WriteLine(Bill.xuatFileHoaDon(docFile(fileHoaDon)[0]));
        }

        #region create code
        static string createCodeBill(string file)
        {
            return $"HD{chechSoMa(file):000}";
        }
        static string createCodeCustomer(string file)
        {
            return $"KH{chechSoMa(file):000}";
        }
        static string createCodeProduct(string file)
        {
            return $"SP{chechSoMa(file):000}";
        }
        static string createCodeStaff(string file)
        {
            return $"NV{chechSoMa(file):000}";
        }
        static int chechSoMa(string file)
        {
            StreamReader sr = new StreamReader(file);
            int a = 0;
            while (sr.ReadLine() != null)
            {
                a++;
            }
            return a;
        }
        #endregion

        #region xử lý file
        static String[] docFile(string file)
        {
            StreamReader sr = new StreamReader(file);

            string[] s = new string[0];
            string s1;
            while ((s1 = sr.ReadLine()) != null)
            {
                Array.Resize(ref s, s.Length + 1);
                s[s.Length - 1] = s1;
            }

            sr.Close();
            return s;
        }

        static void ghiFileDiaChi(string file, string[] data)
        {
            StreamWriter sr = new StreamWriter(file);

            sr.Write(data);

            sr.Close();
        }
        #endregion

        #region them, xoa, sua ,tim kiem
        static bool Delete(string file,string Code)
        {
            string[] s = docFile(file);
            for (int i = 0; i < s.Length; i++)
            {
                if (Bill.xuatFileHoaDon(s[i]).CodeBill == Code)
                {

                }
            }
        }
        #endregion
    }
}
