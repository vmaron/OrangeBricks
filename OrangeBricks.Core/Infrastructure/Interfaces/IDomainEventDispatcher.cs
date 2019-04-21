using OrangeBricks.Core.Infrastructure.SharedKernel;

namespace OrangeBricks.Core.Infrastructure.Interfaces
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(BaseDomainEvent domainEvent);
    }
}