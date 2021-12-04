using Data.Database;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(DataBaseContext context) : base(context)
        {
        }

        public Core.Repository.IUnitOfWork UnitOfWork => _context;

        public City Add(City entity)
        {
            return AddAux(entity);
        }

        public City Update(City entity)
        {
            return UpdateAux(entity);
        }

        public async Task<City> getCityById(int id)
        {
            return await _context.Citys.Where(ele => ele.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<City>> getListCity()
        {
            return await _context.Citys.ToListAsync();

        }

        public async Task<List<City>> getListCityByCountry(int countryId)
        {
            return await _context.Citys.Where(ele => ele.CountyId == countryId).ToListAsync();
        }






    }
}