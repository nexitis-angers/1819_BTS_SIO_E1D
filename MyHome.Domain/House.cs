using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Domain
{
    public class House : IComparable<House>
    {
        #region Properties
        /// <summary>
        /// Affecte ou obtient l'identifiant
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Affecte ou obtient le nom de la maison
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Affecte ou obtient la collection de pièces de la maison
        /// </summary>
        /// <remarks>
        /// Le choix du typage en HashSet, s'explique par la volonté de respecter la règle de gestion "Une maison ne peut pas avoir 2 pièces identiques". Le HashSet se basant sur la méthode GetHashCode() pour évaluer la présence ou non de doublons.
        /// 
        /// Une instanciation en List aurait été plus permissif
        /// </remarks>
        public ICollection<Room> Rooms { get; set; } = new HashSet<Room>();
        #endregion

        #region Constructors
        public House()
        {
            // 2 écritures possibles :
            // soit instanciation de la collection dès la déclaration de celle-ci,
            // ou instanciation dans le constructeur de l'objet
            Rooms = new HashSet<Room>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Obtention du hash de l'objet basé sur les propriétés qui le rendent unique 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            // On interdira d'avoir 2 maisons qui portent le même nom
            return string.IsNullOrEmpty(Name) ? 0 : Name.GetHashCode();
        }

        /// <summary>
        /// Compare notre instance de maison avec celle passée en paramètre
        /// </summary>
        /// <param name="other">Autre maison à comparer</param>
        /// <returns></returns>
        public int CompareTo(House other)
        {
            return GetHashCode().CompareTo(other.GetHashCode());
        }

        /// <summary>
        /// Retourne vrai si l'instance courante est égale à l'instance passée en paramètre
        /// </summary>
        /// <param name="obj">Objet à comparer</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return GetHashCode().Equals(obj.GetHashCode());
        }
        #endregion
    }
}
