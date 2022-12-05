using System;
using System.Runtime.Serialization;

namespace Credit.Domain
{
    [DataContract]

    public class Credit
    {
        [DataMember]
        public int IdCredito { get; set; }
        [DataMember]
        public int TipoCredito { get; set; }
        [DataMember]
        public int IdCliente { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public Decimal Cantidad { get; set; }
        [DataMember]
        public DateTime DiaDePago { get; set; }
        [DataMember]
        public Decimal TasaInteres { get; set; }
        [DataMember]
        public Decimal Comision { get; set; }
    }
}
