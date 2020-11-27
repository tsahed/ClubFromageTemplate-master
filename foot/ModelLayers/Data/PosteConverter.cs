using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ModelLayers.Business;
using ModelLayers.Data;


namespace ModelLayers.Data
{
    public class PosteConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            dbal thedbal = new dbal("foot_americainDB");
            Poste convertedPays = new Poste();
            DAOposte myDaoPoste = new DAOposte(thedbal);
            convertedPays = myDaoPoste.SelectByName(text);
            return convertedPays;
        }
    }
}
