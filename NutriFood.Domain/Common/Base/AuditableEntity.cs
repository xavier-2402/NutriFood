using NutriFood.Domain.Common.Interfaces;

namespace NutriFood.Domain.Common.Base
{
    public abstract class AuditableEntity : IAuditableEntity
    {
        public bool Active { get; set; } = true;

        public DateTime CreaDate { get; set; }

        public short? CreaUsr { get; set; }

        public DateTime ModDate { get; set; }

        public short? ModUsr { get; set; }
    }
}
