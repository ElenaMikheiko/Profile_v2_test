using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ProfileV2Test.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProfileV2Test.Page
{
    public class LandingPage
    {
        private readonly IWebDriver _webDriver;
        private readonly string url = ProjectUrls.landingPageUrl;

        public LandingPage(IWebDriver browser)
        {
            _webDriver = browser;
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.ClassName, Using = "container__header_text")]
        public IWebElement PageTitle { get; set; }

        [FindsBy(How = How.ClassName, Using = "content__text")]
        public IWebElement WelcomeText { get; set; }

        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement EmailInputField { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement PasswordInputField { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn")]
        public IWebElement LoginButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "content__input_recovery")]
        public IWebElement RecoverPasswordSpan { get; set; }

        [FindsBy(How = How.ClassName, Using = "field-validation-error")]
        public IWebElement ErrorMessage { get; set; }


        /// <summary>
        /// Clears the input fields, inputs data and clicks the login button.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        public void Authenticate(string login, string password)
        {
            EmailInputField.Clear();
            EmailInputField.SendKeys(login);
            PasswordInputField.Clear();
            PasswordInputField.SendKeys(password);
            LoginButton.Click();
        }

        public void GoToLandingPage() => _webDriver.Navigate().GoToUrl(url);

        public string GetButtonValue(IWebElement webElement) => webElement.GetAttribute("value");

        public string GetPlaceholder(IWebElement webElement) => webElement.GetAttribute("placeholder");

        public bool CanFindInputWithPlaceholder(string p0)
        {
            ICollection<IWebElement> inputs = _webDriver.FindElements(By.TagName("input"));
            foreach (IWebElement i in inputs)
            {
                if (GetPlaceholder(i) == p0)
                {
                    return true;
                }
            }
            return false;         
        }

        

        /// <summary>
        /// Fills the email input with the data provided.
        /// </summary>
        /// <param name="data"></param>
        public void FillEmailWithData(string data)
        {
            EmailInputField.Clear();
            EmailInputField.SendKeys(data);
        }

        /// <summary>
        /// Fills the password input with 'fakepass'.
        /// </summary>
        public void FillIncorrectEmail()
        {
            PasswordInputField.Clear();
            PasswordInputField.SendKeys("fakepass");
        }

        /// <summary>
        /// Returns 'true' if the element has class 'error'.
        /// </summary>
        /// <param name="webElement"></param>
        /// <returns></returns>
        public bool IsFieldHighlighted(IWebElement webElement)
        {
            if (webElement.GetAttribute("class").Contains("error"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns true if browser url matches the defined in ProjectUrls.
        /// </summary>
        /// <returns></returns>
        public bool IsPageOpened()
        {
            if (_webDriver.Url == ProjectUrls.landingPageUrl)
                return true;
            return false;
        }

        /// <summary>
        /// Compare the welcome text line by line.
        /// </summary>
        public bool DoesWelcomeTextMatch(IList<string> expected)
        {
            IList<string> actual = new List<string>();

            //IReadOnlyCollection<IWebElement> paragraphs = WelcomeText.FindElements(By.TagName("p"));

            string[] lines = WelcomeText.Text.Split(new[] { "\r\n" }, StringSplitOptions.None);

            for (int i = 0; i < lines.Length; i++)
            {
                actual.Add(lines[i]);
            }

            //add empty string
            actual.Insert(6, "");

            if (Enumerable.SequenceEqual(expected, actual))
            {
                return true;
            }

            return false;
        }
    }
}
