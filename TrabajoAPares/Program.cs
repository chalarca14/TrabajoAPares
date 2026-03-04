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
            // Creamos una instancia de ReporteDiario para evitar llamar métodos de instancia como estáticos
            ReporteDiario reporte = new ReporteDiario();
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
                Console.WriteLine("6. Actualizar precio");
                Console.WriteLine("7. Registrar Venta");
                Console.WriteLine("8. Mostrar Ventas");
                Console.WriteLine("9. Reporte Total de Ventas");
                Console.WriteLine("10. Productos con Stock bajo");
                Console.WriteLine("11. Salir");
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
                        // Actualizar Precio
                        Console.Write("Ingrese ID del producto: ");
                        idStock = int.Parse(Console.ReadLine());
                        Console.Write("Ingresa el nuevo precio:  ");
                        decimal nuevoPrecio = int.Parse(Console.ReadLine());
                        inventario.ActualizarPrecio(idStock, nuevoPrecio);
                        Console.WriteLine("✅ Precio Actualizado actualizado.");
                        break;
                    case "7": 
                        Console.Write("Ingrese ID del producto: ");
                        int idVenta = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese cantidad: ");
                        int cantidadVenta = int.Parse(Console.ReadLine());
                        reporte.RegistrarVenta(inventario, idVenta, cantidadVenta);
                        break;
                    case "8":
                        reporte.MostrarVentas();
                        break;
                    case "9":
                        reporte.ReporteTotal();
                        break;
                    case "10":
                        int UMBRAL = 3;

                        List<Producto> productosBajoStock =
                            inventario.ObtenerProductosConStockBajo(UMBRAL);

                        if (productosBajoStock.Count > 0)
                        {
                            Console.WriteLine("Productos con stock bajo:");

                            foreach (Producto p in productosBajoStock)
                            {
                                Console.WriteLine($"Id: {p.Id} - Nombre: {p.Nombre} - Stock: {p.Stock}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No hay productos con stock bajo.");
                        }
                        break;
                    case "11":
                        reporte.MostrarCierreDiario(inventario);
                        salir = true; Console.WriteLine("👋 Cerrando aplicación...");
                        break;

                }
            }
        }
    }
}
