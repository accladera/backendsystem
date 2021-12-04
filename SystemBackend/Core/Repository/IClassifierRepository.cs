using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repository
{
    /// <summary>
    /// Interfaz del repositorio de consulta para clasificadores. Un clasificador es toda tabla que devuelve siempre sus registros o sus registros válidos
    /// </summary>
    public interface IClassifierRepository
    {

        /// <summary>
        /// Obtiene todos los registros válidos del clasificador
        /// </summary>
        /// <typeparam name="TEntity">Tipo de datos del clasificador que se desea obtener.</typeparam>
        /// <returns>Enumerable de todos los registros válidos del clasificador</returns>
        Task<IList<TEntity>> ReadAll<TEntity>() where TEntity : class;

        /// <summary>
        /// Obtiene todos los registros del clasificador
        /// </summary>
        /// <typeparam name="TEntity">Tipo de datos del clasificador que se desea obtener.</typeparam>
        /// <returns>Enumerable de todos los registros del clasificador</returns>
        Task<IList<TEntity>> ReadAllValid<TEntity>() where TEntity : class;

        /// <summary>
        /// Obtiene todos los registros del clasificador por identificador.
        /// </summary>
        /// <typeparam name="TEntity">Tipo de datos del clasificador que se desea obtener.</typeparam>
        /// <param name="keys">Identificadores de la tabla</param>
        /// <returns>Enumerable de todos los registros del clasificador por la llave</returns>
        Task<IList<TEntity>> ReadById<TEntity>(IList<int> keys) where TEntity : class;

        /// <summary>
        /// Obtiene el registro del clasificador.
        /// </summary>
        /// <typeparam name="TEntity">Tipo de datos del clasificador que se desea obtener.</typeparam>
        /// <param name="key">Identificador de la tabla</param>
        /// <returns>Devuelve el registro del clasificador por la llave</returns>
        Task<TEntity> ReadById<TEntity>(int key) where TEntity : class;
    }
}