using Microsoft.AspNetCore.Mvc;
using System;
using WebAPIDemo.Controllers;
using Xunit;

namespace XUnitTestProject2
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            ValuesController valuesController = new ValuesController();
            ActionResult<string> actualResult = valuesController.Get("Hi");
            Assert.Equal("Hello", actualResult.Value);
        }

        [Fact]
        public void Test2()
        {
            ValuesController valuesController = new ValuesController();
            ActionResult<string> actualResult = valuesController.Get();
            Assert.Equal("Greetings!!", actualResult.Value);
        }
    }
}
