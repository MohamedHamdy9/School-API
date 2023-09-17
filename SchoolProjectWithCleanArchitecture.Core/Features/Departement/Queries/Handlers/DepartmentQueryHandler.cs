using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProjectWithCleanArchitecture.Core.Bases;
using SchoolProjectWithCleanArchitecture.Core.Features.Departement.Queries.Models;
using SchoolProjectWithCleanArchitecture.Core.Features.Departement.Queries.Results;
using SchoolProjectWithCleanArchitecture.Core.Resources;
using SchoolProjectWithCleanArchitecture.Core.Wrappers;
using SchoolProjectWithCleanArchitecture.Data.Entities;
using SchoolProjectWithCleanArchitecture.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectWithCleanArchitecture.Core.Features.Departement.Queries.Handlers
{
    public class DepartmentQueryHandler : ResponseHandler,
             IRequestHandler<GetDepartmentByIDQuery, Response<GetDepartmentByIDResponse>>
             
    {

        #region Fields
        private readonly IDepartmentService _departmentService;
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public DepartmentQueryHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                      IDepartmentService departmentService,
                                      IMapper mapper,
                                      IStudentService studentService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _studentService = studentService;
            _departmentService = departmentService;
        }

        #endregion

        #region Handle Functions
        public async Task<Response<GetDepartmentByIDResponse>> Handle(GetDepartmentByIDQuery request, CancellationToken cancellationToken)
        {
            //service Get By Id include St sub ins
            var response = await _departmentService.GetDepartmentById(request.Id);
            //check Is Not exist
            if (response == null) return NotFound<GetDepartmentByIDResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            //mapping 
            var mapper = _mapper.Map<GetDepartmentByIDResponse>(response);

            //pagination
            Expression<Func<Student, StudentResponse>> expression = e => new StudentResponse(e.StudID, e.Localize(e.NameAr, e.NameEn));
            var studentQuerable = _studentService.GetStudentsByDepartmentIDQuerable(request.Id);
            var PaginatedList = await studentQuerable.Select(expression).ToPaginatedListAsync(request.StudentPageNumber, request.StudentPageSize);
            mapper.StudentList = PaginatedList;

            // Log.Information($"Get Department By Id {request.Id}!");
            //return response
            return Success(mapper);
        }


        #endregion
    }
}
