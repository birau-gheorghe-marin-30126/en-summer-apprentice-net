using System;
using System.Collections.Generic;

namespace TMS_API.Models;

public partial class TicketCategory
{
    public int TicketCategoryid { get; set; }

    public string? Description { get; set; }

    public long? Price { get; set; }

    public int? EventId { get; set; }

    public virtual Event? Event { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
