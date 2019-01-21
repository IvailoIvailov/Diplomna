using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Warehouse.ViewModels
{
    public class EmployeeViewModel
    {
        public string Name { get; set; }
        public List<Phone> Phones { get { return _phones; } }
        private List<Phone> _phones = new List<Phone>();
    }
    public class Phone
    {
        public enum Types
        {
            Business,
            Cell,
            Home
        }

        [Required]
        public Types Type { get; set; }

        [Required]
        [Phone]
        public string Number { get; set; }

        public IEnumerable<SelectListItem> ItemsTypeSelectListItems
        {
            get
            {
                foreach (Types type in Enum.GetValues(typeof(Types)))
                {
                    SelectListItem selectListItem = new SelectListItem();
                    selectListItem.Text = type.ToString();
                    selectListItem.Value = type.ToString();
                    selectListItem.Selected = Type == type;
                    yield return selectListItem;
                }
            }
        }
    }
}