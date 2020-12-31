using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleAppNetCoreDI
{
    public class MyDependency1 : IMyDependency1
    {
        private string TestString;

        public MyDependency1(string message)
        {
            TestString = message;
        }

        // We're going to use this method to verify that dependency injection worked. If MyDependency is successfully injected into the client code without the client code having to explicitly instantiate MyDependency, then TestString will be initialized and will equal "mydependency is injected"
        public String TestDependencyInjection()
        {
            return TestString;
        }
    }
}
