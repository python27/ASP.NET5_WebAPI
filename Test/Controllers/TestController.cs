using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var tests = _testService.GetAll();

            return Ok(tests);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TestObj test)
        {
            test = _testService.Create(test.Number, test.Text);

            if (test.Number > 10)
            {
                return BadRequest("Number nie może być większy od 10");
            }
            else if (!Regex.IsMatch(test.Text, @"^[abcd]+$"))
            {
                return BadRequest("Text może składać się tylko z 4 małych litery [a,b,c,d]");
            }

            string text = test.Text;
            var sb = new System.Text.StringBuilder();
            for (int i = 0; i < test.Number; i++)
            {
                if (i % 2 != 0)
                {
                    text = new string (test.Text.Reverse().ToArray());
                }
                sb.Append(text);
                text = test.Text;
            }
            string result = sb.ToString();

            return Created($"api/test", result);
        }
    }
}
