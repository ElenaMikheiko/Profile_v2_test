using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProfileV2Test.Abstract;
using System;
using TechTalk.SpecFlow;

namespace ProfileV2Test.Tests._4
{
    [Binding]
    public class _4_1ToSeeListOfStudentsSteps : BaseSteps
    {
        public _4_1ToSeeListOfStudentsSteps() : base() { }

        #region Background 4.1

        [Given(@"as unauthorised user I come to the landing page of Profile")]
        public void GivenAsUnauthorisedUserIComeToTheLandingPageOfProfile()
        {
            landingPage.GoToLandingPage();
        }

        [Given(@"I login as trainer")]
        public void GivenILoginAsTrainer()
        {
            landingPage.Authenticate("trainer@profile.com", "trainer");
        }

        [Given(@"I see page Trainer's students")]
        public void GivenISeePageTrainerSStudents()
        {
            Assert.IsTrue(trainerPage.IsAuthenticated());
        }

        #endregion

        #region Scenario Outline: Trainer can view list of students on Trainer's students page (student with feedback)

        [When(@"Some Students already have feedback")]
        public void WhenSomeStudentsAlreadyHaveFeedback()
        {
            Assert.IsTrue(true);
        }

        #endregion

        #region Scenario: Trainer can view list of student on Trainer's students page (student without feedback)

        [When(@"Some Students haven't got feedback")]
        public void WhenSomeStudentsHavenTGotFeedback()
        {
            Assert.IsTrue(true);
        }

        #endregion

        #region Scenario Outline: Trainer can view list of students on Trainer's students page (student with feedback)

        [Then(@"I see page header ""(.*)""")]
        public void ThenISeePageHeader(string header)
        {
            Assert.IsTrue(trainerPage.PageHeader.Text == header);
        }
        
        [Then(@"I see ""(.*)"" at column with header ""(.*)""")]
        public void ThenISeeAtColumnWithHeader(int number, string headerName)
        {
            Assert.IsTrue(trainerPage.DoesTableColumnContainExpectedData(headerName, Convert.ToString(number)));
        }
        
        [Then(@"I see ""(.*)"" of student related to me at column with header ""(.*)""")]
        public void ThenISeeOfStudentRelatedToMeAtColumnWithHeader(string nameSurname, string headerName)
        {
            Assert.IsTrue(trainerPage.DoesTableColumnContainExpectedData(headerName, nameSurname));
        }
        
        [Then(@"I see button with name equal feedback submit date ""(.*)"" at column with header ""(.*)""")]
        public void ThenISeeButtonWithNameEqualFeedbackSubmitDateAtColumnWithHeader(string buttonName, string headerName)
        {
            Assert.IsTrue(trainerPage.DoesTableColumnContainExpectedData(headerName, buttonName));
        }

        [Then(@"I see date of the student's account creation ""(.*)"" at column with header ""(.*)""")]
        public void ThenISeeDateOfTheStudentSAccountCreationAtColumnWithHeader(string date, string headerName)
        {
            Assert.IsTrue(trainerPage.DoesTableColumnContainExpectedData(headerName, date));
        }

        #endregion

        #region Scenario: Trainer can view list of student on Trainer's students page (student without feedback)

        [Then(@"I see button ""(.*)"" at column with header ""(.*)""")]
        public void ThenISeeButtonfAtColumnWithHeader(string buttonName, string headerName)
        {
            Assert.IsTrue(trainerPage.DoesTableColumnContainExpectedData(headerName, buttonName));
        }

        #endregion

    }
}