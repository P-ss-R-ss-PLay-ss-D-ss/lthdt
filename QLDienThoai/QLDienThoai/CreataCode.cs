/*
 * Tên: Nguyễn Lê Trọng Tiền
 * ngày: 16/7/2020
 * Mô tả: Tạo ID cho các đối tượng Bill, Customer, Product, Staff
 */
using System;
using System.IO;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace QLDienThoai
{
    class CreateID
    {
        /**/
        public static string createID(string file)
        {
            string result = "";
            Random rd = new Random();

            if (file.Contains("Bill"))
            {
                result = $"hd{checkID(file) + 1:000}";
                while (!IOFile.CheckTrung(result, file))
                {
                    result = $"hd{rd.Next(999) + 1:000}";
                }
            }
            else if (file.Contains("Customer"))
            {
                result = $"kh{checkID(file) + 1:000}";
                while (!IOFile.CheckTrung(result, file))
                {
                    result = $"kh{rd.Next(999) + 1:000}";
                }
            }
            else if (file.Contains("Product"))
            {
                result = $"sp{checkID(file) + 1:000}";
                while (!IOFile.CheckTrung(result, file))
                {
                    result = $"sp{rd.Next(999) + 1:000}";
                }
            }
            else if (file.Contains("Staff"))
            {
                result = $"nv{checkID(file) + 1:000}";
                while (!IOFile.CheckTrung(result, file))
                {
                    result = $"nv{rd.Next(999) + 1:000}";
                }
            }

            return result;
        }
        /**/
        public static int checkID(string file)
        {
            List<string> l = IOFile.docFile(file).ToList<string>();
            return l.Count;
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
