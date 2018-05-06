using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ProfileV2Test.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace ProfileV2Test.Page.ResumePages
{
    public class ResumeCompletedPage
    {
        private readonly IWebDriver _webDriver;
        private readonly string url = ProjectUrls.resumeCompletedPageUrl;

        public ResumeCompletedPage(IWebDriver browser)
        {
            _webDriver = browser;
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.ClassName, Using = "resume_submit")]
        public IWebElement SubmitButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "review__pop-up_main")]
        public IWebElement PopUpDiv { get; set; }


        [FindsBy(How = How.ClassName, Using = "edit_button")]
        public IWebElement EditButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "resume__list_name")]
        public IWebElement NameSurnameField { get; set; }

        /// <summary>
        /// Gets the text of pop-up as string and parses it into a new list.
        /// </summary>
        /// <returns></returns>
        public IList<string> GetPopUpText()
        {
            IList<string> list = new List<string>();
            IWebElement paragraph = PopUpDiv.FindElement(By.TagName("p"));
            string[] arr = paragraph.Text.Split(new[] { "\r\n" }, StringSplitOptions.None);
            for (int i = 0; i < arr.Length; i++)
            {
                list.Add(arr[i]);
            }
            return list;
        }

        /// <summary>
        /// Return IWebElement from the pop-up.
        /// </summary>
        /// <param name="buttonName"></param>
        /// <returns></returns>
        public IWebElement GetPopUpButton(string buttonName)
        {
            IWebElement element = null;

            switch (buttonName)
            {
                case "OK":
                    element = PopUpDiv.FindElement(By.ClassName("review__pop-up_button-submit"));
                    break;
                case "CANCEL":
                    element = PopUpDiv.FindElement(By.ClassName("review__pop-up_button-cancel"));
                    break;
                default:
                    break;
            }

            return element;
        }

        /// <summary>
        /// Returns true if browser url contains expected.
        /// </summary>
        /// <returns></returns>
        public bool IsUrlMatchPage()
        {
            if (_webDriver.Url.Contains(url))
                return true;
            return false;
        }

        /// <summary>
        /// Return true if PopUpDiv is displayed.
        /// </summary>
        /// <returns></returns>
        public bool IsPopUpDisplayed()
        {
            if (PopUpDiv.Displayed)
                return true;
            return false;
        }

        /// <summary>
        /// Compares the text with actual value.
        /// </summary>
        /// <param name="expectedTable"></param>
        /// <returns></returns>
        public bool IsPopUpTextCorrect(Table expectedTable)
        {
            IList<string> expected = new List<string>();
            foreach(TableRow row in expectedTable.Rows)
            {
                expected.Add(row.Values.First());
            }

            IList<string> actual = GetPopUpText();

            if (Enumerable.SequenceEqual(expected, actual))
                return true;
            return false;
        }

        /// <summary>
        /// Compares the text with the selected button.
        /// </summary>
        /// <param name="buttonName"></param>
        /// <returns></returns>
        public bool IsButtonTextCorrect(string buttonName)
        {
            IWebElement selectedButton = null;

            switch (buttonName)
            {
                case "OK":
                    selectedButton = GetPopUpButton(buttonName);
                    break;
                case "CANCEL":
                    selectedButton = GetPopUpButton(buttonName);
                    break;
                default:
                    break;
            }

            if (selectedButton.Text == buttonName)
                return true;
            return false;
        }

        /// <summary>
        /// Press button on the main page.
        /// </summary>
        /// <param name="buttonName"></param>
        public void PressButton(string buttonName)
        {
            switch (buttonName)
            {
                case "SUBMIT":
                    SubmitButton.Click();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Press button on the pop-up.
        /// </summary>
        /// <param name="popupButtonName"></param>
        public void PressPopUpButton(string popupButtonName)
        {
            GetPopUpButton(popupButtonName).Click();
        }

        /// <summary>
        /// Returns true if all main page button are displayed.
        /// </summary>
        /// <returns></returns>
        public bool AreButtonsVisible()
        {
            bool flag = false;
            //TODO: add more buttons here
            try
            {
                if (SubmitButton.Displayed)
                    flag = true;
            }
            catch
            {
            }

            return flag;
           
        }

        public bool AreNameAndSurnameEqualToExpectedText(string expectedText)
        {
            return string.Equals(NameSurnameField.Text, expectedText);
        }
    }
}
