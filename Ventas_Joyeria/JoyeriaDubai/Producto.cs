using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoyeriaDubai
{

    abstract class Producto
    {
        public string Nombre 
        public string Codigo 
        public double Peso  // en gramos
        public string TipoOro // nacional o italiano


        public Producto(string Nombre, string Codigo, double Peso, string TipoOro)
        {
            this.Nombre = Nombre;
            this.Codigo = Codigo;
            this.Peso = Peso;
            this.TipoOro = TipoOro;

        }
    }
}