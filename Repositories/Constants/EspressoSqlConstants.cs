namespace Repositories.Constants
{
    public static class EspressoSqlConstants
    {
        public const string GetAll = @"
            SELECT e.[Id],
                   e.[Name],
                   e.[Description],
                   s.[Id],
                   s.[Name],
                   s.[Description],
                   w.[Id],
                   w.[Amount],
                   w.[Measure],
                   w.[IsHot],
                   sa_amt.[Id],
                   sa_amt.[Quantity],
                   sa_amt.[Measure],
                   sa.[IsDefault]
            FROM [dbo].[Espresso] e
            INNER JOIN [dbo].[Sugar] s ON e.[SugarId] = s.[Id]
            INNER JOIN [dbo].[Water] w ON e.[WaterId] = w.[Id]
            LEFT JOIN [dbo].[Sugar_Amounts] sa ON s.[Id] = sa.[SugarId]
            LEFT JOIN [dbo].[Amount] sa_amt ON sa.[AmountId] = sa_amt.[Id]";

        public const string GetById = @"
            SELECT e.[Id],
                   e.[Name],
                   e.[Description],
                   s.[Id],
                   s.[Name],
                   s.[Description],
                   w.[Id],
                   w.[Amount],
                   w.[Measure],
                   w.[IsHot],
                   sa_amt.[Id],
                   sa_amt.[Quantity],
                   sa_amt.[Measure],
                   sa.[IsDefault]
            FROM [dbo].[Espresso] e
            INNER JOIN [dbo].[Sugar] s ON e.[SugarId] = s.[Id]
            INNER JOIN [dbo].[Water] w ON e.[WaterId] = w.[Id]
            LEFT JOIN [dbo].[Sugar_Amounts] sa ON s.[Id] = sa.[SugarId]
            LEFT JOIN [dbo].[Amount] sa_amt ON sa.[AmountId] = sa_amt.[Id]
            WHERE e.[Id] = @Id";

        public const string Insert = @"
            INSERT INTO [dbo].[Espresso] ([Id], [Name], [Description], [WaterId], [SugarId])
            VALUES (@Id, @Name, @Description, @WaterId, @SugarId)";
    }
}
