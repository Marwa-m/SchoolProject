using CleanArchitecture.Core.Features.Users.Commands.Models;
using CleanArchitecture.Core.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace CleanArchitecture.Core.Features.Users.Commands.Validations
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;

        #endregion

        #region Ctor
        public AddUserValidator(IStringLocalizer<SharedResources> localizer)
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

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.ConfirmPassword)
              .Equal(x => x.Password).WithMessage(_localizer[SharedResourcesKeys.PasswordNotEqualConfirmPass]);
        }

        private void ApplyCustomValidationRules()
        {
            //RuleFor(x => x.NameAr)
            //    .MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameExist(Key))
            //    .WithMessage("Name is already exist");

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
