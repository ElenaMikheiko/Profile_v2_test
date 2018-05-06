using OpenQA.Selenium;
using System.Collections.Generic;

namespace ProfileV2Test.Tests.Shared
{
    public static class CommonVariables
    {
        public static IList<string> commonCompairingList = new List<string>();
        public static IList<string> skillsList = new List<string>();

        public static IDictionary<string, string> languagesData = new Dictionary<string, string>();

        public static string additionalInfo = "";
        public static string summaryText = "";
        public static string sentKeys = "";

        public static IWebElement selectedInput = null;
    }
}
