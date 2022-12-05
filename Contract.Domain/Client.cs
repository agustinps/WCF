using System;
using System.Runtime.Serialization;

namespace Credit.Domain
{
    [DataContract]
    public class Client
    {
        [DataMember]
        public int IdClient { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Apel1 { get; set; }
        [DataMember]
        public string Apel2 { get; set; }
        [DataMember]
        public string DocumentType { get; set; }
        [DataMember]
        public string DocumentNumberNumeroDocumento { get; set; }
        [DataMember]
        public string Sex { get; set; }
        [DataMember]
        public DateTime BirthDate { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string CP { get; set; }
        [DataMember]
        public string Status { get; set; }
    }
}
