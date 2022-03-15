
namespace Hair_Salon_API.DAL.Models
{
    public partial class Address
    {
        public Address()
        {
            Salons = new HashSet<Salon>();
        }

        public int Id { get; set; }
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string Number { get; set; } = null!;
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual ICollection<Salon> Salons { get; set; }
    }
}
