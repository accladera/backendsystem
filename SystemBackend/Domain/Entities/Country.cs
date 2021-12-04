using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Country : BaseClassifier
    {
        public Country(int id, string name, DateTime computed) : base(id, name, computed)
        {
            _city = new List<City>();
        }

        /// <summary>
        /// Listado de ciudad
        /// </summary>
        private readonly List<City> _city;

        /// <summary>
        /// Listado ciudad
        /// </summary>
        public virtual IReadOnlyList<City> City => _city;



    }
}
