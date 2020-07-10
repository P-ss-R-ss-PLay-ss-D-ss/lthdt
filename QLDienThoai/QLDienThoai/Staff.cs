using System;
using System.Collections.Generic;
using System.Text;

namespace QLDienThoai
{
    class Staff : GeneralInfo
    {
        private string codeStraff = "Unknow";

        public string CodeStraff { get { return codeStraff; } set { if (value!=""&&value!=null) { codeStraff = value; } } }

        public Staff(string codeStraff):base("", "", new Address("", "", "", ""))
        {
            CodeStraff = codeStraff;
        }
        public Staff(string maNV, GeneralInfo thongTinChung) : base(thongTinChung.Name, thongTinChung.SoCMND, thongTinChung.Address)
        {
            CodeStraff = maNV;
        }

        public string nhapFileNhanVien()
        {
            return $"{CodeStraff}+{base.nhapFileThongTinChung()}";
        }

        public static Staff xuatFileNhanVien(string staff)
        {
            string[] s = staff.Split('+');
            GeneralInfo ttc = GeneralInfo.xuatFileThongTinChung(s[1]);
            return new Staff(s[0], ttc);
        }

        public static Staff xuatFileNhanVienBangMaSP(string code)
        {
            string fileNV = @"..\Staff.txt";
            return Staff.xuatFileNhanVien(IOFile.docFileBangMa(code,fileNV));
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
