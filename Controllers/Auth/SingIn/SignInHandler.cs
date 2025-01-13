namespace TaskAPI.Controllers.User.GetUser
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using TaskAPI.Controllers.User.GetUser;
    using TaskAPI.Data;
    using TaskAPI.Repositories;

    public class GetUserHandler : IRequestHandler<GetUserRequest, GetUserResponse>
    {
        private IUserRepository _userRepository;

        public GetUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            // Verificar si se debe cancelar la operación
            var jola = await _userRepository.GetAllAsync();

            return new GetUserResponse { };
        }
    }

}
