using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Primitives;

namespace Domain.Entities
{ 
    public sealed class UserProfile : Entity
    {
        public UserProfile(Guid id, string firstName, string lastName): base(id)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        
        public string FirstName { get; private set; }
        public string LastName { get; private set; }        

    }
}
