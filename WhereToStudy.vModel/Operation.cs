using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.vModel
{
    public class Operation
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int PartnerId { get; set; }

        public decimal Amount { get; set; }

        public int OperationTypeId { get; set; }

        public List<OperationType> OperationTypes { get; set; }

        public List<OperationDetail> OperationDetails { get; set; }
    }
}
