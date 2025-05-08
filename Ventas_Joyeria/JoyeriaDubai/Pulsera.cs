using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoyeriaDubai
{
    class Pulsera:Producto
    {
        public double Largo { get; set; } // en cm

        public Pulsera(string Nombre, string Codigo, double Peso, string TipoOro, double Largo)
            : base(Nombre, Codigo, Peso, TipoOro)
        {
            this.Largo = Largo;
        }
    }
}
