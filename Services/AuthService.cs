using InventoryManagement.API.DTOs.Auth;
using InventoryManagement.API.Entities;
using InventoryManagement.API.Exceptions;
using InventoryManagement.API.Interfaces;

namespace InventoryManagement.API.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;

    public AuthService(
        IUserRepository userRepository,
        IJwtService jwtService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }

    public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
    {
        if (await _userRepository.EmailExistsAsync(dto.Email))
            throw new ConflictException("Email already exists.");

        var user = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            RoleId = dto.RoleId
        };

        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        var createdUser = await _userRepository.GetByEmailAsync(user.Email);

        var token = _jwtService.GenerateToken(createdUser!);

        return new AuthResponseDto
        {
            Token = token,
            ExpiresAt = DateTime.UtcNow.AddMinutes(60)
        };
    }

    public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
    {
        var user = await _userRepository.GetByEmailAsync(dto.Email);

        if (user is null ||
            !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
        {
            throw new BusinessRuleException("Invalid email or password.");
        }

        var token = _jwtService.GenerateToken(user);

        return new AuthResponseDto
        {
            Token = token,
            ExpiresAt = DateTime.UtcNow.AddMinutes(60)
        };
    }
}