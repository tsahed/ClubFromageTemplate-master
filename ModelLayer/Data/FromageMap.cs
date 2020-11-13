using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using ModelLayer.Business;

namespace ModelLayer.Data
{
    public class FromageMap : ClassMap<Fromage>
    {
        public FromageMap()
        {
            Map(m => m.Id);
            Map(m => m.Name);
            Map(m => m.Origin).TypeConverter<PaysConverter>();
            Map(m => m.Creation);
            Map(m => m.Image);
        }
    }
}
