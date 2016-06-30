using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BookShop.Contracts
{
    [DataContract]
    public class GenreData
    {
        [DataMember]
        public int Id { get; set; } 

        [DataMember]
        public string GenreName { get; set; }

    }
}
