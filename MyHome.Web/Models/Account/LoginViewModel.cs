using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyHome.Web.Models.Account
{
    public class LoginViewModel
    {
        /// <summary>
        /// Affecte ou obtient l'email de connexion
        /// </summary>
        [Display(Name ="Email")]
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        /// <summary>
        /// Affecte ou obtient le mot de passe
        /// </summary>
        [Display(Name = "Mot de pass")]
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        /// <summary>
        /// Affecte ou obtient un booléen qui si vrai indique que le cookie doit-être permanent
        /// </summary>
        [Display(Name = "Se souvenir de moi")]
        public bool StayConnected { get; set; }
    }
}
