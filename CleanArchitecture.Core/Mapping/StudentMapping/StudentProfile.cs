using AutoMapper;

namespace CleanArchitecture.Core.Mapping.StudentMapping
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            GetStudentListMapping();
            GetStudentByIdMapping();
            AddStudentCommandMapping();
            EditStudentCommandMapping();
            DeleteStudentCommandMapping();
        }
    }
}
