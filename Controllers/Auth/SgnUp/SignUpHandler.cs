namespace TaskAPI.Controllers.User.GetUser
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using TaskAPI.Controllers.User.GetUser;
    using TaskAPI.Data;
    using TaskAPI.Repositories;

    public class SignUpHandler : IRequestHandler<SignUpRequest, SignUpResponse>
    {
        private IUserRepository _userRepository;

        public SignUpHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<SignUpResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            // Verificar si se debe cancelar la operación
            var jola = await _userRepository.GetAllAsync();

            return new SignUpResponse { };
        }
    }

}
