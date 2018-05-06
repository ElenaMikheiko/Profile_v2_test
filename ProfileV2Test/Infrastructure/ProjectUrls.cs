namespace ProfileV2Test.Infrastructure
{
    public static class ProjectUrls
    {
        //chromedriver path
        public const string chromedriverPath = @"C:\";

        public const string projectUrl = @"http://178.124.206.53:81/";
        //public const string projectUrl = @"http://localhost:64025/";

        public const string homePageUrl = projectUrl;
        public const string landingPageUrl = projectUrl + @"Account/Login";
        public const string resumePageUrl = projectUrl + @"Resume";
        public const string trainerPageUrl = projectUrl + @"Trainer";
        public const string hrManagerPageUrl = projectUrl + @"HrManager";
        public const string resumeCompletedPageUrl = projectUrl + @"ResumeReview";
        public const string resumeEditPageUrl = projectUrl + @"EditResume/EditResume";

        //service links
        public const string createTestAccountsUrl = projectUrl + @"Admin/CreateTestAccounts";
        public const string deleteTestAccountsUrl = projectUrl + @"Admin/DeleteTestAccount";
    }
}
