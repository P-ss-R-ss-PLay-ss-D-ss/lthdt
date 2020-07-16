using System;
using System.Collections.Generic;
using System.Text;

namespace QLDienThoai
{
    class Staff : GeneralInfo
    {
        //fileds
        private string codeStaff = "Unknow";
        private string sDT = "Unknow";
        private string mail = "Unknow";
        //properties
        public string CodeStaff { get { return codeStaff; } set { if (Customer.checkString(value)) { codeStaff = value; } } }
        public string SDT
        {
            get { return sDT; }
            set
            {
                if (Customer.checkSDT(value)&&Customer.checkString(value))
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
                if (Customer.checkString(value)&&Customer.checkMail(value))
                {
                    mail = value;
                }
            }
        }
        //method
        /// <summary>
        /// constructor day du tham so
        /// </summary>
        /// <param name="maNhanVien"></param>
        /// <param name="sDT"></param>
        /// <param name="mail"></param>
        /// <param name="thongTinChung"></param>
        public Staff(string maNhanVien, string sDT, string mail, GeneralInfo thongTinChung) : base(thongTinChung)
        {
            CodeStaff = maNhanVien;
            SDT = sDT;
            Mail = mail;
        }
        /// <summary>
        /// constructor k tham so
        /// </summary>
        public Staff()
        {
        }
        /// <summary>
        /// form nhap vao file
        /// </summary>
        /// <returns></returns>
        public string writeStaff()
        {
            return $"{CodeStaff}+{SDT}+{Mail}+{writeGeneralInfo()}";
        }
        /// <summary>
        /// doc doi tuong tu file
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
        public static Staff getStaff(string staff)
        {
            string[] s = staff.Split('+');
            GeneralInfo ttc = GeneralInfo.getGeneralInfo(s[3]);
            return new Staff(s[0], s[1], s[2], ttc);
        }
        /// <summary>
        /// doc doi tuong tu file bang ma
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static Staff getStaffById(string code)
        {
            string fileNV = @"..\Staff.txt";
            string data;
            if ((data = IOFile.docFileBangMa(code, fileNV)) != null)
            {
                return Staff.getStaff(data);
            }
            return null;
        }

        public override string ToString()
        {
            return $"{CodeStaff}";
        }
    }
}
