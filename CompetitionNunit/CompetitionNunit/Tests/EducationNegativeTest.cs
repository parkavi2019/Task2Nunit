using AventStack.ExtentReports;
using CompetitionNunit.Pages;
using CompetitionNunit.TestModel;

using CompetitionNunit.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CompetitionNunit.Tests
{
    // [TestFixture]
    public class EducationNegativeTest : CommonDriver
    {


        EducationNegativepage NegativeeducationPageObj;


#pragma warning disable
        public EducationNegativeTest()
        {

            NegativeeducationPageObj = new EducationNegativepage();
        }




        [Test, Order(1)]
        public void TestAddEducation()

        {
            NegativeeducationPageObj.EducationTabClick();
            

            //read test data from the json file
            List<EducationTestModel> AddEducationNegative = JsonHelper.ReadTestDataFromJson<EducationTestModel>("F:\\CompetitionTask\\Task2Nunit\\CompetitionNunit\\CompetitionNunit\\JsonFile\\AddEducationNegative.json");
            Console.WriteLine(AddEducationNegative.ToString());
            foreach (var data in AddEducationNegative)
            {
                string University = data.University;
                Console.WriteLine(University);

                string Country = data.Country;
                Console.WriteLine(Country);

                string Title = data.Title;
                Console.WriteLine(Title);

                string Degree = data.Degree;
                Console.WriteLine(Degree);

                string Year = data.Year;
                Console.WriteLine(Year);
                NegativeeducationPageObj.AddInvalidEducation(University, Country, Title, Degree, Year);



                IWebElement messagebox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));


                WaitUtilitie.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 100);
                string actualMessage = messagebox.Text;
                Console.WriteLine(actualMessage);
                string expectedMessage1 = "Education has been added";
                string expectedMessage2 = "please enter all the fields";
                string expectedMessage3 = "This information is already exist.";

                Assert.That(actualMessage, Is.EqualTo(expectedMessage2).Or.EqualTo(expectedMessage1).Or.EqualTo(expectedMessage3));

            }





        }





        [Test, Order(2)]
        public void TestEditEducation()

        {
            NegativeeducationPageObj.EducationTabClick();
            
            TestAddEducation();
            //read test data from the json file
            List<EducationTestModel> EditEducationNegative = JsonHelper.ReadTestDataFromJson<EducationTestModel>("F:\\CompetitionTask\\Task2Nunit\\CompetitionNunit\\CompetitionNunit\\JsonFile\\EditEducationNegativefile.json");
            Console.WriteLine(EditEducationNegative.ToString());
            foreach (var data in EditEducationNegative)
            {
                string University = data.University;
                Console.WriteLine(University);

                string Country = data.Country;
                Console.WriteLine(Country);

                string Title = data.Title;
                Console.WriteLine(Title);

                string Degree = data.Degree;
                Console.WriteLine(Degree);

                string Year = data.Year;
                Console.WriteLine(Year);
                NegativeeducationPageObj.EditInvalidEducation(University, Country, Title, Degree, Year);


                IWebElement messagebox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));


                WaitUtilitie.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 100);
                string actualMessage = messagebox.Text;
                Console.WriteLine(actualMessage);
                string expectedMessage1 = "Education as been updated";
                string expectedMessage2 = "please enter all the fields";
                string expectedMessage3 = "This information is already exist.";

                Assert.That(actualMessage, Is.EqualTo(expectedMessage1).Or.EqualTo(expectedMessage2).Or.EqualTo(expectedMessage3));

            }





        }


    }
}
