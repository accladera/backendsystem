using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Core.Classifier
{
    /// <summary>
    /// Clase de configuración para las entidades de system
    /// </summary>
    /// <typeparam name="TEntity">El tipo de datos de una entidad que deriva de Core.Clasifier</typeparam>
	public class ClassifierConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Core.Classifier.BaseClassifier
	{
        /// <summary>
        /// Genera una nueva instancia del configurador con los valores dados por defecto
        /// </summary>
        /// <param name="keyName">Nombre de la columna de la llave primaria</param>
        /// <param name="seed">Listado de valores que con los cuales inicializar el clasificador</param>
        /// <param name="descLength">Longitud de la columna descripción</param>
        /// <param name="descName">Nombre de la columna descripción</param>
        public ClassifierConfiguration(TEntity[] seed = null, string keyName = null, int descLength = 100, string descName = "sName")
        {

            KeyName = keyName??string.Format("n{0}Id", typeof(TEntity).Name);
            DescLength = descLength;
            DescName = descName;
            Seed = seed;
        }

        /// <summary>
        /// Nombre de la columna de la llave primaria
        /// </summary>
        public string KeyName { get; private set; }

        /// <summary>
        /// Longitud de la columna descripción
        /// </summary>
        public int DescLength { get; private set; }

        /// <summary>
        /// Nombre de la columna descripción
        /// </summary>
        public string DescName { get; private set; }

        /// <summary>
        /// Listado de valores que con los cuales inicializar el clasificador
        /// </summary>
        public IList<TEntity> Seed { get; private set; }

    

        /// <summary>
        /// Realiza la configuración del clasificador según los valores dados.
        /// </summary>
        /// <param name="builder"></param>
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
		{
            builder.Property(p => p.Id).HasColumnName(KeyName);
            builder.Property(p => p.Name).HasColumnName(DescName);
            builder.Property(p => p.Name).HasMaxLength(DescLength);
            

            if(Seed is not null)
            {
                foreach(TEntity item in Seed)
                {
                    builder.HasData(item);
                }
            }
        }
	}
}
