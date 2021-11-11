using log4net;
using OpenQA.Selenium;
using Finitive.Pages.PageConstants;
using SeleniumAutomation.Selenium;
using System;
using NUnit.Framework;
using System.Collections.Generic;
using Finitive.Pages.PageConstants;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using SeleniumAutomation.XMLGeneration;
using System.Linq;
using System.Collections;
using SeleniumAutomation.Base;
using SeleniumAutomation.DataProvider;
using OneAtmosphere.Utilities.Generic;
using System.IO;
using System.Diagnostics;
using java.awt;
using System.Windows.Forms;
using OpenQA.Selenium.Support.Extensions;
using SeleniumAutomation.Utilities;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using OpenQA.Selenium.Chrome;

namespace Finitive.Pages.PageParts
{

    public class DataValidationPage : UA
    {
        IWebDriver _localDriver;
        ILog log4Net;
        Actions action;
        public string FinitiveTestSetup;
        public string Url;
        public IWebDriver driver;


        /// <summary>
        /// Parameterized Constructor of the class
        /// </summary>
        /// <params>WebDriver instance </params>

        public DataValidationPage(IWebDriver Driver)
            : base(Driver)
        {
            this._localDriver = Driver;
            log4Net = LogManager.GetLogger("DataValidationPage");
            FinitiveTestSetup = TestContext.Parameters["Setup"];
        }

        // Enter username and password for TaxEx application...
        public void EnterUserNameAndPasswordForTaxEx(string Username, string Password)
        {
            WaitUntilElementIsDisplayed(DataValidationPageLocators.UserNameForTaxEx, 10);
            log4Net.Info("Username is " + Username);
            SafeType(DataValidationPageLocators.UserNameForTaxEx, Username, false, 10);
            WaitUntilElementIsDisplayed(DataValidationPageLocators.PasswordForTaxEx, 10);
            log4Net.Info("Password is " + Password);
            SafeType(DataValidationPageLocators.PasswordForTaxEx, Password, false, 10);
        }
        // Enter username and password for Dev Admin site...
        public void EnterUserNameAndPasswordForDevAdmin(string Username, string Password)
        {
            WaitUntilElementIsDisplayed(DataValidationPageLocators.UserNameForTaxEx, 10);
            log4Net.Info("Username is " + Username);
            SafeType(DataValidationPageLocators.UserNameForTaxEx, Username, false, 10);
            WaitUntilElementIsDisplayed(DataValidationPageLocators.PasswordForTaxEx, 10);
            log4Net.Info("Password is " + Password);
            SafeType(DataValidationPageLocators.PasswordForTaxEx, Password, false, 10);
        }


        public void ClickOnSignupButton()
        {
            WaitUntilElementIsDisplayed(DataValidationPageLocators.SignupButton, 20);
            SafeNormalClick(DataValidationPageLocators.SignupButton, 10);
            WaitUntilElementIsExist(DataValidationPageLocators.SignupPage);
            log4Net.Info("Navigated to Signup Page");
        }

        public void ThenEnterSignupDetails(string Firstname, string Lastname, string Position, string Countrycode, string Telenum, string WebsiteUrl, string Country, string Marketingsource)
        {
            WaitUntilElementIsDisplayed(DataValidationPageLocators.FirstNameTextField, 20);
            SafeSendKeys(DataValidationPageLocators.FirstNameTextField, Firstname, 20);
            WaitUntilElementIsDisplayed(DataValidationPageLocators.LastNameTextField, 20);
            SafeSendKeys(DataValidationPageLocators.LastNameTextField, Lastname, 20);
            WaitUntilElementIsDisplayed(DataValidationPageLocators.PositionTextField, 20);
            SafeSendKeys(DataValidationPageLocators.PositionTextField, Position, 20);
            SafeActionClick(DataValidationPageLocators.CountryCodeDropdown, 20);
            SafeClickFromListOfElements(DataValidationPageLocators.CountryCodeDropdownList, Countrycode);
            SafeSendKeys(DataValidationPageLocators.TelephoneNumberTextfield, Telenum, 12);
            SafeSendKeys(DataValidationPageLocators.CompanyWebsiteUrl, WebsiteUrl, 20);
            SafeActionClick(DataValidationPageLocators.CountryDropdown, 20);
            SafeClickFromListOfElements(DataValidationPageLocators.CountryDropdownList, Country);
            SafeActionClick(DataValidationPageLocators.MarketingSourceDropdown, 20);
            SafeClickFromListOfElements(DataValidationPageLocators.MarketingSourceDropdownList, Marketingsource);
        }

        public string EnterCompanyNameAndUseOfFinitivePlatform(string CompanyName, string Platform)
        {
            WaitUntilElementIsDisplayed(DataValidationPageLocators.CompanyNameTextField, 20);
            SafeSendKeys(DataValidationPageLocators.CompanyNameTextField, CompanyName, 20);
            ScrollIntoView(DataValidationPageLocators.FinitivePlateformList);
            SafeClickFromListOfElements(DataValidationPageLocators.FinitivePlateformList, Platform);

            return CompanyName;
        }


        public void VerifyTheExpectedQuestionIsDisplayed(string Expectedquestion)
        {
            WaitUntilElementIsDisabled(DataValidationPageLocators.ExpectedQuestion, 20);
            string ExpectedQuestionText = SafeGetText(DataValidationPageLocators.ExpectedQuestion, 20, "Expected Question");
            Console.WriteLine(ExpectedQuestionText);
            Assert.AreEqual(Expectedquestion, ExpectedQuestionText);
            log4Net.Info("Expected question verified");

        }

        public void SelectTheInstitutionalInvestorCheckbox(string Investor_question)
        {
            SafeClickFromListOfElements(DataValidationPageLocators.InstitutionalInvestorCheckbox, Investor_question);
        }

        public void VerifyDescribeCompanyQuestionIsDisplayed(string QuestionExpected)
        {
            WaitUntilElementIsDisabled(DataValidationPageLocators.QuestionExpected, 20);
            string ExpectedQuestionText = SafeGetText(DataValidationPageLocators.QuestionExpected, 20, "Question Expected");
            Console.WriteLine(ExpectedQuestionText);
            Assert.AreEqual(QuestionExpected, ExpectedQuestionText);
            log4Net.Info("Expected question verified");
        }

        public string SelectTheOptionDescribingTheCompany(string Describe_company, string Email, string Pwd)
        {
            SafeClickFromListOfElements(DataValidationPageLocators.DescribeYourCompanyCheckbox, Describe_company);
            SafeSendKeys(DataValidationPageLocators.BusinessEmailTextField, Email, 20);
            SafeSendKeys(DataValidationPageLocators.PasswordTextField, Pwd, 20);
            SafeActionClick(DataValidationPageLocators.TermsprivacyCheckbox);
            waitForTime(5);
            return Email;
        }

        public void ClickOnSignup()
        {
            ScrollIntoView(DataValidationPageLocators.ButtonSignup);
            WaitUntilElementIsDisplayed(DataValidationPageLocators.ButtonSignup, 20);
            SafeActionClick(DataValidationPageLocators.ButtonSignup);
            waitForTime(5);
            log4Net.Info("Navigated to Email Verification pending page");
            SafeActionClick(DataValidationPageLocators.UserNameButton);
            SafeActionClick(DataValidationPageLocators.LogOffButton);
        }

        public string ReadAndVerifyTheEmail(string emailID, string emailsubject, int countofEmail)
        {
            string emailpart = emailID.Replace("@gmail.com", "");
            GmailUtility gmailUtility = new GmailUtility(emailID, "UNREAD", "\\Resources\\GmailAuth\\" + emailpart + "credentials.json", "\\Resources\\GmailAuth\\" + emailpart + "token.json");
            waitForTime(TimeOuts.SHORTWAIT);
            string emailData = gmailUtility.getTheDataFromTheEmail(emailsubject, countofEmail);
            //Console.WriteLine(emailData);
            string VerifyEmail = this.FindTextBetween(emailData, "href=", "target=");
            string NewURL = VerifyEmail.ToString().Substring(1, VerifyEmail.Length - 2).Replace("amp;", "");
            Console.WriteLine(NewURL);
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(NewURL);
            bool IsEmailSuccessfull = driver.FindElement(DataValidationPageLocators.EmailVerificationSuccessful).Displayed;
            Assert.IsTrue(IsEmailSuccessfull);
            driver.Quit();
            return VerifyEmail;

        }

        public string FindTextBetween(string text, string left, string right)
        {
            // TODO: Validate input arguments
            int beginIndex = text.IndexOf(left); // find occurence of left delimiter
            if (beginIndex == -1)
                return string.Empty; // or throw exception?
            beginIndex += left.Length;
            int endIndex = text.IndexOf(right, beginIndex); // find occurence of right delimiter
            if (endIndex == -1)
                return string.Empty; // or throw exception?


            return text.Substring(beginIndex, endIndex - beginIndex).Trim();
        }

        public void VerifyUserNavigatedToFinitiveSite(string PageTitle)
        {
            string ActualTitle = driver.Title;
            Assert.AreEqual(PageTitle,ActualTitle); 
            log4Net.Info("Finitive site title verified and user navigated successfully");

        }

        public void VerifyUserNavigatedToSignUpPage(String SignupTitle)
        {
            WaitUntilElementIsDisplayed(DataValidationPageLocators.SignUpPageText, 20);
            string SignUpPageTitle = SafeGetText(DataValidationPageLocators.SignUpPageText, 20, "SignUp Page Title");
            Console.WriteLine(SignUpPageTitle);
            Assert.AreEqual(SignupTitle, SignUpPageTitle);
            log4Net.Info("Signup page title verified and user navigated successfully");
        }


        public void LoginAsAdminNavigateToNotifications(string UserName, string Password, string MenuInput)
        {
            WaitUntilElementIsDisabled(DataValidationPageLocators.LoginButton, 20);
            SafeActionClick(DataValidationPageLocators.LoginButton);
            WaitUntilElementIsDisabled(DataValidationPageLocators.LoginEmailTextField, 20);
            SafeSendKeys(DataValidationPageLocators.LoginEmailTextField, UserName,10);
            SafeActionClick(DataValidationPageLocators.LoginSubmitButton);
            SafeSendKeys(DataValidationPageLocators.PasswordTextField, Password, 10);
            SafeActionClick(DataValidationPageLocators.LoginSubmitButton);
            WaitUntilElementIsDisabled(DataValidationPageLocators.UserNameButton, 20);
            SafeActionClick(DataValidationPageLocators.UserNameButton);
            SafeClickFromListOfElements(DataValidationPageLocators.MenuDropDown, MenuInput);
            SafeActionClick(DataValidationPageLocators.NotificationDropdown);
            
        }



    }
}


