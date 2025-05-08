using System;
using System.Collections.Generic;

namespace JoyeriaDubai
{
    class VentaOnline : IVenta //obligatoriamente vamos a usar los metodos de IVenta
    {   // creamos la lista para almacenar el producto con sus atributos 
        private List<(string TipoVenta, string Cliente, string ID, Producto ProductoVendido, double Precio)> Ventas = new List<(string, string, string, Producto, double)>();
        private GestorProductos Gestor;

        public VentaOnline(GestorProductos gestor)
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

            // calcular el precio según el tipo de oro ya que la joyeria maneja dos tipos de oro y de eso depende el precio
            double Precio = ProductoAVender.TipoOro.ToLower() == "n" ? 380000 * ProductoAVender.Peso : 440000 * ProductoAVender.Peso;

            // agregar la venta en modo "Venta Online"
            Ventas.Add(("Venta Online", Cliente, ID, ProductoAVender, Precio));

            // eliminar el producto del inventario ya que al venderlo no estaria disponible
            Gestor.EliminarProductoPorCodigo(CodigoProducto);

            Console.WriteLine($"Venta online registrada con éxito. Precio: {Precio:N2}");
        }

        public void MostrarVentas()
        {
            Console.WriteLine("\nLista de Ventas Online:");
            if (Ventas.Count == 0)
            {
                Console.WriteLine("No hay ventas online registradas.");
                return;
            }

            foreach (var venta in Ventas)
            {
                Console.WriteLine($"Cliente: {venta.Cliente}");
                Console.WriteLine($"ID: {venta.ID}");
                Console.WriteLine($"Producto: {venta.ProductoVendido.Nombre}");
                Console.WriteLine($"Precio: ${venta.Precio:N2}");
                Console.WriteLine("-----------------------");
            }
        }
    }
}
