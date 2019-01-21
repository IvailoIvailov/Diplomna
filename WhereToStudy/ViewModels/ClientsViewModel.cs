using Warehouse.vModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse.ViewModels
{
    public class ClientsViewModel
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public List<vModel.Item> Items { get; set; }
    }
}