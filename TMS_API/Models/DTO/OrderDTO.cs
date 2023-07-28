using Microsoft.Identity.Client;

namespace TMS_API.Models.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public long NumberOfTickets { get; set; }
        public DateTime OrderedAt { get; set; }
        public long TotalPrice { get; set; }
        public string TicketCategory { get; set; }  
        public string User { get; set; }
    }
}
