using OrangeBricks.Core.Infrastructure.SharedKernel;

namespace OrangeBricks.Core.Infrastructure.Interfaces
{
    public interface IHandle<T> where T : BaseDomainEvent
    {
        void Handle(T domainEvent);
    }
}