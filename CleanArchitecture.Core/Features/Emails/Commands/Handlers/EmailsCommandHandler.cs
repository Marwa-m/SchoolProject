using CleanArchitecture.Core.Bases;
using CleanArchitecture.Core.Features.Emails.Commands.Models;
using CleanArchitecture.Core.Resources;
using CleanArchitecture.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CleanArchitecture.Core.Features.Emails.Commands.Handlers
{
    public class EmailsCommandHandler : ResponseHandler,
                                      IRequestHandler<SendEmailCommand, Response<string>>
    {

        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IEmailService _emailService;
        #endregion

        #region CTOR
        public EmailsCommandHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                    IEmailService emailService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _emailService = emailService;
        }

        public async Task<Response<string>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            var result = await _emailService.SendEmail(request.Email, request.Message, "reason");
            if (result == "Success")
            {
                return Success("");
            }
            return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.BadRequest]);

        }
        #endregion

        #region Functions

        #endregion

    }
}
