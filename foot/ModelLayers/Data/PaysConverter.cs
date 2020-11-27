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
    public class PaysConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            dbal thedbal = new dbal("foot_americainDB");
            Pays convertedPays = new Pays();
            DAOpays myDaoPays = new DAOpays(thedbal);
            convertedPays = myDaoPays.SelectByName(text);
            return convertedPays;
        }
    }
}
