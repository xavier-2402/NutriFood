using NutriFood.Domain.Common.Interfaces;

namespace NutriFood.Domain.Entities
{
    public class Menu : IEntity<short>, ICodeEntity, IActivableEntity
    {
        public short Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Path { get; set; } = string.Empty;

        public bool Active { get; set; } = true;
    }
}
