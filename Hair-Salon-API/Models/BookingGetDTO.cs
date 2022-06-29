
namespace Hair_Salon_API.Models
{
    public class BookingGetDTO
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Salon { get; set; }
        public string Service { get; set; }
        public DateTime BookingDate { get; set; }
        public string Barber { get; set; }
        public bool Paid { get; set; }
    }
}