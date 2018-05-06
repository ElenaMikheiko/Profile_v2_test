using OpenQA.Selenium.Chrome;
using ProfileV2Test.Abstract;
using ProfileV2Test.Infrastructure;
using TechTalk.SpecFlow;

namespace ProfileV2Test.Initializers
{
    [Binding]
    public class ScenarioInitializer : BaseSteps
    {
        [BeforeScenario]
        public static void OnScenarioBegin()
        {
            chromeDriver = new ChromeDriver(ProjectUrls.chromedriverPath);
        }

        [AfterScenario]
        public static void OnScenarioFinish()
        {
            chromeDriver.Quit();
        }
    }
}
