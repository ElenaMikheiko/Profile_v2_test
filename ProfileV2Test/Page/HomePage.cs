using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using ProfileV2Test.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProfileV2Test.Page
{
    public class HomePage
    {
        private readonly IWebDriver _webDriver;
        private readonly string url = ProjectUrls.homePageUrl;

        public HomePage(IWebDriver browser)
        {
            _webDriver = browser;
            PageFactory.InitElements(browser, this);
        }
        [FindsBy(How = How.Id, Using = "logoutForm")]
        public IWebElement LogoutForm { get; set; }

        [FindsBy(How = How.ClassName, Using = "closebtn")]
        public IWebElement MenuButton { get; set; }

        public IWebElement LogoutButton => LogoutForm.FindElement(By.TagName("button"));

        [FindsBy(How = How.ClassName, Using = "content__main_image")]
        public IWebElement ProfileImage { get; set; }

        [FindsBy(How = How.ClassName, Using = "content__data_email")]
        public IWebElement EmailRow { get; set; }

        [FindsBy(How = How.ClassName, Using = "content__data_phone")]
        public IWebElement PhoneNumberRow { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div/header/div/div/div/div[2]/ul/li[1]/a")]
        public IWebElement ResumeButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "content__pop-up_close")]
        public IWebElement CloseButton { get; set; }

        [FindsBy(How = How.Id, Using = "choose_image_button")]
        public IWebElement ChooseImageButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "content__pop-up_text")]
        public IWebElement ProfileImageText { get; set; }

        [FindsBy(How = How.Id, Using = "upload_photo_button")]
        public IWebElement UploadPhotoButton { get; set; }

        [FindsBy(How = How.Id, Using = "fileInput")]
        public IWebElement FileInput { get; set; }

        [FindsBy(How = How.ClassName, Using = "content__pop-up_error")]
        public IWebElement ErrorMessage { get; set; }
        
        public void Navigate() => _webDriver.Navigate().GoToUrl(url);

        public bool IsAuthenticated()
        {
            if (_webDriver.Url == url)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Opens the dropdown menu and waits for the animation.
        /// </summary>
        public void ClickMenuButton()
        {
            MenuButton.Click();

            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            wait.Until(browser => ResumeButton.Displayed == true);
        }

        /// <summary>
        /// Clicks the corresponding link/button in the drop down menu.
        /// </summary>
        /// <param name="buttonName"></param>
        public void SelectOptionFromDropDownmenu(string buttonName)
        {
            switch (buttonName)
            {
                case "Log Out":
                    LogoutButton.Click();
                    break;
                default:
                    break;
            }
        }

        public bool IsElementExists(By by)
        {
            IReadOnlyCollection<IWebElement> elements = _webDriver.FindElements(by);
            return (elements.Count >= 1) ? true : false;
        }

        /// <summary>
        /// Checks if the currently opened url matches the home page url.
        /// </summary>
        /// <returns></returns>
        public bool IsBrowserUrlMatchesResumeUrl()
        {
            if (_webDriver.Url == url | _webDriver.Url == (url + "Home/Index"))
                return true;
            return false;
        }

        public bool DoesElementHaveColor(IWebElement element, string color)
        {
            //use custom converter
            string actualColor = HelperMethods.RgbaToHexConverter(element.GetCssValue("color"));

            if (actualColor == color)
            {
                return true;
            }

            return false;
        }

        public bool CompareExpectedTextToActualTextBySentences(string actualHtmlText, IList<string> expectedText)
        {
            IList<string> actualText = new List<string>();

            //split text into sentences
            string[] htmlSentences = actualHtmlText.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string str in htmlSentences)
            {
                actualText.Add(str.TrimStart() + ".");
            }

            return Enumerable.SequenceEqual(expectedText, actualText);
        }

        //public string GetHtmlText(string nameText)
        //{
        //    string htmlText = null;

        //    switch (nameText)
        //    {
        //        case "<text>":
        //            htmlText = ProfileImageText.Text;
        //            break;
        //        case "<Error message>":
        //            htmlText = ErrorMessage.Text;
        //            break;
        //        default:
        //            break;
        //    }

        //    return htmlText;
        //}

        public bool CheckCloseButton()
        {
            string className = CloseButton.GetAttribute("class");

            return IsElementExists(By.ClassName(className));
        }

        public bool CheckUploadedImage()
        {
            string srcValue = ProfileImage.GetAttribute("src");

            //I use StartWith because when student choose its photo, he can choose defined area in photo 
            return srcValue.StartsWith("data");
        }
    }
}
