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
            return File.ReadLines(file).Skip(IOFile.findInCode(code, createAutoFileCode(file))).Take(1).First();
        }

        public static int findInCode(string code, string file)
        {
            StreamReader sr = new StreamReader(createAutoFileCode(file));

            int length = File.ReadAllLines(file).Length;
            string s1;
            int result = -1;
            for (int i = 0; i < length; i++)
            {
                if (code == (s1 = sr.ReadLine()))
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
            string fileCode = createAutoFileCode(fileData);

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
            string fileCode = createAutoFileCode(fileData);

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
            ghiFile(createAutoFileCode(file), "");
            return ghiFile(file, "");
        }

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
