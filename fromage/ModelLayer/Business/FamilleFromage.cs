using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Business
{
    class FamilleFromage
    {
        private int _id;
        private string _name;
        private List<Fromage> _LesFromages;

        public FamilleFromage()
        {
            _id = 0;
            _name = "";
            _LesFromages = new List<Fromage>();
        }

    }
}
