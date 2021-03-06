USE [master]
GO
/****** Object:  Database [DAIsPizza]    Script Date: 5/16/2018 5:24:21 PM ******/
CREATE DATABASE [DAIsPizza]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DAIsPizza', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\DAIsPizza.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DAIsPizza_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\DAIsPizza_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DAIsPizza] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DAIsPizza].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DAIsPizza] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DAIsPizza] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DAIsPizza] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DAIsPizza] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DAIsPizza] SET ARITHABORT OFF 
GO
ALTER DATABASE [DAIsPizza] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DAIsPizza] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DAIsPizza] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DAIsPizza] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DAIsPizza] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DAIsPizza] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DAIsPizza] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DAIsPizza] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DAIsPizza] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DAIsPizza] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DAIsPizza] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DAIsPizza] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DAIsPizza] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DAIsPizza] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DAIsPizza] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DAIsPizza] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DAIsPizza] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DAIsPizza] SET RECOVERY FULL 
GO
ALTER DATABASE [DAIsPizza] SET  MULTI_USER 
GO
ALTER DATABASE [DAIsPizza] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DAIsPizza] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DAIsPizza] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DAIsPizza] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DAIsPizza] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DAIsPizza', N'ON'
GO
ALTER DATABASE [DAIsPizza] SET QUERY_STORE = OFF
GO
USE [DAIsPizza]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [DAIsPizza]
GO
/****** Object:  Table [dbo].[DoughTypes]    Script Date: 5/16/2018 5:24:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoughTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Price] [decimal](12, 6) NOT NULL,
 CONSTRAINT [PK_DoughTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingredients]    Script Date: 5/16/2018 5:24:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Price] [decimal](12, 6) NOT NULL,
 CONSTRAINT [PK_Ingredients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 5/16/2018 5:24:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[TotalPrice] [decimal](12, 6) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders_Ingredients]    Script Date: 5/16/2018 5:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders_Ingredients](
	[OrderId] [int] NOT NULL,
	[IngredientId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_Orders_Ingredients] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[IngredientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PizzaOrders]    Script Date: 5/16/2018 5:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PizzaOrders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[PizzaId] [int] NOT NULL,
	[SizeId] [int] NOT NULL,
	[DoughTypeId] [int] NOT NULL,
 CONSTRAINT [PK_PizzaOrders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pizzas]    Script Date: 5/16/2018 5:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pizzas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[PicturePath] [nvarchar](500) NULL,
 CONSTRAINT [PK_Pizzas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pizzas_Ingredients]    Script Date: 5/16/2018 5:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pizzas_Ingredients](
	[PizzaId] [int] NOT NULL,
	[IngredientId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_Pizzas_Ingredients] PRIMARY KEY CLUSTERED 
(
	[PizzaId] ASC,
	[IngredientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sizes]    Script Date: 5/16/2018 5:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sizes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Price] [decimal](12, 6) NOT NULL,
 CONSTRAINT [PK_Sizes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/16/2018 5:24:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](1000) NOT NULL,
	[Phone] [nvarchar](20) NULL,
	[PasswordHash] [nchar](64) NOT NULL,
	[PasswordSalt] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DoughTypes] ON 
GO
INSERT [dbo].[DoughTypes] ([Id], [Name], [Price]) VALUES (1, N'Traditional', CAST(0.000000 AS Decimal(12, 6)))
GO
INSERT [dbo].[DoughTypes] ([Id], [Name], [Price]) VALUES (2, N'Italian', CAST(0.000000 AS Decimal(12, 6)))
GO
INSERT [dbo].[DoughTypes] ([Id], [Name], [Price]) VALUES (3, N'Thin', CAST(0.000000 AS Decimal(12, 6)))
GO
INSERT [dbo].[DoughTypes] ([Id], [Name], [Price]) VALUES (4, N'Creamy', CAST(2.250000 AS Decimal(12, 6)))
GO
SET IDENTITY_INSERT [dbo].[DoughTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Ingredients] ON 
GO
INSERT [dbo].[Ingredients] ([Id], [Name], [Price]) VALUES (1, N'Chicken', CAST(2.000000 AS Decimal(12, 6)))
GO
INSERT [dbo].[Ingredients] ([Id], [Name], [Price]) VALUES (2, N'Pork', CAST(1.800000 AS Decimal(12, 6)))
GO
INSERT [dbo].[Ingredients] ([Id], [Name], [Price]) VALUES (3, N'Processed cheese', CAST(2.000000 AS Decimal(12, 6)))
GO
INSERT [dbo].[Ingredients] ([Id], [Name], [Price]) VALUES (4, N'Mozzarella', CAST(2.000000 AS Decimal(12, 6)))
GO
INSERT [dbo].[Ingredients] ([Id], [Name], [Price]) VALUES (5, N'Parmesan', CAST(2.000000 AS Decimal(12, 6)))
GO
INSERT [dbo].[Ingredients] ([Id], [Name], [Price]) VALUES (6, N'Feta', CAST(1.500000 AS Decimal(12, 6)))
GO
INSERT [dbo].[Ingredients] ([Id], [Name], [Price]) VALUES (7, N'Emmental', CAST(1.700000 AS Decimal(12, 6)))
GO
INSERT [dbo].[Ingredients] ([Id], [Name], [Price]) VALUES (8, N'Cheddar', CAST(2.500000 AS Decimal(12, 6)))
GO
INSERT [dbo].[Ingredients] ([Id], [Name], [Price]) VALUES (9, N'Peperoni', CAST(2.100000 AS Decimal(12, 6)))
GO
INSERT [dbo].[Ingredients] ([Id], [Name], [Price]) VALUES (10, N'Smoked ham', CAST(2.100000 AS Decimal(12, 6)))
GO
INSERT [dbo].[Ingredients] ([Id], [Name], [Price]) VALUES (11, N'Smoked bacon', CAST(1.500000 AS Decimal(12, 6)))
GO
INSERT [dbo].[Ingredients] ([Id], [Name], [Price]) VALUES (12, N'Mushrooms', CAST(0.800000 AS Decimal(12, 6)))
GO
INSERT [dbo].[Ingredients] ([Id], [Name], [Price]) VALUES (13, N'Onions', CAST(0.500000 AS Decimal(12, 6)))
GO
INSERT [dbo].[Ingredients] ([Id], [Name], [Price]) VALUES (14, N'Tomatoes', CAST(0.800000 AS Decimal(12, 6)))
GO
INSERT [dbo].[Ingredients] ([Id], [Name], [Price]) VALUES (15, N'Corn', CAST(0.700000 AS Decimal(12, 6)))
GO
INSERT [dbo].[Ingredients] ([Id], [Name], [Price]) VALUES (16, N'Spinach', CAST(1.000000 AS Decimal(12, 6)))
GO
INSERT [dbo].[Ingredients] ([Id], [Name], [Price]) VALUES (17, N'Tomato sauce', CAST(2.000000 AS Decimal(12, 6)))
GO
INSERT [dbo].[Ingredients] ([Id], [Name], [Price]) VALUES (18, N'Cream sauce', CAST(2.000000 AS Decimal(12, 6)))
GO
INSERT [dbo].[Ingredients] ([Id], [Name], [Price]) VALUES (19, N'Halapenos', CAST(1.000000 AS Decimal(12, 6)))
GO
SET IDENTITY_INSERT [dbo].[Ingredients] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 
GO
INSERT [dbo].[Orders] ([Id], [UserId], [TotalPrice]) VALUES (1, 1, CAST(12.900000 AS Decimal(12, 6)))
GO
INSERT [dbo].[Orders] ([Id], [UserId], [TotalPrice]) VALUES (2, 1, CAST(50.000000 AS Decimal(12, 6)))
GO
INSERT [dbo].[Orders] ([Id], [UserId], [TotalPrice]) VALUES (5, 2, CAST(15.900000 AS Decimal(12, 6)))
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
INSERT [dbo].[Orders_Ingredients] ([OrderId], [IngredientId], [Quantity]) VALUES (1, 4, 1)
GO
INSERT [dbo].[Orders_Ingredients] ([OrderId], [IngredientId], [Quantity]) VALUES (1, 17, 2)
GO
INSERT [dbo].[Orders_Ingredients] ([OrderId], [IngredientId], [Quantity]) VALUES (2, 1, 1)
GO
INSERT [dbo].[Orders_Ingredients] ([OrderId], [IngredientId], [Quantity]) VALUES (2, 4, 2)
GO
INSERT [dbo].[Orders_Ingredients] ([OrderId], [IngredientId], [Quantity]) VALUES (2, 6, 1)
GO
INSERT [dbo].[Orders_Ingredients] ([OrderId], [IngredientId], [Quantity]) VALUES (2, 17, 2)
GO
INSERT [dbo].[Orders_Ingredients] ([OrderId], [IngredientId], [Quantity]) VALUES (2, 18, 1)
GO
INSERT [dbo].[Orders_Ingredients] ([OrderId], [IngredientId], [Quantity]) VALUES (5, 4, 2)
GO
INSERT [dbo].[Orders_Ingredients] ([OrderId], [IngredientId], [Quantity]) VALUES (5, 17, 2)
GO
SET IDENTITY_INSERT [dbo].[PizzaOrders] ON 
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (1, 1, 1, 1, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (2, 2, 1, 1, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (5, 2, 3, 1, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (6, 2, 3, 2, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (8, 3, 1, 2, 2)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (9, 4, 1, 1, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (10, 4, 1, 1, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (11, 4, 3, 1, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (12, 4, 3, 2, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (13, 4, 1, 2, 2)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (14, 5, 1, 1, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (15, 5, 1, 1, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (16, 5, 3, 1, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (17, 5, 3, 2, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (18, 5, 1, 2, 2)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (19, 5, 1, 1, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (20, 5, 1, 1, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (21, 5, 3, 1, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (22, 5, 3, 2, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (23, 5, 1, 2, 2)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (24, 6, 1, 1, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (25, 6, 1, 1, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (26, 6, 3, 1, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (27, 6, 3, 2, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (28, 6, 1, 2, 2)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (29, 3, 5, 2, 2)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (30, 4, 5, 1, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (31, 4, 5, 1, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (32, 4, 5, 1, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (33, 4, 5, 2, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (34, 4, 5, 2, 2)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (35, 5, 5, 1, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (36, 5, 5, 1, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (37, 5, 5, 1, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (38, 5, 5, 2, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (39, 5, 5, 2, 2)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (40, 5, 5, 1, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (41, 3, 5, 2, 2)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (42, 4, 5, 1, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (43, 4, 5, 1, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (44, 4, 5, 1, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (45, 4, 5, 2, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (46, 4, 5, 2, 2)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (47, 5, 5, 1, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (48, 5, 5, 1, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (49, 5, 5, 1, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (50, 5, 5, 2, 1)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (51, 5, 5, 2, 2)
GO
INSERT [dbo].[PizzaOrders] ([Id], [OrderId], [PizzaId], [SizeId], [DoughTypeId]) VALUES (52, 5, 5, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[PizzaOrders] OFF
GO
SET IDENTITY_INSERT [dbo].[Pizzas] ON 
GO
INSERT [dbo].[Pizzas] ([Id], [Name], [Description], [PicturePath]) VALUES (1, N'Margaritta', N'A classic', N'https://www.dominos.bg/gallery/fmobile/1265medium.png')
GO
INSERT [dbo].[Pizzas] ([Id], [Name], [Description], [PicturePath]) VALUES (3, N'Alfredo', N'The Italian pasta, reimagined', N'https://www.dominos.bg/gallery/fmobile/1352large.png')
GO
INSERT [dbo].[Pizzas] ([Id], [Name], [Description], [PicturePath]) VALUES (4, N'American hot', N'It''s American, and it''s HOT!', N'https://www.dominos.bg/gallery/fmobile/1291large.png')
GO
INSERT [dbo].[Pizzas] ([Id], [Name], [Description], [PicturePath]) VALUES (5, N'Meat Mania', N'A lot of meat', N'https://www.dominos.bg/gallery/fmobile/1364large.png')
GO
SET IDENTITY_INSERT [dbo].[Pizzas] OFF
GO
INSERT [dbo].[Pizzas_Ingredients] ([PizzaId], [IngredientId], [Quantity]) VALUES (1, 4, 2)
GO
INSERT [dbo].[Pizzas_Ingredients] ([PizzaId], [IngredientId], [Quantity]) VALUES (1, 17, 1)
GO
INSERT [dbo].[Pizzas_Ingredients] ([PizzaId], [IngredientId], [Quantity]) VALUES (3, 1, 1)
GO
INSERT [dbo].[Pizzas_Ingredients] ([PizzaId], [IngredientId], [Quantity]) VALUES (3, 4, 1)
GO
INSERT [dbo].[Pizzas_Ingredients] ([PizzaId], [IngredientId], [Quantity]) VALUES (3, 16, 1)
GO
INSERT [dbo].[Pizzas_Ingredients] ([PizzaId], [IngredientId], [Quantity]) VALUES (3, 18, 1)
GO
INSERT [dbo].[Pizzas_Ingredients] ([PizzaId], [IngredientId], [Quantity]) VALUES (4, 4, 1)
GO
INSERT [dbo].[Pizzas_Ingredients] ([PizzaId], [IngredientId], [Quantity]) VALUES (4, 9, 1)
GO
INSERT [dbo].[Pizzas_Ingredients] ([PizzaId], [IngredientId], [Quantity]) VALUES (4, 13, 1)
GO
INSERT [dbo].[Pizzas_Ingredients] ([PizzaId], [IngredientId], [Quantity]) VALUES (4, 17, 1)
GO
INSERT [dbo].[Pizzas_Ingredients] ([PizzaId], [IngredientId], [Quantity]) VALUES (4, 19, 1)
GO
INSERT [dbo].[Pizzas_Ingredients] ([PizzaId], [IngredientId], [Quantity]) VALUES (5, 1, 1)
GO
INSERT [dbo].[Pizzas_Ingredients] ([PizzaId], [IngredientId], [Quantity]) VALUES (5, 4, 1)
GO
INSERT [dbo].[Pizzas_Ingredients] ([PizzaId], [IngredientId], [Quantity]) VALUES (5, 5, 2)
GO
INSERT [dbo].[Pizzas_Ingredients] ([PizzaId], [IngredientId], [Quantity]) VALUES (5, 10, 1)
GO
INSERT [dbo].[Pizzas_Ingredients] ([PizzaId], [IngredientId], [Quantity]) VALUES (5, 11, 1)
GO
INSERT [dbo].[Pizzas_Ingredients] ([PizzaId], [IngredientId], [Quantity]) VALUES (5, 17, 1)
GO
SET IDENTITY_INSERT [dbo].[Sizes] ON 
GO
INSERT [dbo].[Sizes] ([Id], [Name], [Price]) VALUES (1, N'Medium', CAST(6.000000 AS Decimal(12, 6)))
GO
INSERT [dbo].[Sizes] ([Id], [Name], [Price]) VALUES (2, N'Large', CAST(10.000000 AS Decimal(12, 6)))
GO
INSERT [dbo].[Sizes] ([Id], [Name], [Price]) VALUES (3, N'Extra Large', CAST(12.000000 AS Decimal(12, 6)))
GO
SET IDENTITY_INSERT [dbo].[Sizes] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [Username], [Address], [Phone], [PasswordHash], [PasswordSalt]) VALUES (1, N'admin', N'101, Al. Stamboliyski Blvd.', N'0000000000', N'2bb28071ee31f4834c9d46db4355623b48111bb63463d5dc108cebe71c5f9d32', N'zdooUYtRCE')
GO
INSERT [dbo].[Users] ([Id], [Username], [Address], [Phone], [PasswordHash], [PasswordSalt]) VALUES (2, N'user', N'The second garbage bin on the right', N'1234567890', N'18603752c1b7bc38be82c3f8ed0601ef009257e4b9eb98139862ff3bf15f0ab6', N'm2dsN5Ro6J')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Users_Username]    Script Date: 5/16/2018 5:24:22 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ_Users_Username] ON [dbo].[Users]
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DoughTypes] ADD  CONSTRAINT [DF_DoughTypes_Price]  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[Ingredients] ADD  CONSTRAINT [DF_Ingredients_Price]  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[Orders_Ingredients] ADD  CONSTRAINT [DF_Orders_Ingredients_Quantity]  DEFAULT ((1)) FOR [Quantity]
GO
ALTER TABLE [dbo].[Pizzas_Ingredients] ADD  CONSTRAINT [DF_Pizzas_Ingredients_Quantity]  DEFAULT ((1)) FOR [Quantity]
GO
ALTER TABLE [dbo].[Sizes] ADD  CONSTRAINT [DF_Sizes_Price]  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users]
GO
ALTER TABLE [dbo].[Orders_Ingredients]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Ingredients_Ingredients] FOREIGN KEY([IngredientId])
REFERENCES [dbo].[Ingredients] ([Id])
GO
ALTER TABLE [dbo].[Orders_Ingredients] CHECK CONSTRAINT [FK_Orders_Ingredients_Ingredients]
GO
ALTER TABLE [dbo].[Orders_Ingredients]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Ingredients_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[Orders_Ingredients] CHECK CONSTRAINT [FK_Orders_Ingredients_Orders]
GO
ALTER TABLE [dbo].[PizzaOrders]  WITH CHECK ADD  CONSTRAINT [FK_PizzaOrders_DoughTypes] FOREIGN KEY([DoughTypeId])
REFERENCES [dbo].[DoughTypes] ([Id])
GO
ALTER TABLE [dbo].[PizzaOrders] CHECK CONSTRAINT [FK_PizzaOrders_DoughTypes]
GO
ALTER TABLE [dbo].[PizzaOrders]  WITH CHECK ADD  CONSTRAINT [FK_PizzaOrders_Pizzas] FOREIGN KEY([PizzaId])
REFERENCES [dbo].[Pizzas] ([Id])
GO
ALTER TABLE [dbo].[PizzaOrders] CHECK CONSTRAINT [FK_PizzaOrders_Pizzas]
GO
ALTER TABLE [dbo].[PizzaOrders]  WITH CHECK ADD  CONSTRAINT [FK_PizzaOrders_Sizes] FOREIGN KEY([SizeId])
REFERENCES [dbo].[Sizes] ([Id])
GO
ALTER TABLE [dbo].[PizzaOrders] CHECK CONSTRAINT [FK_PizzaOrders_Sizes]
GO
ALTER TABLE [dbo].[Pizzas_Ingredients]  WITH CHECK ADD  CONSTRAINT [FK_Pizzas_Ingredients_Ingredients] FOREIGN KEY([IngredientId])
REFERENCES [dbo].[Ingredients] ([Id])
GO
ALTER TABLE [dbo].[Pizzas_Ingredients] CHECK CONSTRAINT [FK_Pizzas_Ingredients_Ingredients]
GO
ALTER TABLE [dbo].[Pizzas_Ingredients]  WITH CHECK ADD  CONSTRAINT [FK_Pizzas_Ingredients_Pizzas] FOREIGN KEY([PizzaId])
REFERENCES [dbo].[Pizzas] ([Id])
GO
ALTER TABLE [dbo].[Pizzas_Ingredients] CHECK CONSTRAINT [FK_Pizzas_Ingredients_Pizzas]
GO
USE [master]
GO
ALTER DATABASE [DAIsPizza] SET  READ_WRITE 
GO
