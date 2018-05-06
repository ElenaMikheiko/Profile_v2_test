using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ProfileV2Test.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace ProfileV2Test.Page.ResumePages
{
    public class _01_PersonalInformation_PartialResumePage
    {
        private readonly IWebDriver _webDriver;

        public _01_PersonalInformation_PartialResumePage(IWebDriver browser)
        {
            _webDriver = browser;
            PageFactory.InitElements(browser, this);
        }

        //local constants

        public const string dummyKeys = "123";

        [FindsBy(How = How.ClassName, Using = "tab__header")]
        public IWebElement PageHeader { get; set; }

       
        //user information block
        [FindsBy(How = How.ClassName, Using = "tab__info_common")]
        public IWebElement UserInfoTab { get; set; }

        [FindsBy(How = How.Id, Using = "UserInfo_EnName")]
        public IWebElement UserNameInput { get; set; }

        public IWebElement GetUserNameCounter() => UserInfoTab.FindElements(By.TagName("span")).ElementAt(0);

        [FindsBy(How = How.Id, Using = "UserInfo_EnSurname")]
        public IWebElement UserSurnameInput { get; set; }

        public IWebElement GetUserSurnameCounter() => UserInfoTab.FindElements(By.TagName("span")).ElementAt(1);

        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement EmailField { get; set; }

        [FindsBy(How = How.Id, Using = "phone")]
        public IWebElement PhoneNumberInput { get; set; }

        [FindsBy(How = How.Id, Using = "count_phone")]
        public IWebElement PhoneNumberCounter { get; set; }


        //lower page block
        [FindsBy(How = How.ClassName, Using = "fa-skype")]
        public IWebElement SkypeIcon { get; set; }

        [FindsBy(How = How.Id, Using = "UserInfo_Skype")]
        public IWebElement SkypeInput { get; set; }

        [FindsBy(How = How.Id, Using = "count_skype")]
        public IWebElement SkypeCounter { get; set; }

        [FindsBy(How = How.ClassName, Using = "fa-linkedin")]
        public IWebElement LinkedInIcon { get; set; }

        [FindsBy(How = How.Id, Using = "UserInfo_Linkedin")]
        public IWebElement LinkedInInput { get; set; }

        [FindsBy(How = How.Id, Using = "count_linked")]
        public IWebElement LinkedInCounter { get; set; }

        [FindsBy(How = How.ClassName, Using = "personal__next")]
        public IWebElement NextButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "personal__back")]
        public IWebElement BackButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "personal__cancel")]
        public IWebElement CancelButton { get; set; }


        //methods
        public void SendSimpleKeys(IWebElement webElement)
        {
            webElement.Clear();
            webElement.SendKeys(dummyKeys);
        }

        public bool IsUserNameSurnameDisplayed(string nameSurname)
        {
            if (UserInfoTab.Text.Contains(nameSurname))
            {
                return true;
            }
            return false;
        }

        public bool IsPhoneNumberDisplayed()
        {

            //since the code contains 375, we check for at least 3 numbers
            if (PhoneNumberInput.Text.Count() > 3)
            {
                return true;
            }
            return false;
        }

        public IWebElement PickIcon(string fieldName)
        {
            switch (fieldName)
            {
                case "Skype":
                    return SkypeIcon;
                default:
                    return LinkedInIcon;
            }
        }

        public IWebElement PickInputField(string fieldName)
        {
            switch (fieldName)
            {
                case "Name":
                    return UserNameInput;
                case "Surname":
                    return UserSurnameInput;
                case "Phone number":
                    return PhoneNumberInput;
                case "Skype":
                    return SkypeInput;
                default:
                    return LinkedInInput;
            }
        }

        public IWebElement PickCounterField(string fieldName)
        {
            switch (fieldName)
            {
                case "Name":
                    return GetUserNameCounter();
                case "Surname":
                    return GetUserSurnameCounter();
                case "Phone number":
                    return PhoneNumberCounter;
                case "Skype":
                    return SkypeCounter;
                default:
                    return LinkedInCounter;
            }
        }

        /// <summary>
        /// Fills the corresponding input with pre-defined data and adds it to the list.
        /// </summary>
        /// <param name="inputName"></param>
        /// <param name="listToUpdate"></param>
        public void FillInputWithDummyData(string inputName, IList<string> listToUpdate)
        {

            switch (inputName)
            {
                case "Name":
                    UserNameInput.Clear();
                    UserNameInput.SendKeys("TestName");
                    listToUpdate.Add("TestName");
                    break;
                case "Surname":
                    UserSurnameInput.Clear();
                    UserSurnameInput.SendKeys("TestSurname");
                    listToUpdate.Add("TestSurname");
                    break;
                case "Phone number":
                    PhoneNumberInput.Clear();
                    PhoneNumberInput.SendKeys("258887744");
                    listToUpdate.Add("258887744");
                    break;
                case "Skype":
                    SkypeInput.Clear();
                    SkypeInput.SendKeys("TestSkype");
                    listToUpdate.Add("TestSkype");
                    break;
                case "LinkedIn":
                    LinkedInInput.Clear();
                    LinkedInInput.SendKeys("TestLinkedIn");
                    listToUpdate.Add("TestLinkedIn");
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Fills all the fields in the block with dummy data.
        /// </summary>
        public void FillAllFieldsWithDummyData()
        {
            UserNameInput.Clear();
            UserNameInput.SendKeys("TestName");
            UserSurnameInput.Clear();
            UserSurnameInput.SendKeys("TestSurname");
            PhoneNumberInput.Clear();
            PhoneNumberInput.SendKeys("258887744");
            SkypeInput.Clear();
            SkypeInput.SendKeys("TestSkype");
            LinkedInInput.Clear();
            LinkedInInput.SendKeys("TestLinkedIn");
        }

        public IWebElement PickButton(string buttonName)
        {
            switch (buttonName)
            {
                case "Next":
                    return NextButton;
                default:
                    return BackButton;
            }
        }

        /// <summary>
        /// Returns "true" if the selected IWebElement has class "error"
        /// </summary>
        /// <param name="inputField"></param>
        /// <returns></returns>
        public bool IsElementEncircledRed(IWebElement inputField)
        {
            if (inputField.GetAttribute("class").Contains("error"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Adds data from user name, second name, phone number,
        /// skype, linkedIn inputs to a list and compares it with the expected.
        /// </summary>
        /// <param name="expected"></param>
        /// <returns></returns>
        public bool IsPreviouslyEnteredDataPresent(IList<string> expected)
        {
            IList<string> actual = new List<string>();

            actual.Add(UserNameInput.GetAttribute("value"));
            actual.Add(UserSurnameInput.GetAttribute("value"));

            //rip the phone mask
            string phoneMasked = PhoneNumberInput.GetAttribute("value");
            string[] arr = phoneMasked.Split(new[] { '(', ')', '-' });
            string phoneRaw = arr[1] + arr[2].Substring(1) + arr[3] + arr[4];
            actual.Add(phoneRaw);

            actual.Add(SkypeInput.GetAttribute("value"));
            actual.Add(LinkedInInput.GetAttribute("value"));


            if (Enumerable.SequenceEqual(expected, actual))
            {
                return true;
            }

            return false;
        }
    }
}
