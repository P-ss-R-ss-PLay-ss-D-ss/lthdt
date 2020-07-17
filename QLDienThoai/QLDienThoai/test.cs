﻿/**
 * Tên: Lưu Thị Kiều Oanh
 * Ngày: 16/7/2020
 * Mô tả: Viết các chức năng cho chương trình
 */

using System;
using System.Collections.Generic;

namespace QLDienThoai
{
    class test
    {
        //Tạo liên kết đến file 
        public static string fileBill = @"..\Bill.txt";
        public static string fileProduct = @"..\Product.txt";
        public static string fileCustomer = @"..\Customer.txt";
        public static string fileStaff = @"..\Staff.txt";
        static void Main(string[] args)
        {
            //Console.WriteLine(Product.getProductByID("SP004"));\
            Bill b;
            Console.Write("Nhap vao ma hoa don can tim: ");
            string s = Console.ReadLine();
            if ((b = Bill.getBillByID(s)) == null)
            {
                Console.WriteLine("Khong tim thay ma hoa don!!!");
            }
            else
            {
                Console.WriteLine(b.ToString());
            }
            Read();
            
            //IOFile.docFileBangMa()
            //Console.WriteLine(Bill.getCustomer);
            //while (true)
            //{
            //    //IOFile.Add(CreateID.createIDCustomer(fileCustomer), addCustomer().writeCustomer(), fileCustomer);
            //    //IOFile.Add(CreateID.createIDProduct(fileProduct), addProduct().nhapFileSanPham(), fileProduct);
            //    //IOFile.Add(CreateID.createIDStaff(fileStaff), addStaff().writeStaff(), fileStaff);
            //    IOFile.Add(CreateID.createIDBill(fileBill), addBill().nhapFileHoaDon(), fileBill);
            //    Read();

            //}
        }

        #region nhap thong tin
        //Thêm hóa đơn
        static Bill addBill()
        {
            string c;
            string s;
            int soSP = 0;
            DateTime day;
            LinkedList<Product> listProduct = new LinkedList<Product>();

            /**/
            lap:
            try
            {
                Console.Write("  -  Nhap ngay mua[yyyy/MM/dd]: ");
                day = Convert.ToDateTime(Read());
            }
            catch (Exception)
            {
                goto lap;
            }

            /**/
            do
            {
                Console.Write("  -  Nhap ma khach hang: ");
                c = Read();
            } while (Customer.getCustomerByID(c) == null);

            /**/
            do
            {
                Console.Write("  -  Nhap ma nhan vien: ");
                s = Read();
            } while (Staff.getStaffById(s) == null);

            /**/
            do
            {
                Console.Write("  -  Nhap so san pham: ");
                int.TryParse(Read(), out soSP);
            } while (soSP == 0);

            /**/
            string code;
            for (int i = 0; i < soSP; i++)
            {
                code = Read();
                while (code != "" && Product.getProductByID(code) != null)
                {
                    Console.Write("-  Nhap ma san pham thu {0}: ", i);
                    listProduct.AddLast(Product.getProductByID(code));
                }
            }

            /**/
            Bill bill = new Bill(CreateID.createIDBill(fileBill), day, Customer.getCustomerByID(c), listProduct, Staff.getStaffById(s));
            return bill;
        }
        //Thêm sản phẩm
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

            return new Product(CreateID.createIDProduct(fileProduct), soLuong, gia, xuatXu, name);
        }
        //Thêm khách hàng
        static Customer addCustomer()
        {
            string sDT;
            string mail;
            GeneralInfo g;

            /*Nhap sdt = 10 số*/
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

            return new Customer(CreateID.createIDCustomer(fileCustomer), sDT, mail, g);

        }
        //Thêm thông tin chung cho khách hàng và nhân viên
        static GeneralInfo addGeneralInfo()
        {
            Address dc;
            string name;
            string soCMND;
            DateTime birthday;

            lap:
            try
            {
                Console.Write("  -  Nhap ngay sinh [yyyy/MM/dd]: ");
                birthday = Convert.ToDateTime(Read());
            }
            catch (Exception)
            {
                goto lap;
            }

            do
            {
                Console.Write("  -  Nhap ten : ");
                name = Read();
            } while (Customer.checkString(name) == false);

            do
            {
                Console.Write("  -  Nhap so CMND: ");
                soCMND = Read();
            } while (!GeneralInfo.checkSoCMND(soCMND));

            Console.WriteLine("-  Nhap dia chi: ");
            dc = addAddress();

            return new GeneralInfo(name, birthday, soCMND, dc);
        }
        //Thêm nhân viên
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

            return new Staff(CreateID.createIDStaff(fileStaff), sDT, mail, g);
        }
        //Thêm địa chỉ cho thông tin chung
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
            } while (Customer.checkString(soNha) == false);

            do
            {
                Console.Write("  -  Nhap duong: ");
                duong = Read();
            } while (Customer.checkString(duong) == false);

            do
            {
                Console.Write("  -  Nhap quan: ");
                quan = Read();
            } while (Customer.checkString(quan) == false);

            do
            {
                Console.Write("  -  Nhap thanh pho: ");
                thanhPho = Read();
            } while (Customer.checkString(thanhPho) == false);
            return new Address(soNha, duong, quan, thanhPho);
        }

        //Đọc dữ liệu nhập vào
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
