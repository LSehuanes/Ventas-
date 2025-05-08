using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoyeriaDubai
{
    class Cadena:Producto
    {
        public double Largo { get; set; } // en cm

        public Cadena(string Nombre, string Codigo, double Peso, string TipoOro, double Largo)
            : base(Nombre, Codigo, Peso, TipoOro)
        {
            this.Largo = Largo;
        }
    }

}
