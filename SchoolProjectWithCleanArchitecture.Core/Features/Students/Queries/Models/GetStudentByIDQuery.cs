using MediatR;
using SchoolProjectWithCleanArchitecture.Core.Bases;
using SchoolProjectWithCleanArchitecture.Core.Features.Students.Queries.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectWithCleanArchitecture.Core.Features.Students.Queries.Models
{
    public class GetStudentByIDQuery : IRequest<Response<GetSingleStudentResponse>>
    {
        public int Id { get; set; }
        public GetStudentByIDQuery(int id)
        {
            Id = id;
        }
    }
}
