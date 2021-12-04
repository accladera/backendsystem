using AutoMapper;
using Core.Repository;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Services.Models.Classifier;
using Services.Services;
using System.Reflection;

namespace Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, string connectionString)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Clasificador
            ClassifierRepository.RegisterQueries((x) =>
            {
                services.RegisterClassiffierAndHandler<AreaWorkModel>(x);
                services.RegisterClassiffierAndHandler<CategoryJobsModel>(x);
                services.RegisterClassiffierAndHandler<CountryModel>(x);
                services.RegisterClassiffierAndHandler<GenderModel>(x);
                services.RegisterClassiffierAndHandler<IdomsModel>(x);
                services.RegisterClassiffierAndHandler<LevelStudyModel>(x);
                services.RegisterClassiffierAndHandler<MaritalStatusModel>(x);
                services.RegisterClassiffierAndHandler<StatusJobsAplicationsByClientModel>(x);
                services.RegisterClassiffierAndHandler<StatusJobsModel>(x);
                services.RegisterClassiffierAndHandler<TypeContactModel>(x);
                services.RegisterClassiffierAndHandler<TypeDocumentModel>(x);
                services.RegisterClassiffierAndHandler<UniversityModel>(x);
                services.RegisterClassiffierAndHandler<TypeContractModel>(x);
                services.RegisterClassiffierAndHandler<LevelIdomModel>(x);


            },
           "sys", "sys_");
            // Todos los repositorys


            services.AddScoped<IClassifierRepository>(x => new ClassifierRepository(connectionString));
            services.AddTransient<ICityRepository, CityRepository>();

            return services;
        }

    }
}
