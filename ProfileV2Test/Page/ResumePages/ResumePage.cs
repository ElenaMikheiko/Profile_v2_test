using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ProfileV2Test.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace ProfileV2Test.Page.ResumePages
{
    public class ResumePage
    {
        private readonly IWebDriver _webDriver;
        private readonly string url = ProjectUrls.resumePageUrl;

        public ResumePage(IWebDriver browser)
        {
            _webDriver = browser;
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.XPath, Using = "/html/body/div/div[1]/div/div/div[2]/button[2]")]
        public IWebElement StartButton_ResumeStart { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div/div[1]/div/div/div[2]/button[1]")]
        public IWebElement BackButton_ResumeStart { get; set; }

        /// <summary>
        /// Block that contains navigational links
        /// </summary>
        [FindsBy(How = How.Id, Using = "v-pills-tab")]
        public IWebElement NavigationBlocksDiv { get; set; }

        /// <summary>
        /// The main DIV that wraps all 'tab-pane' blocks with resume steps
        /// </summary>
        [FindsBy(How = How.Id, Using = "v-pills-tabContent")]
        public IWebElement MainBlocksDiv { get; set; }

        [FindsBy(How = How.ClassName, Using = "messageBox__content_text")]
        public IWebElement WelcomeTextDiv { get; set; }

        /// <summary>
        /// This DIV is displayed when student accepts the resume welcome text.
        /// </summary>
        [FindsBy(How = How.Id, Using = "resumeFormContainer")]
        public IWebElement ResumeFormContainerDiv { get; set; }

        /// <summary>
        /// The container of the final message after completing all the steps/tabs.
        /// </summary>
        [FindsBy(How = How.ClassName, Using = "messageBox__complete")]
        public IWebElement FinalMessageBoxContainer { get; set; }


        /// <summary>
        /// Returns &lt;a&gt; IWebElement from the navigation bar that is currently active
        /// </summary>
        /// <returns></returns>
        public IWebElement GetActiveTab()
        {
            IWebElement activeTab = null;
            IReadOnlyCollection<IWebElement> links = NavigationBlocksDiv.FindElements(By.CssSelector("a"));

            foreach (IWebElement link in links)
            {
                if (link.GetAttribute("class").Contains("active"))
                {
                    activeTab = link;
                    break;
                }
            }

            return activeTab;
        }

        /// <summary>
        /// Select the currently displayed DIV by selection from MainBlocksDiv the one that has class 'active'.
        /// </summary>
        public IWebElement GetActiveDiv() => MainBlocksDiv.FindElement(By.ClassName("active"));

        public void Navigate() => _webDriver.Navigate().GoToUrl(url);

        public bool DoesElementHaveBackgroundColor(IWebElement tab, string color)
        {
            //use custom converter
            string actualBgColor = HelperMethods.RgbaToHexConverter(tab.GetCssValue("background-color"));

            if (actualBgColor == color)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Selects the currently displayed DIV,
        /// finds h1 tag and compares it for the exact match with the parameter.
        /// </summary>
        /// <param name="linkText"></param>
        /// <returns></returns>
        public bool DoesBlockNameMatchesLink(string linkText)
        {
            IWebElement activeDiv = GetActiveDiv();

            //retrieve the header
            IWebElement header = activeDiv.FindElement(By.TagName("h1"));
            if (header.Text == linkText)
            {
                return true;
            }
            //exception for "Electronic certificates, tests, exams"
            if (linkText == "Electronic certificates, tests, exams")
            {
                IReadOnlyCollection<IWebElement> headers = activeDiv.FindElements(By.TagName("h1"));
                string firstHeader = headers.ElementAt(0).Text;
                string secondHeader = headers.ElementAt(1).Text;
                if (firstHeader == "Electronic certificates" & secondHeader == "Tests, examinations")
                {
                    return true;
                }
            }

            return false;
        }

        public List<IWebElement> GetListOfNavigationBarItems()
        {
            List<IWebElement> elements = NavigationBlocksDiv.FindElements(By.TagName("span")).ToList();
            return elements;
        }


        /// <summary>
        /// Clicks the START or BACK button on the resume welcome screen.
        /// </summary>
        /// <param name="buttonName"></param>
        public void ClickStartCancelButton(string buttonName)
        {
            if (buttonName == "START")
            {
                StartButton_ResumeStart.Click();
            }
            if (buttonName == "BACK")
            {
                BackButton_ResumeStart.Click();
            }
        }

        public bool IsBrowserUrlMatchesResumeUrl()
        {
            if (_webDriver.Url == url)
                return true;
            return false;
        }

        /// <summary>
        /// Compare the welcome resume message line by line.
        /// </summary>
        public bool CompareWelcomeParagraph(IList<string> expected)
        {
            IList<string> actual = new List<string>();

            IReadOnlyCollection<IWebElement> paragraphs = WelcomeTextDiv.FindElements(By.TagName("p"));

            foreach (IWebElement para in paragraphs)
            {
                actual.Add(para.Text);
            }

            if (Enumerable.SequenceEqual(expected, actual))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if ResumeFormContainerDiv has css value 'display:block'.
        /// </summary>
        /// <returns></returns>
        public bool IsResumeFormContainerDivVisible()
        {
            string status = ResumeFormContainerDiv.GetCssValue("display");

            if (status == "block")
                return true;
            return false;
        }

        /// <summary>
        /// Proceeds to next page by clicking NEXT button on the currently displayed DIV.
        /// </summary>
        public void MoveToNextPage()
        {
            GetActiveDiv().FindElement(By.ClassName("controls_next")).Click();
        }

        /// <summary>
        /// Proceeds to previous page by clicking BACK button on the currently displayed DIV.
        /// </summary>
        public void MoveToPreviousPage()
        {
            GetActiveDiv().FindElement(By.ClassName("controls_back")).Click();
        }

        /// <summary>
        /// Proceeds to home page by clicking CANCEL button on the currently displayed DIV.
        /// </summary>
        public void MoveToHomePage()
        {
            GetActiveDiv().FindElement(By.ClassName("controls_cancel")).Click();
        }

        /// <summary>
        /// Selects button "Check" at the final message box.
        /// </summary>
        public void ProceedToResumeCheck()
        {
            FinalMessageBoxContainer.FindElement(By.ClassName("controls_next")).Click();
        }


        // TODO: after revision put code in its place
        // left it like this for easier view/changes 

        #region _5_7_1ToFillInBlockEducationSteps

        [FindsBy(How = How.Id, Using = "it-academy")]
        public IWebElement GetNotificationText { get; set; }

        [FindsBy(How = How.ClassName, Using = "education__add")]
        public IWebElement GetEducationAddButton { get; set; }

        [FindsBy(How = How.XPath, Using = "(//*[@name='Educations[0].EducationLevelId'])[2]")]
        public IWebElement GetSecondEducationTab { get; set; }

        [FindsBy(How = How.XPath, Using = "(//*[@class='tab__education_form'])[2]")]
        public IWebElement GetSecondEducationForm { get; set; }

        [FindsBy(How = How.XPath, Using = "(//*[@name='Educations[0].EducationLevelId'])")]
        public IWebElement GetLevelSelector { get; set; }

        [FindsBy(How = How.XPath, Using = "(//*[@name='Educations[0].EducationalInstitution'])")]
        public IWebElement GetEducationalInstituteField { get; set; }

        [FindsBy(How = How.XPath, Using = "(//*[@name='Educations[0].Department'])")]
        public IWebElement GetDepartmentField { get; set; }

        [FindsBy(How = How.XPath, Using = "(//*[@name='Educations[0].Specialization'])")]
        public IWebElement GetSpecializationField { get; set; }

        [FindsBy(How = How.XPath, Using = "(//*[@name='Educations[0].YearOfAdmission'])")]
        public IWebElement GetYearOfAdmitionSelector { get; set; }

        [FindsBy(How = How.XPath, Using = "(//*[@name='Educations[0].YearOfGraduation'])")]
        public IWebElement GetYearOfGraduationSelector { get; set; }

        [FindsBy(How = How.ClassName, Using = "tab__education")]
        public IWebElement GetEducationTab { get; set; }
        


        public bool IsEducationTextDisplayed()
        {
            // educationt text is 103 character's long, we check for all lenght
            if (GetNotificationText.Text.Length == 103)
                return true;

            return false;
        }

        public bool ExistDefaultSelectorName(string value)
        {
            IWebElement selectorField = GetSecondEducationTab;

            SelectElement element = new SelectElement(selectorField);

            if (element.SelectedOption.Text == value)
                return true;

            return false;
        }

        public bool IsEducationStudyFieldsEmpty()
        {
            IWebElement form = GetSecondEducationForm;

            foreach (var item in form.FindElements(By.CssSelector("input")))
            {
                if (item.GetAttribute("value") == "")
                {
                    return true;
                }
            }
            return false;
        }

        public void CloseEducationForm()
        {
            IList<IWebElement> list = GetSecondEducationForm.FindElements(By.ClassName("tab__remove_education"));

            foreach (IWebElement webElement in list)
            {
                if (webElement.TagName.Contains("span"))
                {
                    webElement.Click();
                }
            }
        }

        #region _5_11ToFillInBlockAdditionalInformationSteps

        /// <summary>
        /// Returns true if text inside Additional Information textbox is visible and has its full lenght
        /// </summary>
        /// <returns></returns>
        public bool IsAdditionalInfoTextVisible(Table table)
        {
            string expectedText = null;

            // get's expectedText from table
            foreach (TableRow row in table.Rows)
            {
                expectedText = row[0];
            }

            // find all textarea's
            IList<IWebElement> elements = _webDriver.FindElements(By.TagName("textarea"));

            foreach (var element in elements)
            {
                // save placeholder text in 'expectedText'
                string actualText = element.GetAttribute("placeholder");

                // check if 'expectedText' contains 'actualText' and if its visible
                if (actualText.Contains(expectedText) && element.Displayed)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #endregion


    }
}
