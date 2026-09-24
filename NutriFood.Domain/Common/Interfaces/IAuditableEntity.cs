namespace NutriFood.Domain.Common.Interfaces;

public interface IAuditableEntity : IActivableEntity
{
    DateTime CreaDate { get; set; }
    short? CreaUsr { get; set; }
    DateTime ModDate { get; set; }
    short? ModUsr { get; set; }
}
