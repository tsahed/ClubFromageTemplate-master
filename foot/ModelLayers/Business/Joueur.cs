﻿using System;
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
        private string nom;
        private DateTime dateEntree;
        private DateTime dateNaissance;
        private Pays lePays;
        private Poste lePoste;
        private Equipe laEquipe;
        #endregion

        #region Accesseurs
        public int Id { get => id; set => id = value; }
        public DateTime DateEntree { get => dateEntree; set => dateEntree = value; }
        public DateTime DateNaissance { get => dateNaissance; set => dateNaissance = value; }  
        public Pays Pays { get => lePays; set => lePays = value; }
        public Poste Poste { get => lePoste; set => lePoste = value; }
        public string Nom { get => nom; set => nom = value; }
        public Equipe Equipe { get => laEquipe; set => laEquipe = value; }
        #endregion

        #region Constructeurs
        public Joueur(int id, string nom, DateTime dateEntree, DateTime dateNaissance, Pays pays, Poste poste, Equipe equipe)
        {
            this.Id = id;
            this.Nom = nom;
            this.DateEntree = dateEntree;
            this.DateNaissance = dateNaissance;
            this.Pays = pays;
            this.Poste = poste;
            this.Equipe = equipe;
        }
        #endregion
    }
}
