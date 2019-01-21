using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.vModel;

namespace Warehouse.vModel
{
    public class OrderModel
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public Int16 Qty { get; set; }
        public double Price { get; set; }
        public double TotalAmount { get; set; }
    }
}
