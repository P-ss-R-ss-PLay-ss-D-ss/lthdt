/*
 * Tên: Nguyễn Lê Trọng Tiền
 * ngày: 16/7/2020
 * Mô tả: Tạo ID cho các đối tượng Bill, Customer, Product, Staff
 */
using System;
using System.IO;

namespace QLDienThoai
{
    class CreateID
    {
        /**/
        public static string createIDBill(string file)
        {
            return $"HD{checkID(file) + 1:000}";
        }
        /**/
        public static string createIDCustomer(string file)
        {
            return $"KH{checkID(file) + 1:000}";
        }
        /**/
        public static string createIDProduct(string file)
        {
            return $"SP{checkID(file) + 1:000}";
        }
        /**/
        public static string createIDStaff(string file)
        {
            return $"NV{checkID(file) + 1:000}";
        }
        /**/
        public static int checkID(string file)
        {
            StreamReader sr = new StreamReader(file);

            int a = 0;
            while (sr.ReadLine() != null)
            {
                a++;
            }
            sr.Close();

            return a;
        }
        /**/
        //Tạo đường liên kết iD tự động
        public static string createAutoFileCode(string file)
        {

            char[] chTemp = file.ToCharArray();
            Array.Resize(ref chTemp, chTemp.Length + 4);
            for (int i = chTemp.Length - 1; i >= 6; i--)
            {
                chTemp[i] = chTemp[i - 4];
            }
            chTemp[3] = 'C';
            chTemp[4] = 'o';
            chTemp[5] = 'd';
            chTemp[6] = 'e';

            return new string(chTemp);
        }
    }
}
