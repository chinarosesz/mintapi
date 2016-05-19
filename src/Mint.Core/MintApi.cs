using Mint.Core.Models;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Mint.Core
{
    public class MintApi
    {
        private string token;

        public MintApi(string username, string password)
        {
            this.token = this.Login(username, password);
        }

        private string Login(string username, string password)
        {
            using (HttpClient mintClient = new HttpClient())
            {
                // Login
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://wwws.mint.com/login.event?task=L");
                request.Headers.Add("Accept", "*/*");
                HttpResponseMessage response = mintClient.SendAsync(request).Result;
                string result = response.Content.ReadAsStringAsync().Result;

                request = new HttpRequestMessage(HttpMethod.Post, "https://wwws.mint.com/getUserPod.xevent");
                request.Headers.Add("Accept", "*/*");
                request.Content = new StringContent($"username={username}");
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                response = mintClient.SendAsync(request).Result;
                result = response.Content.ReadAsStringAsync().Result;

                request = new HttpRequestMessage(HttpMethod.Post, "https://wwws.mint.com/loginUserSubmit.xevent");
                request.Headers.Add("Accept", "application/json");
                request.Content = new StringContent($"username={username}&password={password}&task=L");
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                response = mintClient.SendAsync(request).Result;
                result = response.Content.ReadAsStringAsync().Result;
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(User));
                MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(result));
                User user = serializer.ReadObject(ms) as User;

                request = new HttpRequestMessage(HttpMethod.Get, $"https://wwws.mint.com/oauth2.xevent?token={user.CsrfToken}");
                request.Headers.Add("Accept", "*/*");
                response = mintClient.SendAsync(request).Result;
                result = response.Content.ReadAsStringAsync().Result;
                serializer = new DataContractJsonSerializer(typeof(OAuth));
                ms = new MemoryStream(Encoding.Unicode.GetBytes(result));
                OAuth auth = serializer.ReadObject(ms) as OAuth;

                return auth.AccessToken;
            }
        }

        public void GetAccountsSummary()
        {
            using (HttpClient mintClient = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://mint.finance.intuit.com/v1/accounts?limit=1000");
                request.Headers.Add("Accept", "application/json");
                request.Headers.Add("Authorization", $"Bearer {this.token}");
                HttpResponseMessage response = mintClient.SendAsync(request).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
            }
        }
    }
}
