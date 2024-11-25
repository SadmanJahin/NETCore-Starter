using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface ITestService
    {
        Task<List<Test>> GetTestData();
        Task SaveData(Test test);
    }
}
