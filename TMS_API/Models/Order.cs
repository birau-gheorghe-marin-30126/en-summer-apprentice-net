using System;
using System.Collections.Generic;

namespace TMS_API.Models;

public partial class Order
{
    public int Orderid { get; set; }

    public long? NumberOfTickets { get; set; }

    public DateTime? OrderedAt { get; set; }

    public long? TotalPrice { get; set; }

    public int? TicketCategoryId { get; set; }

    public int? UserId { get; set; }

    public virtual TicketCategory? TicketCategory { get; set; }

    public virtual User? User { get; set; }
}
