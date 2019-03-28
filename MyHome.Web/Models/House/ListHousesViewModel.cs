using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHome.Web.Models.House
{
    public class ListHousesViewModel
    {
        /// <summary>
        /// Affecte ou obtient la liste des maisons
        /// </summary>
        public List<Domain.House> Houses { get; set; } = new List<Domain.House>();
    }
}
