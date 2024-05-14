using CleanArchitecture.Core.Features.Instructors.Commands.Models;
using CleanArchitecture.Core.Resources;
using CleanArchitecture.Service.Abstracts;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace CleanArchitecture.Core.Features.Instructors.Commands.Validations
{
    public class AddInstructorCommandValidator : AbstractValidator<AddInstructorCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IInstructroService _instructroService;

        #endregion

        #region Ctor
        public AddInstructorCommandValidator(IStringLocalizer<SharedResources> localizer,
        IInstructroService instructroService)
        {
            _localizer = localizer;
            _instructroService = instructroService;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        #endregion

        #region Handle Function
        private void ApplyValidationRules()
        {
            RuleFor(x => x.NameAr)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
     .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.NameEn)
                       .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.DID)
           .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
.NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        }

        private void ApplyCustomValidationRules()
        {
            RuleFor(x => x.NameAr)
        .MustAsync(async (Key, CancellationToken) => !await _instructroService.IsNameExist(Key))
        .WithMessage(_localizer[SharedResourcesKeys.IsExist]);

        }

        #endregion
    }
}
