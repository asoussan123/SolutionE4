//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetE4
{
    using System;
    using System.Collections.Generic;
    
    public partial class reserver
    {
        public int idLivre { get; set; }
        public int idUtilisateur { get; set; }
        public Nullable<System.DateTime> dateReserve { get; set; }
        public System.DateTime dateRemise { get; set; }
    
        public virtual livre livre { get; set; }
        public virtual utilisateur utilisateur { get; set; }
    }
}
