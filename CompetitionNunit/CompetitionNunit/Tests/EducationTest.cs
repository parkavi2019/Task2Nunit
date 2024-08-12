using AventStack.ExtentReports;
using CompetitionNunit.Pages;
using CompetitionNunit.TestModel;

using CompetitionNunit.Utilities;
using NUnit.Framework;

namespace CompetitionNunit.Tests
{
    [TestFixture]
    public class EducationTest : CommonDriver
    {


        EducationPage educationPageObj;

#pragma warning disable
        public EducationTest()
        {

            educationPageObj = new EducationPage();
        }





        [Test, Order(1)]
        public void TestAddEducation()

        {

            educationPageObj.EducationTabClick();
            Thread.Sleep(2000);
          

            //read test data from the json file
            List<EducationTestModel> AddEducationfile = JsonHelper.ReadTestDataFromJson<EducationTestModel>("F:\\CompetitionTask\\Task2Nunit\\CompetitionNunit\\CompetitionNunit\\JsonFile\\AddEducationfile.json");
            Console.WriteLine(AddEducationfile.ToString());
            foreach (var data in AddEducationfile)
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



                educationPageObj.AddEducation(University, Country, Title, Degree, Year);
                string newEducationfile = educationPageObj.getnewEducationfile();



                if (University == newEducationfile)

                {
                    Assert.That(University, Is.EqualTo(newEducationfile));
                }
                else
                {
                    Console.WriteLine("Check error");


                }



            }





        }
        [Test, Order(2)]
        public void TestEditEducation()
        {
            educationPageObj.EducationTabClick();
            TestAddEducation();
            //read test data from the json file
            List<EducationTestModel> editEducationTestData = JsonHelper.ReadTestDataFromJson<EducationTestModel>("F:\\CompetitionTask\\Task2Nunit\\CompetitionNunit\\CompetitionNunit\\JsonFile\\EditEducationfile.json");
            foreach (var data in editEducationTestData)
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
                educationPageObj.EditEducation(University, Country, Title, Degree, Year);
                string neweditEducationfile = educationPageObj.getneweditEducationfile();

                if (University == neweditEducationfile)
                {
                    Assert.That(University, Is.EqualTo(neweditEducationfile));
                }
                else
                {
                    Console.WriteLine("Check error");


                }



            }


        }
        [Test, Order(3)]
        public void TestDeleteEducation()
        {
            educationPageObj.EducationTabClick();
            TestAddEducation();
            educationPageObj.DeleteEducation();

            //read test data from the json file
            List<EducationTestModel> deleteEducationTestData = JsonHelper.ReadTestDataFromJson<EducationTestModel>("F:\\CompetitionTask\\Task2Nunit\\CompetitionNunit\\CompetitionNunit\\JsonFile\\DeleteEducationfile.json");


        }

    }
}
