using System;
using System.Collections.Generic;
using System.Text;
using ModelLayers.Business;
using ModelLayers.Data;


namespace ModelLayers.Data
{
    public class DAOequipe
    {
        private dbal thedbal;
        private List<Joueur> lesJoueurs;

        public DAOequipe(dbal mydbal, List<Joueur> lesJoueurs)
        {
            this.thedbal = mydbal;
            this.lesJoueurs = new List<Joueur>(lesJoueurs);
        }
    }
}
