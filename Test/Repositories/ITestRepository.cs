using System.Collections.Generic;

namespace Test.Repositories
{
    public interface ITestRepository
    {
        IEnumerable<TestObj> GetAll();
        TestObj Add(TestObj test);
    }
}
