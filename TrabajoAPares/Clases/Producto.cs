using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrabajoAPares.Clases
{
    // Clase que representa un producto dentro del inventario
    public class Producto
    {
        // Propiedades encapsuladas (solo lectura desde fuera, escritura dentro de la clase)
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public decimal Precio { get; private set; }
        public int Stock { get; private set; }

        // Constructor: se usa al crear un nuevo producto
        public Producto(int id, string nombre, decimal precio, int stock)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
        }

        // Método para actualizar el stock
        // cantidad puede ser positiva (entrada de inventario) o negativa (venta)
        public void ActualizarStock(int cantidad)
        {
            Stock += cantidad;
        }

        // Método para cambiar el precio del producto
        public void ActualizarPrecio(decimal nuevoPrecio)
        {
            Precio = nuevoPrecio;
        }

        // Método para mostrar la información del producto en formato legible
        public string MostrarInfo()
        {
            return $"ID: {Id}, Nombre: {Nombre}, Precio: {Precio:C}, Stock: {Stock}";
        }

        // Método que valida si el stock está bajo según un umbral configurable
        public bool StockBajo(int umbral)
        {
            return Stock <= umbral;
        }
    }
}
