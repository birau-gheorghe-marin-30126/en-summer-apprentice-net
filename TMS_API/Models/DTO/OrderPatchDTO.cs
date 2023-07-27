namespace TMS_API.Models.DTO
{
    public class OrderPatchDTO
    {
        public int OrderId { get; set; }
        public long NumberOfTickets { get; set; }
        public DateTime OrderedAt { get; set; }
        public long TotalPrice { get; set; }
    }
}
