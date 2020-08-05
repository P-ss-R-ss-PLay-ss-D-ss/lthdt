/**
* Nguyễn Lê Trọng Tiền
* Lớp CD19TT9
* Ngày : 29/7/2020
* class NhapXuatFile
*/

namespace QLDienThoai
{
    interface INhapXuatFile
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

    }
}
