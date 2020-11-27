using System;
using System.Collections.Generic;
using System.Text;
using ModelLayers.Business;
using ModelLayers.Data;

namespace ModelLayers.Business
{
    public class Poste
    {
        #region Attributs
        private int id;
        private string nom;
        private int escouade;
        #endregion

        #region Accesseurs
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public int Escouade { get => escouade; set => escouade = value; }
        #endregion

        #region Constructeur
        public Poste(int id, string nom, int escouade)
        {
            this.Id = id;
            this.Nom = nom;
            this.Escouade = escouade;
        }

        public Poste()
        {
            this.Id = id;
            this.Nom = nom;
            this.Escouade = escouade;
        }
        #endregion

        #region Autres méthodes
        public override string ToString()
        {
            return this.Nom;
        } 
        #endregion
    }
}
