using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ModelLayers.Business;
using ModelLayers.Data;


namespace ModelLayers.Data
{
    public class DAOequipe
    {
        private dbal thedbal;
        private DAOjoueur leDAOjoueur;

        public DAOequipe(dbal mydbal, DAOjoueur monDAOjoueur)
        {
            this.thedbal = mydbal;
            this.leDAOjoueur = monDAOjoueur;
        }

        public void Insert(Equipe laEquipe)
        {
            string requete = "Equipe (id, nom, dateCreation) VALUES ("
                + laEquipe.Id + ","
                + laEquipe.Nom + ","
                + laEquipe.DateCreation + "')";
            this.thedbal.Insert(requete);
        }

        public void Update(Equipe laEquipe)
        {
            string requete = "Equipe SET id = " + laEquipe.Id
                + ", nom = '" + laEquipe.Nom.Replace("'", "''")
                + ", dateCreation = '" + laEquipe.DateCreation.ToString("yyyy-MM-dd")
                + "WHERE id = " + laEquipe.Id + "' ";
            this.thedbal.Update(requete);
        }

        public void Delete(Equipe laEquipe)
        {
            string requete = "Equipe where id = '" + laEquipe.Id + "'";
            this.thedbal.Delete(requete);
        }

        public List<Equipe> SelectAll()
        {
            List<Equipe> listEquipe = new List<Equipe>();
            DataTable myTable = this.thedbal.SelectAll("Equipe");

            foreach (DataRow r in myTable.Rows)
            {                
                listEquipe.Add(new Equipe((int)r["id"], (string)r["nom"], (DateTime)r["dateCreation"]));
            }

            return listEquipe;
        }

        public Equipe SelectById(int id)
        {
            DataRow rowEquipe = this.thedbal.SelectById("Equipe", id);
            return new Equipe((int)rowEquipe["id"], (string)rowEquipe["nom"], (DateTime)rowEquipe["dateCreation"]);
        }

        public Equipe SelectByName(string name)
        {
            string search = "nom = '" + name + "'";
            DataTable tableEquipe = this.thedbal.SelectByField("Equipe", search);
            return new Equipe((int)tableEquipe.Rows[0]["id"], (string)tableEquipe.Rows[0]["nom"], (DateTime)tableEquipe.Rows[0]["dateCreation"]);
        }
    }
}
