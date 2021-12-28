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

        public Activite(string unNom)
        {
            NomActivite = unNom;
        }

        public string NomActivite { get => nomActivite; set => nomActivite = value; }
    }
}
