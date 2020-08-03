using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
