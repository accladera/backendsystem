using Core.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Core.Repository
{
    /// <summary>
    /// Clase que extiende métodos
    /// </summary>
    public static class Service
    {
        /// <summary>
        /// Se encarga de regitrar un clasificador que hereda de BaseClassifierModel, y registra la asociación correspondiente entre 
        /// "IRequestHandler<BaseClassifierQuery<TClassifier>, IList<TClassifier>>" y "BaseClassifierQueryHandler<TClassifier>"
        /// IMPORTANTE: Debe llamarse desde dentro de la función delegada en RegisterQueries.
        /// </summary>
        /// <typeparam name="TEntity">Tipo a registrar</typeparam>
        /// <param name="key">llave para permitir el registro</param>
        /// <param name="keyName">Nombre de la colmna llave (por defecto n{{NombreTipo sin Model}}Id</param>
        /// <param name="table">Nombre de la tabla (por defecto el nombre del tipo eliminando la palabra final Model)</param>
        /// <param name="descName">Nombre de la columna descripción. Por defecto sDescription</param>
        /// <param name="statusName">Nombre de la columna de estado. Por defecto bStatus</param>
        /// <param name="orderBy">Nombre del campo por el que ordenar. Por defecto el valor de descName. Por ejemplo "nReqType" o "nReqType DESC"</param>
        public static void RegisterClassiffierAndHandler<TClassifier>(this IServiceCollection services, string key, string keyName = null, string table = null, string descName = null, string orderBy = null) where TClassifier : BaseClassifierModel
        {
            ClassifierRepository.RegisterClassifier<TClassifier>(key, keyName, table, descName, orderBy);
            services.AddTransient<IRequestHandler<BaseClassifierQuery<TClassifier>, IList<TClassifier>>, BaseClassifierQueryHandler<TClassifier>>();
        }

        /// <summary>
        /// Registra las consultas para un tipo que no hereda directamente de BaseClassifierModel, o que incorpora más campos de los que tiene la clase base, y registra la 
        /// asociación correspondiente entre "IRequestHandler<BaseClassifierQuery<TEntity>, IList<TEntity>>" y "BaseClassifierQueryHandler<TEntity>"
        /// IMPORTANTE: Debe llamarse desde dentro de la función delegada en RegisterQueries.
        /// </summary>
        /// <typeparam name="TEntity">Tipo del modelo</typeparam>
        /// <param name="key">llave para permitir el registro</param>
        /// <param name="validQuery">Consulta SQL para obtener todos los registros válidos.</param>
        /// <param name="allQuery">Consulta SQL para obtener todos los registros.</param>
        /// <param name="byIdQuery">Consulta SQL para obtener todos los registros válidos por identificador.</param>
        /// <param name="keyName">Nombre de columna del identificador de la tabla.</param>
        public static void RegisterClassiffierSpecialAndHandler<TEntity>(this IServiceCollection services, string key, string validQuery, string allQuery, string byIdQuery, string keyName) where TEntity : class
        {
            ClassifierRepository.RegisterClassifierSpecial<TEntity>(key, validQuery, allQuery, byIdQuery, keyName);
            services.AddTransient<IRequestHandler<BaseClassifierQuery<TEntity>, IList<TEntity>>, BaseClassifierQueryHandler<TEntity>>();
        }
    }
}
