using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using CompetitionNunit.Pages;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System;
using System.Drawing.Imaging;
using OpenQA.Selenium.Edge;


namespace CompetitionNunit.Utilities
{
    public class CommonDriver
    {
#pragma warning disable
        public static IWebDriver driver;
        private ExtentReports extent;
        private ExtentTest test;
        [OneTimeSetUp]
        public void ExtentReportsSetup()
        {
            try
            {
                extent = new ExtentReports();
                var htmlReporter = new ExtentHtmlReporter("F:\\CompetitionTask\\Task2Nunit\\CompetitionNunit\\CompetitionNunit\\ExtentReports\\");
                extent.AttachReporter(htmlReporter);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting up ExtentReports: {ex.Message}");
            }
        }
        [SetUp]
        public void SetupActions()
        {
            Console.WriteLine("Setting up WebDriver...");
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/");
            SigninPage signinPage = new SigninPage();
            signinPage.SignInSteps();
            var testTitle = TestContext.CurrentContext.Test.Name;
            Console.WriteLine($"Executing test: {testTitle}");
            test = extent.CreateTest(testTitle);
        }
        [TearDown]
        public void TearDownActions()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {
                test.Log(Status.Pass, "Test Passed");
            }
            else
            {
                test.Log(Status.Fail, $"Test Failed: {TestContext.CurrentContext.Result.Message}");
            }
            CaptureScreenshot(TestContext.CurrentContext.Test.Name);
            Close();
        }
        [OneTimeTearDown]
        public void ExtentReportsCleanup()
        {
            extent.Flush();
        }
        public void CaptureScreenshot(string screenshotName)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshotPath = $"Screenshots/{screenshotName}_{DateTime.Now:yyyyMMddHHmmss}.png";
            string fullPath = Path.Combine("F:\\CompetitionTask\\Task2Nunit\\CompetitionNunit\\CompetitionNunit\\", screenshotPath);
            screenshot.SaveAsFile(fullPath, OpenQA.Selenium.ScreenshotImageFormat.Png);
        }
        public void Close()
        {
            driver.Quit();
        }
    }
}













