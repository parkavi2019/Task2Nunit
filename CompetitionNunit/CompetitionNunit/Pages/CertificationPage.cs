using CompetitionNunit.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionNunit.Pages
{
    public class CertificationPage : CommonDriver
    {
        private static IWebElement newCertificationfile => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[1]"));
        private static IWebElement neweditCertificationfile => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[1]"));
        private static IWebElement certificationTab => driver.FindElement(By.XPath("//a[contains(text(),'Certifications')]"));
        private static IWebElement addNewButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div"));
        private static IWebElement CertificateTextBox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[1]/div/input"));

        private static IWebElement CertifiedFromTextBox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[1]/input"));

        private static IWebElement YearDropDown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[2]/select"));
        private static IWebElement AddButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]"));
        private static IWebElement EditButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[1]/i"));
        private static IWebElement editedCertification => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/div/div[1]/input"));
        private static IWebElement editedCertifiedFrom => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/div/div[2]/input"));
        private static IWebElement editedYear => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/div/div[3]/select"));
        private static IWebElement UpdateButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
        private static IWebElement DeleteButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[2]/i"));

      
        public void CertificationTabClick()
        {
           
            certificationTab.Click();
           // clearExistingdata();
            Thread.Sleep(2000);
        }
        public void AddCertification(string Certification, string CertifiedFrom, string Year)
        {
            

            // Click on AddNew button
            addNewButton.Click();

            //Add certification that needs to be 
            CertificateTextBox.SendKeys(Certification);

            //Enter  CertifiedFrom
            CertifiedFromTextBox.SendKeys(CertifiedFrom);

            //Enter year
            WaitUtilitie.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[2]/select", 1);
            YearDropDown.Click();
            YearDropDown.SendKeys(Year);

            // click addnew button
            AddButton.Click();
            Thread.Sleep(1000);


            IWebElement Messagebox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

            WaitUtilitie.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 100);

            string actualMessage = Messagebox.Text;
            Console.WriteLine(actualMessage);

            string expectedMessage1 = "J2EE has been added to your certification";
            string expectedMessage2 = "Please enter Certification Name,Certification From and Certification Year";
            string expectedMessage3 = "This information is already exist.";

            Assert.That(actualMessage, Is.EqualTo(expectedMessage1).Or.EqualTo(expectedMessage2).Or.EqualTo(expectedMessage3));
        }
        public string getnewCertificatefile()
        {
            Thread.Sleep(2000);
            return neweditCertificationfile.Text;
        }


        //Edit Certification
        public void EditCertification(string Certification, string CertifiedFrom, string Year)
        {
            //Click on editbutton
            Thread.Sleep(1000);

            EditButton.Click();
            //Edit Certification
            editedCertification.Clear();

            editedCertification.SendKeys(Certification);
            //Edit CertificationFrom
            editedCertifiedFrom.Clear();
            editedCertifiedFrom.SendKeys(CertifiedFrom);
            //Edit year
            editedYear.Click();
            editedYear.SendKeys(Year);




            //Click On UpdateButton
            UpdateButton.Click();
            Thread.Sleep(2000);

            
            IWebElement Messagebox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

            WaitUtilitie.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 3);

            string actualMessage = Messagebox.Text;
            Console.WriteLine(actualMessage);
            string expectedMessage1 = "Java has been updated to your certification";
            string expectedMessage2 = "Please enter Certification Name,Certification From and Certification Year";
            string expectedMessage3 = "This information is already exist.";

            Assert.That(actualMessage, Is.EqualTo(expectedMessage1).Or.EqualTo(expectedMessage2).Or.EqualTo(expectedMessage3));


        }

        public string geteditCertificatefile()
        {
            Thread.Sleep(2000);
            return neweditCertificationfile.Text;
        }



        public void DeleteCertification()
        {
            Thread.Sleep(1000);
            WaitUtilitie.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[2]/i", 1);
            DeleteButton.Click();


        }
    }
}
