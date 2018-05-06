using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProfileV2Test.Abstract;
using System;
using TechTalk.SpecFlow;

namespace ProfileV2Test.Tests._5
{
    [Binding]
    public class _5_16ToFillInBlockObjectiveSteps : BaseSteps
    {
        public _5_16ToFillInBlockObjectiveSteps() : base() { }

        #region Scenario: Student checking resume block title of page

        [Then(@"I see text line ""(.*)""")]
        public void ThenISeeTextLine(string p0)
        {
            Assert.IsTrue(objectivePage.IsActualTextEqualToExpectedText(p0));
        }

        #endregion
    }
}
