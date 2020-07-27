<<<<<<< HEAD
﻿using System;
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
=======
﻿namespace QLDienThoai
{
    class Staff : GeneralInfo
    {
        //fileds
        private string codeStaff = "Unknow";
        private string sDT = "Unknow";
        private string mail = "Unknow";
        //properties
        public string CodeStaff
        {
            get
            {
                return codeStaff;
            }
            set
            {
                if (Customer.checkString(value))
                {
                    codeStaff = value;
                }
            }
        }
>>>>>>> of-tien
        public string SDT
        {
            get { return sDT; }
            set
            {
<<<<<<< HEAD
                if (value != null && value != "")
=======
                if (Customer.checkSDT(value) && Customer.checkString(value))
>>>>>>> of-tien
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
<<<<<<< HEAD
                if (value != null && value != "" )
=======
                if (Customer.checkString(value) && !Customer.checkMail(value))
>>>>>>> of-tien
                {
                    mail = value;
                }
            }
        }
<<<<<<< HEAD
=======
        //method
        /// <summary>
        /// constructor day du tham so
        /// </summary>
        /// <param name="maNhanVien"></param>
        /// <param name="sDT"></param>
        /// <param name="mail"></param>
        /// <param name="thongTinChung"></param>
>>>>>>> of-tien
        public Staff(string maNhanVien, string sDT, string mail, GeneralInfo thongTinChung) : base(thongTinChung)
        {
            CodeStaff = maNhanVien;
            SDT = sDT;
            Mail = mail;
        }
<<<<<<< HEAD
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
=======
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
>>>>>>> of-tien
        {
            string fileNV = @"..\Staff.txt";
            string data;
            if ((data = IOFile.docFileBangMa(code, fileNV)) != null)
            {
<<<<<<< HEAD
                return Staff.xuatFileNhanVien(data);
=======
                return Staff.getStaff(data);
>>>>>>> of-tien
            }
            return null;
        }

        public override string ToString()
        {
            return $"{CodeStaff}";
        }
    }
}
