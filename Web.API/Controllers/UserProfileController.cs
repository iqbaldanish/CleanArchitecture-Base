using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using MediatR;

using Application.Features.Commands.CreateUserProfile;
using Application.Features.Commands.UpdateUserProfile;
using Application.Features.Commands.DeleteUserProfile;
using Application.Features.Queries.GetUserProfileById;
using Application.Features.Queries.GetUserProfiles;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class UserProfileController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserProfileController(IMediator mediator)       
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserProfiles(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetUserProfilesQuery(), cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserProfile(int id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetUserProfileByIdQuery(id), cancellationToken);
            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateUserProfileCommand cmd, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(cmd, cancellationToken);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateUserProfileCommand cmd, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(cmd, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(DeleteUserProfileCommand cmd, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(cmd, cancellationToken);
            return Ok(result);
        }
    }
}
