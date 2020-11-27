using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ModelLayers.Business;
using ModelLayers.Data;

namespace ModelLayers.Data
{
    public class DAOpays
    {
        private dbal thedbal;

        public DAOpays(dbal mydbal)
        {
            this.thedbal = mydbal;
        }

        public void Insert(Pays thePays)
        {
            string query = "pays (id, name) VALUES (" + thePays.Id + ",'" + thePays.Name.Replace("'", "''") + "')";
            this.thedbal.Insert(query);
        }

        public List<Pays> SelectAll()
        {
            List<Pays> listPays = new List<Pays>();
            DataTable myTable = this.thedbal.SelectAll("pays");

            foreach (DataRow r in myTable.Rows)
            {
                listPays.Add(new Pays((int)r["id"], (string)r["name"]));
            }

            return listPays;
        }

        public Pays SelectByName(string namePays)
        {
            DataTable result = new DataTable();
            result = this.thedbal.SelectByField("pays", "name = '" + namePays.Replace("'", "''") + "'");
            Pays foundPays = new Pays((int)result.Rows[0]["id"], (string)result.Rows[0]["name"]);
            return foundPays;

        }

        public Pays SelectById(int idPays)
        {
            DataRow result = this.thedbal.SelectById("Pays", idPays);
            return new Pays((int)result["id"], (string)result["name"]);

        }
    }
}
