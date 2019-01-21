using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Warehouse.Enums
{
    public class Enums
    {
        public enum OKS
        {
            Всички = 0,
            [Display(Name = "Бакалавър")]
            Бакалавър = 1,
            [Display(Name = "Магистър")]
            Магистър = 2
        }

        public enum FormOfEducation
        {
            Всички = 0,
            [Display(Name = "Редовна форма")]
            Редовна = 1,
            [Display(Name = "Задочна форма")]
            Задочна = 2
        }

    }
}