using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Warehouse.ViewModels
{
    public class ExcelExportViewModel
    {
        [Description("Наименование")]
        public string Name { get; set; }

        [Description("Код")]
        public string Code { get; set; }

        [Description("Продажна цена")]
        public decimal SalePrice { get; set; }

        [Description("Цена")]
        public decimal Price { get; set; }

        [Description("Количество")]
        public int Quantity { get; set; }

        [Description("Група")]
        public string GroupName { get; set; }

        [Description("Категория")]
        public string TypeName { get; set; }
    }
}