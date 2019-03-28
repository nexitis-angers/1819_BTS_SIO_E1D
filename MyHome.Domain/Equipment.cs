using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Domain
{
    public class Equipment : IComparable<Equipment>
    {
        #region Properties
        /// <summary>
        /// Affecte ou obtient l'identifiant
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Affecte ou obtient le nom de l'équipement
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Affecte ou obtient la propriété de navigation vers la pièce
        /// </summary>
        public Room Room { get; set; }
        /// <summary>
        /// Affecte ou obtient la clé étrangère de la pièce
        /// </summary>
        public int RoomId { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Obtient le hash de l'équipement domotique
        /// </summary>
        /// <remarks>
        /// L'idée ici étant de garantir qu'on aura pas 2 équipements qui portent
        /// le même nom dans la même pièce
        /// </remarks>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int nameHash = string.IsNullOrEmpty(Name) ? 0 : Name.GetHashCode();
            int roomIdHash = RoomId.GetHashCode();

            return nameHash ^ roomIdHash;
        }

        /// <summary>
        /// Compare un équipement domotique avec l'instance courante en se basant sur le getHashCode()
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return GetHashCode().Equals(obj.GetHashCode());
        }

        /// <summary>
        /// Compare 2 équipements domotiques entre eux 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Equipment other)
        {
            return GetHashCode().CompareTo(other.GetHashCode());
        }
        #endregion
    }
}
