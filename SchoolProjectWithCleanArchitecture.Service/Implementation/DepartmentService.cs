﻿using Microsoft.EntityFrameworkCore;
using SchoolProjectWithCleanArchitecture.Data.Entities;
using SchoolProjectWithCleanArchitecture.Infrastructure.Interfaces;
using SchoolProjectWithCleanArchitecture.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectWithCleanArchitecture.Service.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        #region Fields
        private readonly IDepartmentRepository _departmentRepository;
        #endregion

        #region Constructors
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }


        #endregion

        #region Handle Functions
        public async Task<Department> GetDepartmentById(int id)
        {
            var student = await _departmentRepository.GetTableNoTracking().Where(x => x.DID.Equals(id))
                                                        .Include(x => x.DepartmentSubjects).ThenInclude(x => x.Subject)
                                                        .Include(x => x.Instructors)
                                                        .Include(x => x.Instructor).FirstOrDefaultAsync();
            return student;
        }

        public async Task<bool> IsDepartmentIdExist(int departmentId)
        {
            return await _departmentRepository.GetTableNoTracking().AnyAsync(x => x.DID.Equals(departmentId));
        }



        #endregion
    }
}
