using Application.Abstraction;
using MediatR;
using Domain.Entities;

namespace Application.Features.Commands.UpdateUserProfile
{
    public record UpdateUserProfileCommand(
    int id,
    string firstName,
    string lastName) : IRequest<Result<UserProfile>>;
}
