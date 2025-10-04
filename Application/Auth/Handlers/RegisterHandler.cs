using Application.DTOs;
using Application.Users.Commands;
using MediatR;
using Supabase;

namespace Application.Auth.Commands.Register;

public class RegisterHandler : IRequestHandler<RegisterCommand, AuthResponseDto>
{
    private readonly Client _supabase;
    private readonly IMediator _mediator;

    public RegisterHandler(Client supabase, IMediator mediator)
    {
        _supabase = supabase;
        _mediator = mediator;
    }

    public async Task<AuthResponseDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var response = request.RegisterDto;

        if (!IsValidEmail(response.Email))
        {
            return new AuthResponseDto { Success = false, Message = "Formato de email inválido" };
        }

        if (response.TypeUser != "Estudiante" && response.TypeUser != "Maestro")
        {
            return new AuthResponseDto { Success = false, Message = "Tipo de usuario invalido" };
        }

        try
        {
            var authResult = await _supabase.Auth.SignUp(response.Email, response.Password);

            if (authResult?.User?.Id == null)
            {
                return new AuthResponseDto { Success = false, Message = "Error en el registro" };
            }

            var infoUser = new InfoUserDto
            {
                Career = "Default",
                ProfessionalTitle = "Default",
                Semester = "Default",
                Tuition = "Default"
            };
            var createInforUserCommand = new CreateInfoUserCommand(infoUser);
            var infoUserResult = await _mediator.Send(createInforUserCommand, cancellationToken);

            var userDto = new UserDto
            {
                Id = 0,
                Username = response.Username,
                Email = response.Email,
                Name = "Default",
                LastName = "Default",
                Photo = ".url",
                TypeUser = response.TypeUser,
                InfoUserId = infoUserResult.Id,
                CreatedAt = DateTime.UtcNow
            };
            var createUserCommand = new AddCommand(userDto);
            var userResult = await _mediator.Send(createUserCommand, cancellationToken);

            return new AuthResponseDto
            {
                Success = true,
                UserId = authResult.User.Id,
                Username = response.Username,
                AccessToken = authResult.AccessToken,
                Message = "Registro exitoso"
            };
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("already registered"))
            {
                return new AuthResponseDto { Success = false, Message = "El email ya está registrado" };
            }
            return new AuthResponseDto { Success = false, Message = $"Error en registro: {ex.Message}" };
        }
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}