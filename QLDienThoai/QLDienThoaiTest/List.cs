using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace QLDienThoai
{
    class List<t>
    {
        private t[] arr = new t[0];

        public t[] Arr { get => arr; set => arr = value; }

        public t[] Add(t item)
        {
            Array.Resize(ref this.arr, this.arr.Length + 1);
            arr[arr.Length - 1] = item;
            return this.arr;
        }
        public t[] Remove(int index)
        {
            t[] arrNew = new t[0];
            for (int i = 0; i < this.arr.Length; i++)
            {
                if (i!=index)
                {
                    Array.Resize(ref arrNew, arrNew.Length + 1);
                    arrNew[arrNew.Length-1] = this.arr[i];
                }
            }
            this.arr = arrNew;
            return this.arr;
        }
        public t GetIndex(int index)
        {
            return this.arr[index];
        }
        public t[] Replace(int index,t item)
        {
            this.arr[index] = item;
            return this.arr;
        }
        public t[] Clear()
        {
            return new t[0];
        }
        
        public List()
        {

        }
        public List(int capacity)
        {
            Array.Resize(ref this.arr, capacity);
        public List(t[] arr)
        {
            this.arr = arr;
        }
    }
}
