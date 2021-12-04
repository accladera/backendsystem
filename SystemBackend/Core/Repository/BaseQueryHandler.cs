using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Repository
{
    /// <summary>
    /// Clase base para handlers de consultas
    /// </summary>
    /// <typeparam name="TRepository">Repositorio a utilizar</typeparam>
    /// <typeparam name="TRequst">Clase comando</typeparam>
    /// <typeparam name="TResponse">Clase respuesta</typeparam>
    public abstract class BaseQueryHandler<TRepository, TRequst, TResponse> :
        IRequestHandler<TRequst, TResponse>
        where TRepository : class
        where TRequst : IRequest<TResponse>
        where TResponse : class
    {
        /// <summary>
        /// Referencia al repositorio
        /// </summary>
        protected readonly TRepository _repository;

        /// <summary>
        /// Constructor con inyección de dependencias
        /// </summary>
        /// <param name="repository">Referencia al repositorio</param>
        public BaseQueryHandler(TRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Se encarga de hestionar el comando
        /// </summary>
        /// <param name="request">Solicitud del comando</param>
        /// <param name="cancellationToken">Token de cancelación</param>
        /// <returns></returns>
        public abstract Task<TResponse> Handle(TRequst request, CancellationToken cancellationToken);

    }
}
