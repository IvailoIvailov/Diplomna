using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.vModel
{
    public class User : IPrincipal
    {
        public int Id { get; set; }

        [Display(Name = "Потребителско име")]
        //[Required(ErrorMessageResourceName = "Грешка",ErrorMessageResourceType =typeof(String))]
        public string UserName { get; set; }

        [StringLength(255, ErrorMessage = "Паролата трябва да е минимум 6 символа.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        //[Required(ErrorMessageResourceName = "Грешка")]
        public string Password { get; set; }


        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Display(Name = "Презиме")]
        public string SurName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Display(Name = "Пол")]
        public string Gender { get; set; }

        [Display(Name = "Възраст")]
        public int Age { get; set; }

        [Display(Name = "Дата на раждане")]
        public DateTime Date { get; set; }

        [Display(Name = "Имейл")]
        public string Email { get; set; }

        public IIdentity Identity
        {
            get
            {
                return new GenericIdentity(UserName);
            }
        }

        public bool IsInRole(string role)
        {
            return true;
        }

        public bool IsAdmin { get; set; }
    }
}
