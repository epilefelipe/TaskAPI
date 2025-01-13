using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TaskAPI.Controllers.User.GetUser
{
    public class GetUserRequest : IRequest<GetUserResponse>
    {
        [FromQuery]
        public int Id { get; set; }
    }
}
