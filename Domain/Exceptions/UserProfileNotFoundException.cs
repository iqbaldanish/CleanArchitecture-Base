using Domain.Exceptions.Base;

namespace Domain.Exceptions
{    
    public sealed class UserProfileNotFoundException : NotFoundException
    {
        public UserProfileNotFoundException(Guid userProfileId)
            : base($"The userprofile with the identifier {userProfileId} was not found.")
        {
        }
    }
}
