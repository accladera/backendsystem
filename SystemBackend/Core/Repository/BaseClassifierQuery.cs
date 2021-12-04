using MediatR;
using System.Collections.Generic;

namespace Core.Repository
{
    /// <summary>
    /// Clase base genérica para QueryCommands de clasificadores. Se gestiona Core.BaseClassifierQueryHandler<TClassifierModel>
    /// </summary>
    /// <typeparam name="TClassifierModel"></typeparam>
    public class BaseClassifierQuery<TClassifierModel> : IRequest<IList<TClassifierModel>>
    {
        /// <summary>
        /// Crea una nueva isntancia del QueryCommand
        /// </summary>
        public BaseClassifierQuery( IList<int> keys = null)
        {
            Keys = keys;
         }


        /// <summary>
        /// Identificadores de tabla.
        /// </summary>
        public IList<int> Keys { get; set; }
    }
}
