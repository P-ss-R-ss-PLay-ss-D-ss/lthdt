using System;
using System.Collections;
using System.IO;
using System.Text;

namespace QLDienThoai
{
    class Class1
    {
        static void Main(string[] args)
        {
            Address ad = new Address("", "", "", "");
            FileStream f = new FileStream(@"D:\git\lthdt\QLDienThoai\QLDienThoai\Customer.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
            StreamWriter sw = new StreamWriter(f);
            Console.WriteLine(ad);
            sw.Write(ad.ToString());
            ArrayList a = new ArrayList();
            //a.Capacity = 
        }
    }
}
