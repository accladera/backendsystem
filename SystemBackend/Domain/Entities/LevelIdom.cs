using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LevelIdom : BaseClassifier
    {
        public LevelIdom(int id, string name, DateTime computed) : base(id, name, computed)
        {
        }

    }
}
