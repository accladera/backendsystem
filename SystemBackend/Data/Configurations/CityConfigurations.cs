using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Data.Configurations
{
    public class CityConfigurations : IEntityTypeConfiguration<City>
	{
		public virtual void Configure(EntityTypeBuilder<City> builder)
		{
			builder.HasKey(sc => new { sc.Id });

			builder
		   .HasOne<Country>(s => s.Country)
		   .WithMany(g => g.City)
		   .HasForeignKey(s => s.CountyId);


			builder.HasData(
			new City(1, "Santa Cruz Sierra", 1),
			new City(2, "La Paz", 1),
			new City(3, "Cochabamba", 1),
			new City(4, "Beni", 1),
			new City(5, "Pando", 1),
			new City(6, "Chuquisaca", 1),
			new City(7, "Potosi", 1),
			new City(8, "Oruro", 1)
			);

			
					
		}
	}
}