using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GstClasses
{
    public class Praticien
    {
            private int numeroPraticien;
            private string nomPraticien;
            private string prenomPraticien;

            public Praticien(int unNum, string unNom, string unPrenom)
            {
                NumeroPraticien = unNum;
                NomPraticien = unNom;
                PrenomPraticien = unPrenom;
            }

            public int NumeroPraticien { get => numeroPraticien; set => numeroPraticien = value; }
            public string NomPraticien { get => nomPraticien; set => nomPraticien = value; }
            public string PrenomPraticien { get => prenomPraticien; set => prenomPraticien = value; }
    }
}
