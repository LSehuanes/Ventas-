using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoyeriaDubai
{
    class Anillo:Producto
    {
        public string Talla { get; set; }

        public Anillo(string Nombre, string Codigo, double Peso, string TipoOro, string Talla)
            : base(Nombre, Codigo, Peso, TipoOro)
        {
            this.Talla = Talla;
        }
    }
}
