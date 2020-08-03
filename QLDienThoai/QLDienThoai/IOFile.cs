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
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static String[] readFile(string file)
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
        public static string readFileByID(string code, string file)
        {
            int line;
            if ((line = findByCode(code, file)) != -1)
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
        /// </summary>
        /// <param name="code"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static int findByCode(string code, string file)
        {
            List<string> fcode = IOFile.readFile(CreateID.createAutoFileCode(file)).ToList();

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
        /// </summary>
        /// <param name="code"></param>
        /// <param name="fileData"></param>
        /// <returns></returns>
        public static string Remove(string code, string fileData)
        {
            string fileCode = CreateID.createAutoFileCode(fileData);

            List<string> fcode = IOFile.readFile(fileCode).ToList();
            List<string> fData = IOFile.readFile(fileData).ToList();

            int line = IOFile.findByCode(code, fileData);

            if (line == -1)
            {
                return "Sai ma!!!";
            }

            fcode.RemoveAt(line);
            fData.RemoveAt(line);

            File.WriteAllLines(fileCode, fcode.ToArray());
            File.WriteAllLines(fileData, fData.ToArray());

            return code;
        }
        /// <summary>
        /// them doi tuong
        /// </summary>
        /// <param name="code"></param>
        /// <param name="data"></param>
        /// <param name="fileData"></param>
        /// <returns></returns>
        public static string Add(string code, INhapXuatFile data, string fileData)
        {
            string fileCode = CreateID.createAutoFileCode(fileData);

            File.AppendAllText(fileCode,code);
            File.AppendAllText(fileData, data.WriteFile());

            Sort(fileData);

            return code;
        }

        /// <summary>
        /// sua doi tuong
        /// </summary>
        /// <param name="code"></param>
        /// <param name="data"></param>
        /// <param name="fileData"></param>
        /// <returns></returns>
        public static string Update(string code, INhapXuatFile data, string fileData)
        {
            string fileCode = CreateID.createAutoFileCode(fileData);

            List<string> fData = IOFile.readFile(fileData).ToList();

            fData[findByCode(code, fileData)] = data.WriteFile();

            File.WriteAllLines(fileData, fData.ToArray());

            return code;
        }

        public static bool Sort(string fileData)
        {
            string fileCode = CreateID.createAutoFileCode(fileData);

            List<string> fcode = IOFile.readFile(fileCode).ToList();
            List<string> fData = IOFile.readFile(fileData).ToList();

            fcode.Sort();
            fData.Sort();

            File.WriteAllLines(fileCode, fcode.ToArray());
            File.WriteAllLines(fileData, fData.ToArray());

            return true;
        }

        public static bool checkIDTrung(string code, string fileData)
        {
            string fileCode = CreateID.createAutoFileCode(fileData);

            List<string> fcode = IOFile.readFile(fileCode).ToList();

            foreach (var k in fcode)
            {
                if (k.Equals(code))
                    return true;
            }
            return false;
        }
    }
}
