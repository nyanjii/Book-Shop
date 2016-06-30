using System.Collections.Generic;
using System.ServiceModel;

namespace BookShop.Contracts
{
    [ServiceContract]
    public interface IGenreService
    {
        [OperationContract]
        void Add(GenreData item);

        [OperationContract]
        void Delete(GenreData item);

        [OperationContract]
        IEnumerable<GenreData> GetAll();

        [OperationContract]
        GenreData GetItem(int id);

        [OperationContract]
        List<BookData> GetBooksOfGenre(int id);
    }
}
