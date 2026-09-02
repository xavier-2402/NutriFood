using NutriFood.Domain.Common.Interfaces;

namespace NutriFood.Domain.Entities
{
    public class User : IEntity<short>, ICodeEntity, IActivableEntity
    {
        public short Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public bool Active { get; set; } = true;

        public DateTime CreaDate { get; set; } = DateTime.Now;

        public DateTime ModDate { get; set; }

        public List<Patient> Patients { get; set; } = [];
    }
}
