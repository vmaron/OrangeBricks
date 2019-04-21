using System.ComponentModel.DataAnnotations;

namespace OrangeBricks.Core.Infrastructure.SharedKernel
{
    // This can be modified to BaseEntity<TId> to support multiple key types (e.g. Guid)
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}