using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.vModel
{
    public class OperationDetail
    {
        public int Id { get; set; }

        public int OperationId { get; set; }

        public int ItemId { get; set; }

        public int Quantity { get; set; }

        public decimal SalePrice { get; set; }

        public decimal RowSum { get; set; }
    }
}
