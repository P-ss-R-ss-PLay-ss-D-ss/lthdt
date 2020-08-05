/**
 * Tên: Nguyễn Lê Trọng Tiền
 * ngày: 16/7/2020
 * Mô tả: Tạo ID cho các đối tượng Bill, Customer, Product, Staff
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLDienThoai
{
    class CreateID
    {
        /// <summary>
        /// tạo tự động mã
        /// 25/7/2020
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string CreateIDAuto(string file)
        {
            string result = "";
            Random rd = new Random();

            if (file.Contains("HD"))//file hóa đơn
            {
                result = $"hd{Count(file) + 1:000}";
                while (IOFile.CheckIDTrung(result, file))//Kiểm tra mã có tồn tại chưa???
                {
                    result = $"hd{rd.Next(999) + 1:000}";//Tạo mã ngẫu nhiên
                }
            }
            else if (file.Contains("KH"))//file khách hàng
            {
                result = $"kh{Count(file) + 1:000}";
                while (IOFile.CheckIDTrung(result, file))
                {
                    result = $"kh{rd.Next(999) + 1:000}";
                }
            }
            else if (file.Contains("SP"))//file sản phẩm
            {
                result = $"sp{Count(file) + 1:000}";
                while (IOFile.CheckIDTrung(result, file))
                {
                    result = $"sp{rd.Next(999) + 1:000}";
                }
            }
            else if (file.Contains("NV"))//file nhân viên
            {
                result = $"nv{Count(file) + 1:000}";
                while (IOFile.CheckIDTrung(result, file))
                {
                    result = $"nv{rd.Next(999) + 1:000}";
                }
            }

            return result;
        }
        /// <summary>
        /// đếm số id trong file
        /// 25/7/2020
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static int Count(string file)
        {
            List<string> l = IOFile.ReadFile(file).ToList<string>();
            return l.Count;
        }
        /// <summary>
        /// Tạo đường liên kết iD tự động
        /// 25/7/2020
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string CreateAutoFileCode(string file)
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
