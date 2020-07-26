/**
 * Tên: Lưu Thị Kiều Oanh
 * Ngày: 16/7/2020
 * Mô tả: Viết các chức năng cho chương trình
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

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
            Console.OutputEncoding = Encoding.UTF8;
            home:
            Console.WriteLine("******************************************************************************************");
            Console.WriteLine("1. Nhập kho");
            Console.WriteLine("2. Xuất hoa đơn");
            Console.WriteLine("3. Trở về màn hình chính");

            int menu = 0;
            do
            {
                Console.Write("Nhập lựa chọn: ");
                int.TryParse(Console.ReadLine(), out menu);
            } while (menu != 1 && menu != 2 && menu != 3 && menu != 4);

            switch (menu)
            {
                case 1:
                    int soHangHoa = 0;
                    do
                    {
                        Console.Write("nhập số lượng hàng hoá muốn nhập vào kho: ");
                        int.TryParse(Console.ReadLine(), out soHangHoa);
                    } while (soHangHoa<=0);

                    for (int i = 0; i < soHangHoa; i++)
                    {
                        Console.Write("Nhập hàng hoá thứ [{0}]",i);
                        nhapKho();
                    }
                    break;
                case 2:
                    IOFile.Add(CreateID.createID(fileBill), addBill().nhapFileHoaDon(), fileBill);
                    break;
                case 3:
                    Console.Clear();
                    goto home;
            }

            Read();
            //IOFile.Add(CreateID.createID(fileProduct), addProduct().nhapFileSanPham(), fileProduct);
            //IOFile.Add(CreateID.createID(fileCustomer), addCustomer().writeCustomer(), fileCustomer);
            //IOFile.Add(CreateID.createID(fileStaff), addStaff().writeStaff(), fileStaff);
        }

        #region nhap thong tin
        //Thêm hóa đơn
        static Bill addBill()
        {
            string customer = "";
            string staff;
            int soSP = 0;
            DateTime day;
            LinkedList<Product> listProduct = new LinkedList<Product>();

            lap:
            try
            {
                Console.Write("  -  Nhâp ngày mua[yyyy/MM/dd]: ");
                day = Convert.ToDateTime(Read());
            }
            catch (Exception)
            {
                goto lap;
            }

            Console.WriteLine("1. nhâp khách hàng môi");
            Console.WriteLine("2. nhâp khách hàng cũ");

            int menu = 0;
            do
            {
                Console.Write("Nhâp lưa chọn: ");
                int.TryParse(Console.ReadLine(), out menu);
            } while (menu != 1 && menu != 2);

            switch (menu)
            {
                case 1:
                    customer = IOFile.Add(CreateID.createID(fileCustomer), addCustomer().writeCustomer(), fileCustomer);
                    break;
                case 2:
                    do
                    {
                        Console.Write("  -  Nhâp mã khách hàng: ");
                        customer = Read().ToLower();
                    } while (Customer.getCustomerByID(customer) == null);
                    break;
            }

            do
            {
                Console.Write("  -  Nhap ma nhan vien: ");
                staff = Read().ToLower();
            } while (Staff.getStaffById(staff) == null);

            do
            {
                Console.Write("  -  Nhap so san pham: ");
                int.TryParse(Read(), out soSP);
            } while (soSP <= 0);

            string code;
            int amoust = 0;
            for (int i = 0; i < soSP; i++)
            {
                do
                {
                    Console.Write("-  Nhap ma san pham thu [{0}]: ", i);
                    code = Read().ToLower();
                    do
                    {
                        Console.Write("-  Nhap so luong san pham thu [{0}]: ", i);
                        int.TryParse(Console.ReadLine(), out amoust);
                    } while (amoust <= 0);
                    Product a = Product.getProductByID(code);
                    a.Amoust = amoust;
                    listProduct.AddLast(a);
                } while (code != "" && !IOFile.CheckTrung(code, fileProduct));
            }

            Bill bill = new Bill(CreateID.createID(fileBill), day, Customer.getCustomerByID(customer), listProduct, Staff.getStaffById(staff));
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

            return new Product(CreateID.createID(fileProduct), soLuong, gia, xuatXu, name);
        }
        //Thêm khách hàng
        static Customer addCustomer()
        {
            string sDT;
            string mail;
            GeneralInfo g;

            /*Nhap sdt = 10 hơặc 11 số*/
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

            return new Customer(CreateID.createID(fileCustomer), sDT, mail, g);

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

            return new Staff(CreateID.createID(fileStaff), sDT, mail, g);
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

        #region Nhap hàng hoá
        static void nhapKho()
        {
            string code = "";
            int amount = 0;
            Console.WriteLine("1. nhâp sản phầm môi");
            Console.WriteLine("2. nhâp sản phầm cũ");

            int menu = 0;
            do
            {
                Console.Write("Nhâp lưa chọn: ");
                int.TryParse(Console.ReadLine(), out menu);
            } while (menu != 1 && menu != 2);


            switch (menu)
            {
                case 1:
                    code = IOFile.Add(CreateID.createID(fileProduct), addCustomer().writeCustomer(), fileProduct);
                    break;
                case 2:
                    do
                    {
                        Console.Write("  -  Nhâp mã sản phẩm: ");
                        code = Read().ToLower();
                    } while (Product.getProductByID(code) == null);
                    do
                    {
                        Console.Write("  -  Nhập số lượng: ");
                        int.TryParse(Console.ReadLine(), out amount);
                    } while (amount <= 0);
                    break;
            }
            string[] s = IOFile.docFile(fileProduct);
            Product[] p = new Product[s.Length];
            int line = IOFile.findInCode(code, fileProduct);

            p[line] = Product.getProduct(s[line]);
            p[line].Amoust += amount;
            s[line] = p[line].nhapFileSanPham();

            List<string> fData = s.ToList();

            File.WriteAllLines(fileProduct, fData.ToArray());
        }

        #endregion

        #region Xuất hàng hoá
        static void xuatHangHoa()
        {

        }
        #endregion
    }
}
