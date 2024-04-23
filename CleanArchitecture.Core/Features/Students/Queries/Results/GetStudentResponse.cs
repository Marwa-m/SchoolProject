namespace CleanArchitecture.Core.Features.Students.Queries.Results
{
    public class GetStudentResponse
    {
        public int StudentID { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }


        public string? DepartmentName { get; set; }
    }
}
