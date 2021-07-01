using System.Collections.Generic;
namespace Test.Repositories
{
    public class TestRepository : ITestRepository
    {
        private static readonly ISet<TestObj> _tests = new HashSet<TestObj>()
        {
            new TestObj(1, "Text 1"),
            new TestObj(2, "Text 2")
        };

        public IEnumerable<TestObj> GetAll()
        {
            return _tests;
        }

        public TestObj Add(TestObj test)
        {
            _tests.Add(test);
            return test;
        }
    }
}
