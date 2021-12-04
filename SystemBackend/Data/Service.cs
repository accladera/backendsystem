
using Core.AggreateRoot;
using Core.Classifier;
using Core.Repository;
using Data.Database;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Data
{
    /// <summary>
    /// Clase utilizada para extender métodos de registro de esta capa particular del servicio
    /// </summary>
    public static class Service
    {
        public static void RegisterClassifiers(this ModelBuilder modelBuilder)
        {
            {
    
            modelBuilder.ApplyConfiguration(new ClassifierConfiguration<AreaWork>(new AreaWork[] {
                new AreaWork(1, "Dirección",  DateTime.Now),
                new AreaWork(2, "Recursos humanos", DateTime.Now),
                new AreaWork(3, "Producción",DateTime.Now),
                new AreaWork(4, "Finanzas o contabilidad", DateTime.Now),
                new AreaWork(5, "Marketing y ventas", DateTime.Now),
                new AreaWork(6, "Innovación", DateTime.Now),
                new AreaWork(7, "Tecnología", DateTime.Now),
                new AreaWork(8, "Servicio al cliente", DateTime.Now)
            }));

            modelBuilder.ApplyConfiguration(new ClassifierConfiguration<CategoryJobs>(new CategoryJobs[] {
               new CategoryJobs(1, "Ing Sistemas", DateTime.Now),
                new CategoryJobs(2, "Agricultura y campo", DateTime.Now),
                new CategoryJobs(3, "Arquictectura", DateTime.Now),
                new CategoryJobs(4, "Atencion al cliente", DateTime.Now),
                new CategoryJobs(5, "Banca y finanzas", DateTime.Now),
                new CategoryJobs(6, "Cientifico e Investigacio", DateTime.Now),
                new CategoryJobs(7, "Atencion al cliente", DateTime.Now),
                new CategoryJobs(8, "Construccion", DateTime.Now),
                new CategoryJobs(9, "Cocina y Reposteria", DateTime.Now),
            }));


            modelBuilder.ApplyConfiguration(new ClassifierConfiguration<Country>(new Country[] {
               new Country(1, "Bolivia", DateTime.Now),
               new Country(2, "Argentina", DateTime.Now),
               new Country(3, "Chile", DateTime.Now),
               new Country(4, "Paraguay", DateTime.Now),
               new Country(5, "Mexico", DateTime.Now),
            }));


              
                modelBuilder.ApplyConfiguration(new ClassifierConfiguration<Gender>(new Gender[] {
               new Gender(1, "Masculino", DateTime.Now),
               new Gender(2, "Femenino", DateTime.Now),
               new Gender(3, "Otros", DateTime.Now)
                 }));


              

                 modelBuilder.ApplyConfiguration(new ClassifierConfiguration<Idoms>(new Idoms[] {
               new Idoms(1, "Español", DateTime.Now),
               new Idoms(2, "Ingles", DateTime.Now),
               new Idoms(3, "Otros", DateTime.Now)
                }));



             

                modelBuilder.ApplyConfiguration(new ClassifierConfiguration<LevelStudy>(new LevelStudy[] {
               new LevelStudy(1, "Secundaria", DateTime.Now),
               new LevelStudy(2, "Universidad", DateTime.Now),
               new LevelStudy(3, "Otros", DateTime.Now)
            }));

             


                modelBuilder.ApplyConfiguration(new ClassifierConfiguration<MaritalStatus>(new MaritalStatus[] {
               new MaritalStatus(1, "Casado", DateTime.Now),
               new MaritalStatus(2, "Soltero", DateTime.Now),
               new MaritalStatus(3, "Viudo", DateTime.Now)
            }));


                modelBuilder.ApplyConfiguration(new ClassifierConfiguration<StatusJobsAplicationsByClient>(new StatusJobsAplicationsByClient[] {
               new StatusJobsAplicationsByClient(1, "En Espera", DateTime.Now),
               new StatusJobsAplicationsByClient(2, "Rechazado", DateTime.Now),
               new StatusJobsAplicationsByClient(3, "Aceptado", DateTime.Now)
            }));

                

                modelBuilder.ApplyConfiguration(new ClassifierConfiguration<StatusJobs>(new StatusJobs[] {
               new StatusJobs(1, "En Proceso", DateTime.Now),
               new StatusJobs(2, "En Busca Solicitantes", DateTime.Now),
               new StatusJobs(3, "En Selecion", DateTime.Now),
               new StatusJobs(4, "En Finalizado", DateTime.Now)
                }));


                modelBuilder.ApplyConfiguration(new ClassifierConfiguration<TypeContact>(new TypeContact[] {
               new TypeContact(1, "Anonimo", DateTime.Now),
               new TypeContact(2, "Familiares", DateTime.Now),
               new TypeContact(3, "Primos", DateTime.Now)
                }));

           

                modelBuilder.ApplyConfiguration(new ClassifierConfiguration<TypeDocument>(new TypeDocument[] {
               new TypeDocument(1, "Cedula de Identidad", DateTime.Now),
               new TypeDocument(2, "Pasaporte", DateTime.Now),
               new TypeDocument(3, "Otros", DateTime.Now)
                }));

                modelBuilder.ApplyConfiguration(new ClassifierConfiguration<University>(new University[] {
               new University(1, "Universidad Nur", DateTime.Now),
               new University(2, "Grabiel Autonoma", DateTime.Now),
               new University(3, "Universidad UPSA", DateTime.Now)
                }));

                modelBuilder.ApplyConfiguration(new ClassifierConfiguration<TypeContract>(new TypeContract[] {
               new TypeContract(1, "Tiempo completo", DateTime.Now),
               new TypeContract(2, "Medio tiempo", DateTime.Now),
               new TypeContract(3, "Pasantía", DateTime.Now)
                }));

                modelBuilder.ApplyConfiguration(new ClassifierConfiguration<LevelIdom>(new LevelIdom[] {
               new LevelIdom(1, "Básico", DateTime.Now),
               new LevelIdom(2, "Intermedio", DateTime.Now),
               new LevelIdom(3, "Avanzado", DateTime.Now)
                }));

            }
        }

        public static void RegisterDataCommand(this IServiceCollection services, string connectionString)
        {
          
        }

        /// <summary>
        /// Se encarga de regitrar un repositorio para gestiona ABM de un clasificador que hereda de BaseClassifierModel e implementa IAggreggateRoot
        /// IMPORTANTE: Debe llamarse desde dentro de la función delegada en RegisterQueries.
        /// </summary>
        /// <typeparam name="TClassifier">Tipo del clasigficador a registrar</typeparam>
        /// <paramref name="services">Instancia a extender</paramref>
        public static void RegisterClassiffierCommand<TClassifier>(this IServiceCollection services) where TClassifier : Core.Classifier.BaseClassifier, IAggregateRoot, new()
        {
            services.AddScoped<IClassiffierRepository<TClassifier>, GenericClassiffierRepository<TClassifier, DataBaseContext>>();

        }
    }
}