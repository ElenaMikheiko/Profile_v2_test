using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProfileV2Test.Abstract;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Plugins;

namespace ProfileV2Test.Tests._6
{
    [Binding]
    public class ToSortOutInformationInListOfStudentsSteps : BaseSteps
    {
        public ToSortOutInformationInListOfStudentsSteps():base()
        {
            
        }

        [Given(@"I log in as HR")]
        public void GivenILogInAsHR()
        {
            landingPage.Authenticate("hr@profile.com", "hmanager123"); 
            Thread.Sleep(1000); // Dellay to load web elements and animation
        }
        
        [Given(@"I stay on home page")]
        public void GivenIStayOnHomePage()
        {
            hrManagerPage.GoToHrHomePage();
        }

        [When(@"I press ""(.*)"" button in table column ""(.*)""")]
        public void WhenIPressButtonInTableColumn(string sortButton, string columnName)
        {
            Assert.IsTrue(hrManagerPage.IsSortButtonClicked(sortButton, columnName));
        }

        [Then(@"""(.*)"" information in table columns is sorted out in ""(.*)"" order ""(.*)""")]
        public void ThenInformationInTableColumnsIsSortedOutInOrder(string p0, string p1, string p2)
        {
            Assert.IsTrue(hrManagerPage.IsTableDataSorted());
        }


    }
}
