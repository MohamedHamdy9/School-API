using MediatR;
using SchoolProjectWithCleanArchitecture.Core.Bases;
using SchoolProjectWithCleanArchitecture.Core.Features.Students.Queries.Response;
using SchoolProjectWithCleanArchitecture.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectWithCleanArchitecture.Core.Features.Students.Queries.Models
{
    public class GetStudentListQuery : IRequest<Response<List<GetStudentListResponse>>>
    {

    }
}
