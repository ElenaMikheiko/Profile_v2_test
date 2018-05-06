using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProfileV2Test.Abstract;
using System;
using TechTalk.SpecFlow;

namespace ProfileV2Test.Tests._2
{
    [Binding]
    public class _2_3SignOutOfSystemSteps : BaseSteps
    {
        public _2_3SignOutOfSystemSteps() : base() { }

        #region Scenario Outline:  Sign out of Profile system

        [Given(@"I login using my ""(.*)"" and ""(.*)""")]
        public void GivenILoginUsingMyAnd(string p0, string p1)
        {
            landingPage.Authenticate(p0, p1);
        }
        [When(@"I click ""(.*)"" button")]
        public void WhenIClickButton(string p0)
        {
            homePage.SelectOptionFromDropDownmenu(p0);
        }
        [Then(@"I on landing page of profile")]
        public void ThenIOnLandingPageOfProfile()
        {
            Assert.IsTrue(landingPage.IsPageOpened());
        }

        #endregion

    }
}
