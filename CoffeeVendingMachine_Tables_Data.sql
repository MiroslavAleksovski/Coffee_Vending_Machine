USE [CoffeeVendingMachine]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- ============================================================================
-- COFFEE VENDING MACHINE - COMPLETE DATA SCRIPT
-- Data Insert Order (respecting Foreign Key Dependencies)
-- ============================================================================

-- DISABLE FOREIGN KEY CONSTRAINTS TEMPORARILY FOR DATA INSERTION
ALTER TABLE [dbo].[Americano] NOCHECK CONSTRAINT ALL
GO
ALTER TABLE [dbo].[Cappuccino] NOCHECK CONSTRAINT ALL
GO
ALTER TABLE [dbo].[Espresso] NOCHECK CONSTRAINT ALL
GO
ALTER TABLE [dbo].[Latte] NOCHECK CONSTRAINT ALL
GO
ALTER TABLE [dbo].[Macchiato] NOCHECK CONSTRAINT ALL
GO
ALTER TABLE [dbo].[Milk_Amounts] NOCHECK CONSTRAINT ALL
GO
ALTER TABLE [dbo].[Sugar_Amounts] NOCHECK CONSTRAINT ALL
GO

-- ============================================================================
-- INSERT DATA: Amount (No Dependencies)
-- ============================================================================

DELETE FROM [dbo].[Amount]
GO

INSERT INTO [dbo].[Amount] ([Id], [Quantity], [Measure])
VALUES 
(N'5d9b14ff-bfa6-4142-a734-11531d326b47', 20, N'ml'),
(N'ea2df8a8-ff75-49eb-b948-23979d61c151', 40, N'ml'),
(N'a5524159-c2f8-4833-8628-3728f38354e4', 5, N'packs'),
(N'c172d2a6-8da7-49b4-95af-6bad5f2decb8', 1, N'pack'),
(N'f8e78b39-f0a7-42c9-9d26-87d50c6f04f6', 10, N'ml'),
(N'4bfe67b5-8776-4807-84e4-8a44aa215777', 4, N'packs'),
(N'd2c830a5-665e-4c01-b892-9d222b2f0a12', 2, N'packs'),
(N'fc542918-ac7d-4834-9d24-bb48357201ef', 3, N'packs'),
(N'4a2116e5-c4c4-46bc-89b3-f06f13e04a8b', 50, N'ml'),
(N'3246ded9-9397-4d81-ac11-f542670cbbac', 30, N'ml')
GO

-- ============================================================================
-- INSERT DATA: Caramel (No Dependencies)
-- ============================================================================

DELETE FROM [dbo].[Caramel]
GO

INSERT INTO [dbo].[Caramel] ([Id], [Name], [Description], [UseCaramel])
VALUES 
(N'45bda142-acfb-4b7a-86a2-8a8d7e4c2d1f', N'Elah hard candy', N'', 1),
(N'0af690b8-be48-401e-8736-da91f5f44ac7', N'Camp Coffee', N'', 1)
GO

-- ============================================================================
-- INSERT DATA: Creamer (No Dependencies)
-- ============================================================================

DELETE FROM [dbo].[Creamer]
GO

INSERT INTO [dbo].[Creamer] ([Id], [Name], [Description], [UseCreamer])
VALUES 
(N'c1e28f11-ee90-46ec-bbf4-1060d2b9b775', N'DIY', N'', 1),
(N'f759bd5d-00b7-4f8f-808e-2258a50898d7', N'Non-Diary', N'', 1),
(N'c7182238-8fdb-4cf6-bb26-ee03b1d93e4c', N'Traditional', N'', 1)
GO

-- ============================================================================
-- INSERT DATA: Milk (No Dependencies)
-- ============================================================================

DELETE FROM [dbo].[Milk]
GO

INSERT INTO [dbo].[Milk] ([Id], [Name], [Description])
VALUES 
(N'365f4812-981c-4438-aca3-5a567d2be6b5', N'Cow milk', N''),
(N'9b5fa488-7f88-4631-b913-d306d7fa22a6', N'Mixed milk', N''),
(N'6f77ebdf-9d6b-40f6-88c3-eb252c325cc8', N'Milk in powder', N'')
GO

-- ============================================================================
-- INSERT DATA: Sugar (No Dependencies)
-- ============================================================================

DELETE FROM [dbo].[Sugar]
GO

INSERT INTO [dbo].[Sugar] ([Id], [Name], [Description])
VALUES 
(N'413f3fed-272c-4c30-9081-5c6700a0581f', N'Brown', N''),
(N'464ac715-c78c-495d-a4bc-da38db33d249', N'White', N'')
GO

-- ============================================================================
-- INSERT DATA: Water (No Dependencies)
-- ============================================================================

DELETE FROM [dbo].[Water]
GO

INSERT INTO [dbo].[Water] ([Id], [Amount], [Measure], [IsHot])
VALUES 
(N'98896a2b-e0d6-4e20-a24b-3cbf12263171', 30, N'ml', 0),
(N'b08ab8e6-3b35-4048-9879-498369291b05', 10, N'ml', 1),
(N'd589c5ae-2ec1-473f-86e5-7f725184b251', 30, N'ml', 1),
(N'397ae799-8f16-4911-9566-a02f147a5013', 10, N'ml', 1),
(N'665b5cf8-45d4-422a-afb5-ae37d9df949d', 20, N'ml', 1),
(N'4b95bb69-1bd7-4822-beb7-b901d41e9c6c', 20, N'ml', 0)
GO

-- ============================================================================
-- INSERT DATA: Americano (Depends on: Water, Sugar, Milk, Caramel, Creamer)
-- ============================================================================

DELETE FROM [dbo].[Americano]
GO

INSERT INTO [dbo].[Americano] ([Id], [Name], [Description], [WaterId], [SugarId], [MilkId], [CaramelId], [CreamerId])
VALUES 
(N'249b9cef-ea33-4b3d-9c67-30a6f0981718', N'White Americano', N'A standard Americano finished with a small splash of cold milk, cream, or oat milk to soften the acidity and add a touch of creaminess without turning it into a full latte', N'b08ab8e6-3b35-4048-9879-498369291b05', N'413f3fed-272c-4c30-9081-5c6700a0581f', N'6f77ebdf-9d6b-40f6-88c3-eb252c325cc8', N'0af690b8-be48-401e-8736-da91f5f44ac7', N'c7182238-8fdb-4cf6-bb26-ee03b1d93e4c'),
(N'3cd5cf7f-60e8-4733-bcf9-807684da6788', N'Iced Americano', N'Espresso is combined with cold, filtered water and ice cubes.', N'b08ab8e6-3b35-4048-9879-498369291b05', N'413f3fed-272c-4c30-9081-5c6700a0581f', N'365f4812-981c-4438-aca3-5a567d2be6b5', N'0af690b8-be48-401e-8736-da91f5f44ac7', N'c7182238-8fdb-4cf6-bb26-ee03b1d93e4c'),
(N'c1ec9efa-1be1-433e-8266-b5c789d015b4', N'Flavored Americano', N'Enhanced with a pump of flavored syrup like vanilla, hazelnut, or caramel for sweetness', N'b08ab8e6-3b35-4048-9879-498369291b05', N'464ac715-c78c-495d-a4bc-da38db33d249', N'6f77ebdf-9d6b-40f6-88c3-eb252c325cc8', N'0af690b8-be48-401e-8736-da91f5f44ac7', N'c7182238-8fdb-4cf6-bb26-ee03b1d93e4c')
GO

-- ============================================================================
-- INSERT DATA: Cappuccino (Depends on: Water, Sugar, Milk, Caramel)
-- ============================================================================

DELETE FROM [dbo].[Cappuccino]
GO

INSERT INTO [dbo].[Cappuccino] ([Id], [Name], [Description], [WaterId], [SugarId], [MilkId], [CaramelId])
VALUES 
(N'cd29db05-c7f4-464d-ac02-8ac19699e66d', N'Regular Cappuccino', N'', N'b08ab8e6-3b35-4048-9879-498369291b05', N'413f3fed-272c-4c30-9081-5c6700a0581f', N'6f77ebdf-9d6b-40f6-88c3-eb252c325cc8', N'0af690b8-be48-401e-8736-da91f5f44ac7')
GO

-- ============================================================================
-- INSERT DATA: Espresso (Depends on: Water, Sugar)
-- ============================================================================

DELETE FROM [dbo].[Espresso]
GO

INSERT INTO [dbo].[Espresso] ([Id], [Name], [Description], [WaterId], [SugarId])
VALUES 
(N'ddc30045-1a9b-44e3-b33b-1f051e916a3b', N'Short Espresso', N'', N'b08ab8e6-3b35-4048-9879-498369291b05', N'413f3fed-272c-4c30-9081-5c6700a0581f'),
(N'f4a3854f-e439-4912-91db-8e866e4b1719', N'Long Espresso', N'', N'd589c5ae-2ec1-473f-86e5-7f725184b251', N'413f3fed-272c-4c30-9081-5c6700a0581f')
GO

-- ============================================================================
-- INSERT DATA: Latte (Depends on: Water, Sugar, Milk, Creamer)
-- ============================================================================

DELETE FROM [dbo].[Latte]
GO

INSERT INTO [dbo].[Latte] ([Id], [Name], [Description], [WaterId], [SugarId], [MilkId], [CreamerId])
VALUES 
(N'154b5532-2fc8-4d08-9a52-d3b82fded8a3', N'Regular Latte', N'', N'b08ab8e6-3b35-4048-9879-498369291b05', N'413f3fed-272c-4c30-9081-5c6700a0581f', N'6f77ebdf-9d6b-40f6-88c3-eb252c325cc8', N'c7182238-8fdb-4cf6-bb26-ee03b1d93e4c')
GO

-- ============================================================================
-- INSERT DATA: Macchiato (Depends on: Water, Sugar, Milk)
-- ============================================================================

DELETE FROM [dbo].[Macchiato]
GO

INSERT INTO [dbo].[Macchiato] ([Id], [Name], [Description], [WaterId], [SugarId], [MilkId])
VALUES 
(N'34253b8b-06a1-4a70-95a9-1799124e3db7', N'Regular Macchiato', N'', N'b08ab8e6-3b35-4048-9879-498369291b05', N'413f3fed-272c-4c30-9081-5c6700a0581f', N'6f77ebdf-9d6b-40f6-88c3-eb252c325cc8')
GO

-- ============================================================================
-- INSERT DATA: Milk_Amounts (Depends on: Milk, Amount)
-- ============================================================================

DELETE FROM [dbo].[Milk_Amounts]
GO

INSERT INTO [dbo].[Milk_Amounts] ([Id], [MilkId], [AmountId], [IsDefault])
VALUES 
(N'af516f07-b0bc-44b6-b982-3c27300493ff', N'6f77ebdf-9d6b-40f6-88c3-eb252c325cc8', N'3246ded9-9397-4d81-ac11-f542670cbbac', 1),
(N'6ec17943-57c3-42bb-a394-91df7ded28e2', N'6f77ebdf-9d6b-40f6-88c3-eb252c325cc8', N'ea2df8a8-ff75-49eb-b948-23979d61c151', 0),
(N'2f66385d-a4e0-4f93-b837-af8f127b9dc9', N'6f77ebdf-9d6b-40f6-88c3-eb252c325cc8', N'5d9b14ff-bfa6-4142-a734-11531d326b47', 0),
(N'9e170e19-6cd3-4b58-847e-b2d0215494de', N'6f77ebdf-9d6b-40f6-88c3-eb252c325cc8', N'f8e78b39-f0a7-42c9-9d26-87d50c6f04f6', 0),
(N'16f32702-3b99-4a77-8b7d-d68c1c3fd4fe', N'6f77ebdf-9d6b-40f6-88c3-eb252c325cc8', N'4a2116e5-c4c4-46bc-89b3-f06f13e04a8b', 0)
GO

-- ============================================================================
-- INSERT DATA: Sugar_Amounts (Depends on: Sugar, Amount)
-- ============================================================================

DELETE FROM [dbo].[Sugar_Amounts]
GO

INSERT INTO [dbo].[Sugar_Amounts] ([Id], [SugarId], [AmountId], [IsDefault])
VALUES 
(N'33b95f4a-0c73-477e-bbac-0acc711e5b12', N'413f3fed-272c-4c30-9081-5c6700a0581f', N'd2c830a5-665e-4c01-b892-9d222b2f0a12', 0),
(N'39f71e24-9bcb-461b-b9b7-b012c02d3f82', N'413f3fed-272c-4c30-9081-5c6700a0581f', N'c172d2a6-8da7-49b4-95af-6bad5f2decb8', 0),
(N'4bc4933e-f064-4d4b-8515-dd2884e09061', N'413f3fed-272c-4c30-9081-5c6700a0581f', N'fc542918-ac7d-4834-9d24-bb48357201ef', 1)
GO

-- ============================================================================
-- RE-ENABLE FOREIGN KEY CONSTRAINTS
-- ============================================================================

ALTER TABLE [dbo].[Americano] CHECK CONSTRAINT ALL
GO
ALTER TABLE [dbo].[Cappuccino] CHECK CONSTRAINT ALL
GO
ALTER TABLE [dbo].[Espresso] CHECK CONSTRAINT ALL
GO
ALTER TABLE [dbo].[Latte] CHECK CONSTRAINT ALL
GO
ALTER TABLE [dbo].[Macchiato] CHECK CONSTRAINT ALL
GO
ALTER TABLE [dbo].[Milk_Amounts] CHECK CONSTRAINT ALL
GO
ALTER TABLE [dbo].[Sugar_Amounts] CHECK CONSTRAINT ALL
GO

-- ============================================================================
-- VERIFICATION QUERIES
-- ============================================================================

PRINT '========== DATA VERIFICATION =========='
PRINT ''
PRINT 'Amount Records:'
SELECT COUNT(*) AS [Count] FROM [dbo].[Amount]
GO

PRINT 'Caramel Records:'
SELECT COUNT(*) AS [Count] FROM [dbo].[Caramel]
GO

PRINT 'Creamer Records:'
SELECT COUNT(*) AS [Count] FROM [dbo].[Creamer]
GO

PRINT 'Milk Records:'
SELECT COUNT(*) AS [Count] FROM [dbo].[Milk]
GO

PRINT 'Sugar Records:'
SELECT COUNT(*) AS [Count] FROM [dbo].[Sugar]
GO

PRINT 'Water Records:'
SELECT COUNT(*) AS [Count] FROM [dbo].[Water]
GO

PRINT 'Americano Records:'
SELECT COUNT(*) AS [Count] FROM [dbo].[Americano]
GO

PRINT 'Cappuccino Records:'
SELECT COUNT(*) AS [Count] FROM [dbo].[Cappuccino]
GO

PRINT 'Espresso Records:'
SELECT COUNT(*) AS [Count] FROM [dbo].[Espresso]
GO

PRINT 'Latte Records:'
SELECT COUNT(*) AS [Count] FROM [dbo].[Latte]
GO

PRINT 'Macchiato Records:'
SELECT COUNT(*) AS [Count] FROM [dbo].[Macchiato]
GO

PRINT 'Milk_Amounts Records:'
SELECT COUNT(*) AS [Count] FROM [dbo].[Milk_Amounts]
GO

PRINT 'Sugar_Amounts Records:'
SELECT COUNT(*) AS [Count] FROM [dbo].[Sugar_Amounts]
GO

PRINT ''
PRINT '========== DATA INSERTION COMPLETED SUCCESSFULLY =========='
GO

-- ============================================================================
-- END OF DATA SCRIPT
-- ============================================================================
