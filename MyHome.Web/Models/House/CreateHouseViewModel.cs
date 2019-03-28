using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyHome.Web.Models.House
{
    public class CreateHouseViewModel
    {
        #region Properties
        [Display(Name="Nom")] // Libellé affiché à l'écran
        [Required] // La saisie est obligatoire
        [StringLength(50)] // La longueur max de 50 caractères
        public string Name { get; set; }
        #endregion
    }
}
