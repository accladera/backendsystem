using Core.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Repository
{
    /// <summary>
    /// Repositorio de consulta para clasificadores. Un clasificador es toda tabla que devuelve siempre sus registros o sus registros válidos
    /// </summary>
    public class ClassifierRepository : BaseQueryRepository, IClassifierRepository
    {
        /// <summary>
        /// Contiene las consultas genéricas.
        /// </summary>
        protected static Dictionary<Type, QueriesData> queries;
        /// <summary>
        /// Llave para saber si ya han sido registrados los tipos clasificadores
        /// </summary>
        private static bool registered;
        /// <summary>
        /// Almacena la llave aleatoria para evitar registros posteriores o anteriores al RegisterQueries
        /// </summary>
        private static string randomCode;
        /// <summary>
        /// Owner de la base de datos
        /// </summary>
        private static string owner;
        /// <summary>
        /// Prefijo de las tablas
        /// </summary>
        private static string tablePrefix;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="connectionString">Cadena de conección</param>
        public ClassifierRepository(string connectionString = default) : base(connectionString)
        {
        }

        /// <summary>
        /// Constructor estático de la clase
        /// </summary>
        static ClassifierRepository()
        {
            queries = new Dictionary<Type, QueriesData>();
            registered = false;
        }

        /// <summary>
        /// Se encarga de regitrar un clasificador que hereda de BaseClassifierModel
        /// IMPORTANTE: Debe llamarse desde dentro de la función delegada en RegisterQueries.
        /// </summary>
        /// <typeparam name="TEntity">Tipo a registrar</typeparam>
        /// <param name="key">llave para permitir el registro</param>
        /// <param name="keyName">Nombre de la colmna llave (por defecto n{{NombreTipo sin Model}}Id</param>
        /// <param name="table">Nombre de la tabla (por defecto el nombre del tipo eliminando la palabra final Model)</param>
        /// <param name="name">Nombre de la columna descripción. Por defecto sDescription</param>
        /// <param name="orderBy">Nombre del campo por el que ordenar. Por defecto el valor de descName. Por ejemplo "nReqType" o "nReqType DESC"</param>
        public static void RegisterClassifier<TEntity>(string key, string keyName = null, string table = null, string name = null, string orderBy = null) where TEntity : BaseClassifierModel
        {
            QueriesData items = new QueriesData();
            if (key != randomCode || string.IsNullOrEmpty(randomCode)) { throw new InvalidOperationException("El método debe ser llamado mediante RegisterQueries"); }

            name ??= "sName";
            orderBy ??= name;
            if (string.IsNullOrWhiteSpace(table))
            {
                table = typeof(TEntity).Name;
                table = table.EndsWith("Model") ? table.Remove(table.Length - 5) : table;
            }
            keyName ??= string.Format("n{0}Id", table);

            items.queriesValid = string.Format("SELECT {1} Id, {2} Name FROM {5}{0}  WHERE {1} {{0}} ORDER BY {2}", table, keyName, name, orderBy, owner, tablePrefix);
            items.queriesAll = string.Format("SELECT {1} Id, {2} Name FROM {5}{0}  ORDER BY {2}", table, keyName, name, orderBy, owner, tablePrefix);
            items.queriesById = string.Format("SELECT {1} Id, {2} Name FROM {5}{0} WHERE {1} {{0}} ORDER BY {2}", table, keyName, name, orderBy, owner, tablePrefix);
            items.keyName = keyName;
            queries.Add(typeof(TEntity), items);
        }

        /// <summary>
        /// Registra las consultas para un tipo que no hereda directamente de BaseClassifierModel, o que incorpora más campos de los que tiene la clase base
        /// IMPORTANTE: Debe llamarse desde dentro de la función delegada en RegisterQueries.
        /// </summary>
        /// <typeparam name="TEntity">Tipo del modelo</typeparam>
        /// <param name="key">llave para permitir el registro</param>
        /// <param name="validQuery">Consulta SQL para obtener todos los registros válidos.</param>
        /// <param name="allQuery">Consulta SQL para obtener todos los registros.</param>
        /// <param name="byIdQuery">Consulta SQL para obtener todos los registros válidos por identificador.</param>
        /// <param name="keyName">Nombre de columna del identificador de la tabla.</param>
        public static void RegisterClassifierSpecial<TEntity>(string key, string validQuery, string allQuery, string byIdQuery, string keyName) where TEntity : class
        {
            QueriesData items = new QueriesData();
            if (key != randomCode || string.IsNullOrEmpty(randomCode)) { throw new InvalidOperationException("El método debe ser llamado mediante RegisterQueries"); }
            items.queriesValid = validQuery;
            items.queriesAll = allQuery;
            items.queriesById = byIdQuery;
            items.keyName = keyName;
            queries.Add(typeof(TEntity), items);
        }

        /// <summary>
        /// Se encarga de establecer un único punto de registro para las querys. En la acción delegada invocar a RegisterClassifier y RegisterNonClassifier. Esta acción se puede invocar una única vez
        /// </summary>
        /// <param name="register">Acción delegada invocando a RegisterNonClassifier y/o RegisterNonClassifier.</param>
        /// <param name="_owner">Owner de la base de datos</param>
        /// <param name="_tablePrefix">Prefijo de las tablas de la base de datos</param>
        public static void RegisterQueries(Action<string> register, string _owner, string _tablePrefix)
        {
            if (!registered)
            {
                owner = _owner;
                tablePrefix = _tablePrefix;
                randomCode = RandomString(25);
                register.Invoke(randomCode);
                registered = true;
                randomCode = null;
            }
        }

        /// <summary>
        /// Genera una cadena aleatoria de la longitud deseada
        /// </summary>
        /// <param name="length">Longitud de la cadena aleatoria</param>
        /// <returns>La cadena aleatoria generada</returns>
        private static string RandomString(int length)
        {
            Random random;
            random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Obtiene todos los registros válidos del clasificador
        /// </summary>
        /// <typeparam name="TEntity">Tipo de datos del clasificador que se desea obtener.</typeparam>
        /// <returns>Enumerable de todos los registros válidos del clasificador</returns>
        public async Task<IList<TEntity>> ReadAllValid<TEntity>() where TEntity : class
        {
            return await ReadQuery<TEntity>(queries[typeof(TEntity)].queriesValid);
        }

        /// <summary>
        /// Obtiene todos los registros del clasificador
        /// </summary>
        /// <typeparam name="TEntity">Tipo de datos del clasificador que se desea obtener.</typeparam>
        /// <returns>Enumerable de todos los registros del clasificador</returns>
        public async Task<IList<TEntity>> ReadAll<TEntity>() where TEntity : class
        {
            return await ReadQuery<TEntity>(queries[typeof(TEntity)].queriesAll);
        }

        /// <summary>
        /// Obtiene todos los registros del clasificador por identificador.
        /// </summary>
        /// <typeparam name="TEntity">Tipo de datos del clasificador que se desea obtener.</typeparam>
        /// <param name="keys">Identificadores de la tabla</param>
        /// <returns>Enumerable de todos los registros del clasificador por la llave</returns>
        public async Task<IList<TEntity>> ReadById<TEntity>(IList<int> keys) where TEntity : class
        {
            var item = queries[typeof(TEntity)];
            var sentence = string.Format(item.queriesById, GetOptionalEnumerableInSql(item.keyName, "@nKey", keys));
            return await ReadQuery<TEntity>(sentence, new { nKey = keys });
        }

        /// <summary>
        /// Obtiene el registro del clasificador.
        /// </summary>
        /// <typeparam name="TEntity">Tipo de datos del clasificador que se desea obtener.</typeparam>
        /// <param name="key">Identificador de la tabla</param>
        /// <returns>Devuelve el registro del clasificador por la llave</returns>
        public async Task<TEntity> ReadById<TEntity>(int key) where TEntity : class
        {
            return (await ReadById<TEntity>(new List<int>(1) { key })).Single();
        }

        /// <summary>
        /// Se encarga de ejecutar una consulta enviada por parámetro y devolver su enumerable
        /// </summary>
        /// <typeparam name="TEntity">Tipo de datos del clasificador que se desea obtener.</typeparam>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="sentence">Consulta SQL a ejecutar</param>
        /// <param name="param">Parámetros de la consulta</param>
        /// <returns>Enumerable de todos los registros devueltos por la consulta</returns>
        private async Task<IList<TEntity>> ReadQuery<TEntity>(string sentence, object param = null) where TEntity : class
        {
            using var connection =  new MySqlConnection(_connectionString);
            var result2 = await connection.QueryAsync<TEntity>(sentence, param);
            return result2.AsList();
        }

        protected struct QueriesData
        {
            public string queriesValid;
            public string queriesAll;
            public string queriesById;
            public string keyName;
        }
    }
}