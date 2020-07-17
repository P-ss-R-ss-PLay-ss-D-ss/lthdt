/**
 * Nguyễn Lê Trọng Tiền
 * Lớp CD19TT9
 * Ngày : 2/7/2020
 * class khách hàng chứa các thông tin như thẻ ATM , thông tin chung,thông tin liên hệ,mã khách hàng
 */

namespace QLDienThoai
{
    class Customer : GeneralInfo
    {
        //fields
        private string codeCustomer = "Unknow";
        private string sDT = "Unknow";
        private string mail = "Unknow";

        /// <summary>
        /// constructor đầy đủ tham số
        /// </summary>
        /// <param name="maKhachHang"></param>
        /// <param name="thongTinChung"></param>
        /// <param name="thongTinLienHe"></param>
        public Customer(string maKhachHang, string sDT, string mail, GeneralInfo thongTinChung) : base(thongTinChung)
        {
            CodeCustomer = maKhachHang;
            SDT = sDT;
            Mail = mail;
        }
        /// <summary>
        ///  Constructor Copy đối tượng
        /// </summary>
        /// <param name="customer"></param>
        public Customer(Customer customer) : base(customer.Name, customer.SoCMND, customer.Address)
        {
            CodeCustomer = customer.codeCustomer;
            SDT = customer.sDT;
            Mail = customer.Mail;
        }
        /// <summary>
        /// constructor mặc định
        /// </summary>
        public Customer() : base()
        {
        }

        //properties
        public string CodeCustomer
        {
            get { return codeCustomer; }
            set
            {
                if (checkString(value))
                {
                    codeCustomer = value;
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
        /// <summary>
        /// form ghi vao file
        /// ngay : 9/7/2020
        /// </summary>
        /// <returns></returns>
        public string writeCustomer()
        {
            return $"{CodeCustomer}+{SDT}+{Mail}+{writeGeneralInfo()}";
        }
        /// <summary>
        /// đọc dữ liệu khách hàng từ file Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static Customer getCustomer(string customer)
        {
            string[] s = customer.Split('+');
            GeneralInfo ttc = GeneralInfo.getGeneralInfo(s[3]);
            return new Customer(s[0], s[1], s[2], ttc);
        }
        /// <summary>
        /// đọc dữ liệu khách hàng từ id khách hàng
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static Customer getCustomerByID(string code)
        {
            string data;
            if ((data = IOFile.docFileBangMa(code, test.fileCustomer)) != null)
            {
                return Customer.getCustomer(data);
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
        /// ngày : 2/7/2020
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }

        ~Customer() { }
    }
}
