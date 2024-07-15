namespace ProjektSemestralny.Models
{
    public class CompletedService
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CompletionDate { get; set; }

        public CompletedService()
        {
        }

        public CompletedService(int id, int serviceId, int customerId, DateTime completionDate)
        {
            Id = id;
            ServiceId = serviceId;
            CustomerId = customerId;
            CompletionDate = completionDate;
        }
    }
}