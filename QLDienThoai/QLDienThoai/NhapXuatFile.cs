/**
* Nguyễn Lê Trọng Tiền
* Lớp CD19TT9
* Ngày : 29/7/2020
* class NhapXuatFile
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace QLDienThoai
{
    interface NhapXuatFile
    {
        /// <summary>
        /// Phuong thức ghi vao file
        /// </summary>
        /// <returns></returns>
        string WriteFile();
        /// <summary>
        /// Phuong thuc đọc dữ liệu từ file bằng đường dẫn 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        object GetFile(string path);
        /// <summary>
        /// phương thức đọc dữ liệu từ file bằng mã
        /// </summary>
        /// <param name="iD"></param>
        /// <returns></returns>
        object GetFileByID(string iD);
    }
}
