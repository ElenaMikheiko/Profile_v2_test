using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProfileV2Test.Abstract;
using ProfileV2Test.Tests.Shared;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace ProfileV2Test.Tests._1
{
    [Binding]
    public class _1_1_LandingPageSteps : BaseSteps
    {
        public _1_1_LandingPageSteps() : base() { }

        #region Scenario: Verification text fields

        [Then(@"I see welcome text")]
        public void ThenISeeText(Table p0)
        {
            //put table rows into a list
            List<string> expected = new List<string>();
            foreach (var row in p0.Rows)
            {
                expected.Add(row.Values.First());
            }

            Assert.IsTrue(landingPage.DoesWelcomeTextMatch(expected));
        }

        #endregion

        #region Scenario: Verification input fields

        [Then(@"I see input field with Input placeholder ""(.*)""")]
        public void ThenISeeInputFieldWithInputPlaceholder(string p0)
        {
            Assert.IsTrue(landingPage.CanFindInputWithPlaceholder(p0));
        }

        #endregion

        #region Scenario: Verification elements of system (button)

        [Then(@"I see button with name ""(.*)""")]
        public void ThenISeeButtonWithName(string p0)
        {
            Assert.AreEqual(p0, landingPage.GetButtonValue(landingPage.LoginButton));
        }

        #endregion

        #region Scenario: Verification elements of system (link)

        [Then(@"I see link with value ""(.*)""")]
        public void ThenISeeLinkWithValue(string p0)
        {
            Assert.AreEqual(p0, landingPage.RecoverPasswordSpan.Text);
        }

        #endregion
    }
}
