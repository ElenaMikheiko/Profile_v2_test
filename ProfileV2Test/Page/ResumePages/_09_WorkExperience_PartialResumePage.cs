using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileV2Test.Page.ResumePages
{
    public class _09_WorkExperience_PartialResumePage
    {
        private readonly IWebDriver _webDriver;

        public _09_WorkExperience_PartialResumePage(IWebDriver browser)
        {
            _webDriver = browser;
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.ClassName, Using = "_work_start-month")]
        public IWebElement StartOfWorkDropdown_Month { get; set; }

        [FindsBy(How = How.ClassName, Using = "_work_start-year")]
        public IWebElement StartOfWorkDropdown_Year { get; set; }

        [FindsBy(How = How.ClassName, Using = "_work_present")]
        public IWebElement CheckBox { get; set; }


        [FindsBy(How = How.ClassName, Using = "_work-organization")]
        public IWebElement OrganizationInput { get; set; }

        [FindsBy(How = How.ClassName, Using = "_work-position")]
        public IWebElement PositionInput { get; set; }

        [FindsBy(How = How.ClassName, Using = "_work-respons")]
        public IWebElement ResponsibilitiesInput { get; set; }


        /// <summary>
        /// Fills all fields with dummy data.
        /// <para>Does not fill &lt;End of work&gt;, checks &lt;To present&gt;.</para>
        /// </summary>
        public void FillAllFields()
        {
            //fill start of work
            SelectElement se = new SelectElement(StartOfWorkDropdown_Month);
            se.SelectByIndex(3);
            se = new SelectElement(StartOfWorkDropdown_Year);
            se.SelectByIndex(3);

            //make it present
            CheckBox.Click();

            //fill organization
            OrganizationInput.Clear();
            OrganizationInput.SendKeys("TestOrganization");

            //fill position
            PositionInput.Clear();
            PositionInput.SendKeys("TestOrganization");

            //fill Responsibilities
            ResponsibilitiesInput.Clear();
            ResponsibilitiesInput.SendKeys("TestOrganization");
        }
    }
}
