using AutoMapper;
using CleanArchitecture.Core.Bases;
using CleanArchitecture.Core.Features.Students.Queries.Models;
using CleanArchitecture.Core.Features.Students.Queries.Results;
using CleanArchitecture.Core.Resources;
using CleanArchitecture.Core.Wrapper;
using CleanArchitecture.Data.Entities;
using CleanArchitecture.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CleanArchitecture.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler,
        IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>,
        IRequestHandler<GetStudentByIdQuery, Response<GetStudentResponse>>,
         IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>
    {
        #region Field
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;

        #endregion

        #region Ctor
        public StudentQueryHandler(IStudentService studentService,
                                   IMapper mapper,
                                   IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _localizer = localizer;
        }
        #endregion

        #region Handlers
        public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentService.GetStudentsAsync();
            var studentListMapper = _mapper.Map<List<Student>, List<GetStudentListResponse>>(studentList);
            var result = Success(studentListMapper);
            result.Meta = new { Count = studentListMapper.Count() };
            return result;
        }

        public async Task<Response<GetStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdWithIncludeAsync(request.ID);
            if (student == null)
                return NotFound<GetStudentResponse>(_localizer[SharedResourcesKeys.NotFound]);
            var studentMapper = _mapper.Map<Student, GetStudentResponse>(student);
            return (Success(studentMapper));
        }

        public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            //Expression<Func<Student, GetStudentPaginatedListResponse>> expression
            //            = e => new GetStudentPaginatedListResponse(e.StudentID, e.Localize(e.NameAr, e.NameEn), e.Address, e.Department.Localize(e.Department.DNameAr, e.Department.DNameEn));
            var filter = _studentService.FilterStudentPaginatedQueryable(request.OrderBy, request.Search);
            var paginatedList = _mapper.ProjectTo<GetStudentPaginatedListResponse>(filter, null).ToPaginatedListAsync((int)request.PageNumber, (int)request.PageSize).Result;
            paginatedList.Meta = new { Count = paginatedList.Data.Count() };
            return paginatedList;
        }
    }

    #endregion
}
