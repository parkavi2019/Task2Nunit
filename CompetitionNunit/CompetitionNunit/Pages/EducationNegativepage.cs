using CompetitionNunit.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionNunit.Pages
{
    public class EducationNegativepage : CommonDriver

    {
        private static IWebElement educationTab => driver.FindElement(By.XPath("//a[text()='Education']"));

        private static IWebElement AddNew => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div"));

        private static IWebElement addedUniversity => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[1]/input"));
        private static IWebElement addedCountry => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select"));
        private static IWebElement addedTitle => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select"));
        private static IWebElement addedDegree => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[2]/input"));
        private static IWebElement addedYear => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select"));
        private static IWebElement addButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]"));
        private static IWebElement editButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[1]/i"));
        private static IWebElement editUniversity => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[1]/div[1]/input"));
        private static IWebElement editCountry => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[1]/div[2]/select"));
        private static IWebElement editTitle => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[2]/div[1]/select"));
        private static IWebElement editDegree => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[2]/div[2]/input"));
        private static IWebElement editYear => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[2]/div[3]/select"));
        private static IWebElement updateButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[3]/input[1]"));




       
        public void EducationTabClick()
        {

            educationTab.Click();
        }

        public void AddInvalidEducation(string University, string Country, string Title, string Degree, string Year)

        {
            // Click on AddNew button
            AddNew.Click();

            //Enter the University that needs to be added
            Thread.Sleep(1000);
            addedUniversity.SendKeys(University);

            //Enter the Country that needs to be added
            addedCountry.SendKeys(Country);

            //Enter the Title that need to be added

            addedTitle.Click();

            addedTitle.SendKeys(Title);

            //Enter the Degree that need to be added

            addedDegree.SendKeys(Degree);

            //Enter the Year of gratuation that need to be added
            addedYear.Click();

            addedYear.SendKeys(Year);

            //click addnew button

            addButton.Click();

            Thread.Sleep(2000);
            IWebElement messagebox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));


            WaitUtilitie.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 100);

            string actualMessage = messagebox.Text;
            Console.WriteLine(actualMessage);
            string expectedMessage1 = "Education has been added";
            string expectedMessage2 = "please enter all the fields";
            string expectedMessage3 = "This information is already exist.";

            Assert.That(actualMessage, Is.EqualTo(expectedMessage2).Or.EqualTo(expectedMessage1).Or.EqualTo(expectedMessage3));

        }
        public void EditInvalidEducation(string University, string Country, string Title, string Degree, string Year)
        {
            //Click On Edit button

            Thread.Sleep(1000);
            editButton.Click();

            //Edit university

            editUniversity.Clear();
            editUniversity.SendKeys(University);

            // Edit Country
            editCountry.Click();
            editCountry.SendKeys(Country);

            //Edit Title
            editTitle.Click();
            editTitle.SendKeys(Title);

            //Edit Degree
            editDegree.Clear();
            editDegree.SendKeys(Degree);

            //Edit Year
            editYear.Click();
            editYear.SendKeys(Year);



            //Click on update button
            updateButton.Click();
            Thread.Sleep(2000);


            IWebElement Messagebox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

            WaitUtilitie.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 100);

            string actualMessage = Messagebox.Text;
            Console.WriteLine(actualMessage);
            string expectedMessage1 = "Education as been updated";
            string expectedMessage2 = "Please enter all the fields";
            string expectedMessage3 = "This information is already exist.";

            Assert.That(actualMessage, Is.EqualTo(expectedMessage1).Or.EqualTo(expectedMessage2).Or.EqualTo(expectedMessage3));



        }

    }
}

