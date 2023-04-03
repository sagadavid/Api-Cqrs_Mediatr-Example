using CqrsMediatrExample.Commands;
using MediatR;

namespace CqrsMediatrExample.Handlers
{
    //public record AddProductHandler : IRequestHandler<AddProductCommand, Unit>
        public record AddProductHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly FakeDataStore _fakeDataStore;

        public AddProductHandler(FakeDataStore fakeDataStore) => 
            _fakeDataStore = fakeDataStore;
 
        public async Task<Product> Handle
            (AddProductCommand request, CancellationToken cancellationToken)
        {
            await _fakeDataStore.AddProduct(request.product);
            //return Unit.Value;
            return request.product;
        }
    }

}
