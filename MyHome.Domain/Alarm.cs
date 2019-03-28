using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Domain
{
    public class Alarm : Equipment
    {
        /// <summary>
        /// Définition d'une constante
        /// </summary>
        public const int RINGING_DURATION = 5; 

        #region Properties
        /// <summary>
        /// Affecte ou obtient l'heure de détection de la dernière intrusion
        /// </summary>
        public DateTime? IntrusionDetectedAt { get; set; }

        /// <summary>
        /// Obtient un booléen qui indique si l'alarme est en train de sonner
        /// </summary>
        public bool IsRinging
        {
            get
            {
                if (!this.IntrusionDetectedAt.HasValue)
                    return false; // Aucune valeur = pas d'intrusion
                else
                {
                    // Si la différente entre MAINTENANT et l'heure d'intrusion est inférieure à 5 minutes, alors on sonne
                    return DateTime.Now.Subtract(IntrusionDetectedAt.Value).TotalMinutes < RINGING_DURATION;
                }
            }
        }
        #endregion

    }
}
