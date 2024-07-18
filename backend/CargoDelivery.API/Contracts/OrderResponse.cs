namespace CargoDelivery.API.Contracts;

public record OrderResponse(
    Guid id, 
    string OrderNumber,
    string SenderCity, 
    string SenderAddress, 
    string RecipientCity, 
    string RecipientAddress, 
    float Weight, 
    DateTime PickUpDate
    );

