using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;


namespace WhereToStudy.Model
{
    public class User : IPrincipal
    {
        public int Id { get; set; }

        [Display(Name = "Потребителско име")]
        [Required(ErrorMessageResourceName = "Грешка")]

        public string UserName { get; set; }

        [StringLength(255, ErrorMessage = "Паролата трябва да е минимум 6 символа.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        [Required(ErrorMessageResourceName = "Грешка")]
        public string Password { get; set; }


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
