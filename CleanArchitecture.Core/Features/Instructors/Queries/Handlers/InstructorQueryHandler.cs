using AutoMapper;
using CleanArchitecture.Core.Bases;
using CleanArchitecture.Core.Features.Instructors.Queries.Models;
using CleanArchitecture.Core.Resources;
using CleanArchitecture.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;
using Serilog;

namespace CleanArchitecture.Core.Features.Instructors.Queries.Handlers
{
    public class InstructorQueryHandler : ResponseHandler,
        IRequestHandler<GetSummationSalaryOfInstructorQuery, Response<decimal>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;
        private readonly IInstructroService _instrucotrService;

        #endregion

        #region CTOR
        public InstructorQueryHandler(IStringLocalizer<SharedResources> stringLocalizer,
            IMapper mapper,
            IInstructroService instrucotrService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _instrucotrService = instrucotrService;
        }

        public async Task<Response<decimal>> Handle(GetSummationSalaryOfInstructorQuery request, CancellationToken cancellationToken)
        {
            var result = await _instrucotrService.GetSalarySummationOfInstructor();
            Log.Information("Hello, from SeriLog");
            return Success(result);
        }
        #endregion

        #region Functions

        #endregion
    }
}
