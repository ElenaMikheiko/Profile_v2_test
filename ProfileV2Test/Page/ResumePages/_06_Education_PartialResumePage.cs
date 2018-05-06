using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace ProfileV2Test.Page.ResumePages
{
    public class _06_Education_PartialResumePage
    {

        private readonly IWebDriver _webDriver;

        public _06_Education_PartialResumePage(IWebDriver browser)
        {
            _webDriver = browser;
            PageFactory.InitElements(browser, this);
        }

        // Education info tab

        [FindsBy(How = How.ClassName, Using = "_ueducationlevel")]
        public IWebElement LevelSelector { get; set; }

        [FindsBy(How = How.ClassName, Using = "_uinstitute")]
        public IWebElement EducationalInstituteField { get; set; }

        [FindsBy(How = How.ClassName, Using = "_udepartment")]
        public IWebElement DepartmentField { get; set; }

        [FindsBy(How = How.ClassName, Using = "_uspecialization")]
        public IWebElement SpecializationField { get; set; }

        [FindsBy(How = How.ClassName, Using = "_uadmission")]
        public IWebElement YearOfAdmitionSelector { get; set; }

        [FindsBy(How = How.ClassName, Using = "_ugraduation")]
        public IWebElement YearOfGraduationSelector { get; set; }


        public string FillEducationDummyData(string fieldName)
        {
            string filledData = "";

            switch (fieldName)
            {
                case "Level":
                    filledData = "Master";

                    IWebElement selectorLevel = LevelSelector;

                    SelectElement level = new SelectElement(selectorLevel);

                    level.SelectByText(filledData);
                    filledData = level.SelectedOption.Text;

                    return filledData;
                case "Name of educational institution":
                    filledData = "Institute of Minsk";
                    EducationalInstituteField.SendKeys(filledData);
                    return filledData;
                case "Department":
                    filledData = "IT";
                    DepartmentField.SendKeys(filledData);
                    return filledData;
                case "Specialization":
                    filledData = "Software developer";
                    SpecializationField.SendKeys(filledData);
                    return filledData;
                case "Year of admission":
                    filledData = "2018";

                    IWebElement selectorAdmition = YearOfAdmitionSelector;

                    SelectElement admition = new SelectElement(selectorAdmition);

                    admition.SelectByText(filledData);
                    filledData = admition.SelectedOption.Text;
                    return filledData;
                case "Year of graduation":
                    filledData = "2021";

                    IWebElement selectorGraduation = YearOfGraduationSelector;

                    SelectElement graduation = new SelectElement(selectorGraduation);

                    graduation.SelectByText(filledData);
                    filledData = graduation.SelectedOption.Text;
                    return filledData;
                default:
                    return filledData;
            }
        }

        /// <summary>
        /// Fills all fields with dummy data.
        /// </summary>
        public void FillAllFields()
        {
            FillEducationDummyData("Level");
            FillEducationDummyData("Name of educational institution");
            FillEducationDummyData("Department");
            FillEducationDummyData("Specialization");
            FillEducationDummyData("Year of admission");
            FillEducationDummyData("Year of graduation");
        }

    }
}
