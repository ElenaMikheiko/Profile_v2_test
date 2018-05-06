using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProfileV2Test.Abstract;
using TechTalk.SpecFlow;

namespace ProfileV2Test.Tests._5
{
    [Binding]
    public class _5_7_1ToFillInBlockEducationSteps : BaseSteps
    {
        public _5_7_1ToFillInBlockEducationSteps() : base()
        {
            
        }

        private List<string> educationDataList = new List<string>();

        // Student Checks notification hint
        #region Scenario: Student Checks notification hint

        //[Then(@"I see text")]
        //public void ThenISeeText(Table table)
        //{
        //    Assert.IsTrue(resumePage.IsEducationTextDisplayed());
        //}

        #endregion

        //  Student adds more places of study
        #region Scenario: Student adds more places of study

        [When(@"I press on button ""(.*)""")]
        public void WhenIPressOnButton(string p0)
        {
            resumePage.GetEducationAddButton.Click();
        }

        [Then(@"I see new default field/selector Level with name ""(.*)""")]
        public void ThenISeeNewDefaultFieldSelectorLevelWithName(string selectorName)
        {
            Assert.IsTrue(resumePage.ExistDefaultSelectorName(selectorName));
        }

        [Then(@"I see new empty field ""(.*)""")]
        public void ThenISeeNewEmptyField(string p0)
        {
            Assert.IsTrue(resumePage.IsEducationStudyFieldsEmpty());
        }


        #endregion

        // Scenario: Student deletes place about education
        #region Scenario: Student deletes place about education

        [Given(@"I added places of study")]
        public void GivenIAddedPlacesOfStudy()
        {
            resumePage.GetEducationAddButton.Click();
        }

        [When(@"I press on button with cross")]
        public void WhenIPressOnButtonWithCross()
        {
            resumePage.CloseEducationForm();
        }

        [Then(@"place of study is deleted")]
        public void ThenPlaceOfStudyIsDeleted()
        {
            Assert.IsFalse(resumePage.GetSecondEducationForm.Displayed);
        }


        #endregion

        // Scenario: Student saves information
        #region Scenario: Student saves information

        //[Then(@"I can see data ""(.*)"" is present")]
        //public void ThenICanSeeDataIsPresent(string field)
        //{
        //    // fill educationDataList list with dummy data
        //    educationDataList.Add(educationPage.FillEducationDummyData(field));

        //    IList<string> actual = new List<string>();

        //    // Get selectors element
        //    IWebElement selectorLevel = resumePage.GetLevelSelector;
        //    IWebElement selectorAdmition = resumePage.GetYearOfAdmitionSelector;
        //    IWebElement selectorGraduation = resumePage.GetYearOfGraduationSelector;

        //    // get selector values
        //    SelectElement level = new SelectElement(selectorLevel);
        //    SelectElement admition = new SelectElement(selectorAdmition);
        //    SelectElement graduation = new SelectElement(selectorGraduation);


        //    actual.Add(level.SelectedOption.Text);
        //    actual.Add(resumePage.GetEducationalInstituteField.GetAttribute("value"));
        //    actual.Add(resumePage.GetDepartmentField.GetAttribute("value"));
        //    actual.Add(resumePage.GetSpecializationField.GetAttribute("value"));
        //    actual.Add(admition.SelectedOption.Text);
        //    actual.Add(graduation.SelectedOption.Text);

        //    Assert.AreEqual(educationDataList, actual);
        //}

        #endregion


    }
}
