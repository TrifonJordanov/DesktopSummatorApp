using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace DesktopCalculatorAppAutomationTests
{
    public class DesktopCalculatorApp
    {
        private const string AppiumServerUri = "http://127.0.0.1:4723/wd/hub";
        private const string SummatorAppPath = @"C:\SummatorDesktopApp.exe";
        private readonly WindowsDriver<WindowsElement> driver;

        public DesktopCalculatorApp()
        {
            var appiumOptions = new AppiumOptions()
            { PlatformName = "Windows" };
            appiumOptions.AddAdditionalCapability("app", SummatorAppPath);
            driver = new WindowsDriver<WindowsElement>(new Uri(AppiumServerUri), appiumOptions);
        }

        public WindowsElement FirsField => driver.FindElementByAccessibilityId("textBoxFirstNum");
        public WindowsElement SecondField => driver.FindElementByAccessibilityId("textBoxSecondNum");
        public WindowsElement Result => driver.FindElementByAccessibilityId("textBoxSum");
        public WindowsElement CalculateBtn => driver.FindElementByAccessibilityId("buttonCalc");

        public string Calculate(string firstField, string secondField)
        {
            this.FirsField.Click();
            this.FirsField.Clear();
            this.FirsField.SendKeys(firstField);

            this.SecondField.Click();
            this.SecondField.Clear();
            this.SecondField.SendKeys(secondField);

            this.CalculateBtn.Click();
            var result = this.Result.Text;
            return result;
        }

        public void ShutDownApp()
        {
            this.driver.CloseApp();
        }
    }
}
