using Warehouse.vModel;
using Warehouse.vServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Warehouse.ViewModels
{
    public class SaleViewModel
    {
        public List<Item> Items { get; set; }


    }

        public class Item
        {

            public AddEditDeleteService addEditDeleteService = new AddEditDeleteService();
            public int Id { get; set; }

            public int TypeId { get; set; }

            public decimal Price { get; set; }

            public decimal SalePrice { get; set; }

            public int Quantity { get; set; }
        
            public IEnumerable<SelectListItem> ItemsTypeSelectListItems
            {
                get
                {
                    var items = addEditDeleteService.GetItems();
                    return items.ConvertAll(a =>
                    {
                        return new SelectListItem()
                        {
                            Text = a.Name,
                            Value = a.Id.ToString(),
                            Selected = false
                        };
                    });
                }
            }
        }
}