using QLDienThoai;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace dttest
{
    class readfile
    {
        static void Main(string[] args)
        {
            string file = @"D:\git\lthdt\QLDienThoai\QLDienThoai\Customer.txt";
            Address a = new Address("025", "thien ho duong", "thu duc", "tphcm");
            a.ghiFileDiaChi(file);

            Console.ReadLine();
        }
        
    }
}
