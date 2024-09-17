using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Primitives
{
    public abstract class Entity
    {
        protected Entity(int id) => Id = id;

        protected Entity()
        {
        }

        public int Id { get;  set; }
    }
}
