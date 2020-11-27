using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ModelLayers.Business;
using ModelLayers.Data;


namespace ModelLayers.Data
{
    public class DAOjoueur
    {
        #region Attributs
        private dbal thedbal;
        private DAOpays leDAOPays;
        private DAOposte leDAOPoste;
        private DAOequipe leDAOEquipe;
        #endregion

        #region Constructeurs
        public DAOjoueur(dbal mydbal, DAOpays leDAOPays, DAOposte leDAOPoste, DAOequipe leDAOEquipe)
        {
            this.thedbal = mydbal;
            this.leDAOPays = leDAOPays;
            this.leDAOPoste = leDAOPoste;
            this.leDAOEquipe = leDAOEquipe;
        }
        #endregion

        public void Insert(Joueur leJoueur)
        {
            string requete = "Joueur (id, nom, dateEntree, dateNaissance, pays, poste, equipe) VALUES ("
                + leJoueur.Id + ","
                + leJoueur.Nom + ","
                + leJoueur.DateEntree + ","
                + leJoueur.DateNaissance + ","
                + leJoueur.Pays + ","
                + leJoueur.Poste + ","
                + leJoueur.Equipe + "')";
            this.thedbal.Insert(requete);
        }

        public void Update(Joueur leJoueur)
        {
            string requete = "Joueur SET id = " + leJoueur.Id
                + ", nom = '" + leJoueur.Nom.Replace("'", "''")
                + ", dateEntree = '" + leJoueur.DateEntree.ToString("yyyy-MM-dd")
                + ", dateNaissance = '" + leJoueur.DateNaissance.ToString("yyyy-MM--dd")
                + ", pays = '" + leJoueur.Pays
                + ", poste = '" + leJoueur.Poste
                + ", equipe = '" + leJoueur.Equipe
                + "WHERE id = " + leJoueur.Id + "' ";
            this.thedbal.Update(requete);
        }

        public void Delete(Joueur leJoueur)
        {
            string requete = "Joueur where id = '" + leJoueur.Id + "'";
            this.thedbal.Delete(requete);
        }

        public List<Joueur> SelectAll()
        {
            List<Joueur> listJoueur = new List<Joueur>();
            DataTable myTable = this.thedbal.SelectAll("Joueur");

            foreach (DataRow r in myTable.Rows)
            {
                listJoueur.Add(new Joueur((int)r["id"], (string)r["nom"], (DateTime)r["dateEntree"], (DateTime)r["dateNaissance"], (Pays)r["pays"], (Poste)r["poste"], (Equipe)r["equipe"]));
            }

            return listJoueur;
        }

        public Joueur SelectById(int id)
        {
            DataRow rowJoueur = this.thedbal.SelectById("Joueur", id);
            return new Joueur((int)rowJoueur["id"], (string)rowJoueur["nom"], (DateTime)rowJoueur["dateEntree"], (DateTime)rowJoueur["dateNaissance"], (Pays)rowJoueur["pays"], (Poste)rowJoueur["poste"], (Equipe)rowJoueur["equipe"]);
        }

        public Joueur SelectByName(string name)
        {
            string search = "nom = '" + name + "'";
            DataTable tableJoueur = this.thedbal.SelectByField("Joueur", search);
            return new Joueur((int)tableJoueur.Rows[0]["id"], (string)tableJoueur.Rows[0]["nom"], (DateTime)tableJoueur.Rows[0]["dateEntree"], (DateTime)tableJoueur.Rows[0]["dateNaissance"], (Pays)tableJoueur.Rows[0]["pays"], (Poste)tableJoueur.Rows[0]["poste"], (Equipe)tableJoueur.Rows[0]["equipe"]);
        }
    }
}
