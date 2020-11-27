using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using CsvHelper;

using ModelLayer.Business;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;

namespace ModelLayer.Data
{
    public class DaoPays
    {
        private Dbal thedbal;

        public DaoPays(Dbal mydbal)
        {
            this.thedbal = mydbal;
        }

        public void Insert(Pays thePays)
        {
            string query = "pays (id, name) VALUES (" + thePays.Id + ",'" + thePays.Name.Replace("'", "''") + "')";
            this.thedbal.Insert(query);
        }

        public void InsertFromCSV(string filename)
        {
            using (var reader = new StreamReader(filename))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = ";";
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();

                var record = new Pays();
                var records = csv.EnumerateRecords(record);

                foreach (Pays r in records)
                {
                    Console.WriteLine(r.Id + "-" + r.Name);
                    this.Insert(record);
                }
            }
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
            result = this.thedbal.SelectByField("pays", "name = '" + namePays.Replace("'","''") + "'");
            Pays foundPays = new Pays((int)result.Rows[0]["id"],(string)result.Rows[0]["name"]);
            return foundPays;

        }

        public Pays SelectById(int idPays)
        {
            DataRow result = this.thedbal.SelectById("Pays", idPays);
            return new Pays((int)result["id"], (string)result["name"]);

        }
    }
}
