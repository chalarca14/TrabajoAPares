using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoAPares.Clases
{
    internal class Venta
    {
        public int IdVenta {get; set;}
        public Producto Producto {get; set;}
        public int Cantidad {get; set;}
        public decimal Total {get; set;}

        public Venta(int idVenta, Producto producto, int cantidad)
        {
            IdVenta = idVenta;
            Producto = producto;
            Cantidad = cantidad;
            Total = producto.Precio * cantidad;

        }
        public string MostrarInfo() 
        {
            return $"Venta #{IdVenta} | {Fecha} | Producto: {ProductoVendido.Nombre} | Cantidad: {Cantidad} | Total: ${Total}"; 
        }

    }
}
