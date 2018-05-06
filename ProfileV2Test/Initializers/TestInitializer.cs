using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ProfileV2Test.Infrastructure;
using ProfileV2Test.Page;
using ProfileV2Test.Services;
using System;
using TechTalk.SpecFlow;

namespace ProfileV2Test.Initializers
{
    [Binding]
    public class TestInitializer
    {
        //import test accounts
        [BeforeTestRun]
        public static void OnTestBegin()
        {
            IWebDriver chromeDriver = new ChromeDriver(ProjectUrls.chromedriverPath);
            UserService userService = new UserService();

            //create page
            LandingPage lp = new LandingPage(chromeDriver);

            //navigate
            lp.GoToLandingPage();

            //authenticate
            string[] admin = userService.GetAdminCredentials();
            lp.Authenticate(admin[0], admin[1]);

            //execute the service method
            chromeDriver.Navigate().GoToUrl(ProjectUrls.createTestAccountsUrl);

            //wait for the home page
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(20));
            wait.Until(browser => browser.Url == ProjectUrls.homePageUrl);

            //quit
            chromeDriver.Quit();
        }

        //delete test accounts
        [AfterTestRun]
        public static void OnTestEnd()
        {
            IWebDriver chromeDriver = new ChromeDriver(ProjectUrls.chromedriverPath);

            //create page
            LandingPage lp = new LandingPage(chromeDriver);

            //navigate
            lp.GoToLandingPage();

            //authenticate
            lp.Authenticate("admin@profile.com", "admin123");

            //execute the service method
            chromeDriver.Navigate().GoToUrl(ProjectUrls.deleteTestAccountsUrl);

            //quit
            chromeDriver.Quit();
        }
    }
}
