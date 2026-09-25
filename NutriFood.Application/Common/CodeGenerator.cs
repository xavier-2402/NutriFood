namespace NutriFood.Application.Common
{
    public static class CodeGenerator
    {
        public static string Generate(int size = 15)
        {
            size = size <= 0 ? 15 : size;
            return Guid.NewGuid().ToString("n")[..size].ToString();
        }
    }
}
