using Application.Abstraction;
using MediatR;
using domain = Domain.Entities;

namespace Application.UserProfile.Queries.GetUserProfileById
{
    public sealed record GetUserProfileByIdQuery(Guid Id) : IRequest<Result<domain.UserProfile>>;
}
