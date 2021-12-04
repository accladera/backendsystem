using Core.AggreateRoot;
using Core.Classifier;
using Core.Models;
using Core.Repository;
using Data.Configurations;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Data.Database
{
    public class DataBaseContext : BaseDbContext
    {
        public DataBaseContext()
        {
        }

        public DataBaseContext(IMediator mediator) : base(mediator)
        {
        }

        public DataBaseContext(DbContextOptions<DataBaseContext> options, IMediator mediator)
            : base(options, mediator)
        {
        }

        public override string Owner => "sys";
        public override string TablePrefix => "sys_";

       

        protected override void OnPreModelCreating(ModelBuilder modelBuilder)
        {


            // Registro de los clasificadores
            modelBuilder.RegisterClassifiers();

            modelBuilder.ApplyConfiguration(new CityConfigurations());

         

        }

        public DbSet<City> Citys { get; set; }



    }
}
