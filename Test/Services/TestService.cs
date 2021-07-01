using System.Collections.Generic;
using Test.Repositories;

namespace Test.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;

        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public IEnumerable<TestObj> GetAll()
        {
            var tests = _testRepository.GetAll();

            return tests;
        }

        public TestObj Create(int number, string text)
        {
            var test = new TestObj(number, text);
            return _testRepository.Add(test);
        }
    }
}
