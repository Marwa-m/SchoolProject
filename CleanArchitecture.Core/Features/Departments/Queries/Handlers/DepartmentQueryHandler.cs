using AutoMapper;
using CleanArchitecture.Core.Bases;
using CleanArchitecture.Core.Features.Departments.Queries.Models;
using CleanArchitecture.Core.Features.Departments.Queries.Results;
using CleanArchitecture.Core.Resources;
using CleanArchitecture.Core.Wrapper;
using CleanArchitecture.Data.Entities;
using CleanArchitecture.Data.Entities.Procedures;
using CleanArchitecture.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;
using System.Linq.Expressions;

namespace CleanArchitecture.Core.Features.Departments.Queries.Handlers
{
    public class DepartmentQueryHandler : ResponseHandler,
        IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>,
        IRequestHandler<GetDepartmentStudentListCountQuery, Response<List<GetDepartmentStudentListCountResult>>>,
        IRequestHandler<GetDepartmentStudentCountByIdQuery, Response<GetDepartmentStudentCountByIdResult>>
    {

        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IDepartmentService _departmentService;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor
        public DepartmentQueryHandler(IStringLocalizer<SharedResources> stringLocalizer,
            IDepartmentService departmentService,
            IStudentService studentService,
            IMapper mapper) : base(stringLocalizer)
        {
            _localizer = stringLocalizer;
            _departmentService = departmentService;
            _studentService = studentService;
            _mapper = mapper;
        }
        #endregion

        #region Handlers
        public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _departmentService.GetDepartmentByIdAsync(request.Id);
            if (response == null)
                return NotFound<GetDepartmentByIdResponse>(_localizer[SharedResourcesKeys.NotFound]);
            var departmentMapper = _mapper.Map<Department, GetDepartmentByIdResponse>(response);

            Expression<Func<Student, StudentReponse>> expression
                       = e => new StudentReponse(e.StudentID, e.Localize(e.NameAr, e.NameEn));
            var studentsQueryable = _studentService.GetStudentsByDepartmentIdQueryable(request.Id);
            var paginatedList = studentsQueryable.Select(expression).ToPaginatedListAsync((int)request.StudentPageNumber, (int)request.StudentPageSize).Result;
            departmentMapper.StudentList = paginatedList;

            return (Success(departmentMapper));
        }

        public async Task<Response<List<GetDepartmentStudentListCountResult>>> Handle(GetDepartmentStudentListCountQuery request, CancellationToken cancellationToken)
        {
            var result = await _departmentService.GetViewDepartmentDataAsync();
            var mapper = _mapper.Map<List<GetDepartmentStudentListCountResult>>(result);
            return Success(mapper);

        }

        public async Task<Response<GetDepartmentStudentCountByIdResult>> Handle(GetDepartmentStudentCountByIdQuery request, CancellationToken cancellationToken)
        {
            var param = _mapper.Map<DepartmentStudentCountProcParams>(request);
            var procResult = await _departmentService.GetDepartmentStudentCountProc(param);
            var result = _mapper.Map<GetDepartmentStudentCountByIdResult>(procResult.FirstOrDefault());
            return Success(result);

        }
        #endregion

    }
}
