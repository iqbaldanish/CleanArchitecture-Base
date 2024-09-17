using Application.Abstraction;
using MediatR;
using Domain.Entities;

namespace Application.Features.Queries.GetUserProfileById
{
    public record GetUserProfileByIdQuery(int id) : IRequest<Result<UserProfile>>;
}
