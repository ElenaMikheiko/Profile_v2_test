using ProfileV2Test.Abstract;
using ProfileV2Test.Tests.Shared;
using TechTalk.SpecFlow;

namespace ProfileV2Test.Tests._5
{
    [Binding]
    public class _5_3ToAddPersonalAndContactInformationSteps : BaseSteps
    {
        public _5_3ToAddPersonalAndContactInformationSteps() : base() { }

        #region Scenario: Student Moves to next page

        //Moved to CommonSteps.cs

        #endregion

        #region Scenario: Student can see Tab status in status bar

        //moved to CommonSteps.cs

        #endregion

        #region Scenario: Student can Save information

        [When(@"I filled in field ""(.*)""")]
        public void WhenIFilledInField(string p0)
        {
            //for every step, fill the list in common variables
            //than this list will be passed to the method in common steps
            personalInformationPage.FillInputWithDummyData(p0, CommonVariables.commonCompairingList);
        }

        #endregion

        #region Student can Check block "Personal and contact information" on error

        // Moved to common steps.

        #endregion

        #region Scenario Outline: Student check Countdown`s work

        // Moved to common steps.

        #endregion

        #region Student check language filter

        // Moved to common steps.

        #endregion

    }
}
