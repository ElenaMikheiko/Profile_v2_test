using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ProfileV2Test.Page.ResumePages
{
    public class _12AdditionalInformationPage
    {
        private readonly IWebDriver _webDriver;

        public _12AdditionalInformationPage(IWebDriver browser)
        {
            _webDriver = browser;
            PageFactory.InitElements(browser, this);
        }

        /// <summary>
        /// Finds main text box in Additional Info tab
        /// </summary>
        [FindsBy(How = How.Id, Using = "AdditionalInfo_Text")]
        public IWebElement MainTextBox { get; set; }

        [FindsBy(How = How.ClassName, Using = "count_info")]
        public IWebElement Counter { get; set; }

        public void FillInAdditionalInformationDummyData(string input)
        {
            input = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                    "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." +
                    " Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi" +
                    " ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit " +
                    "in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur " +
                    "sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit" +
                    " anim id est laborum.";

            MainTextBox.Clear();
            MainTextBox.SendKeys(input);
        }

        /// <summary>
        /// returns true if expectedText has same value as actualText
        /// </summary>
        /// <param name="expectedText"></param>
        /// <returns></returns>
        public bool IsPreviouslyEnteredDataPresent(string expectedText)
        {
            string actualText = "";

            // get actual data and store in actualText
            actualText = MainTextBox.Text;

            if (expectedText.Contains(actualText))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the placeholder of the main input box and compares it.
        /// </summary>
        /// <param name="expected"></param>
        /// <returns></returns>
        public bool DoesPlaceholderMatch(string expected)
        {
            string actual = MainTextBox.GetAttribute("placeholder");

            if (actual == expected)
                return true;
            return false;
        }

    }
}
