using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.Csharp
{
    public class Rect
    {
        private double _hauteur;

        public double Hauteur
        {
            get { return _hauteur; }
            set { _hauteur = value; }
        }

        public double Largeur { get; set; }

    }
}
