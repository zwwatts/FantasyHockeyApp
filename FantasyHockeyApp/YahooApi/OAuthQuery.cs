using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using RestSharp;

namespace YahooApi
{
    public class OAuthQuery
    {
        //Copy the keys and whatnot and paste them here
        private readonly string _key = ConfigurationManager.AppSettings["consumer_key"];
        private readonly string _secret = ConfigurationManager.AppSettings["consumer_secret"];
        private string _token = ConfigurationManager.AppSettings["oauth_token"];
        private string _tokenSecret = ConfigurationManager.AppSettings["oauth_secret"];
        private readonly string _sessionHandle = ConfigurationManager.AppSettings["session_handle"];

        public Dictionary<string, string> RefreshToken()
        {
            var client = new RestClient("https://api.login.yahoo.com");
            var uri = $"oauth/v2/get_token?oauth_consumer_key={_key}&oauth_signature_method=plaintext&oauth_version=1.0&oauth_token={_token}&oauth_timestamp={ConvertToUnixTimestamp(DateTime.Now)}&oauth_nonce={RandomString(10)}&oauth_signature={_secret}%26{_tokenSecret}&oauth_session_handle={_sessionHandle}";
            var request = new RestRequest(uri);
            var response = client.Execute(request);
            var newToken = Regex.Match(response.Content, @"oauth_token=(.+?)&oauth_token_secret").Groups[1].Value;
            var newSecret = Regex.Match(response.Content, @"oauth_token_secret=(.+?)&oauth_expires").Groups[1].Value;

            _token = newToken;
            _tokenSecret = newSecret;

            var dictionary = new Dictionary<string, string>();
            dictionary.Add("Token", newToken);
            dictionary.Add("TokenSecret", newSecret);

            return dictionary;
        }

        public string QueryWithOAuth(string queryUrl)
        {
            RefreshToken();
            string result;

            var uri = new Uri(queryUrl);
            var o = new OAuthBase();
            string nonce = o.GenerateNonce();
            var timestamp = o.GenerateTimeStamp();

            string normalizedUrl;
            string normalizedParameters;
            string signature = System.Web.HttpUtility.UrlEncode(
                o.GenerateSignature(uri,
                                    _key,
                                    _secret, _token, _tokenSecret, "GET",
                                    timestamp, nonce, out normalizedUrl,
                                    out normalizedParameters));

            uri = new Uri(normalizedUrl + "?" + normalizedParameters.Replace("oauth_token=A%253D", "oauth_token=A%3D") + "&oauth_signature=" + signature);

            using (var httpClient = new WebClient())
            {
                try
                {
                    result = httpClient.DownloadString(uri.AbsoluteUri);
                }
                catch (Exception e)
                {
                    // Likely no internet connection
                    Debug.WriteLine(e.Message);
                    return null;
                }
            }

            return result;
        }

        public static double ConvertToUnixTimestamp(DateTime date)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }

        public static string RandomString(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
