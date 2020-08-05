/**
 * Lưu Thị Kiều Oanh
 * Lớp CD19TT9
 * Ngày : 30/7/2020
 */
namespace QLDienThoai
{
    interface IGetID
    {
        /// <summary>
        /// phương thức đọc dữ liệu từ file bằng mã
        /// 30/7/2020
        /// Lưu Thị Kiều Oanh
        /// </summary>
        /// <param name="iD"></param>
        /// <returns></returns>
        object GetFileByID(string iD);
    }
}
