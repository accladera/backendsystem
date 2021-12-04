using Core.AggreateRoot;
using Core.Classifier;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Repository
{
    /// <summary>
    /// Clase que implementa un repositorio para los clasificadores genéricos
    /// </summary>
    /// <typeparam name="TClassiffier">Tipo del clasificador</typeparam>
    /// <typeparam name="TServiceContext">Tipo del DbContext del proyecto</typeparam>
    public class GenericClassiffierRepository<TClassiffier, TServiceContext> :
        BaseRepository<TClassiffier>,
        IClassiffierRepository<TClassiffier> 
            where TClassiffier : BaseClassifier, IAggregateRoot
            where TServiceContext : DbContext, IUnitOfWork
    {
        /// <summary>
        /// Referencia al contexto de ejecución de EF
        /// </summary>
        protected readonly TServiceContext _context;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="context"></param>
        public GenericClassiffierRepository(TServiceContext context) 
        {
            _context = context;
        }

        /// <summary>
        /// DataSet de la entidad Root
        /// </summary>
        protected override DbSet<TClassiffier> DataSet { get => _context.Set<TClassiffier>(); }

        /// <summary>
        /// Objeto que implementa el patron de unidad de trabajo
        /// </summary>
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        /// <summary>
        /// Añade una entidad a la unidad de trabajo. Se usa para entidades nuevas que no están siendo mapeadas
        /// </summary>
        /// <param name="item">Item a añadir</param>
        /// <returns>Retorna la entidad añadida</returns>
        public TClassiffier Add(TClassiffier item)
        {
            return AddAux(item);
        }

        /// <summary>
        /// Elimina una entidad a la unidad de trabajo. Se usa para entidades que ya están siendo mapeadas
        /// </summary>
        /// <param name="item">Item a actualizar</param>
        /// <returns>Retorna la entidad añadida</returns>
        public void Delete(TClassiffier item)
        {
            DeleteAux(item);
        }

        /// <summary>
        /// Actualiza una entidad a la unidad de trabajo. Se usa para entidades que ya están siendo mapeadas
        /// </summary>
        /// <param name="item">Item a actualizar</param>
        /// <returns>Retorna la entidad añadida</returns>
        public TClassiffier Update(TClassiffier item)
        {
            return UpdateAux(item);
        }

        /// <summary>
        /// Busca un clasificador basado en el ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TClassiffier> FindByIdAsync(int id)
        {
            var item = await DataSet
                .Where(b => b.Id == id)
                .SingleOrDefaultAsync();

            return item;
        }

        /// <summary>
        /// Busca un clasificador con el mismo nombre que el parámetro dado
        /// </summary>
        /// <param name="description">Nombre del clasificador a buscar</param>
        /// <returns></returns>
        public IEnumerable<TClassiffier> FindByNameAsync(string description)
        {
            var item = DataSet.Where(r => r.Name == description).AsNoTracking().ToList();

            return item;
        }
    }
}
