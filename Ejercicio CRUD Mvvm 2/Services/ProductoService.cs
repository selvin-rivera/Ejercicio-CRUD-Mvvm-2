using Ejercicio_CRUD_Mvvm_2.Models;
using SQLite;

namespace Ejercicio_CRUD_Mvvm_2.Services
{
    public class ProductoService
    {
        private readonly SQLiteConnection dbConnection;

        public ProductoService()
        {
            // Construir ruta
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Producto.db3");

            //Inicializamos el objeto
            dbConnection = new SQLiteConnection(dbPath);

            //Creamos la tabla Producto
            dbConnection.CreateTable<Producto>();

        }

        /// <summary>
        /// Lista todos los empleados
        /// </summary>
        /// <returns>Una lista de empleados</returns>
        public List<Producto> GetAll()
        {
            var res = dbConnection.Table<Producto>().ToList();
            return res;
        }

        /// <summary>
        /// Guarda un producto a la base de datos
        /// </summary>
        /// <param name="producto">Objeto con datos del producto a guardar</param>
        /// <returns>Cantidad de registros ingresados</returns>
        public int Insert(Producto producto)
        {
            return dbConnection.Insert(producto);
        }

        /// <summary>
        /// Actualiza un producto seleccionado
        /// </summary>
        /// <param name="producto">Objeto con datos del producto a actualizar</param>
        /// <returns>Cantidad de resgistros actualizados</returns>
        public int Update(Producto producto)
        {
            return dbConnection.Update(producto);
        }

        /// <summary>
        /// Elimina un producto
        /// </summary>
        /// <param name="producto">Objeto con datos del producto a eliminar</param>
        /// <returns>Cantidad de resgistros eliminados</returns>
        public int Delete(Producto producto)
        {
            return dbConnection.Delete(producto);
        }
    }
}
