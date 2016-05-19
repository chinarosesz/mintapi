using Mint.Core.Models;
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
                return user.CsrfToken;
            }
        }

        //public void SampleRequestResponse()
        //{
        //    HttpClient mintClient = new HttpClient();
        //    string username = "chinarosesz@gmail.com";
        //    string password = "Pa$$word123456";

        //    // Login
        //    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://wwws.mint.com/login.event?task=L");
        //    request.Headers.Add("Accept", "*/*");
        //    HttpResponseMessage response = mintClient.SendAsync(request).Result;
        //    string result = response.Content.ReadAsStringAsync().Result;

        //    request = new HttpRequestMessage(HttpMethod.Post, "https://wwws.mint.com/getUserPod.xevent");
        //    request.Headers.Add("Accept", "*/*");
        //    request.Content = new StringContent($"username={username}");
        //    request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
        //    response = mintClient.SendAsync(request).Result;
        //    result = response.Content.ReadAsStringAsync().Result;

        //    request = new HttpRequestMessage(HttpMethod.Post, "https://wwws.mint.com/loginUserSubmit.xevent");
        //    request.Headers.Add("Accept", "application/json");
        //    request.Content = new StringContent($"username={username}&password={password}&task=L");
        //    request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
        //    response = mintClient.SendAsync(request).Result;
        //    result = response.Content.ReadAsStringAsync().Result;
        //    Rootobject rootObject = new JavaScriptSerializer().Deserialize<Rootobject>(result);
        //    Console.WriteLine(rootObject.CSRFToken);

        //    // Get bearer token
        //    request = new HttpRequestMessage(HttpMethod.Get, $"https://wwws.mint.com/oauth2.xevent?token={rootObject.CSRFToken}");
        //    request.Headers.Add("Accept", "*/*");
        //    response = mintClient.SendAsync(request).Result;
        //    result = response.Content.ReadAsStringAsync().Result;
        //    OAuth auth = new JavaScriptSerializer().Deserialize<OAuth>(result);
        //    Console.WriteLine(auth.access_token);

        //    // Get accounts
        //    request = new HttpRequestMessage(HttpMethod.Get, "https://mint.finance.intuit.com/v1/accounts?limit=1000");
        //    request.Headers.Add("Accept", "application/json");
        //    request.Headers.Add("Authorization", $"Bearer {auth.access_token}");
        //    response = mintClient.SendAsync(request).Result;
        //    result = response.Content.ReadAsStringAsync().Result;
        //    Console.WriteLine(result);
        //}
    }
}
