using System.ComponentModel.DataAnnotations;

namespace Backend.DTO
{
    public class CreatedOrder
    {
        [Required]
        public string SenderСity { get; set; }
        [Required]
        public string SenderAddres { get; set; }
        [Required]
        public string RecipientCity { get; set; }
        [Required]
        public string RecipientAddres { get; set; }
        [Required]
        public float WeightCargo { get; set; }
        [Required]
        public DateTime PickupDate { get; set; }
    }
}
