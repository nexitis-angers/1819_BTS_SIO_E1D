using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyHome.Web.Models.Register
{
    public class RegisterViewModel
    {
        [Display(Name ="Prénom")] // Le libellé qui sera affiché 
        [Required(), StringLength(50)] // Le prénom est obligatoire, sa longueur ne doit pas dépasser 50 caractères
        public string FirstName { get; set; }

        [Display(Name = "Nom de famille")]
        [Required(), StringLength(50)]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(), StringLength(125)]
        public string Email { get; set; }

        [Display(Name = "Mot de passe")]
        [Required(), StringLength(50)]
        public string Password { get; set; }
    }
}
