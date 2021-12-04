using Core.Repository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface ICityRepository : IRepository<City>
    {
        Task<City> getCityById(int id);

        Task<List<City>> getListCity();

        Task<List<City>> getListCityByCountry(int countryId);

    }
}
