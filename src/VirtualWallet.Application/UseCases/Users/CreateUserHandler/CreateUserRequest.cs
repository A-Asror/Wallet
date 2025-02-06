using System.ComponentModel.DataAnnotations;
using MediatR;
using VirtualWallet.Domain.Enums.User;
using VirtualWallet.Domain.Enums.Wallet;

namespace VirtualWallet.Application.UseCases.Users.CreateUserHandler;

public class CreateUserRequest: IRequest<CreateUserResponse>
{
    [StringLength(14, MinimumLength = 14)]
    public string? Pinfl { get; set; } = null;
    
    public string? Tin { get; set; } = null;
    
    public string? LastName { get; set; } = null;
    
    public string? FirstName { get; set; } = null;
    
    public string? MiddleName { get; set; } = null;
    
    public UserType UserType { get; set; }
    
    public Guid ExternalId { get; set; }
}