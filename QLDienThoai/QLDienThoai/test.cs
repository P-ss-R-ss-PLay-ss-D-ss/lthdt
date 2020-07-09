using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QLDienThoai
{
    class test
    {
        static void Main(string[] args)
        {
            string file = @"D:\git\lthdt\QLDienThoai\QLDienThoai\Bill.txt";
            Bill bill = new Bill("123", new DateTime(2001, 10, 30), new Customer("1234", new GeneralInfo("nguyentien", "342090200", new Address("025", "thien ho duong", "thu duc", "tphcm"))), new List<Product>(3));
            //ghiFileDiaChi(file, bill.nhapFileHoaDon());
            Console.WriteLine(docFile(file));
        }

        #region xử lý file
        static String docFile(string file)
        {
            StreamReader sr = new StreamReader(file);

            string s = sr.ReadLine();

            sr.Close();
            return s;
        }

        static void ghiFileDiaChi(string file, string data)
        {
            StreamWriter sr = new StreamWriter(file);

            sr.Write(data);

            sr.Close();
        }
        #endregion
    }
}
