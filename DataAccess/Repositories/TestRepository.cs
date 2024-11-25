using DataAccess.DataContext;
using DataAccess.Interfaces;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class TestRepository : GenericRepository<Test>, ITestRepository
    {
        private readonly DatabaseContext _databaseContext;
        public TestRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
            _databaseContext = databaseContext;
        }
    }
}
