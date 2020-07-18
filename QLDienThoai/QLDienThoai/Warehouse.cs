using System;
using System.Collections.Generic;
using System.Text;

namespace QLDienThoai
{
    class Warehouse
    {
        private String productID = "Unknow";
        private int amoust = 1;

        public string ProductID { get { return productID; } set { if (Customer.checkString(value)) { productID = value; } } }
        public int Amoust { get { return amoust; } set { if (value > 1) { amoust = value; } } }

        public Warehouse(string productID, int amoust)
        {
            ProductID = productID;
            Amoust = amoust;
        }

        public Warehouse()
        {
        }

        public virtual string nhapFileSanPham()
        {
            return $"{ProductID}/{Amoust}";
        }
      
        public static Warehouse getWarehouse(string warehouse)
        {
            string[] s = warehouse.Split('/');
            return new Warehouse(s[0], Convert.ToInt32(s[1]) );
        }
       
        public static Warehouse getWarehouseByID(string ID)
        {
            string fileSP = @"..\Warehouse.txt";
            string data;
            if ((data = IOFile.docFileBangMa(ID, fileSP)) != null)
            {
                return Warehouse.getWarehouse(data);
            }
            return null;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
