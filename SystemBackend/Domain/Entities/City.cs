using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using Core.AggreateRoot;

namespace Domain.Entities
{
    public class City : BaseModel, IAggregateRoot
    {
        public override int Id { get; protected set; }

        public string Name { get; set; }

        public int CountyId { get; set; }

        public Country Country { get; set; }

        public City(int id, string name, int countyId)
        {
            Id = id;
            Name = name;
            CountyId = countyId;
        }
    }
}
