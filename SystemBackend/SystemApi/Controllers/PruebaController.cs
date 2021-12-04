using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Domain.Entities;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/system/")]
    [ApiController]

    public class PruebaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PruebaController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Actualiza el usuario.
        /// </summary>

        /// <returns>Tipo de documento y proveedor generado</returns>
        [HttpGet("prueba/")]
        // [TransactionAuthorize]
        [AllowAnonymous]
        public async Task<ActionResult> Prueba()
        {
            try
            {
                return Ok("Prueba");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }




}
