using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace ProfileV2Test.Services
{
    public class UserService
    {
        private IDictionary<string, string> _users;

        public UserService()
        {
           //add users from the test spreadsheet
            _users = JsonService.GetUserEmailsAndPasswords(
                JsonService.GetJObjectByAPI(
                    "AIzaSyD6MYQCVZdN93XIL--ekM0SPOyQeY6fkPU"
                    )
                );
        }

        /// <summary>
        /// Return an array with two values: email(username) at [0] and password at [1].
        /// </summary>
        /// <returns></returns>
        public string[] GetAdminCredentials() => new string[] { "admin@profile.com", "admin123" };

        /// <summary>
        /// Return an array with two values: email(username) at [0] and password at [1].
        /// </summary>
        /// <returns></returns>
        public string[] GetDefaultStudentCredentials() => new string[] { "student@profile.com", "student" };

        /// <summary>
        /// Return an array with two values: email(username) at [0] and password at [1].
        /// </summary>
        /// <returns></returns>
        public string[] GetDefaultTrainerCredentials() => new string[] { "trainer@profile.com", "trainer" };

        /// <summary>
        /// Return an array with two values: email(username) at [0] and password at [1].
        /// </summary>
        /// <returns></returns>
        public string[] GetUserByName(string firstName)
        {
            string[] user = new string[2];

            KeyValuePair<string, string> selectedUser = _users.FirstOrDefault(k => k.Key.Contains(firstName.ToLower()));

            user[0] = selectedUser.Key;
            user[1] = selectedUser.Value;

            return user;
        }
    }

    public static class JsonService
    {
        public static JObject GetJObjectByAPI (string apiKey)
        {
            //Define the web request params
            string apiUrl = "https://sheets.googleapis.com/v4/spreadsheets/";
            string spreadsheetId = "1BK50eogFUI8z1Vmy6gzXRsjTbcywNo8YRgpRKya3qWo";
            string sheetRange = "A2:Z";
            string requestUrl = apiUrl + spreadsheetId + "/values/" + sheetRange + "?key=" + apiKey;

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(requestUrl);
            using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
            {
                //read the response stream
                StreamReader streamReader = new StreamReader(webResponse.GetResponseStream());
                var jsonString = streamReader.ReadToEnd();

                //parse the response
                return JsonConvert.DeserializeObject(jsonString) as JObject;
            }
        }

        public static IDictionary<string, string> GetUserEmailsAndPasswords(JObject jObject)
        {
            IDictionary<string, string> dictionary = new Dictionary<string, string>();

            //get the table
            IEnumerable<JToken> tableRows = jObject.Children<JToken>().ElementAt(2).Children<JToken>().Values<JToken>();

            //fill the dictionary          
            string emailKey, passValue;
            foreach(JToken row in tableRows)
            {
                //add email
                emailKey = row.Children<JToken>().ElementAt(7).Value<string>();
                //add pass
                passValue = row.Children<JToken>().ElementAt(12).Value<string>();
                //add email and pass to the dictionary
                dictionary.Add(new KeyValuePair<string, string>(emailKey, passValue));
            }

            return dictionary;
        }
    }
}
