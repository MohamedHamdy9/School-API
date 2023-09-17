﻿using SchoolProjectWithCleanArchitecture.Core.Features.Students.Queries.Response;
using SchoolProjectWithCleanArchitecture.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectWithCleanArchitecture.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void GetStudentListMapping()
        {
            CreateMap<Student, GetStudentListResponse>()
               .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Localize(src.Department.DNameAr, src.Department.DNameEn)))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));
        }
    }
}
