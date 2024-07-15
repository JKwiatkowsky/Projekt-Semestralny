namespace ProjektSemestralny.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }

        public Appointment()
        {
        }

        public Appointment(int id, int customerId, DateTime date)
        {
            Id = id;
            CustomerId = customerId;
            Date = date;
        }
    }
}