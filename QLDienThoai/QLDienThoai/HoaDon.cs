/**
 * Nguyễn Lê Trọng Tiền,Lưu Thị Kiều Oanh
 * Lớp CD19TT9
 * Ngày : 3/7/2020
 * class HoaDon lưu thông tin khách hàng mua hàng và danh sach sản phẩm
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDienThoai
{
    class HoaDon : KhachHang, INhapXuatFile, IGetID
    {
        //fields
        private LinkedList<SanPham> dSSP;
        private string maHD;
        private DateTime ngayBan;
        private NhanVien nhanVien;
        /// <summary>
        /// constructor mặc định
        /// ngày : 3/7/2020
        /// Lưu thị kiều oanh
        /// </summary>
        public HoaDon()
        {
            dSSP = new LinkedList<SanPham>();
            maHD = "Unknow";
            ngayBan = new DateTime(1900, 1, 1);
            nhanVien = new NhanVien();
        }
        /// <summary>
        /// constructor đầy đủ tham số
        /// ngày : 3/7/2020
        /// Lưu thị kiều oanh
        /// </summary>
        /// <param name="maHoaDon"></param>
        /// <param name="ngayMua"></param>
        /// <param name="khachHang"></param>
        /// <param name="dSSP"></param>
        public HoaDon(string maHoaDon, DateTime ngayMua, KhachHang khachHang, LinkedList<SanPham> dSSP, NhanVien nhanVien) : base(khachHang)
        {
            MaHD = maHoaDon;
            NgayBan = ngayMua;
            DSSP = dSSP;
            NhanVien = nhanVien;
        }
        //properties
        public string MaHD
        {
            get
            {
                return maHD;
            }
            set
            {
                if (value != null && value != "")
                {
                    maHD = value;
                }
            }
        }
        public DateTime NgayBan
        {
            get
            {
                return ngayBan;
            }
            set
            {
                if (value != new DateTime() && value != null)
                {
                    ngayBan = value;
                }
            }
        }
        internal LinkedList<SanPham> DSSP
        {
            get
            {
                return dSSP;
            }
            set
            {
                if (value != null)
                {
                    dSSP = value;
                }
            }
        }
        internal NhanVien NhanVien { get { return nhanVien; } set { if (value != null) { nhanVien = value; } } }
        /// <summary>
        /// Định dạng chuỗi được in ra file
        /// Ngày: 3/7/2020
        /// Nguyễn Lê Trọng Tiền
        /// </summary>
        /// <returns></returns>
        public override string WriteFile()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{maHD}-{NgayBan.ToString("yyyy/MM/dd")}-");

            for (int i = 0; i < DSSP.Count; i++)
            {
                if (i == dSSP.Count - 1)
                {
                    sb.Append($"{DSSP.ElementAt(i).MaSP}/{DSSP.ElementAt(i).SoLuong}");
                    break;
                }
                sb.Append($"{DSSP.ElementAt(i).MaSP}/{DSSP.ElementAt(i).SoLuong}*");
            }

            sb.Append($"-{base.MaKhachHang}");

            sb.Append("-" + NhanVien.StaffID);

            return sb.ToString();
        }
        /// <summary>
        /// Đọc dữ liệu từ file
        /// Ngày : 3/7/2020
        /// Nguyễn Lê Trọng Tiền
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public override object GetFile(string filePath)
        {
            string[] bills = filePath.Split('-');

            LinkedList<SanPham> l = new LinkedList<SanPham>();
            SanPham sp = new SanPham();
            string[] product = bills[2].Split('*');
            for (int i = 0; i < product.Length; i++)
            {
                SanPham s = (SanPham)sp.GetFileByID(product[i].Split('/')[0]);
                s.SoLuong = Convert.ToInt32(product[i].Split('/')[1]);
                l.AddLast(s);
            }

            KhachHang kh = new KhachHang();
            kh = (KhachHang)kh.GetFileByID(bills[3]);

            NhanVien nv = new NhanVien();
            nv = (NhanVien)nv.GetFileByID(bills[4]);

            return new HoaDon(bills[0], Convert.ToDateTime(bills[1]), kh, l, nv);
        }
        /// <summary>
        /// Đọc dữ liệu từ file bằng mã
        /// Ngày : 3/7/2020
        /// Nguyễn Lê Trọng Tiền
        /// </summary>
        /// <param name="iD"></param>
        /// <returns></returns>
        public override object GetFileByID(string iD)
        {
            string data;
            if ((data = IOFile.ReadFileByID(iD, ChucNang.fileHD)) != null)
            {
                HoaDon hd = new HoaDon();
                return hd.GetFile(data);
            }
            return null;
        }
        /// <summary>
        /// tính tổng tiền trong một hóa đơn
        /// ngày : 3/7/2020
        /// Lưu thị kiều oanh
        /// </summary>
        /// <returns></returns>
        public double getTongTien()
        {
            double result = 0;
            LinkedListNode<SanPham> a = dSSP.First;
            do
            {
                result += a.Value.Gia * a.Value.SoLuong;
            } while ((a = a.Next) != null);

            return result;
        }
        /// <summary>
        /// in hoá đơn
        /// ngày : 3/7/2020
        /// Lưu thị kiều oanh
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.Append("+-------------------------------------------------------------------------------------------------+\n");
            s.Append($"{"|",-41}{"HOA DON BAN HANG",-57}|\n");
            s.Append("+-------------------------------------------------------------------------------------------------+\n");
            s.Append($"{"|   Ma Hoa Don",-20}:{MaHD,-27}{"|   Ma khach hang:",-25}{this.MaKhachHang,-25}|\n");
            s.Append($"{"|   Ten nhan vien",-20}:{NhanVien.HoTen,-27}{"|   Ten khach hang:",-25}{this.HoTen,-25}|\n");
            s.Append($"{"|",-48}{"|   SDT:",-25}{this.SDT,-25}|\n");
            s.Append("+-------------------------------------------------------------------------------------------------+\n");
            s.Append($"{"|    STT",-18}{"Ma san pham",-23}{"Ten san pham",-27}{"So luong",-17}{"Gia",-13}|\n");

            LinkedListNode<SanPham> a = dSSP.First;
            int i = 1;
            while (a != null)
            {
                s.Append($"{"|",-5}{i++,-13}{a.Value.MaSP,-23}{a.Value.TenSP,-27}{a.Value.SoLuong,-17}{a.Value.Gia,-13}|\n");
                a = a.Next;
            }
            s.Append("+-------------------------------------------------------------------------------------------------+\n");
            s.Append($"{"|",-10}{"Tong:",-9}{getTongTien() + "VND",-79}|\n");
            s.Append("+-------------------------------------------------------------------------------------------------+\n");

            return s.ToString();
        }
        /// <summary>
        /// phuong thuc huy
        /// ngày : 3/7/2020
        /// Lưu thị kiều oanh
        /// </summary>
        ~HoaDon() { }
    }
}
