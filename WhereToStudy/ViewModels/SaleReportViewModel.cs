using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse.ViewModels
{
    public class SaleReportViewModel
    {

        public DateTime? Date { get; set; }

        public List<vModel.Item> Items{ get; set; }

        public Item Item { get; set; }

        public int Id { get; set; }
    }
}