using System.Runtime.Serialization;

namespace Domain.Credit.Domain
{
    [DataContract]
    public class Error
    {
        [DataMember]
        public string ErrorCode { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
