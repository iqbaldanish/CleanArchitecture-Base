using Application.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.GetUserProfiles
{
    public record GetUserProfilesQuery : IRequest<Result<IEnumerable<Domain.Entities.UserProfile>>>;
}
