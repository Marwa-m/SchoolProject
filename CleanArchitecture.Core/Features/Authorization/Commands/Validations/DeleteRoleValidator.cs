using CleanArchitecture.Core.Features.Authorization.Commands.Models;
using CleanArchitecture.Core.Resources;
using CleanArchitecture.Service.Abstracts;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace CleanArchitecture.Core.Features.Authorization.Commands.Validations
{
    public class DeleteRoleValidator : AbstractValidator<DeleteRoleCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IAuthorizationService _authorizationService;

        #endregion

        #region Ctor
        public DeleteRoleValidator(IStringLocalizer<SharedResources> localizer,
            IAuthorizationService authorizationService)
        {
            _localizer = localizer;
            _authorizationService = authorizationService;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        #endregion

        #region Handle Function
        private void ApplyValidationRules()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
     .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);


        }

        private void ApplyCustomValidationRules()
        {
            //    RuleFor(x => x.Id)
            //.MustAsync(async (Key, CancellationToken) => await _authorizationService.IsRoleExistById(Key))
            //.WithMessage(_localizer[SharedResourcesKeys.IsExist]);

        }

        #endregion
    }
}
