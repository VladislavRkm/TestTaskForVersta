namespace CargoDelivery.API.Contracts;
public record OrderRequest 
    (
    string SenderCity,
    string SenderAddress,
    string RecipientCity,
    string RecipientAddress,
    float Weight,
    DateTime PickUpDate
    );

