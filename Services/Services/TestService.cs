using DataAccess.Interfaces;
using DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Models;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class TestService : ITestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITestRepository _testRepository;
        public TestService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
            _testRepository = (ITestRepository?)_unitOfWork.BuildRepository<TestRepository>();
        }

        public async Task<List<Test>> GetTestData()
        {
            return (List<Test>)await _testRepository.GetAllAsync();
        }

        public async Task SaveData(Test test)
        {
            await _testRepository.SaveAsync(test);
            await _unitOfWork.SaveChangesAsync();
            return;
        }
    }
}
