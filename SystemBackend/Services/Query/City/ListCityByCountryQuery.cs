using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Query.CityQuery
{
    public class ListCityByCountryQuery : IRequest<List<City>>
    {
        public int countryId { get; set; }
    }
}