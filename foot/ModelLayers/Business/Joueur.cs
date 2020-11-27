using System;
using System.Collections.Generic;
using System.Text;
using ModelLayers.Business;
using ModelLayers.Data;

namespace ModelLayers.Business
{
    public class Joueur
    {
        #region Attributs
        private int id;
        private DateTime dateEntree;
        private DateTime dateNaissance;
        private Pays pays;
        private Poste poste;
        #endregion

        #region Accesseurs
        public int Id { get => id; set => id = value; }
        public DateTime DateEntree { get => dateEntree; set => dateEntree = value; }
        public DateTime DateNaissance { get => dateNaissance; set => dateNaissance = value; }  
        public Pays Pays { get => pays; set => pays = value; }
        public Poste Poste { get => poste; set => poste = value; }
        #endregion

        #region Constructeurs
        public Joueur(int id, DateTime dateEntree, DateTime dateNaissance, Pays pays, Poste poste)
        {
            this.Id = id;
            this.DateEntree = dateEntree;
            this.DateNaissance = dateNaissance;
            this.Pays = pays;
            this.Poste = poste;
        }
        #endregion
    }
}
