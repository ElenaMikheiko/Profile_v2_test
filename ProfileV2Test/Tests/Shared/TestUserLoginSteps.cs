using ProfileV2Test.Abstract;
using ProfileV2Test.Services;
using TechTalk.SpecFlow;

namespace ProfileV2Test.Tests.Shared
{
    [Binding]
    public class TestUserLoginSteps : BaseSteps
    {
        private UserService _userService;
        private string[] creds = new string[2];

        public TestUserLoginSteps() : base()
        {
            _userService = new UserService();
        }

        /// <summary>
        /// Picks the corresponding login method for user.
        /// </summary>
        /// <param name="userFullName"></param>
        public void Switcher(string userFullName)
        {
            switch (userFullName)
            {
                case "Ivan Smith":
                    GivenILogInAsIvanSmith();
                    break;
                case "Pavel Jones":
                    GivenILogInAsPavelJones();
                    break;
                case "Nikola Brown":
                    GivenILogInAsNikolaBrown();
                    break;
                case "Vlad Davies":
                    GivenILogInAsVladDavies();
                    break;
                case "Victor Willians":
                    GivenILogInAsVictorWillians();
                    break;
                case "Sveta Evans":
                    GivenILogInAsSvetaEvans();
                    break;
                case "Nadejda Moore":
                    GivenILogInAsNadejdaMoore();
                    break;
                case "Lena Taylor":
                    GivenILogInAsLenaTaylor();
                    break;
                case "Emily Tomas":
                    GivenILogInAsEmilyTomas();
                    break;
                case "Sophie Miler":
                    GivenILogInAsSophieMiler();
                    break;
                case "Ruby Javovich":
                    GivenILogInAsRubyJavovich();
                    break;
                case "Oliver Wilson":
                    GivenILogInAsOliverWilson();
                    break;
                case "Jack Daniel's":
                    GivenILogInAsJackDaniels();
                    break;
                case "Brea Breens":
                    GivenILogInAsBreaBreens();
                    break;
                case "Submit1 Test":
                    GivenILogInAsSubmit1Test();
                    break;
                case "Submit2 Test":
                    GivenILogInAsSubmit2Test();
                    break;
                case "Personal1 Test":
                    GivenILogInAsPersonal1Test();
                    break;
                case "Objective1 Test":
                    GivenILogInAsObjective1Test();
                    break;
                case "Summary1 Test":
                    GivenILogInAsSummary1Test();
                    break;
                case "Lang1 Test":
                    GivenILogInAsLang1Test();
                    break;
                case "Additional1 Test":
                    GivenILogInAsAdditional1Test();
                    break;
                default:
                    break;
            }
        }

        [Given(@"I log in as Kostia Shtine")]
        public void GivenILogInAsKostiaShtine()
        {
            //get the creds
            creds = _userService.GetUserByName("Kostia");

            //authenticate
            landingPage.Authenticate(creds[0], creds[1]);
        }

        [Given(@"I log in as Ivan Smith")]
        public void GivenILogInAsIvanSmith()
        {
            //get the creds
            creds = _userService.GetUserByName("Ivan");

            //authenticate
            landingPage.Authenticate(creds[0], creds[1]);
        }

        [Given(@"I log in as Pavel Jones")]
        public void GivenILogInAsPavelJones()
        {
            //get the creds
            creds = _userService.GetUserByName("Pavel");

            //authenticate
            landingPage.Authenticate(creds[0], creds[1]);
        }

        [Given(@"I log in as Nikola Brown")]
        public void GivenILogInAsNikolaBrown()
        {
            //get the creds
            creds = _userService.GetUserByName("Nikola");

            //authenticate
            landingPage.Authenticate(creds[0], creds[1]);
        }

        [Given(@"I log in as Vlad Davies")]
        public void GivenILogInAsVladDavies()
        {
            //get the creds
            creds = _userService.GetUserByName("Vlad");

            //authenticate
            landingPage.Authenticate(creds[0], creds[1]);
        }

        [Given(@"I log in as Victor Willians")]
        public void GivenILogInAsVictorWillians()
        {
            //get the creds
            creds = _userService.GetUserByName("Victor");

            //authenticate
            landingPage.Authenticate(creds[0], creds[1]);
        }

        [Given(@"I log in as Sveta Evans")]
        public void GivenILogInAsSvetaEvans()
        {
            //get the creds
            creds = _userService.GetUserByName("Sveta");

            //authenticate
            landingPage.Authenticate(creds[0], creds[1]);
        }

        [Given(@"I log in as Nadejda Moore")]
        public void GivenILogInAsNadejdaMoore()
        {
            //get the creds
            creds = _userService.GetUserByName("Nadejda");

            //authenticate
            landingPage.Authenticate(creds[0], creds[1]);
        }

        [Given(@"I log in as Lena Taylor")]
        public void GivenILogInAsLenaTaylor()
        {
            //get the creds
            creds = _userService.GetUserByName("Lena");

            //authenticate
            landingPage.Authenticate(creds[0], creds[1]);
        }

        [Given(@"I log in as Emily Tomas")]
        public void GivenILogInAsEmilyTomas()
        {
            //get the creds
            creds = _userService.GetUserByName("Emily");

            //authenticate
            landingPage.Authenticate(creds[0], creds[1]);
        }

        [Given(@"I log in as Sophie Miler")]
        public void GivenILogInAsSophieMiler()
        {
            //get the creds
            creds = _userService.GetUserByName("Sophie");

            //authenticate
            landingPage.Authenticate(creds[0], creds[1]);
        }

        [Given(@"I log in as Ruby Javovich")]
        public void GivenILogInAsRubyJavovich()
        {
            //get the creds
            creds = _userService.GetUserByName("Ruby");

            //authenticate
            landingPage.Authenticate(creds[0], creds[1]);
        }

        [Given(@"I log in as Oliver Wilson")]
        public void GivenILogInAsOliverWilson()
        {
            //get the creds
            creds = _userService.GetUserByName("Oliver");

            //authenticate
            landingPage.Authenticate(creds[0], creds[1]);
        }

        [Given(@"I log in as Jack Daniel's")]
        public void GivenILogInAsJackDaniels()
        {
            //get the creds
            creds = _userService.GetUserByName("Jack");

            //authenticate
            landingPage.Authenticate(creds[0], creds[1]);
        }

        [Given(@"I log in as Brea Breens")]
        public void GivenILogInAsBreaBreens()
        {
            //get the creds
            creds = _userService.GetUserByName("Brea");

            //authenticate
            landingPage.Authenticate(creds[0], creds[1]);
        }

        [Given(@"I log in as Submit1 Test")]
        public void GivenILogInAsSubmit1Test()
        {
            //get the creds
            creds = _userService.GetUserByName("Submit1");

            //authenticate
            landingPage.Authenticate(creds[0], creds[1]);
        }

        [Given(@"I log in as Submit2 Test")]
        public void GivenILogInAsSubmit2Test()
        {
            //get the creds
            creds = _userService.GetUserByName("Submit2");

            //authenticate
            landingPage.Authenticate(creds[0], creds[1]);
        }

        [Given(@"I log in as Personal1 Test")]
        public void GivenILogInAsPersonal1Test()
        {
            //get the creds
            creds = _userService.GetUserByName("Personal1");

            //authenticate
            landingPage.Authenticate(creds[0], creds[1]);
        }

        [Given(@"I log in as Objective1 Test")]
        public void GivenILogInAsObjective1Test()
        {
            //get the creds
            creds = _userService.GetUserByName("Objective1");

            //authenticate
            landingPage.Authenticate(creds[0], creds[1]);
        }

        [Given(@"I log in as Summary1 Test")]
        public void GivenILogInAsSummary1Test()
        {
            //get the creds
            creds = _userService.GetUserByName("Summary1");

            //authenticate
            landingPage.Authenticate(creds[0], creds[1]);
        }

        [Given(@"I log in as Additional1 Test")]
        public void GivenILogInAsAdditional1Test()
        {
            //get the creds
            creds = _userService.GetUserByName("Additional1");

            //authenticate
            landingPage.Authenticate(creds[0], creds[1]);
        }

        [Given(@"I log in as Lang1 Test")]
        public void GivenILogInAsLang1Test()
        {
            //get the creds
            creds = _userService.GetUserByName("Lang1");

            //authenticate
            landingPage.Authenticate(creds[0], creds[1]);
        }

        



    }
}
