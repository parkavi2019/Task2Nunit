using CompetitionNunit.Utilities;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionNunit.Pages
{
    public class SigninPage : CommonDriver
    {

        private IWebElement signInButton => driver.FindElement(By.XPath("//a[contains(text(),'Sign In')]"));
        private IWebElement emailAddressTextBox => driver.FindElement(By.Name("email"));
        private IWebElement passwordTextBox => driver.FindElement(By.Name("password"));
        private IWebElement loginButton => driver.FindElement(By.XPath("//button[contains(text(),'Login')]"));

        public void SignInSteps()
        {


            Thread.Sleep(3000);
            driver.Navigate().GoToUrl("http://localhost:5000/");
            signInButton.Click();

            //Login credentials from the Json file
            string jsonFilePath = "F:\\CompetitionTask\\Task2Nunit\\CompetitionNunit\\CompetitionNunit\\JsonFile\\Signinfile.json";
        


            //Deserialize the Json content
            string jsonContent = File.ReadAllText(jsonFilePath);

            // parse json using jobject
#pragma warning disable
            JObject jsonObject = JObject.Parse(jsonContent);

            string email = jsonObject["email"].ToString();

            string password = jsonObject["password"].ToString();
            Thread.Sleep(3000);

            // click the sign in button
            // WaitUtilitie.WaitToBeClickable(driver, "XPath", "//*[@id=\"home\"]/div/div/div[1]/div/a", 5);

            //enter the provided email
            WaitUtilitie.WaitToBeVisible(driver, "Name", "email", 5);
            emailAddressTextBox.SendKeys(email);

            //enter the password
            WaitUtilitie.WaitToBeVisible(driver, "Name", "password", 5);
            passwordTextBox.SendKeys(password);

            //click login  button
            WaitUtilitie.WaitToBeClickable(driver, "XPath", "//button[contains(text(),'Login')]", 5);
            loginButton.Click();
            Thread.Sleep(3000);

        }

    }
}
