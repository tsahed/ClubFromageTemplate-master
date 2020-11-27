using System;
using System.Collections.Generic;
using System.Text;
using ModelLayers.Business;
using ModelLayers.Data;

namespace ModelLayers.Business
{
    public class Equipe
    {
        #region Attributs
        private int id;
        private string nom;
        private DateTime dateCreation;
        private List<Joueur> lesJoueurs;
        #endregion

        #region Accesseurs
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public DateTime DateCreation { get => dateCreation; set => dateCreation = value; }
        public List<Joueur> LesJoueurs { get => lesJoueurs; set => lesJoueurs = value; }
        #endregion

        #region Constructeur
        public Equipe(int id, string nom, DateTime dateCreation)
        {
            this.Id = id;
            this.Nom = nom;
            this.DateCreation = dateCreation;
            this.LesJoueurs = new List<Joueur>(lesJoueurs);
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