namespace Repositories.Constants
{
    public static class AmericanoSqlConstants
    {
        public const string GetAll = @"
            SELECT a.[Id],
                   a.[Name],
                   a.[Description],
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
                   c.[Id],
                   c.[Name],
                   c.[Description],
                   c.[UseCaramel],
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
            FROM [dbo].[Americano] a
            INNER JOIN [dbo].[Sugar] s ON a.[SugarId] = s.[Id]
            INNER JOIN [dbo].[Milk] m ON a.[MilkId] = m.[Id]
            INNER JOIN [dbo].[Water] w ON a.[WaterId] = w.[Id]
            INNER JOIN [dbo].[Caramel] c ON a.[CaramelId] = c.[Id]
            INNER JOIN [dbo].[Creamer] cr ON a.[CreamerId] = cr.[Id]
            LEFT JOIN [dbo].[Milk_Amounts] ma ON m.[Id] = ma.[MilkId]
            LEFT JOIN [dbo].[Amount] ma_amt ON ma.[AmountId] = ma_amt.[Id]
            LEFT JOIN [dbo].[Sugar_Amounts] sa ON s.[Id] = sa.[SugarId]
            LEFT JOIN [dbo].[Amount] sa_amt ON sa.[AmountId] = sa_amt.[Id]";

        public const string GetById = @"
            SELECT a.[Id],
                   a.[Name],
                   a.[Description],
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
                   c.[Id],
                   c.[Name],
                   c.[Description],
                   c.[UseCaramel],
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
            FROM [dbo].[Americano] a
            INNER JOIN [dbo].[Sugar] s ON a.[SugarId] = s.[Id]
            INNER JOIN [dbo].[Milk] m ON a.[MilkId] = m.[Id]
            INNER JOIN [dbo].[Water] w ON a.[WaterId] = w.[Id]
            INNER JOIN [dbo].[Caramel] c ON a.[CaramelId] = c.[Id]
            INNER JOIN [dbo].[Creamer] cr ON a.[CreamerId] = cr.[Id]
            LEFT JOIN [dbo].[Milk_Amounts] ma ON m.[Id] = ma.[MilkId]
            LEFT JOIN [dbo].[Amount] ma_amt ON ma.[AmountId] = ma_amt.[Id]
            LEFT JOIN [dbo].[Sugar_Amounts] sa ON s.[Id] = sa.[SugarId]
            LEFT JOIN [dbo].[Amount] sa_amt ON sa.[AmountId] = sa_amt.[Id]
            WHERE a.[Id] = @Id";

        public const string Insert = @"
            INSERT INTO [dbo].[Americano] ([Id], [Name], [Description], [WaterId], [SugarId], [MilkId], [CaramelId], [CreamerId])
            VALUES (@Id, @Name, @Description, @WaterId, @SugarId, @MilkId, @CaramelId, @CreamerId)";
    }
}
