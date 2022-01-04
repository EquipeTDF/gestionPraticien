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
        private int idSpe;

        public Specialite(string unNom)
        {
            NomSpe = unNom;
        }

        public Specialite(int unId, string unNom)
        {
            IdSpe = unId;
            NomSpe = unNom;
        }

        public string NomSpe { get => nomSpe; set => nomSpe = value; }
        public int IdSpe { get => idSpe; set => idSpe = value; }
    }
}
