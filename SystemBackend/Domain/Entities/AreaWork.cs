using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using Core.AggreateRoot;

namespace Domain.Entities
{
    public class AreaWork : BaseClassifier, IAggregateRoot
    {
        public AreaWork(int id, string name, DateTime computed) : base(id, name, computed)
        {
        }

    }
}
