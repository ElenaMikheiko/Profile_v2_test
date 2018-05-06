using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace ProfileV2Test.Page.ResumePages
{
    public class _02_Objective_PartialResumePage
    {
        private readonly IWebDriver _webDriver;

        public _02_Objective_PartialResumePage(IWebDriver browser)
        {
            _webDriver = browser;
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.Id, Using = "text__objective")]
        public IWebElement ObjectiveText { get; set; }

        public bool IsActualTextEqualToExpectedText(string expectedText)
        {
            return string.Equals(ObjectiveText.Text, expectedText);
        }


    }
}
