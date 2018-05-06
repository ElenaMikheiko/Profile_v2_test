using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ProfileV2Test.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProfileV2Test.Page.ResumePages
{
    public class _04_Skills_PartialResumePage
    {
        private readonly IWebDriver _webDriver;

        public _04_Skills_PartialResumePage(IWebDriver browser)
        {
            _webDriver = browser;
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.ClassName, Using = "select2-container")]
        public IWebElement SkillsInputContainer { get; set; }

        [FindsBy(How = How.ClassName, Using = "select2-search__field")]
        public IWebElement SkillsInputField { get; set; }

        public IWebElement GetHeader() => _webDriver.FindElement(By.Id("v-pills-skills")).FindElement(By.ClassName("tab__header"));

        public IWebElement GetUlFromInput() => _webDriver.FindElement(By.Id("v-pills-skills")).FindElement(By.TagName("ul"));


        /// <summary>
        /// Enters "Developer" to the input field.
        /// </summary>
        public void EnterDummySkill()
        {
            ClearField();
            SkillsInputField.SendKeys("Developer");
            SkillsInputField.SendKeys(Keys.Enter);
        }

        /// <summary>
        /// Deletes all skills from the input field.
        /// </summary>
        public void ClearField()
        {
            IWebElement firstLi = GetUlFromInput().FindElement(By.TagName("li"));

            if (firstLi.Text != "")
            {
                //click the 'x'
                firstLi.FindElement(By.TagName("span")).Click();

                //lose focus to hide dropdown
                GetHeader().Click();

                ClearField();
            }

        }

        /// <summary>
        /// Deletes the skill with the title "Developer".
        /// <para></para>
        /// <para>NOTE: throws an exception if the skill is not found.</para>
        /// </summary>
        public void DeleteDummySkill()
        {
            //initialize
            IWebElement selectedLi = null;

            //search all "li" elements in the input field
            IReadOnlyCollection<IWebElement> lis = GetUlFromInput().FindElements(By.TagName("li"));
            foreach (IWebElement li in lis)
            {
                if (li.GetAttribute("title") == "Developer")
                {
                    selectedLi = li;
                    break;
                }
            }

            //find the span with "x" and click it
            if (selectedLi != null)
            {
                IWebElement cross = selectedLi.FindElement(By.TagName("span"));
                cross.Click();
            }
            else
            {
                throw new NotFoundException();
            }
            
        }

        /// <summary>
        /// Returns "true" if at least one &lt;span&gt; contains title="Developer".
        /// </summary>
        /// <returns></returns>
        public bool IsDummySkillPresent()
        {
            IReadOnlyCollection<IWebElement> spans = GetUlFromInput().FindElements(By.TagName("span"));
            foreach (IWebElement span in spans)
            {
                if (span.GetAttribute("title") == "Developer")
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Inputs three skills to the field and adds them to the list.
        /// </summary>
        /// <param name="listToUpdate"></param>
        public void FillSeveralSkills(IList<string> listToUpdate)
        {
            SkillsInputField.Clear();

            SkillsInputField.SendKeys("TestSkill1");
            SkillsInputField.SendKeys(Keys.Enter);
            listToUpdate.Add("TestSkill1");

            SkillsInputField.SendKeys("TestSkill2");
            SkillsInputField.SendKeys(Keys.Enter);
            listToUpdate.Add("TestSkill2");

            SkillsInputField.SendKeys("TestSkill3");
            SkillsInputField.SendKeys(Keys.Enter);
            listToUpdate.Add("TestSkill3");
        }

        public bool IsPreviouslyEnteredDataPresent(IList<string> expected)
        {
            IList<string> actual = new List<string>();

            //get all <li>s
            IReadOnlyCollection<IWebElement> lis = GetUlFromInput().FindElements(By.TagName("li"));
            foreach (IWebElement li in lis)
            {
                if (li.Text != "")
                {
                    //the first char contains 'x', crop it
                    actual.Add(li.Text.Substring(1));
                }
                
            }

            //compare
            if(Enumerable.SequenceEqual(expected, actual))
            {
                return true;
            }

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
