using CqrsMediatrExample.Notifications;
using MediatR;

namespace CqrsMediatrExample.Handlers
{
    public class CashInValidatorHandler : INotificationHandler<ProductAddedNotification>
    {
        private readonly FakeDataStore _fakeDataStore;

        public CashInValidatorHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }

        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            await _fakeDataStore.EventOccured(notification.Product, "cash InValidated");
            await Task.CompletedTask;
        }
    }
}
