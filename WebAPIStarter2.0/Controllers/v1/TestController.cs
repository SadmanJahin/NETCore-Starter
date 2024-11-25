using Asp.Versioning;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Models;
using Services.Interface;

namespace WebAPIStarter.Controllers.v1
{
    [ApiVersion(1.0)]
    [Route("api/v{v:apiVersion}/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<List<Test>>> GetTestData()
        {
            var tests = await _testService.GetTestData();
            return Ok(tests);
        }

        [HttpPost]
        public async Task<ActionResult> SaveData([FromBody] Test test)
        {
            if (test == null)
            {
                return BadRequest("Test data is required.");
            }

            await _testService.SaveData(test);
            return CreatedAtAction(nameof(GetTestData), new { id = test.Id }, test);
        }
    }
}
