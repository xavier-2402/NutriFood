namespace NutriFood.Domain.Common.Base
{
    public abstract class AuditableEntity
    {
        public bool Active { get; set; } = true;

        public DateTime CreaDate { get; set; }

        public short CreaUsr { get; set; }

        public DateTime ModDate { get; set; }

        public short ModUsr { get; set; }
    }
}
