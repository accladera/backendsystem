using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Repository
{
    /// <summary>
    /// Clase base para handlers de queris de clasificadores
    /// </summary>
    /// <typeparam name="TRequst">Clase solicitud de query</typeparam>
    /// <typeparam name="TClassifier">Clasificador que maneja</typeparam>
    public class BaseClassifierQueryHandler<TClassifier> :
        IRequestHandler<BaseClassifierQuery<TClassifier>, IList<TClassifier>>
        where TClassifier : class
    {

        /// <summary>
        /// Referencia al repositorio
        /// </summary>
        private readonly IClassifierRepository _repository;

        /// <summary>
        /// Constructor con inyección de dependencias
        /// </summary>
        /// <param name="repository">Referencia al repositorio</param>
        public BaseClassifierQueryHandler(IClassifierRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Se encarga de hestionar el comando
        /// </summary>
        /// <param name="request">Solicitud del comando</param>
        /// <param name="cancellationToken">Token de cancelación</param>
        /// <returns></returns>
        public Task<IList<TClassifier>> Handle(BaseClassifierQuery<TClassifier> request, CancellationToken cancellationToken)
        {
            Task<IList<TClassifier>> record;

            if (request.Keys is not null && request.Keys.Count>0)
            {
                record = _repository.ReadById<TClassifier>(request.Keys);
            }
            else
            {
               
                    record = _repository.ReadAll<TClassifier>();
              
            }

            return record;
        }
    }
}