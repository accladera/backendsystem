using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class TypeDocument : BaseClassifier
    {
        public TypeDocument(int id, string name, DateTime computed) : base(id, name, computed)
        {
        }
    }
}