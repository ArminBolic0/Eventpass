using EventPass.Application.DTOs.Users;
using EventPass.Domain.Interfaces.Security;
using EventPass.Domain.Interfaces.Services;
using EventPass.Domain.Interfaces.Users;
using MediatR;

namespace EventPass.Application.Commands.Users.Login
{
    public class LoginUserCommandHandler: IRequestHandler<LoginUserCommand, LoginResponseDto>
    {
        IPasswordHasher _hasher;
        IUserRepository _repository;
        IJwtService _jwtService;

        public LoginUserCommandHandler(IPasswordHasher hasher, IUserRepository repository, IJwtService jwtService)
        {
            _hasher = hasher;
            _repository = repository;
            _jwtService = jwtService;
        }

        public async Task<LoginResponseDto> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _repository.GetUserByEmailAsync(command.Email, cancellationToken);
            if (user == null) return null;
            if(!_hasher.VerifyPassword(command.Password, user.PasswordHash, user.PasswordSalt)) return null;
            var token = _jwtService.GenerateToken(user);

            return new LoginResponseDto
            {
                token = token,
                email = user.Email,
                name = user.Name,
                surname = user.Surname
            };
        }
    }
}
