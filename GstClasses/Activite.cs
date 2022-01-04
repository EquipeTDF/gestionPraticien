using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GstClasses
{
    public class Activite
    {
        private string nomActivite;
        private int numActivite;

        public Activite(string unNom)
        {
            NomActivite = unNom;
        }
        public Activite(int unNum, string unNom)
        {
            NumActivite = unNum;
            NomActivite = unNom;
        }

        public string NomActivite { get => nomActivite; set => nomActivite = value; }
        public int NumActivite { get => numActivite; set => numActivite = value; }
    }
}
