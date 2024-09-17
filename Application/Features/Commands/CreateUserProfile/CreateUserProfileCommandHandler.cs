using MediatR;
using Application.Abstraction;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Application.Features.Commands.CreateUserProfile
{
    internal sealed class CreateUserProfileCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateUserProfileCommand, Result<int>>
    {  
        public async Task<Result<int>> Handle(CreateUserProfileCommand command, CancellationToken cancellationToken)
        {
            UserProfile? userProfile = await context.UserProfiles
                                            .AsNoTracking()
                                            .SingleOrDefaultAsync(up => up.Id == command.id, cancellationToken);

            if (userProfile != null)
            {
                return Result<int>.FailureResult("User profile already exists with this Id.");
            }

            var userP = new UserProfile
            (
                command.id,
                command.firstName,
                command.lastName
            );

            context.UserProfiles.Add(userP);
            var result = await context.SaveChangesAsync(cancellationToken);

            return Result<int>.SuccessResult(userP.Id); // Ensure proper wrapping
        }       
    }
}
