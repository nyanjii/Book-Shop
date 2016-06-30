using System.Collections.Generic;
using System.ServiceModel;

namespace BookShop.Contracts
{
    [ServiceContract]
    public interface IBookService
    {
        [OperationContract]
        void Add(BookData item);

        [OperationContract]
        void Update(BookData item);

        [OperationContract]
        void Delete(BookData item);

        [OperationContract]
        IEnumerable<BookData> GetAll();

        [OperationContract]
        BookData GetItem(int id);

    }
}
