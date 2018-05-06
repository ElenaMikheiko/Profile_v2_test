using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProfileV2Test.Abstract;
using TechTalk.SpecFlow;

namespace ProfileV2Test.Tests._5
{
    [Binding]
    public class _5_15ToEditResumeSteps : BaseSteps
    {
        public _5_15ToEditResumeSteps() : base() { }

        #region Scenario: Student changes data and save changes

        [Given(@"I write ""(.*)"" in field ""(.*)""")]
        public void GivenIWriteInField(string p0, string p1)
        {
            resumeEditPage.FillDummyDataInInputs(p0, p1);
        }

        #endregion

        #region Scenario: Student moves to edit resume page

        [When(@"I press button ""(.*)"" on completed resume page")]
        public void WhenIPressButtonOnCompletedResumePage(string p0)
        {
            resumeCompletedPage.EditButton.Click();
        }

        [Then(@"I moved to edit resume page")]
        public void ThenIMovedToEditResumePage()
        {
            Assert.IsTrue(resumeEditPage.IsUrlMatchPage());
        }

        #endregion

        #region Scenario: Student changes data and save changes

        [Then(@"I see my name and surname equal ""(.*)""")]
        public void ThenISeeNameAndSurnameEqual(string p0)
        {
            Assert.IsTrue(resumeCompletedPage.AreNameAndSurnameEqualToExpectedText(p0));
        }

        #endregion
    }
}
