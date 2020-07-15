using System;
using System.Collections.Generic;
using System.Text;

namespace QLDienThoai
{
    class Staff : GeneralInfo
    {
        private string codeStaff = "Unknow";
        private string sDT = "Unknow";
        private string mail = "Unknow";
        public string CodeStaff { get { return codeStaff; } set { if (value != "" && value != null) { codeStaff = value; } } }
        public string SDT
        {
            get { return sDT; }
            set
            {
                if (value != null && value != "")
                {
                    sDT = value;
                }
            }
        }
        public string Mail
        {
            get { return mail; }
            set
            {
                if (value != null && value != "" )
                {
                    mail = value;
                }
            }
        }
        public Staff(string maNhanVien, string sDT, string mail, GeneralInfo thongTinChung) : base(thongTinChung)
        {
            CodeStaff = maNhanVien;
            SDT = sDT;
            Mail = mail;
        }
        public Staff()
        {
        }

        public string nhapFileNhanVien()
        {
            return $"{CodeStaff}+{SDT}+{Mail}+{nhapFileThongTinChung()}";
        }

        public static Staff xuatFileNhanVien(string staff)
        {
            string[] s = staff.Split('+');
            GeneralInfo ttc = GeneralInfo.xuatFileThongTinChung(s[3]);
            return new Staff(s[0], s[1], s[2], ttc);
        }

        public static Staff xuatFileNhanVienBangMaSP(string code)
        {
            string fileNV = @"..\Staff.txt";
            string data;
            if ((data = IOFile.docFileBangMa(code, fileNV)) != null)
            {
                return Staff.xuatFileNhanVien(data);
            }
            return null;
        }

        public override string ToString()
        {
            return $"{CodeStaff}";
        }
    }
}
