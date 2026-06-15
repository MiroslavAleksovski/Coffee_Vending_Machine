namespace Repositories.Constants
{
    public static class MacchiatoSqlConstants
    {
        public const string GetAll = @"
            SELECT mc.[Id],
                   mc.[Name],
                   mc.[Description],
                   s.[Id],
                   s.[Name],
                   s.[Description],
                   m.[Id],
                   m.[Name],
                   m.[Description],
                   w.[Id],
                   w.[Amount],
                   w.[Measure],
                   w.[IsHot],
                   ma_amt.[Id],
                   ma_amt.[Quantity],
                   ma_amt.[Measure],
                   ma.[IsDefault],
                   sa_amt.[Id],
                   sa_amt.[Quantity],
                   sa_amt.[Measure],
                   sa.[IsDefault]
            FROM [dbo].[Macchiato] mc
            INNER JOIN [dbo].[Sugar] s ON mc.[SugarId] = s.[Id]
            INNER JOIN [dbo].[Milk] m ON mc.[MilkId] = m.[Id]
            INNER JOIN [dbo].[Water] w ON mc.[WaterId] = w.[Id]
            LEFT JOIN [dbo].[Milk_Amounts] ma ON m.[Id] = ma.[MilkId]
            LEFT JOIN [dbo].[Amount] ma_amt ON ma.[AmountId] = ma_amt.[Id]
            LEFT JOIN [dbo].[Sugar_Amounts] sa ON s.[Id] = sa.[SugarId]
            LEFT JOIN [dbo].[Amount] sa_amt ON sa.[AmountId] = sa_amt.[Id]";

        public const string GetById = @"
            SELECT mc.[Id],
                   mc.[Name],
                   mc.[Description],
                   s.[Id],
                   s.[Name],
                   s.[Description],
                   m.[Id],
                   m.[Name],
                   m.[Description],
                   w.[Id],
                   w.[Amount],
                   w.[Measure],
                   w.[IsHot],
                   ma_amt.[Id],
                   ma_amt.[Quantity],
                   ma_amt.[Measure],
                   ma.[IsDefault],
                   sa_amt.[Id],
                   sa_amt.[Quantity],
                   sa_amt.[Measure],
                   sa.[IsDefault]
            FROM [dbo].[Macchiato] mc
            INNER JOIN [dbo].[Sugar] s ON mc.[SugarId] = s.[Id]
            INNER JOIN [dbo].[Milk] m ON mc.[MilkId] = m.[Id]
            INNER JOIN [dbo].[Water] w ON mc.[WaterId] = w.[Id]
            LEFT JOIN [dbo].[Milk_Amounts] ma ON m.[Id] = ma.[MilkId]
            LEFT JOIN [dbo].[Amount] ma_amt ON ma.[AmountId] = ma_amt.[Id]
            LEFT JOIN [dbo].[Sugar_Amounts] sa ON s.[Id] = sa.[SugarId]
            LEFT JOIN [dbo].[Amount] sa_amt ON sa.[AmountId] = sa_amt.[Id]
            WHERE mc.[Id] = @Id";

        public const string Insert = @"
            INSERT INTO [dbo].[Macchiato] ([Id], [Name], [Description], [WaterId], [SugarId], [MilkId])
            VALUES (@Id, @Name, @Description, @WaterId, @SugarId, @MilkId)";
    }
}
