using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Domain
{
    /// <summary>
    /// Décrit un utilisateur de l'application
    /// </summary>
    public class User : IComparable<User>
    {
        #region Properties
        /// <summary>
        /// Affecte ou obtient l'identifiant
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Affecte ou obtient le prénom
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Affecte ou obtient le nom de famille
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Affecte ou obtient l'email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Affecte ou obtient le mot de passe
        /// </summary>
        public string Password { get; set; }

        #endregion

        #region Constructors

        #endregion

        #region Methods
        /// <summary>
        /// Compare l'utilisateur courant avec l'utilisateur passé en paramètre
        /// </summary>
        /// <param name="other">l'utilisateur à comparer</param>
        /// <returns></returns>
        public int CompareTo(User other)
        {
            return this.GetHashCode().CompareTo(other.GetHashCode());
        }

        /// <summary>
        /// Retourne vrai si l'objet passé en paramètre est égal à notre instance, sinon faux
        /// </summary>
        /// <param name="obj">Objet à comparer</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this.GetHashCode().Equals(obj.GetHashCode());
        }

        /// <summary>
        /// Calcul le hash de l'objet sur les propriétés qui le rendent unique
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            // On estime que l'email doit-être unique, c'est pour cela que l'on base le calcul sur cette propriété
            return string.IsNullOrEmpty(this.Email) ? 0 : this.Email.GetHashCode();
        }
        #endregion
    }
}
