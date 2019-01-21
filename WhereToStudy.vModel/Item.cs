using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.vModel
{
    public class Item
    { 
        public int Id { get; set; }

        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Display(Name = "Код")]
        public string Code { get; set; }

        [Display(Name = "Продажна цена")]
        public decimal SalePrice { get; set; }

        [Display(Name = "Фиксирана цена")]
        public decimal Price { get; set; }

        [Display(Name = "Количество")]
        public int Quantity { get; set; }

        public int GroupId { get; set; }

        public Groups Group { get; set; }

        public int TypeId { get; set; }

        public Types Type { get; set; }        

        public List<Image> Images { get; set; }

        public Image Image { get; set; }

        public DateTime Date { get; set; }

    }
}
