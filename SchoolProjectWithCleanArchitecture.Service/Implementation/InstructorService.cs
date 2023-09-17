using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SchoolProjectWithCleanArchitecture.Data.Entities;
using SchoolProjectWithCleanArchitecture.Infrastructure.Data;
using SchoolProjectWithCleanArchitecture.Infrastructure.Interfaces;
using SchoolProjectWithCleanArchitecture.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectWithCleanArchitecture.Service.Implementation
{
    public class InstructorService : IInstructorService
    {
        #region Fileds
        private readonly ApplicationDBContext _dbContext;
        private readonly IInstructorsRepository _instructorsRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion
        #region Constructors
        public InstructorService(ApplicationDBContext dbContext,
                                 IInstructorsRepository instructorsRepository,
                                 IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _instructorsRepository = instructorsRepository;
            _httpContextAccessor = httpContextAccessor;
        }



        #endregion
        #region Handle Functions

        public async Task<bool> IsNameArExist(string nameAr)
        {
            //Check if the name is Exist Or not
            var student = _instructorsRepository.GetTableNoTracking().Where(x => x.ENameAr.Equals(nameAr)).FirstOrDefault();
            if (student == null) return false;
            return true;
        }

        public async Task<bool> IsNameArExistExcludeSelf(string nameAr, int id)
        {
            //Check if the name is Exist Or not
            var student = await _instructorsRepository.GetTableNoTracking().Where(x => x.ENameAr.Equals(nameAr) & x.InsId != id).FirstOrDefaultAsync();
            if (student == null) return false;
            return true;
        }

        public async Task<bool> IsNameEnExist(string nameEn)
        {
            //Check if the name is Exist Or not
            var student = await _instructorsRepository.GetTableNoTracking().Where(x => x.ENameEn.Equals(nameEn)).FirstOrDefaultAsync();
            if (student == null) return false;
            return true;
        }

        public async Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id)
        {
            //Check if the name is Exist Or not
            var student = await _instructorsRepository.GetTableNoTracking().Where(x => x.ENameEn.Equals(nameEn) & x.InsId != id).FirstOrDefaultAsync();
            if (student == null) return false;
            return true;
        }
        public async Task<string> AddInstructorAsync(Instructor instructor)
        {
            try
            {
                await _instructorsRepository.AddAsync(instructor);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInAdd";
            }
        }

        #endregion
    }
}
