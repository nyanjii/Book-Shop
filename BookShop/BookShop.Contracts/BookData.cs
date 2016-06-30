using System.Runtime.Serialization;

namespace BookShop.Contracts
{
    [DataContract]
    public class BookData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Author { get; set; }

        [DataMember]
        public decimal Cost { get; set; }

    }
}
