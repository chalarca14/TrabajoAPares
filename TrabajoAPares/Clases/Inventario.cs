using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

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


        // guardar el json
        public void GuardarJson()
        {
            List <Producto> listaOrdenada = productos.OrderBy(x => x.Id).ToList();

            string json = JsonSerializer.Serialize(productos, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText("productos.json", json);
        }

        // cargar json
        public void CargarJson()
        {
            if (File.Exists("productos.json"))
            {
                string json = File.ReadAllText("productos.json");

                productos = JsonSerializer.Deserialize<List<Producto>>(json)
                            .OrderBy(p => p.Id)
                            .ToList();
            }
        }
        public void MostrarJson()
        {
            if (File.Exists("productos.json"))
            {
                string json = File.ReadAllText("productos.json");
                Console.WriteLine("\nContenido del JSON:");
                Console.WriteLine(json);
            }
            else
            {
                Console.WriteLine("No existe el archivo JSON.");
            }
        }

        // Constructor: inicializa la lista vacía
        public Inventario()
        {
            productos = new List<Producto>();
        }

        // Registrar un nuevo producto en el inventario
        public void RegistrarProducto(Producto p)
        {
            bool existe = productos.Any(x => x.Id == p.Id || x.Nombre == p.Nombre);

            if (existe)
            {
                Console.WriteLine("Error: ya existe un producto con ese ID o nombre.");
                return;
            }

            productos.Add(p);
            GuardarJson();
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
                GuardarJson();
            }
        }
        public void ActualizarPrecio(int id, decimal nuevoPrecio) 
        {
            Producto p = BuscarPorId(id);
            if (p != null) 
            {
                p.ActualizarPrecio(nuevoPrecio);
                GuardarJson();
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
