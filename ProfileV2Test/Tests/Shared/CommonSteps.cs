using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ProfileV2Test.Abstract;
using ProfileV2Test.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using static ProfileV2Test.Tests.Shared.CommonVariables;

namespace ProfileV2Test.Tests.Shared
{
    [Binding]
    public class CommonSteps : BaseSteps
    {
        private string standardButtonColor;
        private string highlightedButtonColor;
        private IWebElement inputField;
        private IWebElement counter;
        private IWebElement button;

        private const string capsRange = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string lowerCaseRange = "abcdefghijklmnopqrstuvwxyz";
        private const string numeralsRange = "0123456789";
        private const string specialsRange = "^\"№%*_ =+@#$^&.,:;()!?`-";

        // common background (step) for
        // 5.11
        [Then(@"I see placeholder text")]
        public void ThenISeePlaceholderText(Table table)
        {
                //TODO: write check if on correct tab on corresponding step!
            {
                Assert.IsTrue(resumePage.IsAdditionalInfoTextVisible(table));
            }
        }
          
        //common background (step) for 
        //1.1, 1.2
        //5.1, 5.2, 5.3, 5.4, 5.5, 5,6 5.16
        [Given(@"As unauthorized user I come to landing page of Profile")]
        public void GivenAsUnauthorizedUserIComeToLandingPageOfProfile()
        {
            landingPage.GoToLandingPage();
        }
        [Given(@"As unauthorised user I come to landing page of Profile")]
        public void GivenAsUnauthorisedUserIComeToLandingPageOfProfile()
        {
            landingPage.GoToLandingPage();
        }
        [Given(@"I log in as Student")]
        public void GivenILogInAsStudent()
        {
            landingPage.Authenticate("student@profile.com", "student");
            Assert.IsTrue(homePage.IsAuthenticated());
        }
        [Given(@"I open my personal menu")]
        public void GivenIOpenMyPersonalMenu()
        {
            homePage.MenuButton.Click();

            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));
            wait.Until(driver => homePage.LogoutButton.Displayed == true);
        }
        [Given(@"I select button ""(.*)""")]
        public void WhenISelectButton(string p0)
        {
            homePage.ResumeButton.Click();

            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.Url == ProjectUrls.resumePageUrl);
        }
        [Given(@"I start filling in my resume")]
        public void GivenIStartFillingInMyResume()
        {
            resumePage.StartButton_ResumeStart.Click();
        }
        [Given(@"I go to block ""(.*)""")]
        public void GivenIGoToBlock(string p0)
        {
            //set the counter so the loop won't be endless
            int i = 3;

            while (!resumePage.GetActiveDiv().Text.Contains(p0) & i > 0)
            {
                resumePage.MoveToPreviousPage();
                i--;
            }

            Assert.IsTrue(p0 == resumePage.GetActiveDiv().FindElement(By.ClassName("tab__header")).Text);
        }


        //  Common Scenario step(5.3, 5.4, 5.5, 5.6, 5.11): Student checking resume block title of page
        [Then(@"I see resume block title ""(.*)""")]
        public void ThenISeeResumeBlockTitle(string p0)
        {
            Assert.IsTrue(p0 == resumePage.GetActiveDiv().FindElement(By.ClassName("tab__header")).Text);
        }

        // Common Scenario step(5.3, 5.4, 5.5, 5.6): Student can see Tab status in status bar
        [Then(@"I see that tab name ""(.*)"" is active")]
        public void ThenISeeThatTabNameIsActive(string p0)
        {
            Assert.IsTrue(resumePage.GetActiveTab().Text == p0);
        }

        // Common Scenario step(5.3, 5.4, 5.5, 5.11): Student Moves to next page
        [When(@"I choose to move to next page")]
        public void WhenIChooseToMoveToNextPage()
        {
            resumePage.MoveToNextPage();
        }
        [Then(@"I moved to block ""(.*)""")]
        public void ThenIMoveToBlock(string p0)
        {
            //check if the actual header is included in p0
            //this is to include cases with split header like in tab #8
            Assert.IsTrue(p0.Contains(resumePage.GetActiveDiv().FindElement(By.ClassName("tab__header")).Text));
        }


        // Common Scenario step(5.3, 5.4): Student Moves to previous page
        [When(@"I choose to move to previous page")]
        public void WhenIChooseToMoveToPreviousPage()
        {
            //find the active button
            IWebElement BackButton = resumePage.GetActiveDiv().FindElement(By.ClassName("controls_back"));

            //click
            BackButton.Click();
        }


        //Common Scenario step (5.3, 5.4): Student Cancels saving of changes 
        [When(@"I choose to cancel")]
        public void WhenIChooseToCancel()
        {
            //find the active button
            IWebElement CancelButton = resumePage.GetActiveDiv().FindElement(By.ClassName("controls_cancel"));

            //click
            CancelButton.Click();
        }

        [Then(@"I see my personal page")]
        public void ThenISeeToMyPersonalPage()
        {
            Assert.IsTrue(chromeDriver.Url == ProjectUrls.homePageUrl);
        }


        //Common Scenario step (5.3,5.4,5.5): Student Saves information      
        [Given(@"I filled all fields in ""(.*)""")]
        public void GivenIFilledAllFieldsIn(string p0)
        {
            switch (p0)
            {
                case "Personal and contact information":
                    personalInformationPage.FillAllFieldsWithDummyData();
                    break;
                case "Summary":
                    summaryPage.FillAllFieldsWithDummyData(summaryText);
                    break;
                case "Skills":
                    skillsPage.FillSeveralSkills(skillsList);
                    break;
                case "Foreign languages":
                    languagesPage.FillOnlyOneRow(languagesData);
                    break;
                case "Additional information":
                    additionalInfoPage.FillInAdditionalInformationDummyData(additionalInfo);
                    break;
                default:
                    break;
            }
            
        }
        [When(@"I press ""(.*)"" button")]
        public void WhenIPressButton(string p0)
        {
            if (p0 == "NEXT")
            {
                resumePage.GetActiveDiv().FindElement(By.ClassName("controls_next")).Click();
            }
            if (p0 == "BACK")
            {
                resumePage.GetActiveDiv().FindElement(By.ClassName("controls_back")).Click();
            }
            if (p0 == "PREVIEW")
            {
                resumeEditPage.PreviewButton.Click();
            }
        }
        [Then(@"I can see data ""(.*)"" is present")]
        public void ThenICanSeeDataIsPresent(string p0)
        {
            switch (p0)
            {
                case "Personal and contact information":
                    Assert.IsTrue(personalInformationPage.IsPreviouslyEnteredDataPresent(commonCompairingList));
                    break;
                case "Summary":
                    Assert.IsTrue(summaryPage.IsPreviouslyEnteredDataPresent(summaryText));
                    break;
                case "Skills":
                    Assert.IsTrue(skillsPage.IsPreviouslyEnteredDataPresent(skillsList));
                    break;
                case "Foreign languages":
                    Assert.IsTrue(languagesPage.IsPreviouslyEnteredDataPresent(languagesData));
                    break;
                case "Additional information":
                    Assert.IsTrue(additionalInfoPage.IsPreviouslyEnteredDataPresent(summaryText));
                    break;
                default:
                    break;
            }

            //clear the values
            commonCompairingList.Clear();
            summaryText = "";
            languagesData.Clear();
        }


        //Common scenario (5.3, 5.4): Student Checks button activity "Next" in field "Summary"
        [When(@"I write (.*) of symbols in field ""(.*)""")]
        public void WhenIWriteOfSymbolsInField(int p0, string p1)
        {
            inputField = chromeDriver.FindElement(By.Id(p1));
            inputField.Clear();

            counter = chromeDriver.FindElement(By.Id("count_" + p1.ToLower()));
            for (int i = 0; i < p0; i++)
            {
                inputField.SendKeys("1");
            }

        }

        [Then(@"I see ""(.*)"" of ""(.*)"" button")]
        public void ThenISeeOfButton(string p0, string p1)
        {
            bool buttonStatus = resumePage.GetActiveDiv().FindElement(By.ClassName("controls__next")).Enabled;
            if (p0 == "active")
            {
                Assert.IsTrue(buttonStatus);
            }
            if ((p0 == "inactive"))
            {
                Assert.IsFalse(buttonStatus);
            }
        }

        [Then(@"I see (.*) of symbols")]
        public void ThenISeeOfSymbols(int p0)
        {
            Assert.IsTrue(inputField.GetAttribute("value").Length == p0);
        }


        [Then(@"I see (.*) of countdown")]
        public void ThenISeeOfCountdown(int p0)
        {
            int actual = Convert.ToInt32(counter.Text.Split(new[] { '/' })[0]);

            Assert.AreEqual(p0, actual);
        }

        

        [Then(@"countdown number is red")]
        public void ThenCountdownNumberIsRed()
        {
            //check if the field has class ".error"
            Assert.IsTrue(counter.GetAttribute("class").Contains(".error"));
        }


        //Common scenario outline (5.3, 5.4): Student sees Allowed symbols English letters A-Z, a-z, numbers 0-9, punctuation marks in field "Summary"
        [When(@"I write ""(.*)"" in field ""(.*)""")]
        public void WhenIWriteInField(string p0, string p1)
        {
            switch (p1)
            {
                case "Name":
                    inputField = personalInformationPage.UserNameInput;
                    break;
                case "Summary":
                    inputField = summaryPage.SummaryTextArea;
                    break;
                case "Additional information":
                    inputField = additionalInfoPage.MainTextBox;
                    break;
                default:
                    break;
            }

            inputField.Clear();
            inputField.SendKeys(p0);
        }

        [Then(@"I see the written ""(.*)""")]
        public void ThenISeeTheWritten(string p0)
        {
            Assert.IsTrue(p0 == inputField.GetAttribute("value"));
        }


        //Common scenario (5.3, 5,4): Student Verifies field on error in field "*"
        [When(@"I leave text field ""(.*)"" empty")]
        public void WhenILeaveTextFieldEmpty(string p0)
        {
            switch (p0)
            {
                case "Phone number":
                    inputField = personalInformationPage.PhoneNumberInput;
                    inputField.Clear();
                    break;
                default:
                    break;
            }
        }

        [When(@"I go to next page")]
        public void WhenIGoToNextPage()
        {
            resumePage.MoveToNextPage();
        }

        [Then(@"Text field is encircled red")]
        public void ThenTextFieldIsEncircledRed()
        {
            Assert.IsTrue(personalInformationPage.IsElementEncircledRed(inputField));
        }

        [Then(@"Text field ""(.*)"" is encircled red")]
        public void ThenTextFieldIsEncircledRed(string p0)
        {
            switch (p0)
            {
                case "Surname":
                    Assert.IsTrue(personalInformationPage.IsElementEncircledRed(personalInformationPage.UserSurnameInput));
                    break;
                case "Phone number":
                    Assert.IsTrue(personalInformationPage.IsElementEncircledRed(personalInformationPage.PhoneNumberInput));
                    break;
                case "Summary":
                    Assert.IsTrue(summaryPage.IsElementEncircledRed(summaryPage.SummaryTextArea));
                    break;
                case "Skills":
                    Assert.IsTrue(skillsPage.IsElementEncircledRed(skillsPage.SkillsInputContainer));
                    break;
                case "Proficiency":
                    Assert.IsTrue(languagesPage.IsProficiencyEncircledRed(0));
                    break;
                //intentially fail the test
                default:
                    Assert.IsTrue(false);
                    break;

            }

            //Assert.IsTrue(languagesPage.IsProficiencyEncircledRed(0));
        }


        //Common scenario (5.2, 5.3, 5.4): Student can see Button "*" is highlighted on hover
        /// <summary>
        /// <para>"START" - select the button on the resume welcome screen.</para>
        /// <para>"NEXT" - select the button on the active DIV.</para>
        /// <para>"BACK" - select the button on the active DIV.</para>
        /// </summary>
        /// <param name="p0"></param>
        [When(@"I hover on ""(.*)"" button")]
        public void WhenIHoverOnButton(string p0)
        {
            Actions hoverAction = new Actions(chromeDriver);

            //pick the button
            if(p0 == "START")
            {
                button = resumePage.StartButton_ResumeStart;
            }
            if (p0 == "NEXT")
            {
                button = resumePage.GetActiveDiv().FindElement(By.ClassName("controls_next"));
            }
            if (p0 == "BACK")
            {
                button = resumePage.GetActiveDiv().FindElement(By.ClassName("controls_back"));
            }

            //pick the color
            standardButtonColor = HelperMethods.RgbaToHexConverter(button.GetCssValue("background-color"));

            //move the cursor
            hoverAction.MoveToElement(button).Build().Perform();

            //wait for the action to be performed
            Thread.Sleep(2000);

            //pick the new color
            highlightedButtonColor = HelperMethods.RgbaToHexConverter(button.GetCssValue("background-color"));      
        }

        [Then(@"Button ""(.*)"" is highlighted")]
        public void ThenButtonIsHighlighted(string p0)
        {
            Assert.AreNotEqual(standardButtonColor, highlightedButtonColor);
        }

        //Common step for 5.11
        [Then(@"I see placeholder text in field ""(.*)""")]
        public void ThenISeePlaceholderTextInField(string p0, Table table)
        {
            switch (p0)
            {
                case "Summary":
                    Assert.IsTrue(summaryPage.DoesPlaceholderMatch(table.Rows.FirstOrDefault().Values.First()));
                    break;
                case "Additional information":
                    Assert.IsTrue(additionalInfoPage.DoesPlaceholderMatch(table.Rows.FirstOrDefault().Values.First()));
                    break;
                case "Languages, Proficiency":
                    Assert.IsTrue(languagesPage.DoesPlaceholderMatch(table.Rows.ElementAt(0).Values.First()));
                    Assert.IsTrue(languagesPage.DoesPlaceholderMatch(table.Rows.ElementAt(1).Values.First()));
                    break;
                default:
                    break;
            }
        }


        //Common steps for 5.11
        [When(@"I type any symbol from ""(.*)"" in input field ""(.*)""")]
        public void WhenITypeAnySymbolExceptInInputField(string p0, string p1)
        {
            switch (p1)
            {
                case "Name":
                    selectedInput = personalInformationPage.UserNameInput;
                    break;
                case "Surname":
                    selectedInput = personalInformationPage.UserSurnameInput;
                    break;
                case "Phone number":
                    selectedInput = personalInformationPage.PhoneNumberInput;
                    break;
                case "Skype":
                    selectedInput = personalInformationPage.SkypeInput;
                    break;
                case "LinkedIn":
                    selectedInput = personalInformationPage.LinkedInInput;
                    break;
                case "Summary":
                    selectedInput = summaryPage.SummaryTextArea;
                    break;
                case "Skills":
                    selectedInput = skillsPage.SkillsInputField;
                    break;
                case "Additional information":
                    selectedInput = additionalInfoPage.MainTextBox;
                    break;
                default:
                    break;
            }

            StringBuilder sb = new StringBuilder();

            #region randomizer

            Random rand = new Random();

            //picks one random symbol from every range
            if (p0.Contains("A-Z"))
                sb.Append(capsRange[rand.Next(capsRange.Length)]);
            if (p0.Contains("a-z"))
                sb.Append(lowerCaseRange[rand.Next(lowerCaseRange.Length)]);
            if (p0.Contains("0-9"))
                sb.Append(numeralsRange[rand.Next(numeralsRange.Length)]);
            if (p0.Contains("^№%*"))
                sb.Append(specialsRange[rand.Next(specialsRange.Length)]);

            #endregion

            sentKeys = sb.ToString();

            selectedInput.Clear();
            selectedInput.SendKeys(sentKeys);
        }
        [Then(@"Symbol is entered")]
        public void ThenSymbolIsEntered()
        {
            Assert.IsTrue(selectedInput.GetAttribute("value") == sentKeys);
        }


        //Common steps for 5.3, 5.11
        [Given(@"I leave block ""(.*)"" empty")]
        public void GivenILeaveBlockEmpty(string p0)
        {
            switch (p0)
            {
                case "Personal and contact information":
                    personalInformationPage.UserNameInput.Clear();
                    personalInformationPage.UserSurnameInput.Clear();
                    personalInformationPage.PhoneNumberInput.Clear();
                    personalInformationPage.SkypeInput.Clear();
                    personalInformationPage.LinkedInInput.Clear();
                    break;
                case "Summary":
                    summaryPage.SummaryTextArea.Clear();
                    break;
                case "Skills":
                    skillsPage.ClearField();
                    break;
                case "Additional information":
                    additionalInfoPage.MainTextBox.Clear();
                    break;
                default:
                    break;
            }
        }


        //Common steps for 5.3, 5.7.1
        [Then(@"I stay in block ""(.*)""")]
        public void ThenIStayInBlock(string p0)
        {
            Assert.IsTrue(resumePage.DoesBlockNameMatchesLink(p0));
        }

        [Then(@"I see notification ""(.*)""")]
        public void ThenISeeNotification(string p0)
        {
            //get the first <p>
            IWebElement para = resumePage.GetActiveDiv().FindElement(By.TagName("p"));

            Assert.AreEqual(p0, para.Text);
        }


        //common step for 5.3, 5.11
        [When(@"I write in ""(.*)"" ""(.*)"" of symbol")]
        public void WhenIWriteInOfSymbol(string p0, int p1)
        {
            //local var for effective switch
            IWebElement selected = null;

            //pick the necessary input
            switch (p0)
            {
                case "Name":
                    selected = personalInformationPage.UserNameInput;
                    counter = personalInformationPage.GetUserNameCounter();
                    break;
                case "Surname":
                    selected = personalInformationPage.UserSurnameInput;
                    counter = personalInformationPage.GetUserSurnameCounter();
                    break;
                case "Skype":
                    selected = personalInformationPage.SkypeInput;
                    counter = personalInformationPage.SkypeCounter;
                    break;
                case "LinkedIn":
                    selected = personalInformationPage.LinkedInInput;
                    counter = personalInformationPage.LinkedInCounter;
                    break;
                case "Summary":
                    selected = summaryPage.SummaryTextArea;
                    counter = summaryPage.Counter;
                    break;
                case "Additional information":
                    selected = additionalInfoPage.MainTextBox;
                    counter = additionalInfoPage.Counter;
                    break;
                default:
                    break;
            }

            //clear the input
            selected.Clear();

            //send keys according to the params
            for (int i = 0; i < p1; i++)
            {
                selected.SendKeys("f");
            }
        }

        //common step for 5.11
        [Then(@"Countdown number is ""(.*)""")]
        public void ThenCountdownNumberIs(string p0)
        {
            Assert.AreEqual(p0, counter.Text);
        }

        //common step for 5.11
        [Then(@"Countdown is encircled red")]
        public void ThenCountdownIsEncircledRed()
        {
            Assert.IsTrue(counter.GetAttribute("class").Contains("count_red"));
        }




    }
}
