using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoAPares.Clases
{
    public class ReporteDiario
    {
        private List<Venta> ventas = new List<Venta>();
        private int contadorVentas = 1;
        public void RegistrarVenta(Inventario inventario, int idProducto, int cantidad)
        {
            Producto producto = inventario.BuscarPorId(idProducto);
            if (producto != null && producto.Stock >= cantidad)
            { // Descontar stock 
                inventario.ActualizarStock(idProducto, -cantidad); // Crear venta
                Venta nuevaVenta = new Venta(contadorVentas++, producto, cantidad);
                ventas.Add(nuevaVenta); Console.WriteLine("✅ Venta registrada correctamente.");
                Console.WriteLine(nuevaVenta.MostrarInfo());
            }
            else
            {
                Console.WriteLine("❌ No se pudo realizar la venta. Stock insuficiente o producto inexistente.");
            }
        }

        public void MostrarVentas()
        {
            Console.WriteLine("\n--- LISTA DE VENTAS ---"); foreach (var venta in ventas)
            {
                Console.WriteLine(venta.MostrarInfo());
            }
        }
        public void ReporteTotal()
        {
            decimal total = 0; foreach (var venta in ventas)
            {
                total += venta.Total;
            }
            Console.WriteLine($"\n💰 Total de ventas realizadas: ${total}");
        }
        public void MostrarCierreDiario(Inventario inventario)
        {
            Console.WriteLine("\n===== 📊 CIERRE DIARIO =====");

            // Total vendido
            decimal total = ventas.Sum(v => v.Total);
            Console.WriteLine($"💰 Total vendido: {total:C}");

            // Top 3 productos más vendidos
            var top3 = ventas
                .GroupBy(v => v.Producto.Nombre)
                .OrderByDescending(g => g.Sum(v => v.Cantidad))
                .Take(3);

            Console.WriteLine("\n🏆 Top 3 productos más vendidos:");
            foreach (var grupo in top3)
            {
                Console.WriteLine($"- {grupo.Key} (Cantidad: {grupo.Sum(v => v.Cantidad)})");
            }
            Console.WriteLine("=================***=================");
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

        }
    }
}
