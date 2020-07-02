using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace QLDienThoai
{
    class List<t>
    {
        private t[] arr = new t[0];
        private int capacity = -1;

        public t[] Arr { get => arr; set => arr = value; }

        public t[] add(t item)
        {
            Array.Resize(ref this.arr, this.arr.Length + 1);
            arr[arr.Length - 1] = item;
            return this.arr;
        }
        public List()
        {

        }
        public List(int capacity)
        {
            Array.Resize(ref this.arr, capacity);
        }
        public List(t[] arr)
        {
            this.arr = arr;
        }
    }
}
