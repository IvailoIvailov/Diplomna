using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse.ViewModels
{
    public class DeliveriesViewModel
    {
        public DateTime? Date { get; set; }
        public int Id { get; set; }

        public List<Warehouse.vModel.Item> Items{ get; set; }
        public Item Item { get; internal set; }
    }
}