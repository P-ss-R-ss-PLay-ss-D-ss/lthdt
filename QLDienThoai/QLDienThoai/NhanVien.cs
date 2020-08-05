/**
* Nguyễn Lê Trọng Tiền,Lưu Thị Kiều Oanh
* Lớp CD19TT9
* Ngày : 2/7/2020
* class NhanVien
*/
using System.Text;

namespace QLDienThoai
{
    class NhanVien : ThongTinChung, INhapXuatFile, IGetID
    {
        //fileds
        private string staffID;
        private string sDT;
        private string mail;
        //properties
        public string StaffID
        {
            get
            {
                return staffID;
            }
            set
            {
                if (KhachHang.checkString(value))
                {
                    staffID = value;
                }
            }
        }
        public string SDT
        {
            get { return sDT; }
            set
            {
                if (KhachHang.checkSDT(value) && KhachHang.checkString(value))
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
                if (KhachHang.checkString(value) && !KhachHang.checkMail(value))
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
        public NhanVien(string maNhanVien, string sDT, string mail, ThongTinChung thongTinChung) : base(thongTinChung)
        {
            StaffID = maNhanVien;
            SDT = sDT;
            Mail = mail;
        }
        /// <summary>
        /// constructor k tham so
        /// </summary>
        public NhanVien()
        {
            staffID = "Unknow";
            sDT = "Unknow";
            mail = "Unknow";
        }
        //Cập nhật thông tin dễ dàng hơn
        public ThongTinChung GeneralInfo
        {
            get { return new ThongTinChung(base.HoTen, base.NgaySinh, base.SoCMND, base.DiaChi); }
            set
            {
                this.HoTen = value.HoTen;
                this.NgaySinh = value.NgaySinh;
                this.SoCMND = value.SoCMND;
                this.DiaChi = value.DiaChi;
            }
        }
        /// <summary>
        /// Định dạng chuỗi được in ra file
        /// Ngày: 2/7/2020
        /// </summary>
        /// <returns></returns>
        public override string WriteFile()
        {
            return $"{StaffID}+{SDT}+{Mail}+{base.WriteFile()}";
        }
        /// <summary>
        /// Đọc dữ liệu từ file
        /// Ngày : 3/7/2020
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public override object GetFile(string filePath)
        {
            string[] s = filePath.Split('+');
            ThongTinChung ttc = new ThongTinChung();
            ttc = (ThongTinChung)ttc.GetFile(s[3]);
            return new NhanVien(s[0], s[1], s[2], ttc);
        }
        /// <summary>
        /// Đọc dữ liệu từ file bằng mã
        /// Ngày : 3/7/2020
        /// </summary>
        /// <param name="iD"></param>
        /// <returns></returns>
        public object GetFileByID(string iD)
        {
            string data;
            if ((data = IOFile.readFileByID(iD, ChucNang.fileNV)) != null)
            {
                NhanVien nv = new NhanVien();
                return nv.GetFile(data);
            }
            return null;
        }
        /// <summary>
        /// xuất thông tin nhân viên
        /// ngày : 3/7/2020
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("+-------------------------------------------------------------------------------------------------+\n");
            sb.Append($"{"|",-39}{"THONG TIN NHAN VIEN",-59}|\n");
            sb.Append("+-------------------------------------------------------------------------------------------------+\n");
            sb.Append($"{"|",-5}{"Ma NV:",-10}{this.StaffID,-83}|\n");
            sb.Append($"{"|",-8}{"- Ho ten:",-15}{this.HoTen,-20}{"- Dia chi:",-11}{this.DiaChi,-44}|\n");
            sb.Append($"{"|",-8}{"- Ngay sinh:",-15}{this.NgaySinh.ToString("dd/MM/yyyy"),-20}{"- SDT:",-11}{this.SDT,-44}|\n");
            sb.Append($"{"|",-8}{"- So CMND:",-15}{this.SoCMND,-20}{"- Email:",-11}{this.Mail,-44}|\n");
            sb.Append("+-------------------------------------------------------------------------------------------------+\n");

            return sb.ToString();

        }

        /// <summary>
        /// Phuong thuc huy 
        /// </summary>
        ~NhanVien() { }
    }
}
