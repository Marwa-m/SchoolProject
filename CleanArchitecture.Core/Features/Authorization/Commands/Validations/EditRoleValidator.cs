using CleanArchitecture.Core.Features.Authorization.Commands.Models;
using CleanArchitecture.Core.Resources;
using CleanArchitecture.Service.Abstracts;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace CleanArchitecture.Core.Features.Authorization.Commands.Validations;

public class EditRoleValidator : AbstractValidator<EditRoleCommand>
{
    #region Fields
    private readonly IStringLocalizer<SharedResources> _localizer;
    private readonly IAuthorizationService _authorizationService;

    #endregion

    #region Ctor
    public EditRoleValidator(IStringLocalizer<SharedResources> localizer,
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
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
 .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);


    }

    private void ApplyCustomValidationRules()
    {

    }

    #endregion

}
