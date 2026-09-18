namespace NutriFood.Application.Common
{
    public static class CodeGenerator
    {
        public static string Generate()
        {
            return Guid.NewGuid().ToString("n")[..15].ToString();
        }
    }
}
