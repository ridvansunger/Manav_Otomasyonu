using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manav_Otomasyonu.Entities
{
    public class Product
    {
        //select ProductId,ProductName,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,Discontinued from Products
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public bool Discontinued { get; set; }
    }
}
