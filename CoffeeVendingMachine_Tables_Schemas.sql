USE [CoffeeVendingMachine]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- ============================================================================
-- TABLE: Amount
-- ============================================================================
IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Amount' AND schema_id = SCHEMA_ID('dbo'))
	DROP TABLE [dbo].[Amount]
GO

CREATE TABLE [dbo].[Amount](
	[Id] [uniqueidentifier] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Measure] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Amount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Amount] ADD  CONSTRAINT [DF_Amount_Id]  DEFAULT (newid()) FOR [Id]
GO

-- ============================================================================
-- TABLE: Caramel
-- ============================================================================
IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Caramel' AND schema_id = SCHEMA_ID('dbo'))
	DROP TABLE [dbo].[Caramel]
GO

CREATE TABLE [dbo].[Caramel](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[UseCaramel] [bit] NOT NULL,
 CONSTRAINT [PK_Caramel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Caramel] ADD  CONSTRAINT [DF_Caramel_Id]  DEFAULT (newid()) FOR [Id]
GO

-- ============================================================================
-- TABLE: Creamer
-- ============================================================================
IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Creamer' AND schema_id = SCHEMA_ID('dbo'))
	DROP TABLE [dbo].[Creamer]
GO

CREATE TABLE [dbo].[Creamer](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[UseCreamer] [bit] NOT NULL,
 CONSTRAINT [PK_Creamer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Creamer] ADD  CONSTRAINT [DF_Creamer_Id]  DEFAULT (newid()) FOR [Id]
GO

-- ============================================================================
-- TABLE: Milk
-- ============================================================================
IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Milk' AND schema_id = SCHEMA_ID('dbo'))
	DROP TABLE [dbo].[Milk]
GO

CREATE TABLE [dbo].[Milk](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Milk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Milk] ADD  CONSTRAINT [DF_Milk_Id]  DEFAULT (newid()) FOR [Id]
GO

-- ============================================================================
-- TABLE: Milk_Amounts
-- ============================================================================
IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Milk_Amounts' AND schema_id = SCHEMA_ID('dbo'))
	DROP TABLE [dbo].[Milk_Amounts]
GO

CREATE TABLE [dbo].[Milk_Amounts](
	[Id] [uniqueidentifier] NOT NULL,
	[MilkId] [uniqueidentifier] NOT NULL,
	[AmountId] [uniqueidentifier] NOT NULL,
	[IsDefault] [bit] NOT NULL,
 CONSTRAINT [PK_Milk_Amounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Milk_Amounts] ADD  CONSTRAINT [DF_Milk_Amounts_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[Milk_Amounts]  WITH CHECK ADD  CONSTRAINT [FK_Milk_Amounts_Amount] FOREIGN KEY([AmountId])
REFERENCES [dbo].[Amount] ([Id])
GO

ALTER TABLE [dbo].[Milk_Amounts] CHECK CONSTRAINT [FK_Milk_Amounts_Amount]
GO

ALTER TABLE [dbo].[Milk_Amounts]  WITH CHECK ADD  CONSTRAINT [FK_Milk_Amounts_Milk] FOREIGN KEY([MilkId])
REFERENCES [dbo].[Milk] ([Id])
GO

ALTER TABLE [dbo].[Milk_Amounts] CHECK CONSTRAINT [FK_Milk_Amounts_Milk]
GO

-- ============================================================================
-- TABLE: Sugar
-- ============================================================================
IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Sugar' AND schema_id = SCHEMA_ID('dbo'))
	DROP TABLE [dbo].[Sugar]
GO

CREATE TABLE [dbo].[Sugar](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Sugar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Sugar] ADD  CONSTRAINT [DF_Sugar_Id]  DEFAULT (newid()) FOR [Id]
GO

-- ============================================================================
-- TABLE: Sugar_Amounts
-- ============================================================================
IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Sugar_Amounts' AND schema_id = SCHEMA_ID('dbo'))
	DROP TABLE [dbo].[Sugar_Amounts]
GO

CREATE TABLE [dbo].[Sugar_Amounts](
	[Id] [uniqueidentifier] NOT NULL,
	[SugarId] [uniqueidentifier] NOT NULL,
	[AmountId] [uniqueidentifier] NOT NULL,
	[IsDefault] [bit] NOT NULL,
 CONSTRAINT [PK_Sugar_Amounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Sugar_Amounts] ADD  CONSTRAINT [DF_Sugar_Amounts_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[Sugar_Amounts]  WITH CHECK ADD  CONSTRAINT [FK_Sugar_Amounts_Amount] FOREIGN KEY([AmountId])
REFERENCES [dbo].[Amount] ([Id])
GO

ALTER TABLE [dbo].[Sugar_Amounts] CHECK CONSTRAINT [FK_Sugar_Amounts_Amount]
GO

ALTER TABLE [dbo].[Sugar_Amounts]  WITH CHECK ADD  CONSTRAINT [FK_Sugar_Amounts_Sugar] FOREIGN KEY([SugarId])
REFERENCES [dbo].[Sugar] ([Id])
GO

ALTER TABLE [dbo].[Sugar_Amounts] CHECK CONSTRAINT [FK_Sugar_Amounts_Sugar]
GO

-- ============================================================================
-- TABLE: Water
-- ============================================================================
IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Water' AND schema_id = SCHEMA_ID('dbo'))
	DROP TABLE [dbo].[Water]
GO

CREATE TABLE [dbo].[Water](
	[Id] [uniqueidentifier] NOT NULL,
	[Amount] [int] NOT NULL,
	[Measure] [nvarchar](100) NOT NULL,
	[IsHot] [bit] NOT NULL,
 CONSTRAINT [PK_Water] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Water] ADD  CONSTRAINT [DF_Water_Id]  DEFAULT (newid()) FOR [Id]
GO

-- ============================================================================
-- TABLE: Americano
-- ============================================================================
IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Americano' AND schema_id = SCHEMA_ID('dbo'))
	DROP TABLE [dbo].[Americano]
GO

CREATE TABLE [dbo].[Americano](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[WaterId] [uniqueidentifier] NOT NULL,
	[SugarId] [uniqueidentifier] NOT NULL,
	[MilkId] [uniqueidentifier] NOT NULL,
	[CaramelId] [uniqueidentifier] NOT NULL,
	[CreamerId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Americano] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Americano] ADD  CONSTRAINT [DF_Americano_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[Americano]  WITH CHECK ADD  CONSTRAINT [FK_Americano_Caramel] FOREIGN KEY([CaramelId])
REFERENCES [dbo].[Caramel] ([Id])
GO

ALTER TABLE [dbo].[Americano] CHECK CONSTRAINT [FK_Americano_Caramel]
GO

ALTER TABLE [dbo].[Americano]  WITH CHECK ADD  CONSTRAINT [FK_Americano_Creamer] FOREIGN KEY([CreamerId])
REFERENCES [dbo].[Creamer] ([Id])
GO

ALTER TABLE [dbo].[Americano] CHECK CONSTRAINT [FK_Americano_Creamer]
GO

ALTER TABLE [dbo].[Americano]  WITH CHECK ADD  CONSTRAINT [FK_Americano_Milk] FOREIGN KEY([MilkId])
REFERENCES [dbo].[Milk] ([Id])
GO

ALTER TABLE [dbo].[Americano] CHECK CONSTRAINT [FK_Americano_Milk]
GO

ALTER TABLE [dbo].[Americano]  WITH CHECK ADD  CONSTRAINT [FK_Americano_Sugar] FOREIGN KEY([SugarId])
REFERENCES [dbo].[Sugar] ([Id])
GO

ALTER TABLE [dbo].[Americano] CHECK CONSTRAINT [FK_Americano_Sugar]
GO

ALTER TABLE [dbo].[Americano]  WITH CHECK ADD  CONSTRAINT [FK_Americano_Water] FOREIGN KEY([WaterId])
REFERENCES [dbo].[Water] ([Id])
GO

ALTER TABLE [dbo].[Americano] CHECK CONSTRAINT [FK_Americano_Water]
GO

-- ============================================================================
-- TABLE: Cappuccino
-- ============================================================================
IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Cappuccino' AND schema_id = SCHEMA_ID('dbo'))
	DROP TABLE [dbo].[Cappuccino]
GO

CREATE TABLE [dbo].[Cappuccino](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[WaterId] [uniqueidentifier] NOT NULL,
	[SugarId] [uniqueidentifier] NOT NULL,
	[MilkId] [uniqueidentifier] NOT NULL,
	[CaramelId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Cappuccino] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Cappuccino] ADD  CONSTRAINT [DF_Cappuccino_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[Cappuccino]  WITH CHECK ADD  CONSTRAINT [FK_Cappuccino_Caramel] FOREIGN KEY([CaramelId])
REFERENCES [dbo].[Caramel] ([Id])
GO

ALTER TABLE [dbo].[Cappuccino] CHECK CONSTRAINT [FK_Cappuccino_Caramel]
GO

ALTER TABLE [dbo].[Cappuccino]  WITH CHECK ADD  CONSTRAINT [FK_Cappuccino_Milk] FOREIGN KEY([MilkId])
REFERENCES [dbo].[Milk] ([Id])
GO

ALTER TABLE [dbo].[Cappuccino] CHECK CONSTRAINT [FK_Cappuccino_Milk]
GO

ALTER TABLE [dbo].[Cappuccino]  WITH CHECK ADD  CONSTRAINT [FK_Cappuccino_Sugar] FOREIGN KEY([SugarId])
REFERENCES [dbo].[Sugar] ([Id])
GO

ALTER TABLE [dbo].[Cappuccino] CHECK CONSTRAINT [FK_Cappuccino_Sugar]
GO

ALTER TABLE [dbo].[Cappuccino]  WITH CHECK ADD  CONSTRAINT [FK_Cappuccino_Water] FOREIGN KEY([WaterId])
REFERENCES [dbo].[Water] ([Id])
GO

ALTER TABLE [dbo].[Cappuccino] CHECK CONSTRAINT [FK_Cappuccino_Water]
GO

-- ============================================================================
-- TABLE: Espresso
-- ============================================================================
IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Espresso' AND schema_id = SCHEMA_ID('dbo'))
	DROP TABLE [dbo].[Espresso]
GO

CREATE TABLE [dbo].[Espresso](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[WaterId] [uniqueidentifier] NOT NULL,
	[SugarId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Espresso] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Espresso] ADD  CONSTRAINT [DF_Espresso_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[Espresso]  WITH CHECK ADD  CONSTRAINT [FK_Espresso_Sugar] FOREIGN KEY([SugarId])
REFERENCES [dbo].[Sugar] ([Id])
GO

ALTER TABLE [dbo].[Espresso] CHECK CONSTRAINT [FK_Espresso_Sugar]
GO

ALTER TABLE [dbo].[Espresso]  WITH CHECK ADD  CONSTRAINT [FK_Espresso_Water] FOREIGN KEY([WaterId])
REFERENCES [dbo].[Water] ([Id])
GO

ALTER TABLE [dbo].[Espresso] CHECK CONSTRAINT [FK_Espresso_Water]
GO

-- ============================================================================
-- TABLE: Latte
-- ============================================================================
IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Latte' AND schema_id = SCHEMA_ID('dbo'))
	DROP TABLE [dbo].[Latte]
GO

CREATE TABLE [dbo].[Latte](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[WaterId] [uniqueidentifier] NOT NULL,
	[SugarId] [uniqueidentifier] NOT NULL,
	[MilkId] [uniqueidentifier] NOT NULL,
	[CreamerId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Latte] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Latte] ADD  CONSTRAINT [DF_Latte_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[Latte]  WITH CHECK ADD  CONSTRAINT [FK_Latte_Creamer] FOREIGN KEY([CreamerId])
REFERENCES [dbo].[Creamer] ([Id])
GO

ALTER TABLE [dbo].[Latte] CHECK CONSTRAINT [FK_Latte_Creamer]
GO

ALTER TABLE [dbo].[Latte]  WITH CHECK ADD  CONSTRAINT [FK_Latte_Milk] FOREIGN KEY([MilkId])
REFERENCES [dbo].[Milk] ([Id])
GO

ALTER TABLE [dbo].[Latte] CHECK CONSTRAINT [FK_Latte_Milk]
GO

ALTER TABLE [dbo].[Latte]  WITH CHECK ADD  CONSTRAINT [FK_Latte_Sugar] FOREIGN KEY([SugarId])
REFERENCES [dbo].[Sugar] ([Id])
GO

ALTER TABLE [dbo].[Latte] CHECK CONSTRAINT [FK_Latte_Sugar]
GO

ALTER TABLE [dbo].[Latte]  WITH CHECK ADD  CONSTRAINT [FK_Latte_Water] FOREIGN KEY([WaterId])
REFERENCES [dbo].[Water] ([Id])
GO

ALTER TABLE [dbo].[Latte] CHECK CONSTRAINT [FK_Latte_Water]
GO

-- ============================================================================
-- TABLE: Macchiato
-- ============================================================================
IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Macchiato' AND schema_id = SCHEMA_ID('dbo'))
	DROP TABLE [dbo].[Macchiato]
GO

CREATE TABLE [dbo].[Macchiato](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[WaterId] [uniqueidentifier] NOT NULL,
	[SugarId] [uniqueidentifier] NOT NULL,
	[MilkId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Macchiato] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Macchiato] ADD  CONSTRAINT [DF_Macchiato_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[Macchiato]  WITH CHECK ADD  CONSTRAINT [FK_Macchiato_Milk] FOREIGN KEY([MilkId])
REFERENCES [dbo].[Milk] ([Id])
GO

ALTER TABLE [dbo].[Macchiato] CHECK CONSTRAINT [FK_Macchiato_Milk]
GO

ALTER TABLE [dbo].[Macchiato]  WITH CHECK ADD  CONSTRAINT [FK_Macchiato_Sugar] FOREIGN KEY([SugarId])
REFERENCES [dbo].[Sugar] ([Id])
GO

ALTER TABLE [dbo].[Macchiato] CHECK CONSTRAINT [FK_Macchiato_Sugar]
GO

ALTER TABLE [dbo].[Macchiato]  WITH CHECK ADD  CONSTRAINT [FK_Macchiato_Water] FOREIGN KEY([WaterId])
REFERENCES [dbo].[Water] ([Id])
GO

ALTER TABLE [dbo].[Macchiato] CHECK CONSTRAINT [FK_Macchiato_Water]
GO

-- ============================================================================
-- END OF COMPLETE SCHEMA SCRIPT WITH ALL CONSTRAINTS AND DROP CHECKS
-- ============================================================================
