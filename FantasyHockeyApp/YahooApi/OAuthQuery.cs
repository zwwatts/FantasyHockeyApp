using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using RestSharp;
using RestSharp.Extensions.MonoHttp;

namespace YahooApi
{
    public class OAuthQuery
    {
        //Copy the keys and whatnot and paste them here
        

        public OAuthQuery()
        {

        }

        public void Execute()
        {
            //var client = new RestClient("https://api.login.yahoo.com");
            //var client = new RestClient("http://fantasysports.yahooapis.com");

            //var leagueKey = "363.l.22381";
            //var oauthToken2 = "A%3Dkpc1ngn.5iE2Q3EFM2YsKYRF1PVwdq6VfM9IFt3QrXlLkQnxGV3W2LFttXr5VVSdHzoIHpncU0t9asufaTbvTj2OfQgYkoH97iqFpI85unbj8rGBqnwWJOd3HKGWiNIPtInMLd46v1dcT77cuypqfXrqV4zZSYoXwsrbC_pgbjIpAQfv7NYdHTI5X7jIYUDSPIN538JGQdiknRCJRpy.0LKMg0Dk_aJ.yZI9buqQVwxxmF8ON1C3rjsxbcnRpo1XyPmhrJupZLxW31r65nCNexvmkJPZNcjzSFyYrlmmSO7XJZh4YnPf5f.Zi6sb1ZrKbiNDpz5DrNH6Fmf3sgCSpbhR7WLoxo6mwvizVfnZPtR2JEFN9Oout_lFzgy1vJe0jJBrADeRp0wbxg927mReO147iFfGG0wApylm1LMDMeoFTF9G2ADFRn1NT2TafXswcm8G.MEnvnlUwLpdCC7ME2ZRz0qH9MSaNJlfwdW8WRTDSOZuQA7UaM4HtslwEB2r0ojtVebfDHyReo.e7IDHC9_11RXNgV7zEeHCjQoNx4xt8XSxQyjQzoAVZHJpc5raLZlWjnIvdIXSmHa6cdF0hyXPKih_VzJZx660tGNgGXJjJWE.ITKNoBJ7YSM7ZXAzAHDBEy2BeWpgKatoqMQUrX1iqmUihge5tJHtNL5VUZogw1dJPHRQ3vbHqPvalOzcd_kFY_svRqjkBmNYaDi8dbs2pLWpjV_qY0mYNT_KhbKAGsSOFtGpgcXAYQG6d4VXE9MMBV8FEPDJeHukMdQF2oXJwUdjIdw4nm3s1B8WnOuLWmMDqkQ-";
            //var oauthSecret2 = "deb5c03a3644cd71478ff6be62ce27a0eb3008d8";
            //var sessionHandle = "AFLzd1hRZ3Qhe1tiJExg7DG4Ypbb.dtZ22BmDLybfpPzOyXiuQE-";
            //var uri = $"oauth/v2/get_request_token?oauth_nonce={RandomString(10)}&oauth_timestamp={ConvertToUnixTimestamp(DateTime.Now)}&oauth_consumer_key={key}&oauth_signature_method=plaintext&oauth_signature={secret}%26&oauth_version=1.0&oauth_callback=oob";
            //var uri2 = $"oauth/v2/request_auth?oauth_token={oauthToken}";
            //var uri3 = $"oauth/v2/get_token?oauth_consumer_key={key}&oauth_signature_method=plaintext&oauth_version=1.0&oauth_verifier={oauthVerifier}&oauth_token={oauthToken}&oauth_timestamp={ConvertToUnixTimestamp(DateTime.Now)}&oauth_nonce={RandomString(10)}&oauth_signature={secret}%26{oauthSecret}";
            //var uri4 = $"fantasy/v2/league/{leagueKey}?realm=yahooapis.com&oauth_consumer_key={key}&oauth_nonce={RandomString(10)}&oauth_signature_method=HMAC-SHA1&oauth_timestamp={ConvertToUnixTimestamp(DateTime.Now)}&oauth_token={oauthToken2}&oauth_version=1.0&oauth_signature={siggy}";
            //var uri5 = $"oauth/v2/get_token?oauth_consumer_key={key}&oauth_signature_method=plaintext&oauth_version=1.0&oauth_token={oauthToken2}&oauth_timestamp={ConvertToUnixTimestamp(DateTime.Now)}&oauth_nonce={RandomString(10)}&oauth_signature={secret}%26{oauthSecret2}&oauth_session_handle={sessionHandle}";
            //var request = new RestRequest(uri5);
            //var response = client.Execute(request);
            //return response.Content;
            //return uri5;

            //var urlQuery = "http://fantasysports.yahooapis.com/fantasy/v2/league/363.l.22381";
            //var test = $"http://fantasysports.yahooapis.com/fantasy/v2/league/363.l.22381oauth_consumer_key={key}&oauth_nonce={RandomString(10)}&oauth_signature_method=HMAC-SHA1&oauth_timestamp={ConvertToUnixTimestamp(DateTime.Now)}&oauth_token={oauthToken2}&oauth_version=1.0";
            //var test2 = test.Replace("&", "%26").Replace(@"/", "%2F").Replace(":", "%3A").Replace("=", "%3D");
            //var test3 = "GET&http%3A%2F%2Ffantasysports.yahooapis.com%2Ffantasy%2Fv2%2Fleague%2F363.l.22381&oauth_consumer_key%3Ddj0yJmk9UllsVmE4SU85MjU5JmQ9WVdrOVJWWlljR2xWTldFbWNHbzlNQS0tJnM9Y29uc3VtZXJzZWNyZXQmeD05Nw--%26oauth_nonce%3D7658563%26oauth_signature_method%3Dhmac-sha1%26oauth_timestamp%3D1484429774%26oauth_token%3DA%253DHk5MFwv44FgQR1gwXdZllvxltQEUWRMqBcwPZmNQKG.rkP3NdstT0lKgG83H9iJSwfNHQ2bM4Dmr9jCWRLTADzBzi130o54SS11cQwt6i53xekp11zC1vSwExOGFDGBKm76t6G_Y7wu_VpAKYHlztCkABWYnX8YIOiYWr8_9XRs4Xi2IO.7nTutM_zvrD9z4IURZDM05lfQHzzhXVRU80t06OjD.GzNYXoe0gS2a1XlDZ8NjW756MzzWXc2dXIBeT09WocFEQnzJpcTnbCvFpKYpy6nHwU3QUwmiEiLA8f.LPHgMilmgvqEzJ.PvMyEbR7I76HX0i2ozXFCSkq3S3OVxZd_1L16R77cEh.173daRwdZ7m8MJHZwSDCPgwcbr4ASLbCXimENsR3m2Jeazl962XEeeG93iSmWKzkt1NEpOly5yLoDRs6TZ4_ceKsDt_ApSaFj4Qo2QF._Ex2JYHYsXPB3Vt4V9ERGrYVD6dZDGCGaYGv7K0zdXyz1StfVX5dWruCDDfSbBPVqgq_pFhI0tH_XSVlCmkytSzGWczq5kaGvJK9OhwOX6VT7iKNcQk0GUzUjnXaRYuoi.2HSK38K_OTugMUHQzMDiwVn15ovgo4NSdsHWEvVjGbplpoB6D0TtaSbnybkgE9YtpzshJipUJIQtgS4.LXvwTPhdqe8Tz71JzGch80CaJ7pLPfNXVy5HsGuaNhrTa8hKejD89fe2eAY9YYZDeTdY4Y.9bTJm6wI3zXjaLWm8cwdNkMdp2TfP0sAakxv4SNgoYbWt7QPH22VEcGFci4Me0tBXkG.qXGVo6sYb%26oauth_version%3D1.0";
            //OAuthBase o = new OAuthBase();
            //var request = new RestRequest("fantasy/v2/league/363.l.22381");
            //var time = o.GenerateTimeStamp();
            //var nonce = o.GenerateNonce();
            //string normalizedUrl = "";
            //string normalizedRequestParameters = "";
            //var sigBase =  o.GenerateSignatureBase(new Uri(urlQuery), key, oauthToken2, oauthSecret2, "GET", time, nonce, "HMAC-SHA1", out normalizedUrl, out normalizedRequestParameters);
            //Debug.WriteLine(sigBase);
            //Debug.WriteLine(normalizedUrl + normalizedRequestParameters);
            //var siggy = o.GenerateSignatureUsingHash(sigBase, new HMACSHA1());
            //Debug.WriteLine(siggy);
            //siggy = siggy.Replace("&", "%26").Replace(@"/", "%2F").Replace(":", "%3A").Replace("=", "%3D");
            //Debug.WriteLine(siggy);
            //request.AddHeader("Authorization", $"OAuth realm=\"yahooapis.com\",oauth_consumer_key=\"{key}\",oauth_nonce=\"{nonce}\",oauth_signature_method=\"HMAC-SHA1\",oauth_timestamp=\"{time}\",oauth_token=\"{oauthToken2}\",oauth_version=\"1.0\",oauth_signature=\"{siggy}\"");
            //var response = client.Execute(request);

            //return response.Content;
            //return (normalizedUrl + "" +normalizedRequestParameters);
        }

        public Dictionary<string, string> RefreshToken()
        {
            var client = new RestClient("https://api.login.yahoo.com");
            var uri = $"oauth/v2/get_token?oauth_consumer_key={key}&oauth_signature_method=plaintext&oauth_version=1.0&oauth_token={token}&oauth_timestamp={ConvertToUnixTimestamp(DateTime.Now)}&oauth_nonce={RandomString(10)}&oauth_signature={secret}%26{tokenSecret}&oauth_session_handle={sessionHandle}";
            var request = new RestRequest(uri);
            var response = client.Execute(request);
            var newToken = Regex.Match(response.Content, @"oauth_token=(.+?)&oauth_token_secret").Groups[1].Value;
            var newSecret = Regex.Match(response.Content, @"oauth_token_secret=(.+?)&oauth_expires").Groups[1].Value;

            token = newToken;
            tokenSecret = newSecret;

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
                                    key,
                                    secret, token, tokenSecret, "GET",
                                    timestamp, nonce, out normalizedUrl,
                                    out normalizedParameters));

            uri = new Uri(normalizedUrl + "?" + normalizedParameters.Replace("oauth_token=A%253D", "oauth_token=A%3D") + "&oauth_signature=" + signature);

            using (var httpClient = new WebClient())
            {
                result = httpClient.DownloadString(uri.AbsoluteUri);
            }

            return result;
        }

        public static double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - origin;
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
