using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace CargoDelivery.Core.Models;

public class Order
{
    
    public const int MAX_GEO_LENGTH = 250;
    public Order(Guid id, string senderCity, string senderAddress, string recipientCity, string recipientAddress, float weight, DateTime pickUpDate)
    {
        Id = id;
        OrderNumber = GenerateOrderNumber();
        SenderCity = senderCity;
        SenderAddress = senderAddress;
        RecipientCity = recipientCity;
        RecipientAddress = recipientAddress;
        Weight = weight;
        PickUpDate = pickUpDate;
    }

    public Guid Id { get; }
    public string OrderNumber { get; } = string.Empty;

    public string SenderCity { get; } = string.Empty;

    public string SenderAddress { get; } = string.Empty;

    public string RecipientCity { get; } = string.Empty;

    public string RecipientAddress { get; } = string.Empty;

    public float Weight { get; }

    public DateTime PickUpDate { get; }

    public static (Order Order, string Error) Create(Guid id, string senderCity, string senderAddress, string recipientCity, string recipientAddress, float weight, DateTime pickUpDate)
    {
        var error = string.Empty;
        if (string.IsNullOrEmpty(senderCity) || senderCity.Length > MAX_GEO_LENGTH)
        {
            error = "Sender's city can not be empty or longer than 250 symbols";
        }
        else if (string.IsNullOrEmpty(senderAddress) || senderAddress.Length > MAX_GEO_LENGTH)
        {
            error = "Sender's address can not be empty or longer than 250 symbols";
        }
        else if (string.IsNullOrEmpty(recipientCity) || recipientCity.Length > MAX_GEO_LENGTH)
        {
            error = "Recipient's city can not be empty or longer than 250 symbols";
        }
        else if (string.IsNullOrEmpty(recipientAddress) || recipientAddress.Length > MAX_GEO_LENGTH)
        {
            error = "Recipient's address can not be empty or longer than 250 symbols";
        }
        else if (weight <= 0)
        {
            error = "Cargo's weight can not be less than or equal to zero";
        }
        var order = new Order(id, senderCity, senderAddress, recipientCity, recipientAddress, weight, pickUpDate);
        return (order, error);
    }
    
    Random rng = new Random();

    public string GenerateOrderNumber()
    {
        long orderPart1 = rng.Next(100000, 9999999);
        int orderPart2 = rng.Next(1000, 9999);
        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        char firstLetter = letters[rng.Next(letters.Length)];
        char secondLetter = letters[rng.Next(letters.Length)];
        string orderNumber = $"{firstLetter}{secondLetter}-{orderPart1}-{orderPart2}";        
        return orderNumber;
    }
 
}