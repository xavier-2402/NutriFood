namespace NutriFood.Domain.Entities
{
    public class Menu
    {
        public short Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Path { get; set; } = string.Empty;

        public bool Active { get; set; } = true;
    }
}
