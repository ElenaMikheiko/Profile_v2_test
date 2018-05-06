using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProfileV2Test.Abstract;
using ProfileV2Test.Services;
using System;
using TechTalk.SpecFlow;

namespace ProfileV2Test.Tests._5
{
    [Binding]
    public class _5_5ToFillInBlockSkillsSteps : BaseSteps
    {
        public _5_5ToFillInBlockSkillsSteps() : base() { }     

        #region Scenario: Student deletes skills

        [Given(@"I wrote skills in field ""(.*)""")]
        public void GivenIWroteSkillsInField(string p0)
        {
            skillsPage.EnterDummySkill();
        }
        [When(@"I press cross near skill")]
        public void WhenIPressCrossNearSkill()
        {
            skillsPage.DeleteDummySkill();
        }
        [Then(@"This skill is deleted")]
        public void ThenThisSkillIsDeleted()
        {
            Assert.IsFalse(skillsPage.IsDummySkillPresent());
        }




        #endregion

        #region Scenario: Student can see tab status in status bar

        //Moved to CommonSteps.cs

        #endregion

        #region Student saves information

        //Moved to CommonSteps.cs

        #endregion

        #region Scenario: Student can see Button "NEXT" is highlighted on hover

        //Moved to CommonSteps.cs

        #endregion

    }
}
