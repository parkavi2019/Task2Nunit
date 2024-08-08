using NUnit.Framework;
using OpenQA.Selenium;
using CompetitionNunit.Utilities;
using AventStack.ExtentReports;
using static System.Collections.Specialized.BitVector32;
namespace CompetitionNunit.Pages
{
    public class EducationPage : CommonDriver
    {
        private static IWebElement newEducationfile => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[2]"));
        private static IWebElement neweditEducationfile => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[2]"));
        private static IWebElement educationTab => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]"));

        private static IWebElement AddNew => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div"));

        private static IWebElement addedUniversity => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[1]/input"));
        private static IWebElement addedCountry => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select"));
        private static IWebElement addedTitle => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select"));
        private static IWebElement addedDegree => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[2]/input"));
        private static IWebElement addedYear => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select"));
        private static IWebElement addButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]"));

        private static IWebElement editButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[1]/i"));

        private static IWebElement editedUniversity => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[1]/div[1]/input"));
        private static IWebElement editedCountry => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[1]/div[2]/select"));
        private static IWebElement editedTitle => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[2]/div[1]/select"));
        private static IWebElement editedDegree => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[2]/div[2]/input"));
        private static IWebElement editedYear => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[2]/div[3]/select"));

        private static IWebElement updateButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[3]/input[1]"));
        private static IWebElement deleteButton => driver.FindElement(By.XPath("//tbody/tr[1]/td[6]/span[2]"));
      
        public void EducationTabClick()
        {
            Thread.Sleep(2000);
            educationTab.Click();

           // ClearExistingdata();
            Thread.Sleep(2000);
        }

        public void AddEducation(string University, string Country, string Title, string Degree, string Year)

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

        public string getnewEducationfile()
        {
            Thread.Sleep(2000);
            return newEducationfile.Text;
        }


        //Edit university from the list
        public void EditEducation(string University, string Country, string Title, string Degree, string Year)
        {
            //Click On Edit button

            Thread.Sleep(1000);
            editButton.Click();

            //Edit university

            editedUniversity.Clear();
            editedUniversity.SendKeys(University);

            // Edit Country
            editedCountry.Click();
            editedCountry.SendKeys(Country);

            //Edit Title
            editedTitle.Click();
            editedTitle.SendKeys(Title);

            //Edit Degree
            editedDegree.Clear();
            editedDegree.SendKeys(Degree);

            //Edit Year
            editedYear.Click();
            editedYear.SendKeys(Year);



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

            Assert.That(actualMessage, Is.EqualTo(expectedMessage2).Or.EqualTo(expectedMessage1).Or.EqualTo(expectedMessage3));



        }
        public string getneweditEducationfile()
        {
            Thread.Sleep(2000);
            return neweditEducationfile.Text;
        }

        //Deleting a Education
        public void DeleteEducation()
        {
            Thread.Sleep(1000);

            deleteButton.Click();
        }
    }
}







