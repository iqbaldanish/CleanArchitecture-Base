using MediatR;
using Domain.Repositories;
using Application.Abstraction;

namespace Application.UserProfile.Commands.CreateUserProfile
{
    internal sealed class CreateUserProfileCommandHandler: IRequestHandler<CreateUserProfileCommand, Guid>
    {
        private readonly IUserProfileRepository _userProfileRepository;
        //private readonly IApplicationDbContext _applicationDbContext;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserProfileCommandHandler(IUserProfileRepository userProfileRepository, IUnitOfWork unitOfWork)
        //public CreateUserProfileCommandHandler(IApplicationDbContext applicationDbContext, IUnitOfWork unitOfWork)
        {
            _userProfileRepository = userProfileRepository;
            //_applicationDbContext = applicationDbContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
           var userProfile = new Domain.Entities.UserProfile(Guid.NewGuid(), request.firstName, request.lastName);
            _userProfileRepository.Insert(userProfile);
            //_applicationDbContext.Insert(userProfile);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return userProfile.Id;
        }       
    }
}
