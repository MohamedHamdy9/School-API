using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProjectWithCleanArchitecture.Api.Base;
using SchoolProjectWithCleanArchitecture.Core.Features.Departement.Queries.Models;
using SchoolProjectWithCleanArchitecture.Data.AppMetaData;
using System.Data;

namespace SchoolProjectWithCleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        [HttpGet(Router.DepartmentRouting.GetByID)]
        public async Task<IActionResult> GetDepartmentByID([FromQuery] GetDepartmentByIDQuery query)
        {
            return NewResult(await Mediator.Send(query));
        }


    }
}
