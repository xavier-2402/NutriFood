namespace NutriFood.Domain.Entities
{
    public class Patient
    {
        public int Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string? IdCard { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public DateTime? DateOfBirth { get; set; }

        public short UserId { get; set; }

        public bool Active { get; set; } = true;

        public DateTime CreaDate { get; set; }

        public short? CreaUsr { get; set; }

        public DateTime ModDate { get; set; }

        public short? ModUsr { get; set; }

        public User? User { get; set; }

        public ICollection<AdequacyPercentage> AdequacyPercentages { get; set; }
            = new HashSet<AdequacyPercentage>();
    }
}
