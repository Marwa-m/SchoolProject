using AutoMapper;
using CleanArchitecture.Core.Bases;
using CleanArchitecture.Core.Features.Students.Commands.Models;
using CleanArchitecture.Core.Resources;
using CleanArchitecture.Data.Entities;
using CleanArchitecture.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;

namespace CleanArchitecture.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler,
                            IRequestHandler<AddStudentCommand, Response<string>>,
                            IRequestHandler<EditStudentCommand, Response<string>>,
                            IRequestHandler<DeleteStudentCommand, Response<string>>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;


        #endregion

        #region Ctor
        public StudentCommandHandler(IStudentService studentService,
                                     IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        #endregion

        #region Handlers
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var mapperStudent = _mapper.Map<Student>(request);

            var resultMessage = await _studentService.AddAsync(mapperStudent);
            if (resultMessage == "Success")
                return (Created("The student is added successfully"));
            else
                return (BadRequest<string>(resultMessage));

        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var studentExist = await _studentService.GetStudentByIdWithIncludeAsync(request.Id);
            if (studentExist == null)
            {
                return (NotFound<string>("The Student is not found"));
            }
            var mapperStudent = _mapper.Map(request, studentExist);

            var resultMessage = await _studentService.EditAsync(mapperStudent);
            if (resultMessage == "Success")
                return (Success("The student is updated successfully"));
            else
                return (BadRequest<string>(resultMessage));
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var studentExist = _studentService.GetStudentByIdAsync(request.ID);
            if (studentExist == null)
            {
                return (NotFound<string>("The Student is not found"));
            }
            var mapperStudent = _mapper.Map<Student>(request);
            var resultMessage = await _studentService.DeleteAsync(mapperStudent);
            if (resultMessage == "Success")
                return (Deleted<string>());
            else
                return (BadRequest<string>(resultMessage));
        }

        #endregion
    }
}
