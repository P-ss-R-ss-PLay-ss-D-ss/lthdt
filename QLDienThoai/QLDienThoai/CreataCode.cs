using System;
using System.IO;

namespace QLDienThoai
{
    class CreataCode
    {
        public static string createCodeBill(string file)
        {
            return $"HD{chechSoMa(file) + 1:000}";
        }

        public static string createCodeCustomer(string file)
        {
            return $"KH{chechSoMa(file) + 1:000}";
        }

        public static string createCodeProduct(string file)
        {
            return $"SP{chechSoMa(file) + 1:000}";
        }

        public static string createCodeStaff(string file)
        {
            return $"NV{chechSoMa(file) + 1:000}";
        }

        public static int chechSoMa(string file)
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
