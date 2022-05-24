using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace DesktopCalculatorAppAutomationTests
{
    public class DesktopCalculatorAppTests
    {
        private DesktopCalculatorApp driver;
        [OneTimeSetUp]
        public void Setup()
        {
            this.driver = new DesktopCalculatorApp();
        }

        [OneTimeTearDown]
        public void ShutDown()
        {
            driver.ShutDownApp();
        }
        [TestCase("12", "12", "24")]
        [TestCase("-1", "-1", "-2")]
        [TestCase("-1", "2", "1")]
        [TestCase("0", "0", "0")]
        [TestCase("1a", "1A", "error")]
        [TestCase("12", "", "error")]
        [TestCase("", "12", "error")]
        [TestCase("", "", "error")]
        public void Test1(string first, string second, string result)
        {
            var expectedResult = result;
            var actualResult = driver.Calculate(first, second);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}