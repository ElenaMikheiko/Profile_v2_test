using System;
using TechTalk.SpecFlow;

namespace ProfileV2Test.Tests._5
{
    [Binding]
    public class FillInBlockObjectiveSteps
    {
        [Given(@"I have filled block ""(.*)""")]
        public void GivenIHaveFilledBlock(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I go to next page ""(.*)""")]
        public void GivenIGoToNextPage(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
