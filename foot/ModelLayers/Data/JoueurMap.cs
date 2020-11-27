using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper.Configuration;
using ModelLayers.Business;
using ModelLayers.Data;


namespace ModelLayers.Data
{
    public class JoueurMap : ClassMap<Joueur>
    {
        public JoueurMap()
        {
            Map(m => m.Id);
            Map(m => m.DateEntree);
            Map(m => m.DateNaissance);
            Map(m => m.Pays).TypeConverter<PaysConverter>();            
            Map(m => m.Poste).TypeConverter<PosteConverter>();
        }
    }
}
