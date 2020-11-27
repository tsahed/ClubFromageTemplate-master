using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Business
{
    public class Fromage
    {
        private int id;
        private string name;
        private DateTime creation;
        private Pays origin;
        private string image;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime Creation { get => creation; set => creation = value; }
        public Pays Origin { get => origin; set => origin = value; }
        public string Image { get => image; set => image = value; }

        public Fromage(int id = 0, string name = "", DateTime creation = new DateTime(), Pays origin = null, string image = "")
        {
            Id = id;
            Name = name;
            Creation = creation;
            if (origin == null) { Origin = new Pays(); }
            else Origin = origin; 
            Image = image;
        }

        public Fromage() { }

        public override string ToString()
        {
            return this.Name + "----->" + this.Origin.Name;
        }
    }
}
