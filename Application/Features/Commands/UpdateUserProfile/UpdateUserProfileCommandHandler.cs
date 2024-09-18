using Application.Abstraction;
using Application.Features.Commands.CreateUserProfile;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Application.Features.Commands.UpdateUserProfile
{
    internal sealed class UpdateUserProfileCommandHandler(IApplicationDbContext context) : IRequestHandler<UpdateUserProfileCommand, Result<UserProfile>>
    {
        public async Task<Result<UserProfile>> Handle(UpdateUserProfileCommand command, CancellationToken cancellationToken)
        {
            var userProfile = await context.UserProfiles
                                            .AsNoTracking()
                                            .SingleOrDefaultAsync(up => up.Id == command.id, cancellationToken);
            if (userProfile == null)
            {
                return Result<UserProfile>.FailureResult("There is no profile available with this Id!");
            }
            else
            {
                userProfile.Id = command.id;
                userProfile.FirstName = command.firstName;
                userProfile.LastName = command.lastName;

                context.UserProfiles.Update(userProfile);//Required for In memory Database
                var result = await context.SaveChangesAsync(cancellationToken);

                return Result<UserProfile>.SuccessResult(userProfile); // Ensure proper wrapping
            }    
           
        }
    }

}
