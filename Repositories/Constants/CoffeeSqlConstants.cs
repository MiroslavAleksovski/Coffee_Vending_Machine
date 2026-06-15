namespace Repositories.Constants
{
    public static class CoffeeSqlConstants
    {
        public const string GetAllAmericanos = @"SELECT [Id], [Name] FROM [dbo].[Americano]";
        public const string GetAllEspressos = @"SELECT [Id], [Name] FROM [dbo].[Espresso]";
        public const string GetAllCappuccinos = @"SELECT [Id], [Name] FROM [dbo].[Cappuccino]";
        public const string GetAllLattes = @"SELECT [Id], [Name] FROM [dbo].[Latte]";
        public const string GetAllMacchiatos = @"SELECT [Id], [Name] FROM [dbo].[Macchiato]";
    }
}
