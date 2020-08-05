/**
 * Nguyễn Lê Trọng Tiền
 * Lớp CD19TT9
 * Ngày : 5/7/2020
 * class IOFile dùng để thao tác với file như đọc,ghi,tìm,sửa,xóa file
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace QLDienThoai
{
    class IOFile
    {
        /// <summary>
        /// doc file
        /// 25/7/2020
        /// Nguyễn Lê Trọng Tiền
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static String[] ReadFile(string file)
        {
            string[] s = new string[0];

            if (File.Exists(file))
            {
                StreamReader sr = new StreamReader(file);

                string s1;
                while ((s1 = sr.ReadLine()) != null)
                {
                    Array.Resize(ref s, s.Length + 1);
                    s[s.Length - 1] = s1;
                }

                sr.Close();
            }
            else
            {
                File.Create(file);
            }

            return s;
        }
        /// <summary>
        /// doc doi tuong bang ma
        /// </summary>
        /// <param name="code"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string ReadFileByID(string code, string file)
        {
            int line;
            if ((line = FindByCode(code, file)) != -1)
            {
                List<string> fData = File.ReadAllLines(file).ToList();

                if (line == -1)
                {
                    return null;
                }

                return fData[line];
            }
            return null;
        }
        /// <summary>
        /// tin doi tuong bang ma
        /// 25/7/2020
        /// Nguyễn Lê Trọng Tiền
        /// </summary>
        /// <param name="code"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static int FindByCode(string code, string file)
        {
            List<string> fcode = IOFile.ReadFile(CreateID.CreateAutoFileCode(file)).ToList();

            for (int i = 0; i < fcode.Count; i++)
            {
                if (code.Equals(fcode[i]))
                {
                    return i;
                }
            }

            return -1;
        }
        /// <summary>
        /// xoa doi tuong bang ma
        /// 25/7/2020
        /// Nguyễn Lê Trọng Tiền
        /// </summary>
        /// <param name="code"></param>
        /// <param name="fileData"></param>
        /// <returns></returns>
        public static string Remove(string code, string fileData)
        {
            string fileCode = CreateID.CreateAutoFileCode(fileData);

            List<string> fcode = IOFile.ReadFile(fileCode).ToList();
            List<string> fData = IOFile.ReadFile(fileData).ToList();

            int line = IOFile.FindByCode(code, fileData);

            if (line == -1)
            {
                return null;
            }

            fcode.RemoveAt(line);
            fData.RemoveAt(line);

            File.WriteAllLines(fileCode, fcode.ToArray());
            File.WriteAllLines(fileData, fData.ToArray());

            return code;
        }
        /// <summary>
        /// them doi tuong
        /// 25/7/2020
        /// Nguyễn Lê Trọng Tiền
        /// </summary>
        /// <param name="code"></param>
        /// <param name="data"></param>
        /// <param name="fileData"></param>
        /// <returns></returns>
        public static string Add(string code, INhapXuatFile data, string fileData)
        {
            string fileCode = CreateID.CreateAutoFileCode(fileData);

            File.AppendAllLines(fileCode, new string[] { code });
            File.AppendAllLines(fileData, new string[] { data.WriteFile() });

            Sort(fileData);

            return code;
        }

        /// <summary>
        /// sua doi tuong
        /// 25/7/2020
        /// Nguyễn Lê Trọng Tiền
        /// </summary>
        /// <param name="code"></param>
        /// <param name="data"></param>
        /// <param name="fileData"></param>
        /// <returns></returns>
        public static string Update(string code, INhapXuatFile data, string fileData)
        {
            string fileCode = CreateID.CreateAutoFileCode(fileData);

            List<string> fData = IOFile.ReadFile(fileData).ToList();

            fData[FindByCode(code, fileData)] = data.WriteFile();

            File.WriteAllLines(fileData, fData.ToArray());

            return code;
        }
        /// <summary>
        /// sắp xếp trong file
        /// 25/7/2020
        /// Nguyễn Lê Trọng Tiền
        /// </summary>
        /// <param name="fileData"></param>
        /// <returns></returns>
        public static bool Sort(string fileData)
        {
            string fileCode = CreateID.CreateAutoFileCode(fileData);

            List<string> fcode = IOFile.ReadFile(fileCode).ToList();
            List<string> fData = IOFile.ReadFile(fileData).ToList();

            fcode.Sort();
            fData.Sort();

            File.WriteAllLines(fileCode, fcode.ToArray());
            File.WriteAllLines(fileData, fData.ToArray());

            return true;
        }
        /// <summary>
        /// kiểm tra id trùng
        /// 25/7/2020
        /// Nguyễn Lê Trọng Tiền
        /// </summary>
        /// <param name="code"></param>
        /// <param name="fileData"></param>
        /// <returns></returns>
        public static bool CheckIDTrung(string code, string fileData)
        {
            string fileCode = CreateID.CreateAutoFileCode(fileData);

            List<string> fcode = IOFile.ReadFile(fileCode).ToList();

            foreach (var k in fcode)
            {
                if (k.Equals(code))
                    return true;
            }
            return false;
        }
    }
}
