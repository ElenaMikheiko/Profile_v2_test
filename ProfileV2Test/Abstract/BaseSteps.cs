using OpenQA.Selenium;
using ProfileV2Test.Page;
using ProfileV2Test.Page.ResumePages;

namespace ProfileV2Test.Abstract
{
    public abstract class BaseSteps
    {
        protected static IWebDriver chromeDriver;
        protected LandingPage landingPage;
        protected HomePage homePage;
        protected ResumePage resumePage;
        protected TrainerPage trainerPage;
        protected HrManagerPage hrManagerPage;
        protected _01_PersonalInformation_PartialResumePage personalInformationPage;
        protected _12AdditionalInformationPage additionalInfoPage;
        protected _02_Objective_PartialResumePage objectivePage;
        protected _03_Summary_PartialResumePage summaryPage;
        protected _04_Skills_PartialResumePage skillsPage;
        protected _05_ForeignLanguages_PartialResumePage languagesPage;
        protected _06_Education_PartialResumePage educationPage;
        protected _09_WorkExperience_PartialResumePage workExperiencePage;
        protected ResumeCompletedPage resumeCompletedPage;
        protected ResumeEditPage resumeEditPage;

        protected BaseSteps()
        {
            landingPage = new LandingPage(chromeDriver);
            homePage = new HomePage(chromeDriver);
            resumePage = new ResumePage(chromeDriver);
            trainerPage = new TrainerPage(chromeDriver);
            hrManagerPage = new HrManagerPage(chromeDriver);
            personalInformationPage = new _01_PersonalInformation_PartialResumePage(chromeDriver);
            additionalInfoPage = new _12AdditionalInformationPage(chromeDriver);
            objectivePage = new _02_Objective_PartialResumePage(chromeDriver);
            summaryPage = new _03_Summary_PartialResumePage(chromeDriver);
            skillsPage = new _04_Skills_PartialResumePage(chromeDriver);
            languagesPage = new _05_ForeignLanguages_PartialResumePage(chromeDriver);
            educationPage = new _06_Education_PartialResumePage(chromeDriver);
            workExperiencePage = new _09_WorkExperience_PartialResumePage(chromeDriver);
            resumeCompletedPage = new ResumeCompletedPage(chromeDriver);
            resumeEditPage = new ResumeEditPage(chromeDriver);
        }
    }
}
