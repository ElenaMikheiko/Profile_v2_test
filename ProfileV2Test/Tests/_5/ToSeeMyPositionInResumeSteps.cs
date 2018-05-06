using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProfileV2Test.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace ProfileV2Test.Tests._5
{
    [Binding]
    public class ToSeeMyPositionInResumeSteps : BaseSteps
    {
        public ToSeeMyPositionInResumeSteps() : base() { }

        //create vars
        private IWebElement activeTab;            
        
        [When(@"I stay on particular resume block")]
        public void WhenIStayOnParticularResumeBlock()
        {
            //wait for the page to load
            Thread.Sleep(2000);

            activeTab = resumePage.GetActiveTab();           
        }
               // ⊂_ヽ 
　              //   ＼＼  Λ＿Λ 
　　             //    ＼ ('ㅅ')   
　　　            //     > ⌒ヽ 
　　　            //    / 　 へ＼ 
　　             //    /　　/　＼＼ 
　　             //    ﾚ  ノ     ヽ_つ 
　　             //   /　/  
　              //   /　/|
　              //  (  ( ヽ
　              //  |　| 、＼ 
　              //  | 丿  ＼ ⌒) 
　              //  | |　　 ) / 
               //(`ノ )　　
        [Then(@"I see that tab names are in the specific order")]
        public void ThenISeeThatTabNamesAreInTheSpecificOrder(Table table)
        {
            //get the expected list
            List<string> expectedList = new List<string>();
            foreach(TableRow tr in table.Rows)
            {
                expectedList.Add(tr.Values.FirstOrDefault());
            }

            //get the actual list
            List<IWebElement> navigationBarLinks = resumePage.GetListOfNavigationBarItems();
            List<string> actualList = new List<string>();
            foreach(IWebElement link in navigationBarLinks)
            {
                actualList.Add(link.Text);
            }

            //compare the lists
            Assert.IsTrue(Enumerable.SequenceEqual(expectedList, actualList));
        }
        
        [Then(@"its corresponding box on status bar is colored")]
        public void ThenItsCorrespondingBoxOnStatusBarIsColored()
        {
            Assert.IsTrue(resumePage.DoesElementHaveBackgroundColor(activeTab, "#2CA8DE"));
        }
    }
}
