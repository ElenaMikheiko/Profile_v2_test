using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace ProfileV2Test.Page.ResumePages
{
    public class _03_Summary_PartialResumePage
    {
        private readonly IWebDriver _webDriver;
        public _03_Summary_PartialResumePage(IWebDriver browser)
        {
            _webDriver = browser;
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='v-pills-summary']/form/div/p")]
        public IWebElement SubHeader { get; set; }

        [FindsBy(How = How.Id, Using = "Summary")]
        public IWebElement SummaryTextArea { get; set; }

        [FindsBy(How = How.ClassName, Using = "count_summary")]
        public IWebElement Counter { get; set; }


        //check if input keys in a webelement match the actual value (for textarea only)
        public bool CanInputKeys(IWebElement webElement)
        {
            string expected = "test";
            webElement.SendKeys(expected);

            string actual = webElement.Text;

            if (actual.Contains(expected))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Fills the text field with dummy data and updates the string.
        /// </summary>
        public void FillAllFieldsWithDummyData(string stringToUpdate)
        {
            stringToUpdate = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            SummaryTextArea.Clear();
            SummaryTextArea.SendKeys(stringToUpdate);
        }

        /// <summary>
        /// Adds data from the main text area to string and compares it with the expected.
        /// </summary>
        /// <param name="expected"></param>
        /// <returns></returns>
        public bool IsPreviouslyEnteredDataPresent(string expected)
        {
            string actual = SummaryTextArea.Text;

            if (actual.Equals(expected))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Compares placeholder.
        /// </summary>
        /// <param name="expected"></param>
        /// <returns></returns>
        public bool DoesPlaceholderMatch(string expected)
        {
            string actual = SummaryTextArea.GetAttribute("placeholder");

            if (actual == expected)
                return true;
            return false;
        }

        /// <summary>
        /// Returns "true" if the selected IWebElement has class "error"
        /// </summary>
        /// <param name="inputField"></param>
        /// <returns></returns>
        public bool IsElementEncircledRed(IWebElement inputField)
        {
            if (inputField.GetAttribute("class").Contains("error"))
            {
                return true;
            }
            return false;
        }
    }
}
