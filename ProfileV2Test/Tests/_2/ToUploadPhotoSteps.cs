using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Interactions;
using ProfileV2Test.Abstract;
using ProfileV2Test.Infrastructure;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TechTalk.SpecFlow;

namespace ProfileV2Test.Tests._2
{
    [Binding]
    public class ToUploadPhotoSteps : BaseSteps
    {
        public ToUploadPhotoSteps() : base() { }

        static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        [Given(@"I put cursor in photo area")]
        public void GivenIPutCursorInPhotoArea()
        {
            homePage.ClickMenuButton();
            Actions action = new Actions(chromeDriver);
            action.MoveToElement(homePage.ProfileImage);
        }
        
        [Given(@"I click on photo area")]
        public void GivenIClickOnPhotoArea()
        {
            homePage.ProfileImage.Click();
        }
        
        [Given(@"I click ""(.*)"" button")]
        public void GivenIClickButton(string p0)
        {
            homePage.ChooseImageButton.Click();
        }

        [Given(@"I choose img with size bigger than (.*) Mbyte from local storage")]
        public void GivenIChooseImgWithSizeBiggerThanMbyteFromLocalStorage(int p0)
        {
            homePage.FileInput.SendKeys(PathsToFiles.PathToImageIsBiggerThan3Mb);
        }
        
        [Given(@"img size is bigger than (.*) Mbyte")]
        public void GivenImgSizeIsBiggerThanMbyte(int p0)
        {
            FileInfo file = new FileInfo(PathsToFiles.PathToImageIsBiggerThan3Mb);
            Assert.IsTrue(ConvertBytesToMegabytes(file.Length) > p0);
        }

        [Then(@"I see upload error message")]
        public void ThenISeeUploadErrorMessage(Table table)
        {
            IList<string> expectedText = new List<string>();

            //read table and add row to the list
            foreach (TableRow row in table.Rows)
            {
                expectedText.Add(row.Values.First());
            }

            //compare by sentences
            Assert.IsTrue(homePage.CompareExpectedTextToActualTextBySentences(homePage.ErrorMessage.Text, expectedText));
        }


        #region Scenario: Open form for upload foto

        [When(@"I click on photo area")]
        public void WhenIClickOnPhotoArea()
        {
            homePage.ProfileImage.Click();
        }

        #endregion

        #region Scenario: Student upload photo

        [When(@"I click ""(.*)""")]
        public void WhenIClick(string p0)
        {
            homePage.UploadPhotoButton.Click();
        }

        #endregion

        #region Scenario: Open form for upload foto

        [Then(@"I see the close button")]
        public void ThenISeeTheCloseButton()
        {
            Assert.IsTrue(homePage.CheckCloseButton());
        }

        #endregion

        #region Scenario: Open form for upload foto

        [Then(@"I see ""(.*)"" button")]
        public void ThenISeeButton(string p0)
        {
            Assert.IsTrue(homePage.ChooseImageButton.Text == p0);
        }

        #endregion

        #region Scenarios: Open form for upload foto, Upload photo bigger then 3 Mbyte


        [Then(@"I see upload photo text hint")]
        public void ThenISeeUploadPhotoTextHint(Table table)
        {
            IList<string> expectedText = new List<string>();

            //read table and add row to the list
            foreach (TableRow row in table.Rows)
            {
                expectedText.Add(row.Values.First());
            }

            //compare by sentences
            Assert.IsTrue(homePage.CompareExpectedTextToActualTextBySentences(homePage.ProfileImageText.Text, expectedText));
        }

        #endregion

        #region Scenario: Student upload photo

        [Then(@"I see student's profile page with uploaded img")]
        public void ThenISeeStudentSProfilePageWithUploadedImg()
        {
            Assert.IsTrue(homePage.CheckUploadedImage());
        }

        #endregion
    }
}
