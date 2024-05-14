﻿using CleanArchitecture.Core.Features.Instructors.Commands.Models;
using CleanArchitecture.Data.Entities;

namespace CleanArchitecture.Core.Mapping.Instructors
{
    public partial class InstructorProfile
    {
        public void AddInstructorMapping()
        {
            CreateMap<AddInstructorCommand, Instructor>()
            .ForMember(dest => dest.Image, opt => opt.Ignore());
        }
    }
}
