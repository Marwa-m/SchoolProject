using CleanArchitecture.Core.Features.Departments.Queries.Results;
using CleanArchitecture.Data.Entities;

namespace CleanArchitecture.Core.Mapping.DepartmentMapping
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentByIdMapping()
        {
            CreateMap<Department, GetDepartmentByIdResponse>()
    .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Instructor.Localize(src.Instructor.NameAr, src.Instructor.NameEn)))
    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.DNameAr, src.DNameEn)))
    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DID))
    .ForMember(dest => dest.Subjectist, opt => opt.MapFrom(src => src.DepartmentSubjects))
    // .ForMember(dest => dest.StudentList, opt => opt.MapFrom(src => src.Students))
    .ForMember(dest => dest.InstructorList, opt => opt.MapFrom(src => src.Instructors));

            CreateMap<DepartmentSubject, SubjectReponse>()
    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SubID))
    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Subject.Localize(src.Subject.SubjectNameAr, src.Subject.SubjectNameEn)));
            //CreateMap<Student, StudentReponse>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StudentID))
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));
            CreateMap<Instructor, InstructorReponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.InsID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));



            ;

        }
    }
}
