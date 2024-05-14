using AutoMapper;
using CleanArchitecture.Core.Bases;
using CleanArchitecture.Core.Features.Instructors.Commands.Models;
using CleanArchitecture.Core.Resources;
using CleanArchitecture.Data.Entities;
using CleanArchitecture.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CleanArchitecture.Core.Features.Instructors.Commands.Handlers
{
    public class InstructorCommandHandler : ResponseHandler,
        IRequestHandler<AddInstructorCommand, Response<string>>
    {

        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;
        private readonly IInstructroService _instructroService;

        #endregion

        #region CTOR
        public InstructorCommandHandler(IStringLocalizer<SharedResources> stringLocalizer,
            IMapper mapper,
            IInstructroService instructroService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _instructroService = instructroService;
        }


        #endregion

        #region Functions
        public async Task<Response<string>> Handle(AddInstructorCommand request, CancellationToken cancellationToken)
        {
            var instructor = _mapper.Map<Instructor>(request);
            var result = await _instructroService.AddInstructorAsync(instructor, request.Image);
            switch (result)
            {
                case "FailedToUpload": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToUploadImage]);
                case "NoImage": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.NoImage]);
            }
            return Success(result);
        }
        #endregion
    }
}
