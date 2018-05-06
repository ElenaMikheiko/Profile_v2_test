using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ProfileV2Test.Infrastructure;

namespace ProfileV2Test.Page.ResumePages
{
    public class ResumeEditPage
    {
        private readonly IWebDriver _webDriver;

        public ResumeEditPage(IWebDriver browser)
        {
            _webDriver = browser;
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.Id, Using = "edit__name")]
        public IWebElement NameInput { get; set; }

        [FindsBy(How = How.Id, Using = "edit__surname")]
        public IWebElement SurnameInput { get; set; }

        [FindsBy(How = How.ClassName, Using = "controls_next")]
        public IWebElement PreviewButton { get; set; }

        /// <summary>
        /// Compares the url from browser to the expected.
        /// </summary>
        /// <returns></returns>
        public bool IsUrlMatchPage()
        {
            if (_webDriver.Url == ProjectUrls.resumeEditPageUrl)
                return true;
            return false;
        }

        public void FillDummyDataInInputs(string data, string inputName)
        {
            switch(inputName)
            {
                case "Name":
                    {
                        NameInput.Clear();
                        NameInput.SendKeys(data);
                    }
                    break;
                case "Surname":
                    {
                        SurnameInput.Clear();
                        SurnameInput.SendKeys(data);
                    }
                    break;
                default:
                    break;
            }
        }

    }
}
