using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Core.Models
{
    /// <summary>
    /// Interfaz que deben implementar los modelos para almacenarse en caché como diccionarios y listados
    /// </summary>
    public interface ICacheStorable
    {
        /// <summary>
        /// Llave a utilizar en el diccionario
        /// </summary>
        public int Id { get; }
    }
}
