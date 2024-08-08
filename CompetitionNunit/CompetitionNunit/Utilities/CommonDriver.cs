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

        public static EducationPage educationPageObj;
        public static CertificationPage certificationPageObj;
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
            Cleanup();
        }
        [SetUp]
        public void SetupActions()
        {
            
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
           
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
        public void Cleanup()
        {
             educationPageObj = new EducationPage();
            educationPageObj.EducationTabClick();
            educationPageObj.ClearEducationExistingdata();

             certificationPageObj = new CertificationPage();
            certificationPageObj.CertificationTabClick();
            certificationPageObj.clearCertificationExistingdata();

            /*EducationNegativepage NegativeeducationPageObj = new EducationNegativepage();
            NegativeeducationPageObj.EducationTabClick();
            NegativeeducationPageObj.ClearNegativeEducationExistingdata();

            CertificationNegativepage NegativecertificationPageObj = new CertificationNegativepage();
            NegativecertificationPageObj.CertificationTabClick();
            NegativecertificationPageObj.clearNegativeCertificationExistingdata();
*/
        }
        public void clearCertificationExistingdata()
        {
            try
            {
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[2]/i"));
                var deleteButtons = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[2]/i"));
                foreach (var button in deleteButtons)
                {
                    button.Click();
                    Thread.Sleep(2000);
                }

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("no items to delete");
            }

        }
        public void ClearEducationExistingdata()
        {
            try
            {
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[2]/i"));
                var deleteButtons = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[2]/i"));
                foreach (var button in deleteButtons)
                {
                    button.Click();
                    Thread.Sleep(2000);
                }

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("no items to delete");
            }

        }
        public void ClearNegativeEducationExistingdata()
        {
            try
            {
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id='account - profile - section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[3]/tr/td[6]/span[2]/i"));
                var deleteButtons = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[3]/tr/td[6]/span[2]/i"));
                foreach (var button in deleteButtons)
                {
                    button.Click();
                }

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("no items to delete");
            }

        }
        public void clearNegativeCertificationExistingdata()
        {
            try
            {
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[2]/i"));
                var deleteButtons = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[2]/i"));
                foreach (var button in deleteButtons)
                {
                    button.Click();
                }

            }

            catch (NoSuchElementException)
            {
                Console.WriteLine("no items to delete");
            }
        }
        public void Close()
        {
            driver.Quit();
        }
    }
}













