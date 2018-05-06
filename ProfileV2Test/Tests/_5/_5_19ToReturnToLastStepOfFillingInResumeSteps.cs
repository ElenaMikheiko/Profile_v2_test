using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProfileV2Test.Abstract;
using ProfileV2Test.Tests.Shared;
using TechTalk.SpecFlow;

namespace ProfileV2Test.Tests._5
{
    [Binding]
    public class _5_19ToReturnToLastStepOfFillingInResumeSteps : BaseSteps
    {
        public _5_19ToReturnToLastStepOfFillingInResumeSteps() : base() { }

        //local var
        string student = "";

        [Given(@"I log in as '(.*)'")]
        public void GivenILogInAs(string p0)
        {
            student = p0;
            TestUserLoginSteps steps = new TestUserLoginSteps();
            steps.Switcher(p0);
        }

        [Given(@"I start or continue filling in my resume")]
        public void GivenIStartOrContinueFillingInMyResume()
        {

            //we need to check for the first student
            //as he sees the welcome screen
            switch (student)
            {
                case "Ivan Smith":
                    resumePage.ClickStartCancelButton("START");
                    personalInformationPage.FillAllFieldsWithDummyData();
                    resumePage.MoveToNextPage();
                    resumePage.MoveToPreviousPage();
                    break;
                default:
                    break;
            }
        }


        [Given(@"I pressed button “CANCEL” in '(.*)'")]
        public void GivenIPressedButtonCANCELIn(string p0)
        {
            Assert.IsTrue(resumePage.DoesBlockNameMatchesLink(p0));
            resumePage.MoveToHomePage();
        }
    }
}
