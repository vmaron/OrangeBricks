using OrangeBricks.Core.Infrastructure.SharedKernel;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class FindPropertyCommand : BaseDomainEvent
    {
        public string Search { get; set; }
    }
}