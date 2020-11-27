using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ModelLayers.Business;
using ModelLayers.Data;


namespace ModelLayers.Data
{
    public class DAOposte
    {
        private dbal thedbal;

        public DAOposte(dbal mydbal)
        {
            this.thedbal = mydbal;
        }

        public Poste SelectById(int id)
        {
            DataRow rowEquipe = this.thedbal.SelectById("Poste", id);
            return new Poste((int)rowEquipe["id"], (string)rowEquipe["nom"], (int)rowEquipe["escouade"]);
        }

        public Poste SelectByName(string name)
        {
            string search = "nom = '" + name + "'";
            DataTable tablePoste = this.thedbal.SelectByField("Poste", search);
            return new Poste((int)tablePoste.Rows[0]["id"], (string)tablePoste.Rows[0]["nom"], (int)tablePoste.Rows[0]["escouade"]);
        }
    }
}
