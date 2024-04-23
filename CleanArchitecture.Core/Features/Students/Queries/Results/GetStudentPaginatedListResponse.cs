namespace CleanArchitecture.Core.Features.Students.Queries.Results;

public class GetStudentPaginatedListResponse
{
    public GetStudentPaginatedListResponse(int studentID, string? name, string? address, string? departmentName)
    {
        StudentID = studentID;
        Name = name;
        Address = address;
        DepartmentName = departmentName;
    }

    public int StudentID { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }


    public string? DepartmentName { get; set; }
}
