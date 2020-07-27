﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
<<<<<<< HEAD
using System.Reflection.Emit;
=======
>>>>>>> of-tien

namespace QLDienThoai
{
    class IOFile
    {
<<<<<<< HEAD
=======
        /// <summary>
        /// doc file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
>>>>>>> of-tien
        public static String[] docFile(string file)
        {
            string[] s = new string[0];

            StreamReader sr = new StreamReader(file);

            string s1;
            while ((s1 = sr.ReadLine()) != null)
            {
                Array.Resize(ref s, s.Length + 1);
                s[s.Length - 1] = s1;
            }

            sr.Close();
            return s;
        }
<<<<<<< HEAD

=======
        /// <summary>
        /// ghi du lieu vao file
        /// </summary>
        /// <param name="file"></param>
        /// <param name="data"></param>
        /// <returns></returns>
>>>>>>> of-tien
        public static bool ghiFile(string file, string data)
        {
            if (File.Exists(file))
            {
                StreamWriter sr = new StreamWriter(file);

                sr.Write(data);

                sr.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
<<<<<<< HEAD

        public static string docFileBangMa(string code, string file)
        {
            int line;
            if ((line = findInCode(code,file))!=-1)
            {
                return File.ReadLines(file).Skip(line).Take(1).First();
            }
            return null;
        }

        public static int findInCode(string code, string file)
        {
            StreamReader sr = new StreamReader(CreataCode.createAutoFileCode(file));

            int length = File.ReadAllLines(file).Length;
            int result = -1;
            for (int i = 0; i < length; i++)
            {
                if (code == sr.ReadLine())
                {
                    result = i;
                    break;
                }
            }

            sr.Close();
            return result;
        }

        public static string Delete(string code, string fileData)
        {
            string fileCode = CreataCode.createAutoFileCode(fileData);
=======
        /// <summary>
        /// doc doi tuong bang ma
        /// </summary>
        /// <param name="code"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string docFileBangMa(string code, string file)
        {
            int line;
            if ((line = findInCode(code, file)) != -1)
            {
                List<string> fData = IOFile.docFile(file).ToList();

                if (line == -1)
                {
                    return "Sai ma!!!";
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
        public static int findInCode(string code, string file)
        {
            List<string> fcode = IOFile.docFile(CreateID.createAutoFileCode(file)).ToList();

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
        public static string Delete(string code, string fileData)
        {
            string fileCode = CreateID.createAutoFileCode(fileData);
>>>>>>> of-tien

            List<string> fcode = IOFile.docFile(fileCode).ToList();
            List<string> fData = IOFile.docFile(fileData).ToList();

            int line = IOFile.findInCode(code, fileCode);

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
<<<<<<< HEAD

        public static string Add(string code, string data,  string fileData)
        {
            string fileCode = CreataCode.createAutoFileCode(fileData);
=======
        /// <summary>
        /// them doi tuong
        /// </summary>
        /// <param name="code"></param>
        /// <param name="data"></param>
        /// <param name="fileData"></param>
        /// <returns></returns>
        public static string Add(string code, string data, string fileData)
        {
            string fileCode = CreateID.createAutoFileCode(fileData);
>>>>>>> of-tien

            List<string> fcode = IOFile.docFile(fileCode).ToList();
            List<string> fData = IOFile.docFile(fileData).ToList();

            fcode.Add(code);
            fData.Add(data);

            File.WriteAllLines(fileCode, fcode.ToArray());
            File.WriteAllLines(fileData, fData.ToArray());

            return code;
        }
<<<<<<< HEAD

        public static bool Clear(string file)
        {
            ghiFile(CreataCode.createAutoFileCode(file), "");
            return ghiFile(file, "");
        }
=======
        /// <summary>
        /// sua doi tuong
        /// </summary>
        /// <param name="code"></param>
        /// <param name="data"></param>
        /// <param name="fileData"></param>
        /// <returns></returns>
        public static string setInCode(string code, string data, string fileData)
        {
            string fileCode = CreateID.createAutoFileCode(fileData);

            List<string> fcode = IOFile.docFile(fileCode).ToList();
            List<string> fData = IOFile.docFile(fileData).ToList();

            fData[findInCode(code, fileCode)] = data;

            File.WriteAllLines(fileData, fData.ToArray());

            return code;
        }
        /// <summary>
        /// xoa toan bo file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool Clear(string file)
        {
            ghiFile(CreateID.createAutoFileCode(file), "");
            return ghiFile(file, "");
        }

        public static bool Sort(string fileData)
        {
            string fileCode = CreateID.createAutoFileCode(fileData);

            List<string> fcode = IOFile.docFile(fileCode).ToList();
            List<string> fData = IOFile.docFile(fileData).ToList();

            fcode.Sort();
            fData.Sort();

            File.WriteAllLines(fileCode, fcode.ToArray());
            File.WriteAllLines(fileData, fData.ToArray());

            return true;
        }

        public static bool CheckTrung(string code, string fileData)
        {
            string fileCode = CreateID.createAutoFileCode(fileData);

            List<string> fcode = IOFile.docFile(fileCode).ToList();

            foreach (var k in fcode)
            {
                if (k.Equals(code))
                    return true;
            }
            return false;
        }
>>>>>>> of-tien
    }
}
