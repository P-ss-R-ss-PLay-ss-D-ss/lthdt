﻿/**
 * Tên: Lưu Thị Kiều Oanh, Nguyễn Lê Trọng Tiền
 * Ngày: 16/7/2020
 * Mô tả: Viết các chức năng cho chương trình
 */

using System;
using System.Collections.Generic;
using System.IO;

namespace QLDienThoai
{
    class ChucNang
    {
        //Tạo logo 
        #region logo
        static string FirstLogo()
        {
            string str = "\n\n\n\t      ___       __   __         ___   \n";
            str += "\t|  | |__  |    /  ` /  \\  |\\/| |__     \n";
            str += "\t|/\\| |___ |___ \\__, \\__/  |  | |___   \n\n";
            str += "\t\t    ___  __  \n";
            str += "\t\t     |  /  \\ \n";
            str += "\t\t     |  \\__/";
            return str;
        }
        static string LoGo()
        {
            string str = "\t     _____      ___     _____  \n";
            str += "\t    |_   _|    | __|   |_   _| \n";
            str += "\t      | |      | _|      | |   \n";
            str += "\t     _|_|_    _|_|_     _|_|_  \n";
            str += "\t   _|\"\"\"\"\"| _| \"\"\" |  _|\"\"\"\"\"| \n";
            str += "\t   \"`-0-0-' \"`-0-0-'  \"`-0-0-' \n\n\n";
            return str;
        }
        #endregion
        //phần menu chính
        #region home
        static string Home()
        {
            string str = "";
            str += "+-------------------------------------------------------------------+\n";
            str += $"{"|",-14} __    __    ______   .___  ___.  _______ {"|",13}\n";
            str += $"{"| ",-14}|  |  |  |  /  __  \\  |   \\/   | |   ____|{"|",13}\n";
            str += $"{"| ",-14}|  |__|  | |  |  |  | |  \\  /  | |  |__   {"|",13}\n";
            str += $"{"| ",-14}|   __   | |  |  |  | |  |\\/|  | |   __|  {"|",13}\n";
            str += $"{"| ",-14}|  |  |  | |  `--'  | |  |  |  | |  |____ {"|",13}\n";
            str += $"{"| ",-14}|__|  |__|  \\______/  |__|  |__| |_______|{"|",13}\n";
            str += $"{"| ",-14}                                          {"|",13}\n";
            str += "+-------------------------------------------------------------------+\n";
            str += $"{"| ",-14}                                          {"|",13}\n";
            str += $"{"|",-25}1. Nhap kho{"|",33}\n";
            str += $"{"|",-25}2. Xuat hoa don{"|",29}\n";
            str += $"{"|",-25}3. Xuat thong tin{"|",27}\n";
            str += $"{"|",-25}4. Sua thong tin{"|",28}\n";
            str += $"{"| ",-12}                                          {"|",15}\n";
            str += "+-------------------------------------------------------------------+\n";
            return str;
        }
        #endregion
        //menu phụ
        static string Menu()
        {
            string str = "";
            str += "+---------------------------------------------------------+\n";
            str += $"{"|",-14}  _ __ ___    ___  _ __   _   _ {"|",13}\n";
            str += $"{"|",-14} | '_ ` _ \\  / _ \\| '_ \\ | | | |{"|",13}\n";
            str += $"{"|",-14} | | | | | ||  __/| | | || |_| |{"|",13}\n";
            str += $"{"|",-14} |_| |_| |_| \\___||_| |_| \\__,_|{"|",13}\n";
            str += $"{"|",-14}                                {"|",13}\n";
            str += "+---------------------------------------------------------+\n";
            return str;
        }
        //Tạo liên kết đến file 
        #region file
        public static string fileHD = @".\HD.txt";
        public static string fileSP = @".\SP.txt";
        public static string fileKH = @".\KH.txt";
        public static string fileNV = @".\NV.txt";
        #endregion
        static void Main(string[] args)
        {
            //xuất logo
            #region logo
            //set size cho cửa sổ console
            Console.SetWindowSize(100, 50);
            string home = Home();
            Console.WriteLine(FirstLogo());
            Console.WriteLine();
            Console.WriteLine(LoGo());
            Console.ReadKey();
            Console.Clear();
            #endregion
            #region main
            //set title cho console
            Console.Title = "Quản Lý Bán Hàng";//Tiêu đề cho màn hình console
            home:
            Console.WriteLine();
            Console.WriteLine(home);//Giao diện home menu

            int menu = 0;
            do
            {
                Console.Write(">> ");
                int.TryParse(Console.ReadKey().KeyChar + "", out menu);
                Console.WriteLine();
            } while (menu != 1 && menu != 2 && menu != 3 && menu != 4);

            switch (menu)
            {
                case 1:
                    //nhập hàng hoá vào kho
                    Console.Clear();
                    int soHangHoa = 0;
                    do
                    {
                        Console.WriteLine("=:>>>.>>> \n");
                        Console.Write("- Nhap so luong hang hoa muon nhap vao kho: ");
                        int.TryParse(Read(), out soHangHoa);
                    } while (soHangHoa <= 0);
                    for (int i = 0; i < soHangHoa; i++)
                    {
                        Console.WriteLine("\n - Nhap hang hoa thu [{0}]", i);
                        nhapKho();
                    }
                    Console.Clear();
                    goto home;
                case 2:
                    //xuất hàng hoá ra khỏi kho
                    Console.Clear();
                    xuatHoaDon();
                    Console.Clear();
                    goto home;
                case 3:
                    //xuất thông tin các phần
                    xuatThongTin();
                    goto home;
                case 4:
                    ThemSuaXoa();
                    goto home;
            }
            #endregion
        }

        #region nhap thong tin
        //Thêm hóa đơn
        static HoaDon addBill()
        {
            string customerID = "";
            string staffID;
            int soSP = 0;
            DateTime day = DateTime.Now;
            LinkedList<SanPham> listProduct = new LinkedList<SanPham>();
            KhachHang kh = new KhachHang();
            NhanVien nv = new NhanVien();
            SanPham sp = new SanPham();

            ////nhập ngày mua
            //lap:
            //try
            //{
            //    Console.Write("\n- Nhap ngay mua[yyyy/MM/dd]: ");
            //    day = Convert.ToDateTime(Read());
            //}
            //catch (Exception)
            //{
            //    goto lap;
            //}
            //nhập khách hàng
            Console.WriteLine("1. Nhap khach hang moi");
            Console.WriteLine("2. Nhap khach hang cu");

            int menu = 0;
            do
            {
                Console.Write(">> ");
                int.TryParse(Console.ReadKey().KeyChar + "", out menu);
                Console.WriteLine();
            } while (menu != 1 && menu != 2);

            switch (menu)
            {
                case 1:
                    //nhập khách hàng mới
                    themThongTinKhachHang();
                    kh = addCustomer();
                    customerID = IOFile.Add(kh.MaKhachHang, kh, fileKH);
                    break;
                case 2:
                    //nhập khách hàng đã từng xuất mua tại của hàng
                    do
                    {
                        kh = new KhachHang();
                        Console.Write("- Nhap ma khach hang: ");
                        customerID = Read().ToLower();
                    } while ((kh = (KhachHang)kh.GetFileByID(customerID)) == null);
                    break;
            }

            //nhập nhân viên bán hàng
            do
            {
                nv = new NhanVien();
                Console.Write("- Nhap ma nhan vien: ");
                staffID = Read().ToLower();
            } while ((nv = (NhanVien)nv.GetFileByID(staffID)) == null);

            //nhập sản phẩm mua
            do
            {
                Console.Write("- Nhap so san pham: ");
                int.TryParse(Read(), out soSP);
            } while (soSP <= 0);

            string code;
            int amoust = 0;
            for (int i = 0; i < soSP; i++)
            {
                do
                {
                    //kiểm tra sản phẩm có tồn tại không nếu không nhập lại
                    do
                    {
                        sp = new SanPham();
                        Console.Write(" -  Nhap ma san pham thu [{0}]: ", i);
                        code = Read().ToLower();
                    } while ((sp = (SanPham)sp.GetFileByID(code)) == null);

                    //kiểm tra so lượng có hợp lệ không nếu không nhập lại
                    do
                    {
                        Console.Write(" -  Nhap so luong san pham thu [{0}]: ", i);
                        int.TryParse(Read(), out amoust);
                    } while (amoust <= 0 && amoust > sp.SoLuong);

                    sp.SoLuong = amoust;
                    listProduct.AddLast(sp);
                } while (code != "" && !IOFile.CheckIDTrung(code, fileSP));
            }

            HoaDon bill = new HoaDon(CreateID.CreateIDAuto(fileHD), day, kh, listProduct, nv);
            return bill;
        }

        //Thêm san phẩm
        static SanPham addProduct()
        {
            double gia;
            int soLuong;
            string name;
            string xuatXu;
            //nhập các yêu cầu nhập sai nhập lại

            do
            {
                Console.Write("  - Nhap ten san pham: ");
                name = Read();
            } while (!KhachHang.checkString(name));

            do
            {
                Console.Write("  - Nhap gia: ");
                double.TryParse(Read(), out gia);
            } while (gia == 0);

            do
            {
                Console.Write("  - Nhap xuat xu san pham: ");
                xuatXu = Read();
            } while (!KhachHang.checkString(xuatXu));

            do
            {
                Console.Write("  - Nhap so luong: ");
                int.TryParse(Read(), out soLuong);
            } while (soLuong <= 0);

            return new SanPham(CreateID.CreateIDAuto(fileSP), soLuong, gia, xuatXu, name);
        }
        //Thêm khách hàng
        static KhachHang addCustomer()
        {
            string sDT;
            string mail;
            ThongTinChung g;


            Console.WriteLine("-  Nhap thong tin chung: ");
            g = addGeneralInfo();


            /*Nhap sdt = 10 hơặc 11 số*/
            do
            {
                Console.Write("  -  Nhap SDT khach hang: ");
                sDT = Read();
            } while (!KhachHang.checkSDT(sDT));

            do
            {
                Console.Write("  -  Nhap mail khach hang: ");
                mail = Read();
            } while (KhachHang.checkMail(mail));

            return new KhachHang(CreateID.CreateIDAuto(fileKH), sDT, mail, g);

        }
        //Them thông tin chung cho khách hàng và nhân viên
        static ThongTinChung addGeneralInfo()
        {
            DiaChi dc;
            string name;
            string soCMND;
            DateTime birthday;

            //nhập thông tin nhập sai nhập lại
            do
            {
                Console.Write("  -  Nhap ten : ");
                name = Read();
            } while (!KhachHang.checkString(name));

            do
            {
                Console.Write("  -  Nhap so CMND: ");
                soCMND = Read();
            } while (!ThongTinChung.checkSoCMND(soCMND));

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
            Console.WriteLine("-  Nhap dia chi: ");
            dc = addAddress();

            return new ThongTinChung(name, birthday, soCMND, dc);
        }
        //Thêm nhân viên
        static NhanVien addStaff()
        {
            string sDT;
            string mail;
            ThongTinChung g;
            //nhập thông tin nhân viên nhập ái nhập lại

            Console.WriteLine("- Nhap thong tin chung");
            g = addGeneralInfo();

            do
            {
                Console.Write("  -  Nhap SDT nhan vien: ");
                sDT = Read();
            } while (!KhachHang.checkSDT(sDT));

            do
            {
                Console.Write("  -  Nhap mail nhan vien: ");
                mail = Read();
            } while (KhachHang.checkMail(mail));



            return new NhanVien(CreateID.CreateIDAuto(fileNV), sDT, mail, g);
        }
        //Thêm địa chỉ cho thông tin chung
        static DiaChi addAddress()
        {
            string soNha;
            string duong;
            string quan;
            string thanhPho;

            //nhập thông tin nhập sai nhập lại
            do
            {
                Console.Write("  -  Nhap so nha: ");
                soNha = Read();
            } while (KhachHang.checkString(soNha) == false);

            do
            {
                Console.Write("  -  Nhap duong: ");
                duong = Read();
            } while (KhachHang.checkString(duong) == false);

            do
            {
                Console.Write("  -  Nhap quan: ");
                quan = Read();
            } while (KhachHang.checkString(quan) == false);

            do
            {
                Console.Write("  -  Nhap thanh pho: ");
                thanhPho = Read();
            } while (KhachHang.checkString(thanhPho) == false);
            return new DiaChi(soNha, duong, quan, thanhPho);
        }
        //Ngừng chương trình
        static string Read()
        {
            string s = Console.ReadLine();

            if (s.Equals("exit"))
            {
                Environment.Exit(0);
            }

            return s;
        }
        #endregion

        #region Nhap hàng hoá vào kho
        static void nhapKho()
        {
            string code = "";
            int amount = 0;
            SanPham p = new SanPham();
            //nhập sản phẩm vào kho
            Console.WriteLine("1. Nhap san pham moi");
            Console.WriteLine("2. Nhap san pham cu");

            int menu = 0;
            do
            {
                Console.Write(">> ");
                int.TryParse(Console.ReadKey().KeyChar + "", out menu);
                Console.WriteLine();
            } while (menu != 1 && menu != 2);


            switch (menu)
            {
                case 1:
                    //thêm sản phẩm mới
                    SanPham sp = addProduct();
                    code = IOFile.Add(sp.MaSP, sp, fileSP);
                    Console.Clear();
                    Console.WriteLine((SanPham)p.GetFileByID(code));
                    Console.WriteLine("Press any key to continue . . .");
                    Console.ReadKey();
                    return;
                case 2:
                    //nhập sản phẩm cũ
                    do
                    {
                        Console.Write("  -  Nhap ma san pham: ");
                        code = Read().ToLower();
                    } while (p.GetFileByID(code) == null);
                    do
                    {
                        Console.Write("  -  Nhap so luong: ");
                        int.TryParse(Read(), out amount);
                    } while (amount <= 0);
                    break;
            }
            string[] s = IOFile.ReadFile(fileSP);//đọc file sp
            int line = IOFile.FindByCode(code, fileSP);//vị trí chứa dữ liệu có mã vừa nhập vào

            p = (SanPham)p.GetFile(s[line]);//gán p= sp dòng thứ line 
            p.SoLuong += amount;
            s[line] = p.WriteFile();

            File.WriteAllLines(fileSP, s);

            Console.Clear();
            Console.WriteLine((SanPham)p.GetFile(s[line]));
            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey();
        }

        #endregion

        #region Xuất hóa đơn
        static void xuatHoaDon()
        {
            HoaDon hd = addBill();//thêm hóa đơn

            LinkedList<SanPham> listProduct = hd.DSSP;//danh sách sản phẩm trong hóa đơn

            string[] s = IOFile.ReadFile(fileSP);//đọc file sản phẩm
            SanPham sp = new SanPham();

            for (LinkedListNode<SanPham> i = listProduct.First; i != null; i = i.Next)
            {
                int line = IOFile.FindByCode(i.Value.MaSP, fileSP);

                sp = (SanPham)sp.GetFile(s[line]);
                sp.SoLuong -= i.Value.SoLuong;
                s[line] = sp.WriteFile();
            }

            File.WriteAllLines(fileSP, s);

            IOFile.Add(hd.MaHD, hd, fileHD);

            Console.Clear();
            Console.WriteLine(hd);
            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey();
        }
        #endregion

        #region xuất thông tin

        static void xuatThongTin()
        {
            Console.Clear();
            string menu1 = Menu();
            menu1 += $"{"|",-58}|\n";
            menu1 += $"{"|",-17}1. Xuat toan bo thong tin{"|",17}\n";
            menu1 += $"{"|",-17}2. Xuat mot thong tin{" | ",22}\n";
            menu1 += $"{"|",-17}3. Tro ve man hinh chinh {"|",17}\n";
            menu1 += $"{"|",-58}|\n";
            menu1 += "+---------------------------------------------------------+\n";
            Console.WriteLine(menu1);

            int menu = 0;
            do
            {
                Console.Write(">> ");
                int.TryParse(Console.ReadKey().KeyChar + "", out menu);
                Console.WriteLine();
            } while (menu != 1 && menu != 2 && menu != 3);

            switch (menu)
            {
                case 1:
                    xuatToanBoThongTin();
                    Console.Clear();
                    return;
                case 2:
                    xuatMotThongTin();
                    Read();
                    Console.Clear();
                    return;
                case 3:
                    Console.Clear();
                    return;
            }
        }

        /// <summary>
        /// xuất toàn bộ thông tin có trong csdl
        /// </summary>
        static void xuatToanBoThongTin()
        {
            Console.Clear();
            string menu1 = "";
            menu1 += Menu();
            menu1 += $"{"|",-58}|\n";
            menu1 += $"{"|",-17}1. Xuat thong tin hoa don{"|",17}\n";
            menu1 += $"{"|",-17}2. Xuat thong tin khach hang{" | ",15}\n";
            menu1 += $"{"|",-17}3. Xuat thong tin nhan vien{"|",15}\n";
            menu1 += $"{"|",-17}4. Xuat thong tin san pham{"|",16}\n";
            menu1 += $"{"|",-17}5. Tro ve man hinh chinh {"|",17}\n";
            menu1 += $"{"|",-58}|\n";
            menu1 += "+---------------------------------------------------------+\n";
            Console.WriteLine(menu1);

            int menu = 0;
            do
            {
                Console.Write(">> ");
                int.TryParse(Console.ReadKey().KeyChar + "", out menu);
                Console.WriteLine();
            } while (menu != 1 && menu != 2 && menu != 3 && menu != 4 && menu != 5);

            switch (menu)
            {
                case 1:
                    Console.Clear();
                    foreach (var k in IOFile.ReadFile(fileHD))
                    {
                        HoaDon hd = new HoaDon();
                        Console.WriteLine(hd.GetFile(k));
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                    Console.WriteLine("Press any key to continue . . .");
                    Console.ReadKey();
                    return;
                case 2:
                    Console.Clear();
                    foreach (var k in IOFile.ReadFile(fileKH))
                    {
                        KhachHang kh = new KhachHang();
                        Console.WriteLine(kh.GetFile(k));
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                    Console.WriteLine("Press any key to continue . . .");
                    Console.ReadKey();
                    return;
                case 3:
                    Console.Clear();
                    foreach (var k in IOFile.ReadFile(fileNV))
                    {
                        NhanVien nv = new NhanVien();
                        Console.WriteLine(nv.GetFile(k));
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                    Read();
                    return;
                case 4:
                    Console.Clear();
                    foreach (var k in IOFile.ReadFile(fileSP))
                    {
                        SanPham sp = new SanPham();
                        Console.WriteLine(sp.GetFile(k));
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                    Console.WriteLine("Press any key to continue . . .");
                    Console.ReadKey();
                    return;
                case 5:
                    Console.Clear();
                    return;
            }
        }
        /// <summary>
        /// xuất một thông tin từ mã 
        /// </summary>
        /// <returns></returns>
        static string xuatMotThongTin()
        {
            Console.Clear();
            Console.WriteLine("=:>>>>.>>>>.>>>> \n");
            string id;
            do
            {
                Console.Write("Nhap ma: ");
                id = Read();
            } while (!checkID(id));

            string newId = id.Substring(0, 2);

            if (newId.Equals("sp"))
            {
                Console.Clear();
                SanPham sp = new SanPham();
                sp = (SanPham)sp.GetFileByID(id);

                Console.WriteLine(sp);
                Console.WriteLine("Press any key to continue . . .");
                Console.ReadKey();
                return sp.MaSP;
            }
            if (newId.Equals("nv"))
            {
                Console.Clear();
                NhanVien nv = new NhanVien();
                Console.WriteLine((nv = (NhanVien)nv.GetFileByID(id)));

                Console.WriteLine("Press any key to continue . . .");
                Console.ReadKey();
                return nv.StaffID;
            }
            if (newId.Equals("kh"))
            {
                Console.Clear();
                KhachHang kh = new KhachHang();
                Console.WriteLine((kh = (KhachHang)kh.GetFileByID(id)));

                Console.WriteLine("Press any key to continue . . .");
                Console.ReadKey();
                return kh.MaKhachHang;
            }
            if (newId.Equals("hd"))
            {
                Console.Clear();
                HoaDon hd = new HoaDon();
                Console.WriteLine((hd = (HoaDon)hd.GetFileByID(id)));

                Console.WriteLine("Press any key to continue . . .");
                Console.ReadKey();
                return hd.MaKhachHang;
            }
            return null;
        }
        /// <summary>
        /// kiểm tra id có hợp lệ không
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool checkID(string id)
        {
            id = id.ToLower();
            if (id.Length != 5)
            {
                return false;
            }

            try
            {
                Convert.ToInt32(id.Substring(2, 3));
            }
            catch (Exception)
            {
                return false;
            }

            string newId = id.Substring(0, 2);

            if (newId.Equals("sp"))
            {
                SanPham sp = new SanPham();
                return !((SanPham)sp.GetFileByID(id)).Equals(null);
            }
            if (newId.Equals("nv"))
            {
                NhanVien nv = new NhanVien();
                return !((NhanVien)nv.GetFileByID(id)).Equals(null);
            }
            if (newId.Equals("kh"))
            {
                KhachHang kh = new KhachHang();
                return !((KhachHang)kh.GetFileByID(id)).Equals(null);
            }
            if (newId.Equals("hd"))
            {
                HoaDon hd = new HoaDon();
                return !((HoaDon)hd.GetFileByID(id)).Equals(null);
            }
            return true;
        }

        #endregion

        #region Sửa thong tin
        /// <summary>
        /// thêm sửa xoá
        /// </summary>
        static void ThemSuaXoa()
        {
            Console.Clear();
            string menu1 = "";
            menu1 += Menu();
            menu1 += $"{"|",-58}|\n";
            menu1 += $"{"|",-25}1. Them{"|",27}\n";
            menu1 += $"{"|",-25}2. Sua{" | ",29}\n";
            menu1 += $"{"|",-25}3. Xoa{"|",28}\n";
            menu1 += $"{"|",-25}4. Tro ve {"|",24}\n";
            menu1 += $"{"|",-58}|\n";
            menu1 += "+---------------------------------------------------------+\n";
            Console.WriteLine(menu1);

            int menu = 0;
            do
            {
                Console.Write(">> ");
                int.TryParse(Console.ReadKey().KeyChar + "", out menu);
                Console.WriteLine();
            } while (menu != 1 && menu != 2 && menu != 3 && menu != 4);

            switch (menu)
            {
                case 1:
                    themThongTin();
                    Console.Clear();
                    return;
                case 2:
                    suaThongTin();
                    Console.Clear();
                    return;
                case 3:
                    xoaThongTin();
                    Console.Clear();
                    return;
                case 4:
                    Console.Clear();
                    return;
            }
        }

        #region sua
        /// <summary>
        /// sửa thông tin trong csdl
        /// </summary>
        static void suaThongTin()
        {
            Console.Clear();
            string menu1 = "";
            menu1 += Menu();
            menu1 += $"{"|",-58}|\n";
            menu1 += $"{"|",-17}1. Sua thong tin san pham{"|",17}\n";
            menu1 += $"{"|",-17}2. Sua thong tin nhan vien{" | ",17}\n";
            menu1 += $"{"|",-17}3. Sua thong tin khach hang{"|",15}\n";
            menu1 += $"{"|",-17}4. Tro ve man hinh chinh{"|",18}\n";
            menu1 += $"{"|",-58}|\n";
            menu1 += "+---------------------------------------------------------+\n";
            Console.WriteLine(menu1);

            int menu = 0;
            do
            {
                Console.Write(">> ");
                int.TryParse(Console.ReadKey().KeyChar + "", out menu);
                Console.WriteLine();
            } while (menu != 1 && menu != 2 && menu != 3 && menu != 4);

            switch (menu)
            {
                case 1:
                    suaThongTinSanPham();
                    Console.Clear();
                    return;
                case 2:
                    suaThongTinNhanVien();
                    Console.Clear();
                    return;
                case 3:
                    suaThongTinKhachHang();
                    Console.Clear();
                    return;
                case 4:
                    Console.Clear();
                    return;
            }

        }
        /// <summary>
        /// sửa thông tin sản phẩm trong csdl
        /// </summary>
        static void suaThongTinSanPham()
        {
            string id;
            do
            {
                id = xuatMotThongTin();
            } while (!id.Substring(0, 2).Equals("sp"));
            Console.Clear();
            update:
            SanPham sp = new SanPham();
            sp = (SanPham)sp.GetFileByID(id);
            Console.WriteLine(sp);
            Console.WriteLine("**** CHON PHAN MUON SUA ====>>>>");
            Console.WriteLine("1. Sua ten san pham");
            Console.WriteLine("2. Sua gia san pham");
            Console.WriteLine("3. Sua xuat xu san pham");
            Console.WriteLine("4. Tro ve man hinh chinh");

            int menu = 0;
            do
            {
                Console.Write(">> ");
                int.TryParse(Console.ReadKey().KeyChar + "", out menu);
                Console.WriteLine();
            } while (menu != 1 && menu != 2 && menu != 3 && menu != 4);

            switch (menu)
            {
                case 1:
                    string name = "";
                    do
                    {
                        Console.Write(" - Ten: ");
                        name = Read();
                        Console.WriteLine();
                    } while (!KhachHang.checkString(name));

                    sp.TenSP = name;

                    IOFile.Update(id, sp, fileSP);

                    Console.Clear();
                    goto update;
                case 2:
                    double gia = 0;
                    do
                    {
                        Console.Write(" - Gia: ");
                        double.TryParse(Read(), out gia);
                        Console.WriteLine();
                    } while (gia <= 0);

                    sp.Gia = gia;

                    IOFile.Update(id, sp, fileSP);

                    Console.Clear();
                    goto update;
                case 3:
                    string makeIn = "";
                    do
                    {
                        Console.Write(" - Xuat xu: ");
                        makeIn = Read();
                        Console.WriteLine();
                    } while (!KhachHang.checkString(makeIn));

                    sp.XuatXu = makeIn;

                    IOFile.Update(id, sp, fileSP);

                    Console.Clear();
                    goto update;
                case 4:
                    Console.Clear();
                    return;
            }
        }
        /// <summary>
        /// sửa thông tin nhân viên trogn csdl
        /// </summary>
        static void suaThongTinNhanVien()
        {
            string id;
            do
            {
                id = xuatMotThongTin();
            } while (!id.Substring(0, 2).Equals("nv"));
            Console.Clear();
            update:
            NhanVien nv = new NhanVien();
            nv = (NhanVien)nv.GetFileByID(id);
            Console.WriteLine(nv);
            Console.WriteLine("**** CHON PHAN MUON SUA ====>>>>");
            Console.WriteLine("1. Sua SDT");
            Console.WriteLine("2. Sua Mail");
            Console.WriteLine("3. Sua thong tin chung");
            Console.WriteLine("4. Tro ve man hinh chinh");

            int menu = 0;
            do
            {
                Console.Write(">> ");
                int.TryParse(Console.ReadKey().KeyChar + "", out menu);
                Console.WriteLine();
            } while (menu != 1 && menu != 2 && menu != 3 && menu != 4);

            switch (menu)
            {
                case 1:
                    string sdt = "";
                    do
                    {
                        Console.Write(" - SDT: ");
                        sdt = Read();
                        Console.WriteLine();
                    } while (!KhachHang.checkString(sdt));

                    nv.SDT = sdt;

                    IOFile.Update(id, nv, fileNV);

                    Console.Clear();
                    goto update;
                case 2:
                    String mail = "";
                    do
                    {
                        Console.Write(" - Mail: ");
                        mail = Read();
                        Console.WriteLine();
                    } while (!KhachHang.checkMail(mail));

                    nv.Mail = mail;

                    IOFile.Update(id, nv, fileNV);

                    Console.Clear();
                    goto update;
                case 3:
                    ThongTinChung info = new ThongTinChung();
                    do
                    {
                        Console.WriteLine(" - Thong tin chung: ");
                        info = addGeneralInfo();
                        Console.WriteLine();
                    } while (info.Equals(null));

                    nv.GeneralInfo = info;

                    IOFile.Update(id, nv, fileNV);

                    Console.Clear();
                    goto update;
                case 4:
                    Console.Clear();
                    return;
            }
        }
        /// <summary>
        /// sửa thông tin sản phẩm trong csdl
        /// </summary>
        static void suaThongTinKhachHang()
        {
            string id;
            do
            {
                id = xuatMotThongTin();
            } while (!id.Substring(0, 2).Equals("kh"));
            Console.Clear();
            update:
            KhachHang kh = new KhachHang();
            kh = (KhachHang)kh.GetFileByID(id);
            Console.WriteLine(kh);
            Console.WriteLine("**** CHON PHAN MUON SUA ====>>>>");
            Console.WriteLine("1. Sua SDT");
            Console.WriteLine("2. Sua Mail");
            Console.WriteLine("3. Sua thong tin chung");
            Console.WriteLine("4. Tro ve man hinh chinh");

            int menu = 0;
            do
            {
                Console.Write(">> ");
                int.TryParse(Console.ReadKey().KeyChar + "", out menu);
                Console.WriteLine();
            } while (menu != 1 && menu != 2 && menu != 3 && menu != 4);

            switch (menu)
            {
                case 1:
                    string sdt = "";
                    do
                    {
                        Console.Write(" - SDT: ");
                        sdt = Read();
                        Console.WriteLine();
                    } while (!KhachHang.checkString(sdt));

                    kh.SDT = sdt;

                    IOFile.Update(id, kh, fileKH);

                    Console.Clear();
                    goto update;
                case 2:
                    String mail = "";
                    do
                    {
                        Console.Write(" - Mail: ");
                        mail = Read();
                        Console.WriteLine();
                    } while (KhachHang.checkMail(mail));

                    kh.Mail = mail;

                    IOFile.Update(id, kh, fileKH);

                    Console.Clear();
                    goto update;
                case 3:
                    ThongTinChung info = new ThongTinChung();
                    do
                    {
                        Console.WriteLine(" - Thong tin chung: ");
                        info = addGeneralInfo();
                        Console.WriteLine();
                    } while (info.Equals(null));

                    kh.GeneralInfo = info;

                    IOFile.Update(id, kh, fileKH);

                    Console.Clear();
                    goto update;
                case 4:
                    Console.Clear();
                    return;
            }
        }
        #endregion

        #region Chức năng Thêm trong menu
        /// <summary>
        /// thêm thông tin vào file
        /// </summary>
        static void themThongTin()
        {
            Console.Clear();
            string menu1 = "";
            menu1 += Menu();
            menu1 += $"{"|",-58}|\n";
            menu1 += $"{"|",-17}1. Them thong tin nhan vien{"|",15}\n";
            menu1 += $"{"|",-17}2. Them thong tin khach hang{" | ",15}\n";
            menu1 += $"{"|",-17}3. Tro ve man hinh chinh{"|",18}\n";
            menu1 += $"{"|",-58}|\n";
            menu1 += "+---------------------------------------------------------+\n";
            Console.WriteLine(menu1);

            int menu = 0;
            do
            {
                Console.Write(">> ");
                int.TryParse(Console.ReadKey().KeyChar + "", out menu);
                Console.WriteLine();
            } while (menu != 1 && menu != 2 && menu != 3);

            switch (menu)
            {

                case 1:
                    themThongTinNhanVien();
                    Console.Clear();
                    return;
                case 2:
                    themThongTinKhachHang();
                    Console.Clear();
                    return;
                case 3:
                    Console.Clear();
                    return;
            }
        }
        /// <summary>
        /// thêm thông tin nhân viên vào csdl
        /// </summary>
        /// <returns></returns>
        static string themThongTinNhanVien()
        {
            NhanVien a = addStaff();


            Console.Clear();
            Console.WriteLine(a);
            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey();
            return IOFile.Add(a.StaffID, a, fileNV);
        }
        /// <summary>
        /// thêm thông tin khách hàng vào csdl
        /// </summary>
        /// <returns></returns>
        static string themThongTinKhachHang()
        {
            KhachHang a = addCustomer();

            Console.Clear();
            Console.WriteLine(a);
            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey();
            return IOFile.Add(a.MaKhachHang, a, fileKH);

        }

        #endregion

        #region Xoá
        /// <summary>
        /// xoá thông tin khỏi csdl
        /// </summary>
        static void xoaThongTin()
        {
            Console.Clear();
            string menu1 = "";
            menu1 += Menu();
            menu1 += $"{"|",-58}|\n";
            menu1 += $"{"|",-17}1. Xoa thong tin san pham{"|",17}\n";
            menu1 += $"{"|",-17}2. Xoa thong tin nhan vien{" | ",17}\n";
            menu1 += $"{"|",-17}3. Xoa thong tin khach hang{"|",15}\n";
            menu1 += $"{"|",-17}4. Tro ve man hinh chinh{"|",18}\n";
            menu1 += $"{"|",-58}|\n";
            menu1 += "+---------------------------------------------------------+\n";
            Console.WriteLine(menu1);

            int menu = 0;
            do
            {
                Console.Write(">> ");
                int.TryParse(Console.ReadKey().KeyChar + "", out menu);
                Console.WriteLine();
            } while (menu != 1 && menu != 2 && menu != 3 && menu != 4);

            switch (menu)
            {
                case 1:
                    xoaThongTinSanPham();
                    Console.Clear();
                    return;
                case 2:
                    xoaThongTinNhanVien();
                    Console.Clear();
                    return;
                case 3:
                    xoaThongTinKhachHang();
                    Console.Clear();
                    return;
                case 4:
                    Console.Clear();
                    return;
            }
        }
        /// <summary>
        /// xoá thông tin sản phẩm khỏi csdl
        /// </summary>
        static void xoaThongTinSanPham()
        {
            string id;
            do
            {
                id = xuatMotThongTin();
            } while (!id.Substring(0, 2).Equals("sp"));
            Select(id, fileSP);
        }
        /// <summary>
        /// xoá thông tin nhân viên khỏi csdl
        /// </summary>
        static void xoaThongTinNhanVien()
        {
            string id;
            do
            {
                id = xuatMotThongTin();
            } while (!id.Substring(0, 2).Equals("nv"));
            Select(id, fileNV);
        }
        /// <summary>
        /// xoá thông tin khách hàng khỏi csdl
        /// </summary>
        static void xoaThongTinKhachHang()
        {
            string id;
            do
            {
                id = xuatMotThongTin();
            } while (!id.Substring(0, 2).Equals("kh"));
            Select(id, fileKH);
        }
        /// <summary>
        /// bảng chọn
        /// </summary>
        /// <param name="id"></param>
        /// <param name="file"></param>
        static void Select(string id, string file)
        {
            lap:
            Console.Clear();
            Console.WriteLine("yes/no");
            string select = Read();
            if (select.Equals("yes"))
            {
                if (IOFile.Remove(id, file) != null)
                {
                    Console.WriteLine("Xoa thanh cong");
                    Console.WriteLine("Press any key to continue . . .");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Xoa khong thanh cong");
                    Console.WriteLine("Press any key to continue . . .");
                    Console.ReadKey();
                }
            }
            else if (select.Equals("no"))
            {
                return;
            }
            else
            {
                goto lap;
            }
        }

        #endregion

        #endregion

    }
}
