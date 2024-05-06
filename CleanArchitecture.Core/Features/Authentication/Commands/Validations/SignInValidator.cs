using CleanArchitecture.Core.Features.Authentication.Commands.Models;
using CleanArchitecture.Core.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace CleanArchitecture.Core.Features.Authentication.Commands.Validations
{
    public class SignInValidator : AbstractValidator<SignInCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;

        #endregion

        #region Ctor
        public SignInValidator(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;

            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        #endregion

        #region Handle Function
        private void ApplyValidationRules()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
     .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);


            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        }

        private void ApplyCustomValidationRules()
        {

            //When(x => x.DepartmentID != null, () =>
            //{
            //    RuleFor(x => x.DepartmentID)
            //    .MustAsync(async (Key, CancellationToken) => await _departmentService.IsDepartmentExist(Key))
            //    .WithMessage(_localizer[SharedResourcesKeys.IsNotExist]);
            //});

        }

        #endregion
    }
}
