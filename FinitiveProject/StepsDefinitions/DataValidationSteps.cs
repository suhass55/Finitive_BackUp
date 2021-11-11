using log4net;
using NUnit.Framework;
using Finitive.Pages.PageParts;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using SeleniumAutomation.Base;
using SeleniumAutomation.Selenium;
using SeleniumAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Xml;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Finitive.Pages.PageConstants;
using OpenQA.Selenium.Chrome;

namespace Finitive.StepsDefinitions
{
    [Binding]
    public class DataValidationSteps : BaseClass
    {
        public DataValidationPage _DataValidationPage;
        public string Filename;
        public string CompanyName1;
        public string ImportError;
        public IWebDriver driver;
        public ILog log4Net;
        public string FinitiveTestSetup;
        public string CompanyDateToUpdate;
        public string CompanyDateReceived;


        public Dictionary<string, string> _QTDDictionary = new Dictionary<string, string>();
        public Dictionary<string, string> _YTDDictionary = new Dictionary<string, string>();
        public string _QERQuarter;
        public List<string> _Covid19LinksTaxData = new List<string>();
        public DataValidationSteps(IWebDriver _driver)
        {
            driver = _driver;
            log4Net = LogManager.GetLogger("DataValidationSteps");
            _autoutilities = new AutomationUtilities();
            _DataValidationPage = new DataValidationPage(driver);
            FinitiveTestSetup = TestContext.Parameters["Setup"];
        }
        public string TaxCode { get; set; }
        public string ReportCode { get; set; }
        public string EmployeeSSN { get; set; }
        public string MessageType { get; set; }
        public string Message { get; set; }
        public string DataSetup { get; private set; }

        public string Resources_Path;
        public string CompName;
        public string CompName2;
        public string CompName3;
        public string CompName1;
        public string Url;
        public string portlet;
        public int iCategory, iCode;
        public static string cname = null;
        public static string ccode = null;
        public static string EIN = null;
        public static string cname2 = null;
        public static string cname3 = null;
        public static string Portlet = null;
        public string FileNameToImport = "XMLWithCurrentQuarter";


        [Given(@"Navigate to Finitive url And Verify '(.*)'")]
        public void ThenNavigateToUrl(string PageTitle)
        {
            if (FinitiveTestSetup == "Yes")
            {
                Url = TestContext.Parameters["FinitiveURL"];
                driver.Navigate().GoToUrl(Url);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.Manage().Window.Maximize();
                string ActualTitle = driver.Title;
                Assert.AreEqual(PageTitle, ActualTitle);
                log4Net.Info("Finitive site title verified and user navigated successfully");

            }
        }

        [Then(@"Click On Signup Button In The Header")]
        public void ThenClickOnSignupButton()
        {
            _DataValidationPage.ClickOnSignupButton();
        }

        [Then(@"Verify User Navigates to '(.*)' Page")]
        public void VerifyUserNavigatesToSignupPage(string SignupTitle)
        {
            _DataValidationPage.VerifyUserNavigatedToSignUpPage(SignupTitle);
        }


        [Then(@"Enter Valid Signup Details")]
        public void ThenEnterSignupDetails()
        {
            long milliseconds = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            _DataValidationPage.ThenEnterSignupDetails("Test", "ZenQ" + milliseconds, "Test Engineer", "+91", "9630405561", "WWW.Test.com", "India", "Online Search");

        }

        [Then(@"Enter Company Name And Your Use From FinitivePlatform")]
        public void EnterCompanyNameAndUseOfFinitivePlatform()
        {
            _DataValidationPage.EnterCompanyNameAndUseOfFinitivePlatform("ZenQ", "Invest");
            

        }

        [Then(@"Verify The Expected Question '(.*)' Is Desplayed")]
        public void VerifyTheExpectedQuestionIsDisplayed(string Expectedquestion)
        {
            _DataValidationPage.VerifyTheExpectedQuestionIsDisplayed(Expectedquestion);
        }

        [Then(@"Select The Institutional Investor Checkbox As '(.*)'")]
        public void SelectInstitutionalInvestorCheckbox(string Investor_question)
        {
            _DataValidationPage.SelectTheInstitutionalInvestorCheckbox(Investor_question);
        }

        [Then(@"Verify Describe Company Question '(.*)' Is Displayed")]
        public void VerifyDescribeCompanyQuestionDisplayed(string QuestionExpected)
        {
            _DataValidationPage.VerifyDescribeCompanyQuestionIsDisplayed(QuestionExpected);
        }

        [Then(@"Select The Option Describing The Company")]
        public void SelectOptionDescribingTheCompany()
        {
            long milliseconds = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            _DataValidationPage.SelectTheOptionDescribingTheCompany("Asset Manager", "testzenq98+" + milliseconds + "@gmail.com", "Second@123");
        }



        [Then(@"Click On Signup")]
        public void ThenClickOnSignup()
        {
            _DataValidationPage.ClickOnSignup();

        }


        [Then(@"Login And Click On Verify Button From Registered Email")]
        public void ThenClickOnVerifyButtonFromRegisteredEmailAndVerify()
        {

            _DataValidationPage.ReadAndVerifyTheEmail(TestContext.Parameters["UserName"], "Finitive: New User Verification", 1);
            
        }

        [Then(@"Login And Verify User Created In The Admin Portal")]
        public void LoginAndVerifyUserCreatedInTheAdminPortal()
        {
            _DataValidationPage.LoginAsAdminNavigateToNotifications("saikrishna.oggo@zenq.com", "Nopassword@2", "Dashboard");
        }
    }

}
