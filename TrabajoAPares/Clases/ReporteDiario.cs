using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoAPares.Clases
{
    internal class ReporteDiario
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

    }
}
