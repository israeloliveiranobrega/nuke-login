using MediatR;
using NukeLogin.Src.Domain.Entitys;
using NukeLogin.Src.Features.AccessControl.Register.DTOs;
using NukeLogin.Src.Infrastructure.Repositorys.AccessControl.Contracts;
using NukeLogin.Src.Shared;

namespace NukeLogin.Src.Features.AccessControl.Register;
public class RegisterUserHandler(IUserRepository userRepository) : IRequestHandler<RegisterUserCommand, Result<RegisterUserResponse>>
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<Result<RegisterUserResponse>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        #region Validations
        if (await _userRepository.ExistsByCpfAsync(request.RegisterRequest.Person.Cpf, cancellationToken))
            return Result<RegisterUserResponse>.Failure("O cpf já está cadastrado.");

        if (await _userRepository.ExistsByEmailAsync(request.RegisterRequest.Email.Address, request.RegisterRequest.Email.Domain, cancellationToken))
            return Result<RegisterUserResponse>.Failure("O email já está cadastrado.");

        if (request.RegisterRequest.Phone != null)
            if (await _userRepository.ExistsByPhoneAsync(request.RegisterRequest.Phone.CountryCode, request.RegisterRequest.Phone.Number, cancellationToken))
                return Result<RegisterUserResponse>.Failure("O telefone já está cadastrado.");
        #endregion

        User user = request.RegisterRequest.ToEntity();
        user.Id = Guid.CreateVersion7();

        user.CreatedBy = request.WhoCriated?? user.Id;

        Guid guidId = await _userRepository.Create(user, cancellationToken);

        return Result<RegisterUserResponse>.Success(new RegisterUserResponse(guidId, user.FullName, user.MaskedEmail));
    } 
}
  