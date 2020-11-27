using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Business;
using CsvHelper;
using CsvHelper.TypeConversion;
using CsvHelper.Configuration;

namespace ModelLayer.Data
{
    public class PaysConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            Dbal thedbal = new Dbal("dbclubfromage");
            Pays convertedPays = new Pays();
            DaoPays myDaoPays = new DaoPays(thedbal);
            convertedPays = myDaoPays.SelectByName(text);
            return convertedPays;
        }
    }

}
