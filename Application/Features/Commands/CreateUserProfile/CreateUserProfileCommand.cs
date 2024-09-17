using Application.Abstraction;
using MediatR;

namespace Application.Features.Commands.CreateUserProfile
{
    public record CreateUserProfileCommand(
    int id,    
    string firstName,
    string lastName) : IRequest<Result<int>>;    
}
