using MediatR;

namespace Application.UserProfile.Commands.CreateUserProfile
{
    public record CreateUserProfileCommand(
    Guid id,    
    string firstName,
    string lastName) : IRequest<Guid>;    
}
