using System.Collections.Generic;

namespace Test
{
    public interface ITestService
    {
        IEnumerable<TestObj> GetAll();
        TestObj Create(int number, string text);
    }
}
