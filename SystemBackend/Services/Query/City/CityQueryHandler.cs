using Domain.Entities;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Threading;

namespace Services.Query.CityQuery
{
    public class CityQueryHandler :
           IRequestHandler<GetCityQuery, City>,
        IRequestHandler<ListCityByCountryQuery, List<City>>,
        IRequestHandler<ListCityQuery, List<City>>


    {
        private readonly ICityRepository _repository;

        public CityQueryHandler(
           ICityRepository roleRepository)
        {
            _repository = roleRepository;
        }

        public async Task<City> Handle(GetCityQuery request, CancellationToken cancellationToken)
        {
            return await _repository.getCityById(request.cityId);
        }

        public async Task<List<City>> Handle(ListCityByCountryQuery request, CancellationToken cancellationToken)
        {
            return await _repository.getListCityByCountry(request.countryId);
        }

        public async Task<List<City>> Handle(ListCityQuery request, CancellationToken cancellationToken)
        {
            return await _repository.getListCity();
        }
    }
}