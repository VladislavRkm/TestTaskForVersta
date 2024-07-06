using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoDelivery.DataAccess.Entities;

public class OrderEntity
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
