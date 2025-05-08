using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace JoyeriaDubai
{
    class Venta : IVenta
    {
        private List<(string Cliente, string ID, Producto ProductoVendido, double Precio)> Ventas = new List<(string, string, Producto, double)>();
        private GestorProductos Gestor; // instanciamos del gestor de productos

        public Venta(GestorProductos gestor)
        {
            this.Gestor = gestor;
        }

        public void RealizarVenta()
        {
            Console.Write("\nIngrese el Nombre del Cliente: ");
            string Cliente = Console.ReadLine();

            Console.Write("Ingrese el ID del Cliente: ");
            string ID = Console.ReadLine();

            Console.Write("Ingrese el Código del Producto que desea comprar: ");
            string CodigoProducto = Console.ReadLine();

            // buscar el producto en la lista del gestor
            Producto ProductoAVender = Gestor.BuscarProducto(CodigoProducto);

            if (ProductoAVender == null)
            {
                Console.WriteLine("El producto no existe o ya ha sido vendido.");
                return;
            }

            // calcular el precio dependiendo el tipo del oro
            double Precio = 0;
            if (ProductoAVender.TipoOro.ToLower() == "n" || ProductoAVender.TipoOro.ToLower() == "nacional")
            {
                Precio = 380000 * ProductoAVender.Peso;
            }
            else if (ProductoAVender.TipoOro.ToLower() == "i" || ProductoAVender.TipoOro.ToLower() == "italiano")
            {
                Precio = 440000 * ProductoAVender.Peso;
            }
            else
            {
                Console.WriteLine("Tipo de oro inválido.");
                return;
            }

            // agregar la venta a la lista
            Ventas.Add((Cliente, ID, ProductoAVender, Precio));

            // eliminar el producto vendido
            Gestor.EliminarProductoPorCodigo(CodigoProducto);

            Console.WriteLine($"Venta realizada con éxito. Precio: {Precio:N2}");
        }

        public void MostrarVentas()
        {
            Console.WriteLine("\n---Lista de Ventas Realizadas en Fisico:---");
            if (Ventas.Count == 0)
            {
                Console.WriteLine("No hay ventas registradas.");
                return;
            }

            foreach (var venta in Ventas)
            {
                Console.WriteLine($"Cliente: {venta.Cliente}");
                Console.WriteLine($"ID: {venta.ID}");
                Console.WriteLine($"Producto: { venta.ProductoVendido.Nombre}");
                Console.WriteLine($"Precio: ${venta.Precio:N2}");
                Console.WriteLine("--------------------------");
            }
        }
    }
}
