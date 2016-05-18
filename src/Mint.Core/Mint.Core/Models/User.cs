using System.Runtime.Serialization;

namespace Mint.Core.Models
{
    [DataContract]
    public class User
    {
        [DataMember(Name ="CSRFToken")]
        public string CsrfToken { get; set; }
    }
}
