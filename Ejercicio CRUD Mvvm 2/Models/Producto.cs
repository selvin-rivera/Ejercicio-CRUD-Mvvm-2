using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_CRUD_Mvvm_2.Models
{
    public class Producto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string Nombre { get; set; }
       
       
        public string Descripcion { get; set; }

       
        public string Ubicacion { get; set; }

        
        public string Proveedor { get; set; }

    }
}
