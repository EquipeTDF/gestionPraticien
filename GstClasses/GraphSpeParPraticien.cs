using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GstClasses
{
    public class GraphSpeParPraticien
    {
        private string nomPraticien;
        private int nombreSpe;

        public GraphSpeParPraticien(string unNom, int unNombre)
        {
            NomPraticien = unNom;
            NombreSpe = unNombre;
        }

        public string NomPraticien { get => nomPraticien; set => nomPraticien = value; }
        public int NombreSpe { get => nombreSpe; set => nombreSpe = value; }
    }
}
