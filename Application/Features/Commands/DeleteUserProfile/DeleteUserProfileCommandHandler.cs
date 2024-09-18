using Application.Abstraction;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Application.Features.Commands.DeleteUserProfile
{
    public class DeleteUserProfileCommandHandler (IApplicationDbContext context) : IRequestHandler<DeleteUserProfileCommand, Result<int>>
    {
        public async Task<Result<int>> Handle(DeleteUserProfileCommand command, CancellationToken cancellationToken)
        {
            UserProfile? userProfile = await context.UserProfiles
                                            .AsNoTracking()
                                            .SingleOrDefaultAsync(up => up.Id == command.id, cancellationToken);
            if (userProfile == null) {
                return Result<int>.FailureResult("There is no profile available with this Id!");
            }

            context.UserProfiles.Remove(userProfile);
            await context.SaveChangesAsync(cancellationToken);
            return Result<int>.SuccessResult(userProfile.Id); // Ensure proper wrapping
        }
    }
}
