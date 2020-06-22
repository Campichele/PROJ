using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieToGo.ViewModels
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "The name is required")]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The mail is required")]
        [EmailAddress(ErrorMessage = "The mail isn't correct")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Your forget this !")]
        [StringLength(100)]
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Message")]
        public string Message { get; set; }
    }
}
