using AutoMapper;
using Core.Controllers;
using Core.Repository;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Models.Classifier;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{

    [Produces("application/json")]
    [Route("api/system/classifier")]
    [ApiController]
    //[TransactionAuthorize]
    public class ClassifierController : ServiceBaseController
    {
        public ClassifierController(IMapper mapper, IMediator mediator, IClassifierRepository repository) : base(mapper, mediator)
        {

        }

        /// <summary>
        /// Obtiene Area de trabajo
        /// </summary>
        /// <param name = "keys" > Identificadores </param >
        /// <returns>Indentificador</returns>
        [HttpGet("area-work")]
        // [TransactionAuthorize]
        [AllowAnonymous]
        public Task<ActionResult<IList<AreaWorkModel>>> ClasificadorAreaWork([FromQuery] IList<int> keys)
        {

            return SendRequest(new BaseClassifierQuery<AreaWorkModel>(keys: keys));

        }

        /// <summary>
        /// Obtiene Tipo de contraro
        /// </summary>
        /// <param name = "keys" > Identificadores </param >
        /// <returns>Indentificador</returns>
        [HttpGet("type-contract")]
        // [TransactionAuthorize]
        [AllowAnonymous]
        public Task<ActionResult<IList<TypeContractModel>>> ClasificadorTypeContract([FromQuery] IList<int> keys)
        {

            return SendRequest(new BaseClassifierQuery<TypeContractModel>(keys: keys));

        }

        /// <summary>
        /// Obtiene Niveles de idioma
        /// </summary>
        /// <param name = "keys" > Identificadores </param >
        /// <returns>Indentificador</returns>
        [HttpGet("level-idom")]
        // [TransactionAuthorize]
        [AllowAnonymous]
        public Task<ActionResult<IList<LevelIdomModel>>> ClasificadorLevelIdom([FromQuery] IList<int> keys)
        {

            return SendRequest(new BaseClassifierQuery<LevelIdomModel>(keys: keys));

        }


        /// <summary>
        /// Obtiene el clasificador Categoria de trabajo
        /// </summary>
        /// <param name = "keys" > Identificadores </param >
        /// <returns>Indentificador</returns>
        [HttpGet("category-job")]
        // [TransactionAuthorize]
        [AllowAnonymous]
        public Task<ActionResult<IList<CategoryJobsModel>>> ClasificadorCateogoryJobs([FromQuery] IList<int> keys)
        {

            return SendRequest(new BaseClassifierQuery<CategoryJobsModel>(keys: keys));

        }

        /// <summary>
        /// Obtiene el clasificador de pais
        /// </summary>
        /// <param name = "keys" > Identificadores </param >
        /// <returns>Indentificador</returns>
        [HttpGet("country")]
        // [TransactionAuthorize]
        [AllowAnonymous]
        public Task<ActionResult<IList<CountryModel>>> ClasificadorCountry([FromQuery] IList<int> keys)
        {

            return SendRequest(new BaseClassifierQuery<CountryModel>(keys: keys));
        }

        
        /// <summary>
        /// Obtiene el clasificador de genero
        /// </summary>
        /// <param name = "keys" > Identificadores </param >
        /// <returns>Indentificador</returns>
        [HttpGet("gender")]
        // [TransactionAuthorize]
        [AllowAnonymous]
        public Task<ActionResult<IList<GenderModel>>> ClasificadorGender([FromQuery] IList<int> keys)
        {

            return SendRequest(new BaseClassifierQuery<GenderModel>(keys: keys));

        }

        /// <summary>
        /// Obtiene el clasificador de idioma
        /// </summary>
        /// <param name = "keys" > Identificadores </param >
        /// <returns>Indentificador</returns>
        [HttpGet("idoms")]
        // [TransactionAuthorize]
        [AllowAnonymous]
        public Task<ActionResult<IList<IdomsModel>>> ClasificadorIdoms([FromQuery] IList<int> keys)
        {

            return SendRequest(new BaseClassifierQuery<IdomsModel>(keys: keys));

        }

        /// <summary>
        /// Obtiene el clasificador de nivel estudio
        /// </summary>
        /// <param name = "keys" > Identificadores </param >
        /// <returns>Indentificador</returns>
        [HttpGet("level-study")]
        // [TransactionAuthorize]
        [AllowAnonymous]
        public Task<ActionResult<IList<LevelStudyModel>>> ClasificadorLevelStudy([FromQuery] IList<int> keys)
        {

            return SendRequest(new BaseClassifierQuery<LevelStudyModel>(keys: keys));

        }


        /// <summary>
        /// Obtiene el clasificador de Casado o no
        /// </summary>
        /// <param name = "keys" > Identificadores </param >
        /// <returns>Indentificador</returns>
        [HttpGet("marital-status")]
        // [TransactionAuthorize]
        [AllowAnonymous]
        public Task<ActionResult<IList<MaritalStatusModel>>> ClasificadorMaritalStatus([FromQuery] IList<int> keys)
        {

            return SendRequest(new BaseClassifierQuery<MaritalStatusModel>(keys: keys));

        }

        /// <summary>
        /// Obtiene el clasificador de estado trabajo
        /// </summary>
        /// <param name = "keys" > Identificadores </param >
        /// <returns>Indentificador</returns>
        [HttpGet("status-jobs")]
        // [TransactionAuthorize]
        [AllowAnonymous]
        public Task<ActionResult<IList<StatusJobsModel>>> ClasificadorStatusJobs([FromQuery] IList<int> keys)
        {

            return SendRequest(new BaseClassifierQuery<StatusJobsModel>(keys: keys));

        }

        /// <summary>
        /// Obtiene el clasificador de trabajo del cliente 
        /// </summary>
        /// <param name = "keys" > Identificadores </param >
        /// <returns>Indentificador</returns>
        [HttpGet("status-jobs-application-client")]
        // [TransactionAuthorize]
        [AllowAnonymous]
        public Task<ActionResult<IList<StatusJobsAplicationsByClientModel>>> ClasificadorStatusJobsAplicationClient([FromQuery] IList<int> keys)
        {

            return SendRequest(new BaseClassifierQuery<StatusJobsAplicationsByClientModel>(keys: keys));

        }

        /// <summary>
        /// Obtiene el clasificador de tipo de contacto
        /// </summary>
        /// <param name = "keys" > Identificadores </param >
        /// <returns>Indentificador</returns>
        [HttpGet("type-contact")]
        // [TransactionAuthorize]
        [AllowAnonymous]
        public Task<ActionResult<IList<TypeContactModel>>> ClasificadorTypeContact([FromQuery] IList<int> keys)
        {

            return SendRequest(new BaseClassifierQuery<TypeContactModel>(keys: keys));

        }

        /// <summary>
        /// Obtiene el clasificador de tipo documento
        /// </summary>
        /// <param name = "keys" > Identificadores </param >
        /// <returns>Indentificador</returns>
        [HttpGet("type-document")]
        // [TransactionAuthorize]
        [AllowAnonymous]
        public Task<ActionResult<IList<TypeDocumentModel>>> ClasificadorTypeDocument([FromQuery] IList<int> keys)
        {

            return SendRequest(new BaseClassifierQuery<TypeDocumentModel>(keys: keys));

        }

        /// <summary>
        /// Obtiene el clasificador de universidad
        /// </summary>
        /// <param name = "keys" > Identificadores </param >
        /// <returns>Indentificador</returns>
        [HttpGet("university")]
        // [TransactionAuthorize]
        [AllowAnonymous]
        public Task<ActionResult<IList<UniversityModel>>> ClasificadorUniversity([FromQuery] IList<int> keys)
        {

            return SendRequest(new BaseClassifierQuery<UniversityModel>(keys: keys));

        }







    }
}