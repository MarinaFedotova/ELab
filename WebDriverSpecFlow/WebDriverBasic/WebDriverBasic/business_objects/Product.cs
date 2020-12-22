using OpenQA.Selenium;
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
            Discontinued = discontinued;
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
        public bool Discontinued { get; set; }

        public override bool Equals(Object obj)
        {
            if (!(obj is Product product)) return false;
            return ProductName == product.ProductName &&
                CategoryName == product.CategoryName &&
                SupplierName == product.SupplierName &&
                UnitPrice == product.UnitPrice &&
                QuantityPerUnit == product.QuantityPerUnit &&
                UnitsInStock == product.UnitsInStock &&
                UnitsOnOrder == product.UnitsOnOrder &&
                ReorderLevel == product.ReorderLevel &&
                Discontinued == product.Discontinued;
        }
        public override int GetHashCode()
        {
            var hashcode = 13;
            hashcode = (hashcode * 7) + ProductName.GetHashCode();
            hashcode = (hashcode * 7) + CategoryName.GetHashCode();
            hashcode = (hashcode * 7) + SupplierName.GetHashCode();
            hashcode = (hashcode * 7) + UnitPrice.GetHashCode();
            hashcode = (hashcode * 7) + QuantityPerUnit.GetHashCode();
            hashcode = (hashcode * 7) + UnitsInStock.GetHashCode();
            hashcode = (hashcode * 7) + UnitsOnOrder.GetHashCode();
            hashcode = (hashcode * 7) + ReorderLevel.GetHashCode();
            hashcode = (hashcode * 7) + Discontinued.GetHashCode();
            return hashcode;
        }
    }
}
