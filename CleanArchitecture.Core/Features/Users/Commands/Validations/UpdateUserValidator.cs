using CleanArchitecture.Core.Features.Users.Commands.Models;
using CleanArchitecture.Core.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace CleanArchitecture.Core.Features.Users.Commands.Validations
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;

        #endregion

        #region Ctor
        public UpdateUserValidator(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;

            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        #endregion

        #region Handle Function
        private void ApplyValidationRules()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                 .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);
            RuleFor(x => x.UserName).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
     .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
     .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

        }

        private void ApplyCustomValidationRules()
        {


        }

        #endregion
    }
}
