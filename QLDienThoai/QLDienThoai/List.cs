/**
 * Nguyễn Lê Trọng Tiền
 * Lớp CD19TT9
 * Ngày : 2/7/2020
 * thư viện thêm sửa xoá thông tin 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace QLDienThoai
{
    class List<t>
    {
        //fields
        private t[] arr = new t[0];
        //properties
        public t[] Arr { get => arr; set => arr = value; }
        /// <summary>
        /// thêm thông tin vào danh sách
        /// ngày : 2/7/2020
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public t[] Add(t item)
        {
            Array.Resize(ref this.arr, this.arr.Length + 1);
            arr[arr.Length - 1] = item;
            return this.arr;
        }
        /// <summary>
        /// xoá thông tin khỏi danh sách
        /// ngày : 2/7/2020
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public t[] Remove(int index)
        {
            t[] arrNew = new t[0];
            for (int i = 0; i < this.arr.Length; i++)
            {
                if (i != index)
                {
                    Array.Resize(ref arrNew, arrNew.Length + 1);
                    arrNew[arrNew.Length - 1] = this.arr[i];
                }
            }
            this.arr = arrNew;
            return this.arr;
        }
        /// <summary>
        /// lấy thông tin tại vị trí thứ index
        /// ngày : 2/7/2020
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public t GetIndex(int index)
        {
            return this.arr[index];
        }
        /// <summary>
        /// sữa thông tin tại vị trí thứ index
        /// ngày : 2/7/2020
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public t[] Replace(int index, t item)
        {
            this.arr[index] = item;
            return this.arr;
        }
        /// <summary>
        /// xoá toàn bộ thông tin trong danh sách
        /// ngày : 2/7/2020
        /// </summary>
        /// <returns></returns>
        public t[] Clear()
        {
            return new t[0];
        }
        /// <summary>
        /// constructor mặc định
        /// ngày : 2/7/2020
        /// </summary>
        public List()
        {

        }
        /// <summary>
        /// constructor có 1 tham số
        /// ngày : 2/7/2020
        /// </summary>
        /// <param name="arr"></param>
        public List(t[] arr)
        {
            this.arr = arr;
        }
    }
}
