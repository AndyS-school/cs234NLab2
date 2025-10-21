using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Xml.Linq;

namespace MMABooksBusinessClasses
{
    public class Product
    {
        //constructors
        public Product() { }

        public Product(string id, string description, Nullable<double> unitPrice, Nullable<int> onHandQuantity)
        {
            ProductCode = id;
            Description = description;
            UnitPrice = unitPrice;
            OnHandQuantity = onHandQuantity;
        }
        //instance variables
        private string productCode;
        private string description;
        private Nullable<double> unitPrice;
        private Nullable<int> onHandQuantity;

        //get/set

        public string ProductCode {
            get
            {
                return productCode;
            }
            set
            {
                if (value.Trim().Length == 4)
                    productCode = value;
                else
                    throw new ArgumentOutOfRangeException("product code must be 4 characters");
            }
        }
        public string Description {
            get
            {
                return description;
            }
            set
            {
                if ((value.Trim().Length > 0) && (value.Length <= 50))
                    description = value;
                else
                    throw new ArgumentOutOfRangeException("description must be between 1 and 50 characters");
            }
        }
        public Nullable<double> UnitPrice {
            get
            {
                return unitPrice;
            }
            set
            {
                if (value >= 0)
                    unitPrice = value;
                else
                    throw new ArgumentOutOfRangeException("unit price must be 0 or more");
            }
        }
        public Nullable<int> OnHandQuantity {
            get
            {
                return onHandQuantity;
            }
            set
            {
                if (value >= 0)
                    onHandQuantity = value;
                else
                    throw new ArgumentOutOfRangeException("on hand quantity must be 0 or more.");
            }
        }

        //override
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
