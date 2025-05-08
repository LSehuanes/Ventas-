using System;

namespace JoyeriaDubai
{
    class Menu
    {   //instacias
        private GestorProductos Gestor; //objeto de la calse gestorprodcutos para acceder a la lista    
        private Venta Ventas;// obejto...
        private VentaOnline VentasOnline;//objeto...

        //constructor
        public Menu()
        {
            Gestor = new GestorProductos();
            Ventas = new Venta(Gestor);
            VentasOnline = new VentaOnline(Gestor);
        }

        public void MostrarMenu()
        {
            while (true)
            {
                Console.WriteLine("\n=======================");
                Console.WriteLine("== Menú Principal: ==");
                Console.WriteLine("1. Ingresar Producto");
                Console.WriteLine("2. Eliminar Producto");
                Console.WriteLine("3. Mostrar Productos");
                Console.WriteLine("4. Realizar Venta Física");
                Console.WriteLine("5. Realizar Venta Online");
                Console.WriteLine("6. Mostrar Ventas Físicas");
                Console.WriteLine("7. Mostrar Ventas Online");
                Console.WriteLine("8. Salir");
                Console.WriteLine("Seleccione una opción: ");
                Console.WriteLine("=======================");


                string Opcion = Console.ReadLine();

                switch (Opcion)
                {
                    case "1":
                        Gestor.IngresarProducto();
                        break;
                    case "2":
                        Gestor.EliminarProducto();
                        break;
                    case "3":
                        Gestor.MostrarProductos();
                        break;
                    case "4":
                        Ventas.RealizarVenta(); //  Venta Física
                        break;
                    case "5":
                        VentasOnline.RealizarVenta(); // Venta Online
                        break;
                    case "6":
                        Ventas.MostrarVentas(); //  Mostrar Ventas Físicas
                        break;
                    case "7":
                        VentasOnline.MostrarVentas(); // Mostrar Ventas Online
                        break;
                    case "8":
                        Console.WriteLine("Saliendo del programa...");
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }
            }
        }

        //creamos una instancia de Menu y llamamos al metodo MostrarMenu
        public static void Main()
        {

            Menu menu = new Menu();
            menu.MostrarMenu();
        }
    }
}
