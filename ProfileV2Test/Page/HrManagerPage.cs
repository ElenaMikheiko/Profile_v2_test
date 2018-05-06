using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ProfileV2Test.Infrastructure;

namespace ProfileV2Test.Page
{
    public class HrManagerPage
    {
        private readonly IWebDriver _webDriver;

        private const string Url = ProjectUrls.hrManagerPageUrl;

        private List<string> _list;

        private List<string> _listSorted;


        public HrManagerPage(IWebDriver browser)
        {
            _webDriver = browser;
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.Id, Using = "students-table")]
        public IWebElement HrStudentTable { get; set; }

        public void GoToHrHomePage() => _webDriver.Navigate().GoToUrl(Url);

        public bool IsListSorted(IList<string> list, IList<string> listSorted) => list.SequenceEqual(listSorted);

        public bool IsAuthenticated()
        {
            if (_webDriver.Url == Url)
            {
                return true;
            }
            return false;
        }

        #region Tests 6.1

        /// <summary>
        /// Return true if header name is exactly the same
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsHeaderNameCorrect(string name)
        {
            var table = HrStudentTable; 
            var rows = table.FindElements(By.TagName("tr"));

            foreach (var row in rows)
            {
                var rowTh = row.FindElements(By.TagName("th"));

                foreach (var th in rowTh)
                {
                    if (th.Text == name)
                        return true;
                }
            }
            return false;
        }

        /// <summary>
            /// Returns true if correct header name and value in same column as header is not empty
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            public bool IsStudentColumnEmpty(string name)
        {
            var table = HrStudentTable;
            var rows = table.FindElements(By.TagName("tr"));
            var columns = table.FindElements(By.TagName("td"));

            // store count to get to right column
            int count = default(int);

            foreach (var row in rows)
            {
                // find's all table headers
                var rowTh = row.FindElements(By.TagName("th"));

                foreach (var th in rowTh)
                {
                    count++;

                    // checks for correct column header name and
                    // if any text exists in same column as header
                    if ((th.Text == name) && (columns[count - 1].Text.Length != 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion

        #region Tests 6.3

        public bool IsSortButtonClicked(string expectedButtonName, string expectedColumnName)
        {
            IList<IWebElement> elements = HrStudentTable.FindElements(By.TagName("tr"));

            foreach (IWebElement element in elements)
            {
                if (element.GetAttribute(expectedColumnName).Contains(expectedButtonName))
                {
                    element.Click();
                    return true;
                }

            }

            return false;
        }

        public bool IsTableDataSorted()
        {
            // creates new List _list
            _list = new List<string>();

            IList<IWebElement> elements = HrStudentTable.FindElements(By.TagName("tr"));

            // finds text data in student table
            foreach (IWebElement element in elements)
            {
                if (element.FindElement(By.TagName("td")).Text.Equals(element.GetAttribute("value")))
                {
                    // add data to list
                    _list.Add(element.Text);
                }
            }

            // makes new list _listSorted and copy data from _list to _listSorted
            _listSorted = new List<string>(_list);

            // sortes _listSorted
            _listSorted.Sort();

            // checks _list and _listSorted data and returns true if both lists have same data
            return IsListSorted(_list, _listSorted);
        }


        #endregion

    }
}

