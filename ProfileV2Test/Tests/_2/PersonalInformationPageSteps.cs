using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ProfileV2Test.Abstract;
using System.Threading;
using TechTalk.SpecFlow;

namespace ProfileV2Test.Tests._2
{
    [Binding]
    public class PersonalInformationPageSteps : BaseSteps
    {
        public PersonalInformationPageSteps() : base() { }

        [Given(@"User log in as Student")]
        public void GivenUserLogInAsStudent()
        {
            landingPage.GoToLandingPage();
            landingPage.Authenticate("student@profile.com", "student");
            Assert.IsTrue(homePage.IsAuthenticated());
        }
        
        [When(@"I go to personal menu")]
        public void WhenIGoToPersonalMenu()
        {
            homePage.MenuButton.Click();
            
            //the animation of menu takes some time so the test execution has to be temporarily suspended
            Thread.Sleep(3000);
        }
        
        [When(@"I see ""(.*)"" button")]
        public void WhenISeeButton(string p0)
        {         
            Assert.AreEqual(p0, homePage.LogoutButton.Text);
        }
        
        [Then(@"I see field for foto")]
        public void ThenISeeFieldForFoto()
        {
            Assert.IsTrue(homePage.IsElementExists(By.ClassName("content__main_image")));
        }
        
        [Then(@"I see my name")]
        public void ThenISeeMyName()
        {
            Assert.IsTrue(homePage.IsElementExists(By.ClassName("content__information_name")));
        }
        
        [Then(@"surname")]
        public void ThenSurname()
        {
            Assert.IsTrue(homePage.IsElementExists(By.ClassName("content__information_name")));
        }
        
        [Then(@"role")]
        public void ThenRole()
        {
            Assert.IsTrue(homePage.IsElementExists(By.ClassName("content__information_cv")));
        }
        
        [Then(@"e-mail")]
        public void ThenE_Mail()
        {
            Assert.IsTrue(homePage.EmailRow.Text != "");
        }
        
        [Then(@"phone number")]
        public void ThenPhoneNumber()
        {
            Assert.IsTrue(homePage.PhoneNumberRow.Text != "");
        }
        
        [Then(@"I see my skype")]
        public void ThenISeeMySkype()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"linkdin")]
        public void ThenLinkdin()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I exit from my account")]
        public void ThenIExitFromMyAccount()
        {
            homePage.LogoutButton.Click();
            Assert.IsTrue(chromeDriver.Url.Contains(@"/Account/Login"));
        }
        
        [Then(@"I see icons e-mail")]
        public void ThenISeeIconsE_Mail()
        {
            Assert.IsTrue(homePage.IsElementExists(By.ClassName("fa-envelope-o")));
        }

        [Then(@"phone number icon")]
        public void ThenPhoneNumberIcon()
        {
            Assert.IsTrue(homePage.IsElementExists(By.ClassName("fa-phone-square")));
        }

        [Then(@"skype icon")]
        public void ThenSkypeIcon()
        {
            Assert.IsTrue(homePage.IsElementExists(By.ClassName("fa-skype")));
        }
        
        [Then(@"linkedin icon")]
        public void ThenLinkedinIcon()
        {
            Assert.IsTrue(homePage.IsElementExists(By.ClassName("fa-linkedin")));
        }
    }
}
