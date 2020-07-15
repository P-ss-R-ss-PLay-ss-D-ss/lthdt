using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;

namespace QLDienThoai
{
    class IOFile
    {
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

        public static string Add(string code, string data,  string fileData)
        {
            string fileCode = CreataCode.createAutoFileCode(fileData);

            List<string> fcode = IOFile.docFile(fileCode).ToList();
            List<string> fData = IOFile.docFile(fileData).ToList();

            fcode.Add(code);
            fData.Add(data);

            File.WriteAllLines(fileCode, fcode.ToArray());
            File.WriteAllLines(fileData, fData.ToArray());

            return code;
        }

        public static bool Clear(string file)
        {
            ghiFile(CreataCode.createAutoFileCode(file), "");
            return ghiFile(file, "");
        }
    }
}
