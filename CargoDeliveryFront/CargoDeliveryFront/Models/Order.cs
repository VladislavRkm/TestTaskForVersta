namespace CargoDeliveryFront.Models;

public class Order
{
    public Guid Id { get; set; }
    public string OrderNumber { get; set; } = string.Empty;

    public string SenderCity { get; set; } = string.Empty;

    public string SenderAddress { get; set; } = string.Empty;

    public string RecipientCity { get; set; } = string.Empty;

    public string RecipientAddress { get; set; } = string.Empty;

    public float Weight { get; set; }

    public DateTime PickUpDate { get; set; }
}
