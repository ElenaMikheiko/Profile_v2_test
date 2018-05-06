using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ProfileV2Test.Abstract;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace ProfileV2Test.Tests._5
{
    [Binding]
    public class _5_14ToSubmitResumeSteps : BaseSteps
    {
        public _5_14ToSubmitResumeSteps() : base()
        {
            //we assume that the user starts on the first block
            //they must compete all the steps

            //check if this is a first run or not
            //if yes, go thru all the steps

            if (!resumePage.GetActiveDiv().FindElement(By.ClassName("tab__header")).Text.Contains("Recommendations"))
            {

                //start resume
                resumePage.ClickStartCancelButton("START");

                //move to block Objective
                resumePage.MoveToNextPage();

                //move to block Summary
                resumePage.MoveToNextPage();

                //input summary
                summaryPage.SummaryTextArea.SendKeys("Test summary");

                //move to block Skills
                resumePage.MoveToNextPage();

                //input skill
                skillsPage.EnterDummySkill();

                //move to block Foreign languages
                resumePage.MoveToNextPage();

                //pick language level
                languagesPage.FillOnlyOneRow(new Dictionary<string, string>());

                //move to block Education
                resumePage.MoveToNextPage();

                //fill all fields
                educationPage.FillAllFields();

                //move to block Professional development
                resumePage.MoveToNextPage();

                //move to block Electronic certificates
                resumePage.MoveToNextPage();

                //move to block Work experience
                resumePage.MoveToNextPage();

                //fill all fields
                workExperiencePage.FillAllFields();

                //move to block Portfolio
                resumePage.MoveToNextPage();

                //move to block Military status
                resumePage.MoveToNextPage();

                //move to block Additional information
                resumePage.MoveToNextPage();

                //move to block Recommendations
                resumePage.MoveToNextPage();

            }

            //move to final message
            resumePage.MoveToNextPage();

            //we have to wait for the asynchronous calls to end
            Thread.Sleep(5000);

        }

        //Background
        [Given(@"I am on completed resume page")]
        public void GivenIAmOnCompletedResumePage()
        {         

            //select "Check"
            resumePage.ProceedToResumeCheck();

            //verify
            Assert.IsTrue(resumeCompletedPage.IsUrlMatchPage());
        }


        #region Scenario: Student sees notification

        [When(@"I press button ""(.*)""")]
        public void WhenIPressButton(string p0)
        {
            resumeCompletedPage.PressButton(p0);
        }
        [Then(@"I see pop-up message")]
        public void ThenISeePop_UpMessage(Table table)
        {
            Assert.IsTrue(resumeCompletedPage.IsPopUpDisplayed());
            //Assert.IsTrue(resumeCompletedPage.IsPopUpTextCorrect(table));
        }
        [Then(@"I see button ""(.*)""")]
        public void ThenISeeButton(string p0)
        {
            Assert.IsTrue(resumeCompletedPage.IsButtonTextCorrect(p0));
        }

        #endregion

        #region Scenario: Student Submits resume

        [When(@"I press button ""(.*)"" on pop-up message")]
        public void WhenIPressButtonOnPop_UpMessage(string p0)
        {
            resumeCompletedPage.PressPopUpButton(p0);
        }
        [Then(@"I moved to my personal page")]
        public void WhenIMovedToMyPersonalPage()
        {
            Assert.IsTrue(homePage.IsBrowserUrlMatchesResumeUrl());
        }
        [Then(@"I open my personal menu")]
        public void WhenIOpenMyPersonalMenu()
        {
            homePage.ClickMenuButton();
        }
        [Then(@"I select button ""(.*)""")]
        public void WhenISelectButton(string p0)
        {
            homePage.ResumeButton.Click();
        }
        [Then(@"I see my completed resume")]
        public void ThenISeeMyCompletedResume()
        {
            Assert.IsTrue(resumeCompletedPage.IsUrlMatchPage());
        }
        [Then(@"I cannot edit it")]
        public void ThenICannotEditIt()
        {
            Assert.IsFalse(resumeCompletedPage.AreButtonsVisible());
        }

        #endregion

        #region Scenario: Student cancels submission of resume

        [Then(@"I am on completed resume page")]
        public void ThenIAmOnCompletedResumePage()
        {
            Assert.IsTrue(resumeCompletedPage.IsUrlMatchPage());
        }

        #endregion
    }
}
