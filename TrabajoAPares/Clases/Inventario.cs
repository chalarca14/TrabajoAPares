using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoAPares.Clases
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // Clase que gestiona la lista de productos
    public class Inventario
    {
        // Lista interna de productos
        private List<Producto> productos;

        // Constructor: inicializa la lista vacía
        public Inventario()
        {
            productos = new List<Producto>();
        }

        // Registrar un nuevo producto en el inventario
        public void RegistrarProducto(Producto p)
        {
            productos.Add(p);
        }

        // Buscar producto por ID
        public Producto BuscarPorId(int id)
        {
            return productos.FirstOrDefault(p => p.Id == id);
        }

        // Buscar producto por nombre
        public Producto BuscarPorNombre(string nombre)
        {
            return productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }

        // Actualizar stock de un producto específico
        public void ActualizarStock(int id, int cantidad)
        {
            Producto p = BuscarPorId(id);
            if (p != null)
            {
                p.ActualizarStock(cantidad);
            }
        }

        // Mostrar todos los productos del inventario
        public void MostrarInventario()
        {
            foreach (var p in productos)
            {
                Console.WriteLine(p.MostrarInfo());
            }
        }

        // Obtener lista de productos con stock bajo
        public List<Producto> ObtenerProductosConStockBajo(int umbral)
        {
            return productos.Where(p => p.StockBajo(umbral)).ToList();
        }
    }
}
