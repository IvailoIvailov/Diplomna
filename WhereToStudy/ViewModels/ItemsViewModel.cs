using Warehouse.vModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse.ViewModels
{
    public class ItemsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Quantity { get; set; }

        public int TypeId { get; set; }

        public List<Item> Books { get; set; }
        
    }
}