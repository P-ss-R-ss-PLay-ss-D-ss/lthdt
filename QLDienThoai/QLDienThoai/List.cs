using System;
using System.Collections.Generic;
using System.Text;

namespace QLDienThoai
{
    class List<t>
    {
        private t[] arr;

        public t[] add(t item)
        {
            Array.Resize(ref this.arr, this.arr.Length + 1);
            arr[arr.Length - 1] = item;
            return this.arr;
        }

    }
}
