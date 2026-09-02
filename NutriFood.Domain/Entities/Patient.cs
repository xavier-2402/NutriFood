using NutriFood.Domain.Common.Base;
using NutriFood.Domain.Common.Interfaces;

namespace NutriFood.Domain.Entities
{
    public class Patient : AuditableEntity, IEntity<int>, ICodeEntity
    {
        public int Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string? IdCard { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public DateTime? DateOfBirth { get; set; }

        public short UserId { get; set; }

        public User? User { get; set; }

        public List<AdequacyPercentage> AdequacyPercentages { get; set; } = [];
    }
}
