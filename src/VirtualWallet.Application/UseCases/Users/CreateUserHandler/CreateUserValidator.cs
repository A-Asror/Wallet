using FluentValidation;
using Microsoft.Extensions.Localization;
using VirtualWallet.Domain.Enums.User;


namespace VirtualWallet.Application.UseCases.Users.CreateUserHandler;

public class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    private int _pinflLength = 14;

    public CreateUserValidator(IStringLocalizer<CreateUserValidator> localizer)
    {
        RuleFor(u => u).Custom((u, context) =>
        {
            if (u.Pinfl == null && u.Tin == null)
            {
                context.AddFailure("Pinfl", localizer["ValidatorPinflAndTinErrorNotFound"]);
                context.AddFailure("Tin", localizer["ValidatorPinflAndTinErrorNotFound"]);
            }
            else if (u.Pinfl != null && u.Tin != null)
            {
                context.AddFailure("Pinfl", localizer["ValidatorPinflAndTinErrorFound"]);
                context.AddFailure("Tin", localizer["ValidatorPinflAndTinErrorFound"]);
            }
            else if (u.Pinfl != null && u.UserType != UserType.Individual)
            {
                context.AddFailure("UserType", localizer["ValidatorUserTypeMustBeLegalEntity"]);
            }
            else if (u.Tin != null && u.UserType != UserType.LegalEntity)
            {
                context.AddFailure("UserType", localizer["ValidatorUserTypeMustBeIndividual"]);
            }
        });

        RuleFor(u => u.Pinfl)
            .NotNull()
            .When(u => u.Pinfl != null && u.Pinfl.Length != _pinflLength)
            .WithMessage(localizer["ValidatorPinflLengthError"]);
    }
}