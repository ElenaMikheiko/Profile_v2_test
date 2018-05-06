using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using ProfileV2Test.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace ProfileV2Test.Page.ResumePages
{
    public class _05_ForeignLanguages_PartialResumePage
    {
        private readonly IWebDriver _webDriver;

        public _05_ForeignLanguages_PartialResumePage(IWebDriver browser)
        {
            _webDriver = browser;
            PageFactory.InitElements(browser, this);
        }

        /// <summary>
        /// Main DIV that contains all elements from the tab "Languages".
        /// </summary>
        [FindsBy(How = How.Id, Using = "v-pills-languages")]
        public IWebElement LanguagesDiv { get; set; }

        /// <summary>
        /// Gets the first language dropdown.
        /// </summary>
        /// <returns></returns>
        public IWebElement GetFirstLanguageDropDown() => LanguagesDiv.FindElement(By.ClassName("tab__languages_dropdown"));

        /// <summary>
        /// Gets the first proficiency dropdown
        /// </summary>
        /// <returns></returns>
        public IWebElement GetFirstProficiencyDropDown() => LanguagesDiv.FindElement(By.ClassName("_langlevel"));

        /// <summary>
        /// Clicks "Add another language" link.
        /// </summary>
        public void ClickAddNewLanguage() => LanguagesDiv.FindElement(By.ClassName("tab__add")).Click();

        /// <summary>
        /// Resets the first proficiency dropdown to the placeholder.
        /// </summary>
        public void ResetProficiencyToDefault()
        {
            SelectElement se = new SelectElement(GetFirstProficiencyDropDown());
            se.SelectByIndex(0);
        }

        /// <summary>
        /// Selects random proficiency from 1 to 6. Index starts at 0.
        /// </summary>
        /// <param name="rowIndex"></param>
        public void SelectProfficiencyByRow(int rowIndex)
        {
            Random rand = new Random();
            SelectElement se = new SelectElement(LanguagesDiv.FindElements(By.ClassName("_langlevel")).ElementAt(rowIndex));
            se.SelectByValue(rand.Next(1, 7).ToString());
        }

        /// <summary>
        /// Removes the selected row. Index starts at 0.
        /// </summary>
        /// <param name="rowIndex"></param>
        public void RemoveLanguageByRow(int rowIndex)
        {
            LanguagesDiv.FindElements(By.ClassName("tab__remove")).ElementAt(rowIndex).Click();
        }

        /// <summary>
        /// Returns false if the number of rows is less than index (starts at 1).
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public bool IsLanguageRowPresent(int rowIndex)
        {
            IReadOnlyCollection<IWebElement> rows =  LanguagesDiv.FindElements(By.ClassName("_ulanguages"));

            if (rows.Count() == rowIndex)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns false if proficiency at row is set to "---". Index starts at 0.
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public bool IsProficiencySet(int rowIndex)
        {
            SelectElement se = new SelectElement(LanguagesDiv.FindElements(By.ClassName("_langlevel")).ElementAt(rowIndex));
            if(se.SelectedOption.Text != "---")
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns true is the proficiency input at row has class "error". Index starts at 0.
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public bool IsProficiencyEncircledRed(int rowIndex)
        {
            IWebElement element = LanguagesDiv.FindElements(By.ClassName("_langlevel")).ElementAt(rowIndex);
            if (element.GetAttribute("class").Contains("error"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Sends "English, B1" to the first row and updates the dictionary.
        /// </summary>
        /// <param name="dicToStoreData"></param>
        public void FillOnlyOneRow(IDictionary<string, string> dicToStoreData)
        {
            //ensure that there is only one row left
            IReadOnlyCollection<IWebElement> rows = LanguagesDiv.FindElements(By.ClassName("tab__remove"));

            for (int i = rows.Count - 1; i > 1; i--)
            {
                rows.ElementAt(i).Click();
            }

            SelectElement languages = new SelectElement(GetFirstLanguageDropDown());
            SelectElement proficiencies = new SelectElement(GetFirstProficiencyDropDown());

            //pick "English"
            languages.SelectByValue("1");
            //pick "B1"
            proficiencies.SelectByValue("3");
            //add key-value to dictionary
            dicToStoreData.Add(
                new KeyValuePair<string, string> ( 
                    languages.SelectedOption.Text,
                    proficiencies.SelectedOption.Text
                    ));
        }

        public bool IsPreviouslyEnteredDataPresent(IDictionary<string, string> expected)
        {
            IDictionary<string, string> actual = new Dictionary<string, string>();

            IReadOnlyCollection<IWebElement> languages = LanguagesDiv.FindElements(By.ClassName("tab__languages_dropdown"));
            IReadOnlyCollection<IWebElement> proficiencies = LanguagesDiv.FindElements(By.ClassName("_langlevel"));

            for (int i = 0; i < languages.Count; i++)
            {
                SelectElement se = new SelectElement(languages.ElementAt(i));
                SelectElement pr = new SelectElement(proficiencies.ElementAt(i));
                actual.Add(
                    new KeyValuePair<string, string>(
                        se.SelectedOption.Text,
                        pr.SelectedOption.Text
                        ));
            }

            foreach (KeyValuePair<string, string> kvp in actual)
            {
                string val = "";
                expected.TryGetValue(kvp.Key, out val);
                if (val != kvp.Value)
                    return false; 
            }

            return true;

        }

        /// <summary>
        /// Compares the first row's expected and actual values.
        /// </summary>
        /// <param name="expected"></param>
        /// <returns></returns>
        public bool DoesPlaceholderMatch(string expected)
        {
            switch (expected)
            {
                case "English":
                    SelectElement languages = new SelectElement(GetFirstLanguageDropDown());
                    return (expected == languages.SelectedOption.Text);
                case "---":
                    //we expect that the proficiency is not set
                    return (IsProficiencySet(0) == false);
                default:
                    return false;
            }
        }

        /// <summary>
        /// Returns true if the values and the order of options in the first proficiency dropdown match the expectedValues.
        /// </summary>
        /// <param name="expectedValues"></param>
        /// <returns></returns>
        public bool DoProficiencyValuesMatch(Table expectedValues)
        {
            IList<string> expected = new List<string>();
            foreach(TableRow row in expectedValues.Rows)
            {
                expected.Add(row.Values.First());
            }

            IList<string> actual = new List<string>();
            IReadOnlyCollection<IWebElement> options = GetFirstProficiencyDropDown().FindElements(By.TagName("option"));
            foreach(IWebElement option in options)
            {
                actual.Add(option.Text);
            }

            return Enumerable.SequenceEqual(actual, expected);

        }
    }
}
