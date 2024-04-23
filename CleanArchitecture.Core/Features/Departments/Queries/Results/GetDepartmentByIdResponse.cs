using CleanArchitecture.Core.Wrapper;

namespace CleanArchitecture.Core.Features.Departments.Queries.Results
{
    public class GetDepartmentByIdResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string ManagerName { get; set; }
        public PaginatedResult<StudentReponse>? StudentList { get; set; }
        public List<SubjectReponse>? Subjectist { get; set; }
        public List<InstructorReponse>? InstructorList { get; set; }
    }

    public class StudentReponse
    {
        public StudentReponse(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
    public class SubjectReponse
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
    public class InstructorReponse
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
