using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TaskAPI.Controllers.User.GetUser
{
    public class GetUserRequest : IRequest<SignUpResponse>
    {
        [FromQuery]
        public int Id { get; set; }
    }
}
