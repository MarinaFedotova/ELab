using System;
using System.Collections.Generic;
using System.Text;
using WebDriverBasic.po;

namespace WebDriverBasic.business_objects
{
    class Product
    {
        public Product(string productName, string categoryName, string supplierName, int unitPrice, 
            string quantityPerUnit, int unitsInStock, int unitsOnOrder, int reorderLevel, bool discontinued)
        {
            Index = 0;
            ProductName = productName;
            CategoryName = categoryName;
            SupplierName = supplierName;
            UnitPrice = unitPrice.ToString();
            QuantityPerUnit = quantityPerUnit;
            UnitsInStock = unitsInStock.ToString();
            UnitsOnOrder = unitsOnOrder.ToString();
            ReorderLevel = reorderLevel.ToString();
            Discontinued = discontinued.ToString();
        }

        public int Index { get; set;  }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
        public string UnitPrice { get; set; }
        public string QuantityPerUnit { get; set; }
        public string UnitsInStock { get; set; }
        public string UnitsOnOrder { get; set; }
        public string ReorderLevel { get; set; }
        public string Discontinued { get; set; }


    }
}
