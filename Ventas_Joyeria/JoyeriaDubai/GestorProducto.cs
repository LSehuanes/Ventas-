using System;
using System.Collections.Generic; // esto es para usar list
using JoyeriaDubai; // para usar las clases del x namespace
namespace JoyeriaDubai
{

    class GestorProductos
    {
        private List<Producto> Productos = new List<Producto>(); // creamos la lita para guardar los productos sin que nos la vayan a modificar 

        // aqui le preguntamos al usuario que objeto va a ingresar
        public void IngresarProducto()
        {
            Console.WriteLine("\nIngreso de Producto");
            Console.WriteLine("Seleccione el tipo de producto a ingresar:");
            Console.WriteLine("1. Cadena");
            Console.WriteLine("2. Pulsera");
            Console.WriteLine("3. Anillo");
            Console.Write("Ingrese una opción (1.Cadena    2.Pulsera   3.Anillo): ");
            Console.WriteLine(" ");

            string Opcion = Console.ReadLine();
            Console.WriteLine(" ");
            Console.Write("Ingrese el Nombre del producto: ");
            string Nombre = Console.ReadLine();

            Console.Write("Ingrese el Código del producto: ");
            string Codigo = Console.ReadLine();

            Console.Write("Ingrese el Peso del producto (en gramos): ");
            double Peso = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ingrese el Tipo de Oro (Nacional/Italiano): ");
            string TipoOro = Console.ReadLine();


            Producto NuevoProducto = null; // por buena practica inicializamos la variable

            if (Opcion == "1") 
            {
                Console.Write("Ingrese el Largo de la Cadena (en cm): ");
                double Largo = Convert.ToDouble(Console.ReadLine());
                NuevoProducto = new Cadena(Nombre, Codigo, Peso, TipoOro, Largo);
            }
            else if (Opcion == "2") 
            {
                Console.Write("Ingrese el Largo de la Pulsera (en cm): ");
                double Largo = Convert.ToDouble(Console.ReadLine());
                NuevoProducto = new Pulsera(Nombre, Codigo, Peso, TipoOro, Largo);
            }
            else if (Opcion == "3")
            {
                Console.Write("Ingrese la Talla del Anillo: ");
                string Talla = Console.ReadLine();
                NuevoProducto = new Anillo(Nombre, Codigo, Peso, TipoOro, Talla);
            }
            else
            {
                Console.WriteLine("Opción inválida.");
                return;
            }

            Productos.Add(NuevoProducto); //aniadimos el producto a la lista
            Console.WriteLine("Producto agregado correctamente");

        }

        // este es el metodo que elimina un producto independiente de la razon a exepcion de que el motivo sea una venta 
        public void EliminarProducto()
        {
            Console.Write("\nIngrese el código del producto a eliminar: ");
            string Codigo = Console.ReadLine();

            if (Productos.Count == 0)
            {
                Console.WriteLine("No hay productos registrados.");
                return;
            }

            //la variable que vamos a almacenar es de la clase producto y mediante find buscamos el primer objeto que coincide con el codigo
            Producto ProductoAEliminar = Productos.Find(p => p.Codigo == Codigo);


            if (ProductoAEliminar != null)
            {
                Productos.Remove(ProductoAEliminar);
                Console.WriteLine($"Producto con código {Codigo} eliminado correctamente.");
            }
            else
            {
                Console.WriteLine($"No se encontró un producto con el código {Codigo}.");
            }
        }

        // metodo para mostrar los productos ingresados y disponibles
        public void MostrarProductos()
        {
            Console.WriteLine("\nLista de Productos Registrados:");

            if (Productos.Count == 0) //si noy productos almacenados por el momento arroja un mensaje
            {
                Console.WriteLine("No hay productos disponibles.");
                return;
            }

            foreach (var Producto in Productos) //  para recorrer la lista y leer los elementos dentro de la lista
            {
                Console.WriteLine("***PRODUCTO***");
                Console.WriteLine($"Nombre: {Producto.Nombre}");
                Console.WriteLine($"Código: {Producto.Codigo}");
                Console.WriteLine($"Peso: {Producto.Peso}");
                Console.WriteLine($"Tipo de Oro: {Producto.TipoOro}");

                if (Producto is Cadena)
                {
                    Console.WriteLine($"Largo: {(Producto as Cadena).Largo} cm");
                }
                else if (Producto is Pulsera)
                {
                    Console.WriteLine($"Largo: {(Producto as Pulsera).Largo} cm");
                }
                else if (Producto is Anillo)
                {
                    Console.WriteLine($"Talla: {(Producto as Anillo).Talla} unidad de medidad especial para anillos");
                }
            }

        }

        //este metodo es para bsucar un producto por su codigo 
        public Producto BuscarProducto(string Codigo)
        {
            return Productos.Find(p => p.Codigo == Codigo);
        }

        //este es para eliminarlo por venta e imprime un mensaje informativo
        public void EliminarProductoPorCodigo(string Codigo)
        {
            Producto ProductoAEliminar = BuscarProducto(Codigo);
            if (ProductoAEliminar != null) //confirmamos que existe el producto
            {
                Productos.Remove(ProductoAEliminar); //finalmente lo eliminamos
                Console.WriteLine($"El producto {Codigo} ha sido vendido y eliminado del inventario.");
            }
        }



    }
}