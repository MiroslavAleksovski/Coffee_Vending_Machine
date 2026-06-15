namespace Repositories.Constants
{
    public static class CappuccinoSqlConstants
    {
        public const string GetAll = @"
            SELECT c.[Id],
                   c.[Name],
                   c.[Description],
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
                   car.[Id],
                   car.[Name],
                   car.[Description],
                   car.[UseCaramel],
                   ma_amt.[Id],
                   ma_amt.[Quantity],
                   ma_amt.[Measure],
                   ma.[IsDefault],
                   sa_amt.[Id],
                   sa_amt.[Quantity],
                   sa_amt.[Measure],
                   sa.[IsDefault]
            FROM [dbo].[Cappuccino] c
            INNER JOIN [dbo].[Sugar] s ON c.[SugarId] = s.[Id]
            INNER JOIN [dbo].[Milk] m ON c.[MilkId] = m.[Id]
            INNER JOIN [dbo].[Water] w ON c.[WaterId] = w.[Id]
            INNER JOIN [dbo].[Caramel] car ON c.[CaramelId] = car.[Id]
            LEFT JOIN [dbo].[Milk_Amounts] ma ON m.[Id] = ma.[MilkId]
            LEFT JOIN [dbo].[Amount] ma_amt ON ma.[AmountId] = ma_amt.[Id]
            LEFT JOIN [dbo].[Sugar_Amounts] sa ON s.[Id] = sa.[SugarId]
            LEFT JOIN [dbo].[Amount] sa_amt ON sa.[AmountId] = sa_amt.[Id]";

        public const string GetById = @"
            SELECT c.[Id],
                   c.[Name],
                   c.[Description],
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
                   car.[Id],
                   car.[Name],
                   car.[Description],
                   car.[UseCaramel],
                   ma_amt.[Id],
                   ma_amt.[Quantity],
                   ma_amt.[Measure],
                   ma.[IsDefault],
                   sa_amt.[Id],
                   sa_amt.[Quantity],
                   sa_amt.[Measure],
                   sa.[IsDefault]
            FROM [dbo].[Cappuccino] c
            INNER JOIN [dbo].[Sugar] s ON c.[SugarId] = s.[Id]
            INNER JOIN [dbo].[Milk] m ON c.[MilkId] = m.[Id]
            INNER JOIN [dbo].[Water] w ON c.[WaterId] = w.[Id]
            INNER JOIN [dbo].[Caramel] car ON c.[CaramelId] = car.[Id]
            LEFT JOIN [dbo].[Milk_Amounts] ma ON m.[Id] = ma.[MilkId]
            LEFT JOIN [dbo].[Amount] ma_amt ON ma.[AmountId] = ma_amt.[Id]
            LEFT JOIN [dbo].[Sugar_Amounts] sa ON s.[Id] = sa.[SugarId]
            LEFT JOIN [dbo].[Amount] sa_amt ON sa.[AmountId] = sa_amt.[Id]
            WHERE c.[Id] = @Id";

        public const string Insert = @"
            INSERT INTO [dbo].[Cappuccino] ([Id], [Name], [Description], [WaterId], [SugarId], [MilkId], [CaramelId])
            VALUES (@Id, @Name, @Description, @WaterId, @SugarId, @MilkId, @CaramelId)";
    }
}
