using AventStack.ExtentReports;
using CompetitionNunit.TestModel;
using CompetitionNunit.Pages;


using CompetitionNunit.Utilities;
using NUnit.Framework;

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionNunit.Tests
{
    [TestFixture]
    public class CertificationTest : CommonDriver
    {

        CertificationPage certificationPageObj;
#pragma warning disable
        public CertificationTest()
        {

            certificationPageObj = new CertificationPage();
        }


        [Test, Order(1)]
        public void TestAddCertification()

        {
            certificationPageObj.CertificationTabClick();
            Thread.Sleep(2000);
          

            //read test data from the json file
            List<CertificationTestModel> AddCertificationfile = JsonHelper.ReadTestDataFromJson<CertificationTestModel>("F:\\CompetitionTask\\Task2Nunit\\CompetitionNunit\\CompetitionNunit\\JsonFile\\AddCertificationfile.json");
            Console.WriteLine(AddCertificationfile.ToString());
            foreach (var data in AddCertificationfile)
            {
                string Certificate = data.Certificate;
                Console.WriteLine(Certificate);

                string CertifiedFrom = data.CertifiedFrom;
                Console.WriteLine(CertifiedFrom);

                string Year = data.Year;
                Console.WriteLine(Year);

                certificationPageObj.AddCertification(Certificate, CertifiedFrom, Year);
                string newCertificatefile = certificationPageObj.getnewCertificatefile();

                if (Certificate == newCertificatefile)
                {
                    Assert.That(Certificate, Is.EqualTo(newCertificatefile));
                }
                else
                {
                    Console.WriteLine("Check error");


                }

            }





        }
        [Test, Order(2)]
        public void TestEditCertification()
        {
            certificationPageObj.CertificationTabClick();

            Thread.Sleep(1000);
            TestAddCertification();

            //read test data from the json file
            List<CertificationTestModel> editCertificationTestData = JsonHelper.ReadTestDataFromJson<CertificationTestModel>("F:\\CompetitionTask\\Task2Nunit\\CompetitionNunit\\CompetitionNunit\\JsonFile\\EditCertificationfile.json");
            Console.WriteLine(editCertificationTestData.ToString());
            foreach (var data in editCertificationTestData)
            {
                string Certificate = data.Certificate;
                Console.WriteLine(Certificate);

                string CertifiedFrom = data.CertifiedFrom;
                Console.WriteLine(CertifiedFrom);

                string Year = data.Year;
                Console.WriteLine(Year);

                certificationPageObj.EditCertification(Certificate, CertifiedFrom, Year);
                string neweditCertificationfile = certificationPageObj.geteditCertificatefile();

                if (Certificate == neweditCertificationfile)
                {
                    Assert.That(Certificate, Is.EqualTo(neweditCertificationfile));
                }
                else
                {
                    Console.WriteLine("Check error");


                }

            }

        }
        [Test, Order(3)]
        public void TestDeleteCertification()
        {
            certificationPageObj.CertificationTabClick();
            TestAddCertification();


            certificationPageObj.DeleteCertification();
            List<CertificationTestModel> editCertificationTestData = JsonHelper.ReadTestDataFromJson<CertificationTestModel>("F:\\CompetitionTask\\Task2Nunit\\CompetitionNunit\\CompetitionNunit\\JsonFile\\DeleteCertificationfile.json");
        }

    }
}
