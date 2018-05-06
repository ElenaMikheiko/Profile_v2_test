using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProfileV2Test.Abstract;
using TechTalk.SpecFlow;

namespace ProfileV2Test.Tests._6
{
    [Binding]
    public class _6_1ToSeeDefaultListOfStudentsSteps : BaseSteps
    {
        public _6_1ToSeeDefaultListOfStudentsSteps() : base()
        {
        }

        // Background: Background HR.feature

        [Given(@"I see page HR's list of students")]
        public void GivenISeePageHRSListOfStudents()
        {
            hrManagerPage.IsAuthenticated();
        }

        // Scenario: View list of student's  at HR's list of students page
        [Then(@"I can see Student's id number at column with header ""(.*)""")]
        public void ThenICanSeeStudentSIdNumberAtColumnWithHeader(string columnName)
        {
            Assert.IsTrue(hrManagerPage.IsStudentColumnEmpty(columnName));
        }

        [Then(@"I can see column with header ""(.*)""")]
        public void ThenICanSeeColumnWithHeader(string columnName)
        {
            Assert.IsTrue(hrManagerPage.IsHeaderNameCorrect(columnName));
        }

        [Then(@"I can see Student's Stream at column with header ""(.*)""")]
        public void ThenICanSeeStudentSStreamAtColumnWithHeader(string columnName)
        {
            Assert.IsTrue(hrManagerPage.IsStudentColumnEmpty(columnName));
        }

        [Then(@"I can see Student's Name\.rus at column with header ""(.*)""")]
        public void ThenICanSeeStudentSName_RusAtColumnWithHeader(string columnName)
        {
            Assert.IsTrue(hrManagerPage.IsStudentColumnEmpty(columnName));
        }

        [Then(@"I can see Student's Surname\.rus at column with header ""(.*)""")]
        public void ThenICanSeeStudentSSurname_RusAtColumnWithHeader(string columnName)
        {
            Assert.IsTrue(hrManagerPage.IsStudentColumnEmpty(columnName));
        }

        [Then(@"I can see Student's Date of birth at column with header ""(.*)""")]
        public void ThenICanSeeStudentSDateOfBirthAtColumnWithHeader(string columnName)
        {
            Assert.IsTrue(hrManagerPage.IsStudentColumnEmpty(columnName));
        }

        [Then(@"I can see Student's e-mail at column with header ""(.*)""")]
        public void ThenICanSeeStudentSE_MailAtColumnWithHeader(string columnName)
        {
            Assert.IsTrue(hrManagerPage.IsStudentColumnEmpty(columnName));
        }

        [Then(@"I can see Student's Phone at column with header ""(.*)""")]
        public void ThenICanSeeStudentSPhoneAtColumnWithHeader(string columnName)
        {
            Assert.IsTrue(hrManagerPage.IsStudentColumnEmpty(columnName));
        }

        [Then(@"I can see Student's Trainer at column with header ""(.*)""")]
        public void ThenICanSeeStudentSTrainerAtColumnWithHeader(string columnName)
        {
            Assert.IsTrue(hrManagerPage.IsStudentColumnEmpty(columnName));
        }

        [Then(@"I can see Student's Date of graduate at column with header ""(.*)""")]
        public void ThenICanSeeStudentSDateOfGraduateAtColumnWithHeader(string columnName)
        {
            Assert.IsTrue(hrManagerPage.IsStudentColumnEmpty(columnName));
        }

        [Then(@"I can see Student's final score at column with header ""(.*)""")]
        public void ThenICanSeeStudentSFinalScoreAtColumnWithHeader(string columnName)
        {
            Assert.IsTrue(hrManagerPage.IsStudentColumnEmpty(columnName));
        }
    }
}
