using MediatR;
using CqrsMediatrExample.Queries;

namespace CqrsMediatrExample.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly FakeDataStore _fakeDataStore;

        public GetProductsHandler(FakeDataStore fakeDataStore) => 
            _fakeDataStore = fakeDataStore;
       

        public Task<IEnumerable<Product>> Handle
            (GetProductsQuery request, CancellationToken cancellationToken)=>  
                    _fakeDataStore.GetAllProducts();
    }
}
