using Application.Abstraction;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.DeleteUserProfile
{
   public record DeleteUserProfileCommand(
   int id) : IRequest<Result<int>>;
}
