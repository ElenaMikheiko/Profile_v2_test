using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProfileV2Test.Abstract;
using ProfileV2Test.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace ProfileV2Test.Tests._5
{
    [Binding]
    public class _5_2ToFillInResumeBlocksSteps : BaseSteps
    {
        public _5_2ToFillInResumeBlocksSteps() : base() { }       

        #region Scenario: Student is directed to editing resume page

        [When(@"I move to resume creation page")]
        public void ThenIMoveToResumeCreationPage()
        {
            Assert.IsTrue(resumePage.IsBrowserUrlMatchesResumeUrl());
        }

        [Then(@"I see message")]
        public void ThenISee(Table table)
        {
            IList<string> expected = new List<string>();
            foreach(var row in table.Rows)
            {
                expected.Add(row.Values.First());
            }

            Assert.IsTrue(resumePage.CompareWelcomeParagraph(expected));
        }

        #endregion

        #region Scenario: Student starts to fill in resume
        [When(@"I choose button ""(.*)""")]
        public void WhenIChooseButton(string p0)
        {
            resumePage.ClickStartCancelButton(p0);
        }

        [Then(@"I go to block ""(.*)""")]
        public void ThenIGoToBlock(string p0)
        {
            Assert.IsTrue(resumePage.DoesBlockNameMatchesLink(p0));
        }

        #endregion

        #region Scenario: Student can cancel filling in resume

        [Then(@"I am on first tab and choose button ""(.*)""")]
        public void ThenIAmOnFirstTabAndChooseButton(string p0)
        {
            switch (p0)
            {
                case "BACK":
                    resumePage.MoveToPreviousPage();
                    break;
                case "CANCEL":
                    resumePage.MoveToHomePage();
                    break;
                default:
                    break;
            }
        }
        [Then(@"I'm on my personal page")]
        public void WhenIMOnMyPersonalPage()
        {
            Assert.IsTrue(homePage.IsBrowserUrlMatchesResumeUrl());
        }

        #endregion

        #region Scenario: Student can see button "Resume" is highlighted on hover

        //see CommonSteps.cs

        #endregion

    }
}
