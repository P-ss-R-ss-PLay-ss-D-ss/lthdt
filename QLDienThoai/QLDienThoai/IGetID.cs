namespace QLDienThoai
{
    interface IGetID
    {
        /// <summary>
        /// phương thức đọc dữ liệu từ file bằng mã
        /// </summary>
        /// <param name="iD"></param>
        /// <returns></returns>
        object GetFileByID(string iD);
    }
}
