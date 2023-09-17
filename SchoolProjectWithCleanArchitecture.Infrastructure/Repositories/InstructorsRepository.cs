using Microsoft.EntityFrameworkCore;
using SchoolProjectWithCleanArchitecture.Data.Entities;
using SchoolProjectWithCleanArchitecture.Infrastructure.Data;
using SchoolProjectWithCleanArchitecture.Infrastructure.InfrastructureBases;
using SchoolProjectWithCleanArchitecture.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProjectWithCleanArchitecture.Infrastructure.Repositories
{
    public class InstructorsRepository : GenericRepositoryAsync<Instructor>, IInstructorsRepository
    {
        #region Fields
        private DbSet<Instructor> instructors;
        #endregion

        #region Constructors
        public InstructorsRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            instructors = dbContext.Set<Instructor>();
        }
        #endregion

        #region Handle Functions

        #endregion
    }
}
