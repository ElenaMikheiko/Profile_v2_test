using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ProfileV2Test.Infrastructure;

namespace ProfileV2Test.Page
{
    public class TrainerPage
    {
        private readonly IWebDriver _webDriver;
        private readonly string url = ProjectUrls.trainerPageUrl;

        public TrainerPage(IWebDriver browser)
        {
            _webDriver = browser;
            PageFactory.InitElements(browser, this);
        }

        [FindsBy(How = How.ClassName, Using = "table__caption")]
        public IWebElement PageHeader { get; set; }

        [FindsBy(How = How.ClassName, Using = "table")]
        public IWebElement TrainerStudentTable { get; set; }
        
        public IWebElement [,] GetAllTableCells()
        {
            IList<IWebElement> rows = TrainerStudentTable.FindElements(By.TagName("tr"));
            IList<IWebElement> columns = TrainerStudentTable.FindElements(By.TagName("th"));
            IList<IWebElement> td = TrainerStudentTable.FindElements(By.TagName("td"));
            IWebElement[,] cells = new IWebElement[rows.Count() - 1, columns.Count()];

            // store count to get to right value in td
            int count = default(int);

            //fill table cells
            for (int i = 0; i < rows.Count() - 1; i++)
            {
                for (int j = 0; j < columns.Count(); j++)
                {
                    cells[i, j] = td[count];
                    count++;
                }
            }

            return cells;
        }

        public bool DoesTableColumnContainExpectedData(string expectedHeader, string expectedValue = null)
        {
            IList<IWebElement> columns = TrainerStudentTable.FindElements(By.TagName("th"));
            IWebElement[,] tableCells = GetAllTableCells();

            for (int j = 0; j < columns.Count(); j++)
            {
                // checks for correct column header name and
                // if any text exists in same column as header
                if (columns[j].Text == expectedHeader)
                {
                    for (int i = 0; i < tableCells.GetLength(0); i++)
                    {
                        switch (expectedHeader)
                        {
                            case "№":
                            case "Student":
                            case "Request date":
                                {
                                    if (tableCells[i, j].Text == expectedValue)
                                        return true;
                                }
                                break;
                            case "Status":
                                {
                                    if(IsButtonNameCorrect(expectedValue))
                                    {
                                        if (tableCells[i, j].Text == expectedValue)
                                            return true;
                                    }
                                }
                                break;
                            default:
                                break;
                        }

                    }
                }
            }

            return false;

        }

        // returns true if trainer is valid
        public bool IsAuthenticated()
        {
            if (_webDriver.Url == url)
            {
                return true;
            }
            return false;
        }

        public bool IsButtonNameCorrect(string buttonName)
        {
            IList<IWebElement> buttons = TrainerStudentTable.FindElements(By.ClassName("btn"));

            foreach(IWebElement button in buttons)
            {
                if(button.Text == buttonName)
                {
                    return true;
                }
            }

            return false;
        }
    }
}