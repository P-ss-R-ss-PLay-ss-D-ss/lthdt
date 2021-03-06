﻿/**
* Nguyễn Lê Trọng Tiền,Lưu Thị Kiều Oanh
* Lớp CD19TT9
* Ngày : 2/7/2020
* class DiaChi chứa các thông tin địa chỉ nhà như số nhà đường quận thành phố
*/
namespace QLDienThoai
{
    class DiaChi : INhapXuatFile
    {
        //fields
        private string soNha;
        private string duong;
        private string quan;
        private string thanhPho;
        /// <summary>
        /// Constructor không tham so
        /// 3/7/2020
        /// Lưu Thị Kiều Oanh
        /// </summary>
        public DiaChi()
        {
            soNha = "Unknow";
            duong = "Unknow";
            quan = "Unknow";
            thanhPho = "Unknow";
        }
        /// <summary>
        /// consrtuctor đầy đủ tham số
        /// 3/7/2020
        /// Lưu Thị Kiều Oanh
        /// </summary>
        /// <param name="soNha"></param>
        /// <param name="duong"></param>
        /// <param name="quan"></param>
        /// <param name="thanhPho"></param>
        public DiaChi(string soNha, string duong, string quan, string thanhPho)
        {
            SoNha = soNha;
            Duong = duong;
            Quan = quan;
            ThanhPho = thanhPho;
        }
        //properties
        public string SoNha
        {
            get
            {
                return soNha;
            }
            set
            {
                if (value != null && value != "")
                {
                    soNha = value;
                }
            }
        }
        public string Duong
        {
            get
            {
                return duong;
            }
            set
            {
                if (value != null && value != "")
                {
                    duong = value;
                }
            }
        }
        public string Quan
        {
            get
            {
                return quan;
            }
            set
            {
                if (value != null && value != "")
                {
                    quan = value;
                }
            }
        }
        public string ThanhPho
        {
            get
            {
                return thanhPho;
            }
            set
            {
                if (value != null && value != "")
                {
                    thanhPho = value;
                }
            }
        }
        /// <summary>
        /// Định dạng chuỗi được ghi xuống file
        /// Ngay sửa:1/8/2020
        /// Nguyễn Lê Trọng Tiền
        /// </summary>
        /// <returns></returns>
        public string WriteFile()
        {
            return $"{SoNha},{Duong},{Quan},{ThanhPho}";
        }
        /// <summary>
        /// Lấy dữ liệu từ file
        /// Ngày sửa: 1/8/2020
        /// Nguyễn Lê Trọng Tiền
        /// </summary>
        /// <param name="diaChi"></param>
        /// <returns></returns>
        public object GetFile(string diaChi)
        {
            string[] s = diaChi.Split(',');
            return new DiaChi(s[0], s[1], s[2], s[3]);
        }

        /// <summary>
        /// in địa chỉ
        /// 3/7/2020
        /// Lưu Thị Kiều Oanh
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"so {SoNha}, duong {Duong}, quan {Quan}, TP {ThanhPho}";
        }
    }
}
