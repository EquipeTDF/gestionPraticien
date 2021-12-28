using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GstClasses
{
    public class Specialite
    {
        private string nomSpe;

        public Specialite(string unNom)
        {
            NomSpe = unNom;
        }

        public string NomSpe { get => nomSpe; set => nomSpe = value; }
    }
}
