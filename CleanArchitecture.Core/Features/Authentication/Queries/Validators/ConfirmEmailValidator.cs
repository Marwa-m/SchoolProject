using CleanArchitecture.Core.Features.Authentication.Queries.Models;
using CleanArchitecture.Core.Resources;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace CleanArchitecture.Core.Features.Authentication.Queries.Validators
{
    public class ConfirmEmailValidator : AbstractValidator<ConfirmEmailQuery>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;

        #endregion

        #region Ctor
        public ConfirmEmailValidator(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;

            ApplyValidationRules();
        }
        #endregion

        #region Handle Function
        private void ApplyValidationRules()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
     .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);


            RuleFor(x => x.Code)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        }


        #endregion
    }
}
