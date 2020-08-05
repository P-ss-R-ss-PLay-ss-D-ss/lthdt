/**
* Nguyễn Lê Trọng Tiền,Lưu Thị Kiều Oanh
* Lớp CD19TT9
* Ngày : 3/7/2020
* class KhachHang chứa các thông tin như thông tin chung, mã khách hàng, sDT, mail
*/
using System.Text;

namespace QLDienThoai
{
    class KhachHang : ThongTinChung, INhapXuatFile, IGetID
    {
        //fields
        private string maKhachHang;
        private string sDT;
        private string mail;

        /// <summary>
        /// constructor đầy đủ tham số
        /// Ngày: 3/7/2020
        /// </summary>
        /// <param name="maKhachHang"></param>
        /// <param name="thongTinChung"></param>
        /// <param name="thongTinLienHe"></param>
        public KhachHang(string maKhachHang, string sDT, string mail, ThongTinChung thongTinChung) : base(thongTinChung)
        {
            MaKhachHang = maKhachHang;
            SDT = sDT;
            Mail = mail;
        }
        /// <summary>
        ///  Constructor Copy đối tượng
        /// </summary>
        /// <param name="customer"></param>
        public KhachHang(KhachHang customer) : base(customer.HoTen, customer.NgaySinh, customer.SoCMND, customer.DiaChi)
        {
            MaKhachHang = customer.maKhachHang;
            SDT = customer.sDT;
            Mail = customer.Mail;
        }
        /// <summary>
        /// constructor mặc định
        /// </summary>
        public KhachHang() : base()
        {
            maKhachHang = "Unknow";
            sDT = "Unknow";
            mail = "Unknow";
        }

        //properties
        public string MaKhachHang
        {
            get { return maKhachHang; }
            set
            {
                if (checkString(value))
                {
                    maKhachHang = value;
                }
            }
        }
        public string SDT
        {
            get { return sDT; }
            set
            {
                if (checkString(value) && checkSDT(value))
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
                if (checkString(value) && !checkMail(value))
                {
                    mail = value;
                }
            }
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
        /// Ngày: 3/7/2020
        /// </summary>
        /// <returns></returns>
        public override string WriteFile()
        {
            return $"{MaKhachHang}+{SDT}+{Mail}+{base.WriteFile()}";
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
            return new KhachHang(s[0], s[1], s[2], ttc);
        }
        /// <summary>
        /// Đọc dữ liệu từ file bằng mã
        /// Ngày : 3/7/2020
        /// </summary>
        /// <param name="iD"></param>
        /// <returns></returns>
        public virtual object GetFileByID(string iD)
        {
            string data;
            if ((data = IOFile.readFileByID(iD, ChucNang.fileKH)) != null)
            {
                KhachHang kh = new KhachHang();
                return kh.GetFile(data);
            }
            return null;
        }
        /// <summary>
        /// Check mail
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        public static bool checkMail(string mail)
        {
            return checkCharacter(mail) != 1 || mail.Contains(" ");
        }
        /// <summary>
        /// Check ký tự @
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        private static int checkCharacter(string mail)
        {
            int result = 0;
            foreach (var k in mail)
            {
                if (k == '@')
                {
                    result++;
                }
            }
            return result;
        }
        /// <summary>
        /// Check Chuỗi rỗng
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool checkString(string value)
        {
            if (value != null && value != "")
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Kiểm tra số điện thoại
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool checkSDT(string value)
        {
            return value.Length >= 10 && value.Length <= 11;
        }
        /// <summary>
        /// xuất thông tin khách hàng
        /// ngày : 3/7/2020
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("+-------------------------------------------------------------------------------------------------+\n");
            sb.Append($"{"|",-39}{"THONG TIN KHACH HANG",-59}|\n");
            sb.Append("+-------------------------------------------------------------------------------------------------+\n");
            sb.Append($"{"|",-5}{"Ma KH:",-10}{this.MaKhachHang,-83}|\n");
            sb.Append($"{"|",-6}{"- Ho ten:",-15}{this.HoTen,-20}{"- Dia chi:",-11}{this.DiaChi,-46}|\n");
            sb.Append($"{"|",-6}{"- Ngay sinh:",-15}{this.NgaySinh.ToString("dd/MM/yyyy"),-20}{"- SDT:",-11}{this.SDT,-46}|\n");
            sb.Append($"{"|",-6}{"- So CMND:",-15}{this.SoCMND,-20}{"- Email:",-11}{this.Mail,-46}|\n");
            sb.Append("+-------------------------------------------------------------------------------------------------+\n\n");

            return sb.ToString();

        }
        /// <summary>
        /// Phuong thuc huy KhachHang
        /// </summary>
        ~KhachHang() { }
    }
}
