using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Domain
{
    public class Light : Equipment
    {
        #region Properties
        /// <summary>
        /// Affecte ou obtient un booléen qui indique si l'éclairage est allumé ou non
        /// </summary>
        public bool IsOn { get; set; }
        #endregion
    }
}
