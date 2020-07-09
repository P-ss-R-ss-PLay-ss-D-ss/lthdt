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
            string file = @"..\Bill.txt";
            Product p1 = new Product("123", 1, 123, "my", "dt1");
            Product p2 = new Product("1123", 1, 123, "my", "dt2");
            Product p3 = new Product("1223", 1, 123, "my", "dt3");
            Product p4 = new Product("1234", 1, 123, "my", "dt4");
            List<Product> l = new List<Product>();
            l.Add(p1);
            l.Add(p2);
            l.Add(p3);
            l.Add(p4);
            Bill bill = new Bill("123", new DateTime(2001, 10, 30), new Customer("1234", new GeneralInfo("nguyentien", "342090200", new Address("025", "thien ho duong", "thu duc", "tphcm"))), l);
            ghiFileDiaChi(file, bill.nhapFileHoaDon());
            //Console.WriteLine(docFile(file));
            //foreach (var k in docFile(file))
            //{
            //    Console.WriteLine(k);
            //}
            docFileBill(docFile(file)[0]);
        }

        #region xử lý file
        static String[] docFile(string file)
        {
            StreamReader sr = new StreamReader(file);

            string[] s = new string[0];
            string s1;
            while ((s1=sr.ReadLine()) != null)
            {
                Array.Resize(ref s, s.Length + 1);
                s[s.Length-1] = s1;
            }

            sr.Close();
            return s;
        }

        static void ghiFileDiaChi(string file, string data)
        {
            StreamWriter sr = new StreamWriter(file);

            sr.Write(data);

            sr.Close();
        }

        static string docFileBill(string data)
        {
            string[] bill = data.Split('-');
            string[] customer = bill[3].Split('+');
            string[] generalInfo = customer[1].Split('.');
            string[] address = generalInfo[2].Split(',');
            string[] products = bill[2].Split('*');
            string[] product;
            foreach (var k in bill)
            {
                Console.WriteLine(k);
            }
            Console.WriteLine();
            foreach (var k in customer)
            {
                Console.WriteLine(k);
            }
            Console.WriteLine();
            foreach (var k in generalInfo)
            {
                Console.WriteLine(k);
            }
            Console.WriteLine();
            foreach (var k in address)
            {
                Console.WriteLine(k);
            }
            Console.WriteLine();
            foreach (var k in products)
            {
                Console.WriteLine(k);
            }
            return "";
        }
        static string[] docFileProducts(string[] products)
        {
            string[] product = new string[0];

            string[] temp;
            for (int i = 0; i < products.Length; i++)
            {
                Array.Resize(ref product, product.Length + 4);
                temp = products[i].Split(',');

            }

            return product.Split(',');
        }
        #endregion
    }
}
