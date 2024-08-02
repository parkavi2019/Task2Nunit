using AventStack.ExtentReports;
using CompetitionNunit.TestModel;
using CompetitionNunit.Pages;

using CompetitionNunit.Utilities;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionNunit.Tests
{
    public class CertificationNegativeTest : CommonDriver
    {


        CertificationNegativepage NegativecertificationPageObj;
#pragma warning disable
        public CertificationNegativeTest()
        {

            NegativecertificationPageObj = new CertificationNegativepage();
        }
        [Test, Order(1)]
        public void TestAddCertification()
        {
            NegativecertificationPageObj.CertificationTabClick();
          

            //read test data from the json file
            List<CertificationTestModel> addNegativeTestData = JsonHelper.ReadTestDataFromJson<CertificationTestModel>("F:\\CompetitionTask\\Task2Nunit\\CompetitionNunit\\CompetitionNunit\\JsonFile\\AddCertificationNegativefile.json");
            Console.WriteLine(addNegativeTestData.ToString());
            foreach (var data in addNegativeTestData)
            {
                string Certificate = data.Certificate;
                Console.WriteLine(Certificate);

                string CertifiedFrom = data.CertifiedFrom;
                Console.WriteLine(CertifiedFrom);

                string Year = data.Year;
                Console.WriteLine(Year);
                NegativecertificationPageObj.AddInvalidCertification(Certificate, CertifiedFrom, Year);




                IWebElement Messagebox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

                WaitUtilitie.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 100);

                string actualMessage = Messagebox.Text;
                Console.WriteLine(actualMessage);

                string expectedMessage1 = "J2EE12 has been added to your certification";
                string expectedMessage2 = "Please enter Certification Name,Certification From and Certification Year";
                string expectedMessage3 = "This information is already exist.";

                Assert.That(actualMessage, Is.EqualTo(expectedMessage1).Or.EqualTo(expectedMessage2).Or.EqualTo(expectedMessage3));

            }




        }
        [Test, Order(2)]
        public void TestEditCertification()
        {
            NegativecertificationPageObj.CertificationTabClick();
            Thread.Sleep(1000);

            
            //read test data from the json file
            List<CertificationTestModel> EditCertificationNegative = JsonHelper.ReadTestDataFromJson<CertificationTestModel>("F:\\CompetitionTask\\Task2Nunit\\CompetitionNunit\\CompetitionNunit\\JsonFile\\EditCertificationNegativefile.json");
            Console.WriteLine(EditCertificationNegative.ToString());
            foreach (var data in EditCertificationNegative)
            {
                string Certificate = data.Certificate;
                Console.WriteLine(Certificate);

                string CertifiedFrom = data.CertifiedFrom;
                Console.WriteLine(CertifiedFrom);

                string Year = data.Year;
                Console.WriteLine(Year);

                NegativecertificationPageObj.EditCertification(Certificate, CertifiedFrom, Year);
                WaitUtilitie.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/span/input[1]", 1);
                IWebElement Messagebox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

                WaitUtilitie.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 3);

                string actualMessage = Messagebox.Text;
                Console.WriteLine(actualMessage);
                string expectedMessage1 = "Java has been updated to your certification";
                string expectedMessage2 = "Please enter Certification Name,Certification From and Certification Year";
                string expectedMessage3 = "This information is already exist.";

                Assert.That(actualMessage, Is.EqualTo(expectedMessage1).Or.EqualTo(expectedMessage2).Or.EqualTo(expectedMessage3));


            }

        }
    }

}
