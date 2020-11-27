using System;
using System.Collections.Generic;
using System.Text;
using ModelLayers.Business;
using ModelLayers.Data;


namespace ModelLayers.Data
{
    public class DAOjoueur
    {
        #region Attributs
        private dbal thedbal;
        private Pays lePays;
        private Poste lePoste;
        #endregion

        #region Constructeurs
        public DAOjoueur(dbal mydbal, Pays lePays, Poste lePoste)
        {
            this.thedbal = mydbal;
            this.lePays = lePays;
            this.lePoste = lePoste;
        } 
        #endregion
    }
}
