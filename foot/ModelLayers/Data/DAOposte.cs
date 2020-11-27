using System;
using System.Collections.Generic;
using System.Text;
using ModelLayers.Business;
using ModelLayers.Data;


namespace ModelLayers.Data
{
    public class DAOposte
    {
        private dbal thedbal;

        public DAOposte(dbal mydbal)
        {
            this.thedbal = mydbal;
        }
    }
}
