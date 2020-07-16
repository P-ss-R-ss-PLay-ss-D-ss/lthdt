using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

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
            //IOFile.Add(CreataCode.createCodeBill(fileBill), addBill().nhapFileHoaDon(), fileBill);
            do
            {
                Read();
                IOFile.Add(CreataCode.createCodeProduct(fileProduct), addProduct().nhapFileSanPham(), fileProduct);
            } while (true);
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

            do
            {
                Console.Write("  -  Nhap ma khach hang: ");
                c = Read();
            } while (Customer.xuatFileKhachHangBangMaKH(c) == null);

            do
            {
                Console.Write("  -  Nhap ma nhan vien: ");
                s = Read();
            } while (Staff.xuatFileNhanVienBangMaSP(s) == null);

            do
            {
                Console.Write("  -  Nhap so san pham: ");
                int.TryParse(Read(), out soSP);
            } while (soSP == 0);

            string code;
            for (int i = 0; i < soSP; i++)
            {
                Console.Write("-  Nhap ma san pham thu {0}: ", i);
                if ((code = Read()) != "" && Product.xuatFileSanPhamBangMaSP(code) != null)
                {
                    l.AddLast(Product.xuatFileSanPhamBangMaSP(code));
                }
            }

            return new Bill(CreataCode.createCodeProduct(fileBill), birthday, Customer.xuatFileKhachHangBangMaKH(c), l, Staff.xuatFileNhanVienBangMaSP(s));
        }
        static Product addProduct()
        {
            double gia;
            int soLuong;
            string name;
            string xuatXu;

            do
            {
                Console.Write("Nhap xuat xu san pham: ");
                xuatXu = Read();
            } while (!Customer.checkString(xuatXu));

            do
            {
                Console.Write("Nhap ten san pham: ");
                name = Read();
            } while (!Customer.checkString(name));

            do
            {
                Console.Write("Nhap gia: ");
                double.TryParse(Read(), out gia);
            } while (gia == 0);

            Console.Write("Nhap so luong: ");
            int.TryParse(Read(), out soLuong);

            return new Product(CreataCode.createCodeProduct(fileProduct), soLuong, gia, xuatXu, name);
        }
        static Customer addCustomer()
        {
            string sDT;
            string mail;
            GeneralInfo g;

            do
            {
                Console.Write("  -  Nhap SDT khach hang: ");
                sDT = Read();
            } while (!Customer.checkSDT(sDT));

            do
            {
                Console.Write("  -  Nhap mail khach hang: ");
                mail = Read();
            } while (Customer.checkMail(mail));

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

            do
            {
                Console.Write("  -  Nhap ten nhan vien: ");
                name = Read();
            } while (Customer.checkString(name));

            do
            {
                Console.Write("  -  Nhap so CMND: ");
                soCMND = Read();
            } while (GeneralInfo.checkSoCMND(soCMND));

            Console.WriteLine("-  Nhap dia chi: ");
            dc = addAddress();

            return new GeneralInfo(name, birthday, soCMND, dc);
        }
        static Staff addStaff()
        {
            string sDT;
            string mail;
            GeneralInfo g;

            do
            {
                Console.Write("  -  Nhap SDT nhan vien: ");
                sDT = Read();
            } while (!Customer.checkSDT(sDT));

            do
            {
                Console.Write("  -  Nhap mail nhan vien: ");
                mail = Read();
            } while (Customer.checkMail(mail));
           

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

            do
            {
                Console.Write("  -  Nhap so nha: ");
                soNha = Read();
            } while (Customer.checkString(soNha));
            
            do
            {
                Console.Write("  -  Nhap duong: ");
                duong = Read();
            } while (Customer.checkString(duong));

            do
            {
                Console.Write("  -  Nhap quan: ");
                quan = Read();
            } while (Customer.checkString(quan));
           
            do
            {
                Console.Write("  -  Nhap thanh pho: ");
                thanhPho = Read();
            } while (Customer.checkString(thanhPho));
            return new Address(soNha, duong, quan, thanhPho);
        }
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
        #endregion
    }
}
