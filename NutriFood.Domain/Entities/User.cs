namespace NutriFood.Domain.Entities
{
    public class User
    {
        public short Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public ICollection<Patient> Patients { get; set; }
            = new HashSet<Patient>();
    }
}
