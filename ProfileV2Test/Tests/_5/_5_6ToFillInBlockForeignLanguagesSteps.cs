using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProfileV2Test.Abstract;
using TechTalk.SpecFlow;

namespace ProfileV2Test.Tests._5
{
    [Binding]
    public class _5_6ToFillInBlockForeignLanguagesSteps : BaseSteps
    {
        public _5_6ToFillInBlockForeignLanguagesSteps() : base() { }

        #region Student checking resume block title of page

        // Moved to commons steps.

        #endregion

        #region Student Saves information

        // Moved to common steps.

        #endregion

        #region Scenario: Student deletes added languages

        [Given(@"I added language")]
        public void GivenIAddedLanguages()
        {
            languagesPage.ClickAddNewLanguage();
        }
        [Given(@"I added proficiency level")]
        public void GivenIAddedProficiencyLevel()
        {
            languagesPage.SelectProfficiencyByRow(1);
        }
        [When(@"I press button with cross")]
        public void WhenIPressButtonWithCross()
        {
            languagesPage.RemoveLanguageByRow(1);
        }
        [Then(@"Added language and proficiency level are deleted")]
        public void ThenAddedLanguageAndProficiencyLevelAreDeleted()
        {
            Assert.IsFalse(languagesPage.IsLanguageRowPresent(2));
        }

        #endregion

        #region Student checks list from field "Proficiency"

        [Then(@"I see values in the dropdown list")]
        public void ThenISeeValuesInTheDropdownList(Table table)
        {
            Assert.IsTrue(languagesPage.DoProficiencyValuesMatch(table));
        }

        #endregion

        #region Scenario: Student can Check field "Proficiency" on error

        [Given(@"I left default value ""(.*)"" in field ""(.*)""")]
        public void GivenILeftDefaultValueInField(string p0, string p1)
        {
            languagesPage.ResetProficiencyToDefault();
            Assert.IsFalse(languagesPage.IsProficiencySet(0));
        }

        #endregion


        #region Student moves to next page

        // Moved to common steps.

        #endregion
    }
}
