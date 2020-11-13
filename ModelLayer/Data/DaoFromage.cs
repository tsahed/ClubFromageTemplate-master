using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using CsvHelper;

using ModelLayer.Business;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Data;
using System.Runtime.CompilerServices;

namespace ModelLayer.Data
{
    public class DaoFromage
    {
        private Dbal thedbal;
        private DaoPays theDaoPays;

        public DaoFromage(Dbal mydbal, DaoPays theDaoPays)
        {
            this.thedbal = mydbal;
            this.theDaoPays = theDaoPays;
        }

        public void Insert(Fromage theFromage)
        {
            string query = "fromage (id, pays_origine_id, name, creation, image) VALUES ("
                + theFromage.Id + ","
                + theFromage.Origin.Id + ",'"
                + theFromage.Name.Replace("'", "''") + "','"
                + theFromage.Creation.ToString("yyyy-MM-dd") + "','"
                + theFromage.Image + "')";
            this.thedbal.Insert(query);
        }

        public void InsertFromCSV(string filename)
        {
            using (var reader = new StreamReader(filename))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = ";";
                csv.Configuration.RegisterClassMap<FromageMap>();
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();

                var record = new Fromage();
                IEnumerable<Fromage> records = csv.EnumerateRecords(record);

                foreach (Fromage r in records)
                {
                    Console.WriteLine(r.Id + "-" + r.Name + "-" + r.Origin.Name);
                    this.Insert(record);
                }
            }
        }

        public void Update(Fromage myFromage)
        {
            string query = "fromage SET id = " + myFromage.Id
                + ", name = '" + myFromage.Name.Replace("'","''")
                + "', pays_origine_id = " + myFromage.Origin.Id
                + ", creation = '" + myFromage.Creation.ToString("yyyy-MM-dd")
                + "', image = '" + myFromage.Image + "' " 
                + "WHERE id = " + myFromage.Id;
            this.thedbal.Update(query);
        }

        public List<Fromage> SelectAll()
        {
            List<Fromage> listFromage = new List<Fromage>();
            DataTable myTable = this.thedbal.SelectAll("fromage");

            foreach (DataRow r in myTable.Rows)
            {
                Pays myPays = this.theDaoPays.SelectById((int)r["pays_origine_id"]);
                listFromage.Add(new Fromage((int)r["id"], (string)r["name"], (DateTime)r["creation"], myPays, (string)r["image"]));
            }

            return listFromage;
        }

        public Fromage SelectById(int id)
        {
            DataRow rowFromage = this.thedbal.SelectById("fromage", id);
            Pays myPays = this.theDaoPays.SelectById((int)rowFromage["pays_origine_id"]);
            return new Fromage((int)rowFromage["id"],(string)rowFromage["name"],(DateTime)rowFromage["creation"], myPays,(string)rowFromage["image"]);
        }

        public Fromage SelectByName(string name)
        {
            string search = "name = '" + name + "'";
            DataTable tableFromage = this.thedbal.SelectByField("fromage", search);
            Pays myPays = this.theDaoPays.SelectById((int)tableFromage.Rows[0]["pays_origine_id"]);
            return new Fromage((int)tableFromage.Rows[0]["id"], (string)tableFromage.Rows[0]["name"], (DateTime)tableFromage.Rows[0]["creation"], myPays, (string)tableFromage.Rows[0]["image"]);
        }
    }
}

