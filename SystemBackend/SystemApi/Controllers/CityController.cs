using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Query.CityQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemApi.Controllers
{
    [Produces("application/json")]
    [Route("api/system/city")]
    [ApiController]

    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }





        /// <summary>
        /// Devuelve lista de roles
        /// </summary>
        /// <returns>Listado de roles</returns>
        [HttpGet("list/")]
        // [TransactionAuthorize]
        [AllowAnonymous]
        public async Task<ActionResult> ListCity()
        {
            try
            {
                return Ok(await _mediator.Send(new ListCityQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Crea un usuario Cliente
        /// </summary>
        /// <param name="Id">Id del libro</param>

        /// <returns>True</returns>
        [HttpGet("{Id}/")]
        // [TransactionAuthorize]
        [AllowAnonymous]
        public async Task<ActionResult> getCityById(int Id)
        {
            try
            {
                return Ok(await _mediator.Send(new GetCityQuery
                {
                    cityId = Id
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Crea un usuario Cliente
        /// </summary>
        /// <param name="Id">Id del libro</param>

        /// <returns>True</returns>
        [HttpGet("{IdCountry}/country")]
        // [TransactionAuthorize]
        [AllowAnonymous]
        public async Task<ActionResult> getListCityByCountry(int IdCountry)
        {
            try
            {
                return Ok(await _mediator.Send(new ListCityByCountryQuery
                {
                    countryId = IdCountry
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }







    }




}