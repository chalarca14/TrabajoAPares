namespace TrabajoAPares
{
    using System;
    using TrabajoAPares.Clases;

    class Program
    {
        static void Main(string[] args)
        {
            // Creamos el inventario (tu clase)
            Inventario inventario = new Inventario();
            bool salir = false;

            while (!salir)
            {
                // Menú principal
                Console.WriteLine("\n--- MENÚ PRINCIPAL ---");
                Console.WriteLine("1. Registrar Producto");
                Console.WriteLine("2. Consultar Producto por ID");
                Console.WriteLine("3. Consultar Producto por Nombre");
                Console.WriteLine("4. Mostrar Inventario");
                Console.WriteLine("5. Actualizar Stock");
                Console.WriteLine("6. Registrar Venta");
                Console.WriteLine("7. Mostrar Ventas");
                Console.WriteLine("8. Reporte Total de Ventas");
                Console.WriteLine("9. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        // Registrar producto
                        Console.Write("Ingrese ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese Nombre: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Ingrese Precio: ");
                        decimal precio = decimal.Parse(Console.ReadLine());
                        Console.Write("Ingrese Stock: ");
                        int stock = int.Parse(Console.ReadLine());

                        Producto nuevo = new Producto(id, nombre, precio, stock);
                        inventario.RegistrarProducto(nuevo);
                        Console.WriteLine("✅ Producto registrado correctamente.");
                        break;

                    case "2":
                        // Consultar por ID
                        Console.Write("Ingrese ID: ");
                        int idBuscar = int.Parse(Console.ReadLine());
                        var prodId = inventario.BuscarPorId(idBuscar);
                        Console.WriteLine(prodId != null ? prodId.MostrarInfo() : "❌ Producto no encontrado.");
                        break;

                    case "3":
                        // Consultar por Nombre
                        Console.Write("Ingrese Nombre: ");
                        string nombreBuscar = Console.ReadLine();
                        var prodNom = inventario.BuscarPorNombre(nombreBuscar);
                        Console.WriteLine(prodNom != null ? prodNom.MostrarInfo() : "❌ Producto no encontrado.");
                        break;

                    case "4":
                        // Mostrar inventario completo
                        inventario.MostrarInventario();
                        break;

                    case "5":
                        // Actualizar stock
                        Console.Write("Ingrese ID del producto: ");
                        int idStock = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese cantidad (+ para entrada, - para salida): ");
                        int cantidad = int.Parse(Console.ReadLine());
                        inventario.ActualizarStock(idStock, cantidad);
                        Console.WriteLine("✅ Stock actualizado.");
                        break;

                    case "6": 
                        Console.Write("Ingrese ID del producto: ");
                        int idVenta = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese cantidad: ");
                        int cantidadVenta = int.Parse(Console.ReadLine());
                        ReporteDiario.RegistrarVenta(inventario, idVenta, cantidadVenta);
                        break;
                    case "7":
                        ReporteDiario.MostrarVentas();
                        break;
                    case "8":
                        ReporteDiario.ReporteTotal();
                        break;
                    case "9":
                        salir = true; Console.WriteLine("👋 Cerrando aplicación...");
                        break;
                }
            }
        }
    }
}
