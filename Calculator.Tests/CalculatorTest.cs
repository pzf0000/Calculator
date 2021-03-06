// <copyright file="CalculatorTest.cs">Copyright ©  2018</copyright>
using System;
using Calculator;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    /// <summary>此类包含 Calculator 的参数化单元测试</summary>
    [PexClass(typeof(global::Calculator.Calculator))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class CalculatorTest
    {
        [TestMethod()]
        public void calculateTest()
        {
            Assert.AreEqual(Calculator.Calculate("1+2"), "3");
            Assert.AreEqual(Calculator.Calculate("4*2"), "8");
            Assert.AreEqual(Calculator.Calculate("3*3+2"), "11");
            Assert.AreEqual(Calculator.Calculate("3*(3+2)"), "15");
            Assert.AreEqual(Calculator.Calculate("3/(3+2)"), "0.6");
        }
    }
}
