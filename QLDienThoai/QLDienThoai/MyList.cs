/**
 * Nguyễn Lê Trọng Tiền
 * Lớp CD19TT9
 * Ngày : 2/7/2020
 * thư viện thêm sửa xoá thông tin 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace QLDienThoai
{
    class MyList
    {
        //fields
        private int size = 0;
        private int capacity = 0;
        private object[] arr = new object[0];
        //indexer
        public object this[int index]
        {
            get
            {
                string thongbao = "vuot ngoai vung nho";
                if (index < 0 && index >= capacity)
                    throw new Exception(thongbao);
                return arr[index];
            }
            set
            {
                string thongbao = "vuot ngoai vung nho";
                if (index < 0 && index >= capacity)
                    throw new Exception(thongbao);
                arr[index] = value;
            }
        }
        //properties
        public int Size { get => size; }
        public int Capacity
        {
            get => capacity;
            set
            {
                string thongBao = "capacity khong duoc nho hon gia tri mang hien tai";
                if (value < size)
                    throw new Exception(thongBao);
                if (value == size)
                    return;
                if (value > 0)
                {
                    capacity = value;
                    object[] arrTemp = new object[capacity];
                    if (size > 0)
                        Array.Copy(arr, arrTemp, size);
                    arr = arrTemp;
                }
                else
                {
                    capacity = 10;
                    arr = new object[capacity];
                }
            }
        }
        /// <summary>
        /// thêm thông tin vào danh sách
        /// ngày : 2/7/2020
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void Add(object item)
        {
            if (!IsFull())
            {
                arr[size] = item;
                size++;
            }
            else
            {
                Capacity = Capacity + 1;
                arr[size] = item;
                size++;
            }
        }

        /// <summary>
        /// kiểm tra danh sách đã đầy chưa
        /// ngày : 3/7/2020
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            return size == capacity;
        }

        /// <summary>
        /// xoá thông tin khỏi danh sách
        /// ngày : 2/7/2020
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool RemoveAt(int index)
        {
            bool result = false;
            object[] arrNew = new object[0];
            for (int i = 0; i < this.arr.Length; i++)
            {
                if (i != index)
                {
                    Array.Resize(ref arrNew, arrNew.Length + 1);
                    arrNew[arrNew.Length - 1] = this.arr[i];
                    result = true;
                }
            }
            this.arr = arrNew;
            return result;
        }

        /// <summary>
        /// chèn thông tin vào danh sách
        /// ngày : 3/7/2020
        /// </summary>
        /// <param name="position"></param>
        /// <param name="data"></param>
        public void Insert(int position, object data)
        {
            if (position >= 0 && position <= size)
            {
                if (!IsFull())
                {
                    for (int i = size; i > position; i--)
                    {
                        arr[i] = arr[i - 1];
                    }
                    arr[position] = data;
                    size++;
                }
                else
                {
                    Capacity++;
                    for (int i = size; i > position; i--)
                    {
                        arr[i] = arr[i - 1];
                    }
                    arr[position] = data;
                    size++;
                }
            }
            else if (position > size && position < capacity)
                Replace(position, data);
            else throw new InvalidOperationException();
        }

        /// <summary>
        /// lấy giá trị tại vị trí thú index 
        /// ngày : 3/7/2020
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(object value)
        {
            return Array.IndexOf(arr, value);
        }

        /// <summary>
        /// sữa thông tin tại vị trí thứ index
        /// ngày : 2/7/2020
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public object[] Replace(int index, object item)
        {
            this.arr[index] = item;
            return this.arr;
        }

        /// <summary>
        /// kt trong danh sách có chứa phần tử hay k
        /// ngày : 3/7/2020
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Content(object value)
        {
            for (int i = 0; i < size; i++)
            {
                if (arr[i] == value)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// xoá thông tin tại giá trị nhập vào
        /// ngày : 3/7/2020
        /// </summary>
        /// <param name="value"></param>
        public bool Remove(object value)
        {
            bool result = false;
            int index = IndexOf(value);
            if (index < 0)
                return result;
            return RemoveAt(index);
        }

        /// <summary>
        /// kiểm tra có phải là danh sách rỗng hay k
        /// ngày : 3/7/2020
        /// </summary>
        /// <returns></returns>
        public bool IsEmple()
        {
            return size == 0;
        }

        /// <summary>
        /// xoá tất cả phần tử có giá trị nhập vào
        /// ngày : 3/7/2020
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool RemoveAll(object value)
        {
            bool result = false;
            while (Remove(value)==false)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// in danh sách ra màn hinh
        /// ngày : 3/7/2020
        /// </summary>
        /// <returns></returns>
        public String PrintList()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                sb.Append(arr[i] + "\t");
            }
            return sb.ToString();
        }

        /// <summary>
        /// trả danh sách về kiểu mảng
        /// có ván đè
        /// ngày : 3/7/2020
        /// </summary>
        /// <returns></returns>
        //public object[] ToArray()
        //{
        //    return arr;
        //}
        public int LastIndexOf(object value)
        {
            return Array.LastIndexOf(arr, value);
        }

        /// <summary>
        /// xoá toàn bộ thông tin trong danh sách
        /// ngày : 2/7/2020
        /// </summary>
        /// <returns></returns>
        public void Clear()
        {
            if (size > 0)
            {
                Array.Resize(ref arr, 0);
                size = 0;
            }
        }

        /// <summary>
        /// constructor mặc định
        /// ngày : 2/7/2020
        /// </summary>
        public MyList()
        {

        }

        /// <summary>
        /// constructor có 1 tham số
        /// ngày : 2/7/2020
        /// </summary>
        /// <param name="arr"></param>
        public MyList(int capacity)
        {
            arr = new object[capacity];
            Capacity = capacity;
        }
    }
}
