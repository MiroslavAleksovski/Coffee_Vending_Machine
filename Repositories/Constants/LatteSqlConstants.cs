namespace Repositories.Constants
{
    public static class LatteSqlConstants
    {
        public const string GetAll = @"
            SELECT l.[Id],
                   l.[Name],
                   l.[Description],
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
                   cr.[Id],
                   cr.[Name],
                   cr.[Description],
                   cr.[UseCreamer],
                   ma_amt.[Id],
                   ma_amt.[Quantity],
                   ma_amt.[Measure],
                   ma.[IsDefault],
                   sa_amt.[Id],
                   sa_amt.[Quantity],
                   sa_amt.[Measure],
                   sa.[IsDefault]
            FROM [dbo].[Latte] l
            INNER JOIN [dbo].[Sugar] s ON l.[SugarId] = s.[Id]
            INNER JOIN [dbo].[Milk] m ON l.[MilkId] = m.[Id]
            INNER JOIN [dbo].[Water] w ON l.[WaterId] = w.[Id]
            INNER JOIN [dbo].[Creamer] cr ON l.[CreamerId] = cr.[Id]
            LEFT JOIN [dbo].[Milk_Amounts] ma ON m.[Id] = ma.[MilkId]
            LEFT JOIN [dbo].[Amount] ma_amt ON ma.[AmountId] = ma_amt.[Id]
            LEFT JOIN [dbo].[Sugar_Amounts] sa ON s.[Id] = sa.[SugarId]
            LEFT JOIN [dbo].[Amount] sa_amt ON sa.[AmountId] = sa_amt.[Id]";

        public const string GetById = @"
            SELECT l.[Id],
                   l.[Name],
                   l.[Description],
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
                   cr.[Id],
                   cr.[Name],
                   cr.[Description],
                   cr.[UseCreamer],
                   ma_amt.[Id],
                   ma_amt.[Quantity],
                   ma_amt.[Measure],
                   ma.[IsDefault],
                   sa_amt.[Id],
                   sa_amt.[Quantity],
                   sa_amt.[Measure],
                   sa.[IsDefault]
            FROM [dbo].[Latte] l
            INNER JOIN [dbo].[Sugar] s ON l.[SugarId] = s.[Id]
            INNER JOIN [dbo].[Milk] m ON l.[MilkId] = m.[Id]
            INNER JOIN [dbo].[Water] w ON l.[WaterId] = w.[Id]
            INNER JOIN [dbo].[Creamer] cr ON l.[CreamerId] = cr.[Id]
            LEFT JOIN [dbo].[Milk_Amounts] ma ON m.[Id] = ma.[MilkId]
            LEFT JOIN [dbo].[Amount] ma_amt ON ma.[AmountId] = ma_amt.[Id]
            LEFT JOIN [dbo].[Sugar_Amounts] sa ON s.[Id] = sa.[SugarId]
            LEFT JOIN [dbo].[Amount] sa_amt ON sa.[AmountId] = sa_amt.[Id]
            WHERE l.[Id] = @Id";

        public const string Insert = @"
            INSERT INTO [dbo].[Latte] ([Id], [Name], [Description], [WaterId], [SugarId], [MilkId], [CreamerId])
            VALUES (@Id, @Name, @Description, @WaterId, @SugarId, @MilkId, @CreamerId)";
    }
}
