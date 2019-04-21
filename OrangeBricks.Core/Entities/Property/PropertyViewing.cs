using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OrangeBricks.Core.Infrastructure.SharedKernel;

namespace OrangeBricks.Core.Entities.Property
{
    public class PropertyViewing : BaseEntity
    {
        [Required] [MaxLength(36)] [Index] public string BuyerUserId { get; set; }

        [Required] [MaxLength(64)] public string BuyerName { get; set; }

        [Required] [MaxLength(16)] public string BuyerPhone { get; set; }

        [Required] [MaxLength(64)] public string BuyerEmail { get; set; }

        public string BuyerMessage { get; set; }

        public string SellerNotes { get; set; }

        public PropertyViewingStatus Status { get; set; }

        public DateTime? AppointmentDate { get; set; }

        [Required] public DateTime CreatedAt { get; set; }

        [Required] public DateTime UpdatedAt { get; set; }

        public int? PropertyId { get; set; }

        [ForeignKey("PropertyId")] public virtual Property Property { get; set; }
    }
}