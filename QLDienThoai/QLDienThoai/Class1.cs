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
            string file = @"D:\git\lthdt\QLDienThoai\QLDienThoai\Customer.txt";
            Console.WriteLine(docFile(file));
        }

        #region xử lý file
        static String docFile(string file)
        {
            StreamReader sr = new StreamReader(file);

            string s = sr.ReadLine();

            return s;
        }

        static void ghiFileDiaChi(string file, string data)
        {
            FileStream f = new FileStream(file, FileMode.Open);
            StreamWriter sr = new StreamWriter(f, Encoding.UTF8);

            sr.Write(data);

            sr.Close();
            f.Close();
        }
        #endregion
    }
}
