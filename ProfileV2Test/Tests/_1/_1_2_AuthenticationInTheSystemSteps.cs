using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProfileV2Test.Abstract;
using TechTalk.SpecFlow;

namespace ProfileV2Test.Tests._1
{
    [Binding]
    public class _1_2_AuthenticationInTheSystemSteps: BaseSteps
    {
        public _1_2_AuthenticationInTheSystemSteps() : base() { }

        #region Scenario: Authorization in the system of User (correct data)

        [When(@"I write e-mail of existing user")]
        public void WhenIWriteE_MailOfExistingUser()
        {
            landingPage.EmailInputField.SendKeys("admin@profile.com");
        }

        [When(@"I write password of this user")]
        public void WhenIWritePasswordOfThisUser()
        {
            landingPage.PasswordInputField.SendKeys("admin123");
        }
        
        [When(@"I log in to the system")]
        public void WhenILogInToTheSystem()
        {
            landingPage.LoginButton.Click();
        }

        [Then(@"I go to personal page")]
        public void ThenIGoToPersonalPage()
        {
            homePage.Navigate();
        }

        #endregion

        #region Scenario: Authorization in the system (incorrect data)

        [When(@"I write incorrect ""(.*)"" as email")]
        public void WhenIWriteIncorrectAsEmail(string p0)
        {
            landingPage.FillEmailWithData(p0);
        }
        
        [When(@"I write incorrect data in field password")]
        public void WhenIWriteIncorrectDataInFieldPassword()
        {
            landingPage.FillIncorrectEmail();
        }

        [Then(@"I see error message ""(.*)""")]
        public void ThenISeeErrorMessage(string p0)
        {
           Assert.AreEqual(p0, landingPage.ErrorMessage.Text);
        }

        [Then(@"I do not get access to the system")]
        public void ThenIDoNotGetAccessToTheSystem()
        {
            Assert.IsFalse(homePage.IsAuthenticated());
        }

        #endregion

        #region Scenario: Authorization with empty fields (incorrect data)

        [Then(@"Fields are highlighted")]
        public void ThenFieldAreHighlighted()
        {
            Assert.IsTrue(landingPage.IsFieldHighlighted(landingPage.EmailInputField));
            Assert.IsTrue(landingPage.IsFieldHighlighted(landingPage.PasswordInputField));
        }

        #endregion
    }
}
