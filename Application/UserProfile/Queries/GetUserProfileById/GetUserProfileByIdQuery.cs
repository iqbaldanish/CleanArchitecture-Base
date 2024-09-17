using Application.Abstraction;
using MediatR;

namespace Application.UserProfile.Queries.GetUserProfileById
{
    public record GetUserProfileByIdQuery(Guid Id) : IRequest<Result<Domain.Entities.UserProfile>>;
}
