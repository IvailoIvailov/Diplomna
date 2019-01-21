using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse.ViewModels
{
    public class ItemViewModel
    {
        public int Id { get; set; }

        public List<vModel.Item> Items{ get; set; }
    }
}