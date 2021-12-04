using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Services.Query.CityQuery
{
    public class GetCityQuery : IRequest<City>
    {
        public int cityId { get; set; }
    }
}