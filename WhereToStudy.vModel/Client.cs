using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.vModel
{
    public class Client
    {
        public int Id { get; set; }

        [Display(Name = "Име")]
        public string Name { get; set; }

        [Display(Name = "Булстат")]
        public string Bulstat { get; set; }

        [Display(Name = "Код")]
        public string Code { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Факс")]
        public string Faks { get; set; }

        [Display(Name = "Телефон")]
        public string Phone { get; set; }
    }
}
