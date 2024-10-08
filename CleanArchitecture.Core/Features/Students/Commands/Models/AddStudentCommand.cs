﻿using CleanArchitecture.Core.Bases;
using MediatR;

namespace CleanArchitecture.Core.Features.Students.Commands.Models
{
    public class AddStudentCommand : IRequest<Response<string>>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Address { get; set; }
        public string? Phone { get; set; }
        public int DepartmentID { get; set; }


    }


}
