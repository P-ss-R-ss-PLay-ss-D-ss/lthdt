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

            if (file.Contains("HD"))//file hóa đơn
            {
                result = $"hd{checkID(file) + 1:000}";
                while (IOFile.checkIDTrung(result, file))//Kiểm tra mã có tồn tại chưa???
                {
                    result = $"hd{rd.Next(999) + 1:000}";//Tạo mã ngẫu nhiên
                }
            }
            else if (file.Contains("KH"))//file khách hàng
            {
                result = $"kh{checkID(file) + 1:000}";
                while (IOFile.checkIDTrung(result, file))
                {
                    result = $"kh{rd.Next(999) + 1:000}";
                }
            }
            else if (file.Contains("SP"))//file sản phẩm
            {
                result = $"sp{checkID(file) + 1:000}";
                while (IOFile.checkIDTrung(result, file))
                {
                    result = $"sp{rd.Next(999) + 1:000}";
                }
            }
            else if (file.Contains("NV"))//file nhân viên
            {
                result = $"nv{checkID(file) + 1:000}";
                while (IOFile.checkIDTrung(result, file))
                {
                    result = $"nv{rd.Next(999) + 1:000}";
                }
            }

            return result;
        }
        /**/
        public static int checkID(string file)
        {
            List<string> l = IOFile.readFile(file).ToList<string>();
            return l.Count;
        }
        /**/
        //Tạo đường liên kết iD tự động
        public static string createAutoFileCode(string file)
        {
            char[] chTemp = file.ToCharArray();
            Array.Resize(ref chTemp, chTemp.Length + 3);

            for (int i = chTemp.Length - 1; i >= 5; i--)
            {
                chTemp[i] = chTemp[i - 3];
            }
            chTemp[2] = 'I';
            chTemp[3] = 'D';
            chTemp[4] = '_';

            return new string(chTemp);
        }
    }
}
