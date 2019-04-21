using OrangeBricks.Core.Infrastructure.SharedKernel;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class ListPropertyCommand : BaseDomainEvent
    {
        public int PropertyId { get; set; }
    }
}