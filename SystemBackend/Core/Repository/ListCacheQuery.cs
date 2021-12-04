using Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    /// <summary>
    /// Clase genérca para peticiones de que piden listados de cosas que se encuentran en caché
    /// </summary>
    /// <typeparam name="T">Objeto de tipo T que implemente ICacheStorable</typeparam>
    public class ListCacheQuery<T> : IRequest<IEnumerable<T>> where T : ICacheStorable
    {
        /// <summary>
        /// Crea una neuva isntancia de la solicitud de consulta
        /// </summary>
        /// <param name="cacheKey">Llave a usar en la caché. Nulo si el tipo T la define como atributo Table</param>
        public ListCacheQuery(string cacheKey = null)
        {
            CacheKey = cacheKey;
        }

        /// <summary>
        /// Llave a usar en la caché. Nulo si el tipo T la define como atributo Table
        /// </summary>
        public string CacheKey { get; private set; }

    }
}
