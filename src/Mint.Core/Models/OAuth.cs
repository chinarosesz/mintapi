using System.Runtime.Serialization;

namespace Mint.Core.Models
{
    [DataContract]
    public class OAuth
    {
        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }

        [DataMember(Name = "expires")]
        public int Expires { get; set; }
    }
}
