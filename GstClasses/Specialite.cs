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
        private int numSpe;

        public Specialite(string unNom)
        {
            NomSpe = unNom;
        }

        public Specialite(int unId, string unNom)
        {
            IdSpe = unId;
            NomSpe = unNom;
        }

        public Specialite(int unNum, string unNom)
        {
            NomSpe = unNom;
            NumSpe = unNum;
        }


        public string NomSpe { get => nomSpe; set => nomSpe = value; }
        public int NumSpe { get => numSpe; set => numSpe = value; }
        public int IdSpe { get => idSpe; set => idSpe = value; }
    }
}
