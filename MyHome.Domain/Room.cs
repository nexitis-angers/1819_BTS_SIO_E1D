using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Domain
{
    public class Room : IComparable<Room>
    {
        #region Properties
        /// <summary>
        /// Affecte ou obtient l'identifiant
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Affecte ou obtient le nom de la pièce
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Affecte ou obtient la propriété de navigation vers la maison
        /// </summary>
        public House House { get; set; }
        /// <summary>
        /// Affecte ou obtient la clé étrangère vers la maison
        /// </summary>
        public int HouseId { get; set; }
        #endregion

        #region Methods
        public override int GetHashCode()
        {
            int nameHash = string.IsNullOrEmpty(Name) ? 0 : Name.GetHashCode();
            int houseIdHash = HouseId.GetHashCode();

            // Le hash doit reposer à la fois sur le nom de la pièce, et sur l'id de la maison
            return nameHash ^ houseIdHash;
        }

        /// <summary>
        /// Retourne vrai si l'instance passée en paramètre est égale à l'instance en cours
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return GetHashCode().Equals(obj.GetHashCode());
        }

        /// <summary>
        /// Compare la pièce passée en paramètre avec l'instance courante
        /// </summary>
        /// <param name="other">Pièce à comparer</param>
        /// <returns></returns>
        public int CompareTo(Room other)
        {
            return GetHashCode().CompareTo(other.GetHashCode());
        }
        #endregion
    }
}
