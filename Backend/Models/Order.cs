namespace Backend.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string SenderСity { get; set; }
        public string SenderAddres { get; set; }
        public string RecipientCity { get; set; }
        public string RecipientAddres { get; set; }
        public float WeightCargo { get; set; }
        public DateTime PickupDate { get; set; }
        
    }
}
