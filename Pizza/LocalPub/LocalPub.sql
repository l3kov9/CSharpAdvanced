USE [master]
GO
/****** Object:  Database [LocalPub]    Script Date: 5/23/2018 5:29:05 PM ******/
CREATE DATABASE [LocalPub]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LocalPub', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\LocalPub.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LocalPub_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\LocalPub_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [LocalPub] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LocalPub].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LocalPub] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LocalPub] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LocalPub] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LocalPub] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LocalPub] SET ARITHABORT OFF 
GO
ALTER DATABASE [LocalPub] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LocalPub] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LocalPub] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LocalPub] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LocalPub] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LocalPub] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LocalPub] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LocalPub] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LocalPub] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LocalPub] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LocalPub] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LocalPub] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LocalPub] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LocalPub] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LocalPub] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LocalPub] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LocalPub] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LocalPub] SET RECOVERY FULL 
GO
ALTER DATABASE [LocalPub] SET  MULTI_USER 
GO
ALTER DATABASE [LocalPub] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LocalPub] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LocalPub] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LocalPub] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LocalPub] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'LocalPub', N'ON'
GO
ALTER DATABASE [LocalPub] SET QUERY_STORE = OFF
GO
USE [LocalPub]
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
USE [LocalPub]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 5/23/2018 5:29:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Username] [nvarchar](50) NOT NULL,
	[PasswordHash] [nchar](64) NOT NULL,
	[PasswordSalt] [nchar](10) NOT NULL,
	[ClientTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientTypes]    Script Date: 5/23/2018 5:29:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NULL,
 CONSTRAINT [PK_ClientTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meals]    Script Date: 5/23/2018 5:29:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[MealTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Meals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MealTypes]    Script Date: 5/23/2018 5:29:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MealTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_MealTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderMeals]    Script Date: 5/23/2018 5:29:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderMeals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[MealId] [int] NOT NULL,
 CONSTRAINT [PK_OrderMeals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 5/23/2018 5:29:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[OrderDate] [date] NOT NULL,
	[IsCancelled] [bit] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clients] ON 
GO
INSERT [dbo].[Clients] ([Id], [Name], [Username], [PasswordHash], [PasswordSalt], [ClientTypeId]) VALUES (1, N'Гошо Админчето', N'admin', N'b8fe18df23194e299dbaf57f3b34748e41870eae36b843381567ec06216b9bea', N'HZa1oMgqQB', 2)
GO
INSERT [dbo].[Clients] ([Id], [Name], [Username], [PasswordHash], [PasswordSalt], [ClientTypeId]) VALUES (3, N'Пешо Клиентчето', N'pesho', N'934735d54622fa19468705cc055098f1201b0d1d39bb4663c06befa2da329e68', N'jnWBCrmU4K', 1)
GO
INSERT [dbo].[Clients] ([Id], [Name], [Username], [PasswordHash], [PasswordSalt], [ClientTypeId]) VALUES (14, N'Гинка', N'ginka', N'934735d54622fa19468705cc055098f1201b0d1d39bb4663c06befa2da329e68', N'jnWBCrmU4K', 2)
GO
SET IDENTITY_INSERT [dbo].[Clients] OFF
GO
SET IDENTITY_INSERT [dbo].[ClientTypes] ON 
GO
INSERT [dbo].[ClientTypes] ([Id], [Name]) VALUES (1, N'Обикновен')
GO
INSERT [dbo].[ClientTypes] ([Id], [Name]) VALUES (2, N'Връзкар')
GO
SET IDENTITY_INSERT [dbo].[ClientTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Meals] ON 
GO
INSERT [dbo].[Meals] ([Id], [Name], [MealTypeId]) VALUES (1, N'Задушени картофи с копър', 1)
GO
INSERT [dbo].[Meals] ([Id], [Name], [MealTypeId]) VALUES (2, N'Омлет „Асорти”', 1)
GO
INSERT [dbo].[Meals] ([Id], [Name], [MealTypeId]) VALUES (3, N'Пилешки филенца с корнфлейкс', 1)
GO
INSERT [dbo].[Meals] ([Id], [Name], [MealTypeId]) VALUES (4, N'Пържени картофи', 1)
GO
INSERT [dbo].[Meals] ([Id], [Name], [MealTypeId]) VALUES (5, N'Тиквички с млечен сос', 1)
GO
INSERT [dbo].[Meals] ([Id], [Name], [MealTypeId]) VALUES (6, N'Пилешко филе', 2)
GO
INSERT [dbo].[Meals] ([Id], [Name], [MealTypeId]) VALUES (7, N'Тортила с пилешко', 2)
GO
INSERT [dbo].[Meals] ([Id], [Name], [MealTypeId]) VALUES (8, N'Ризото на рибаря', 2)
GO
INSERT [dbo].[Meals] ([Id], [Name], [MealTypeId]) VALUES (9, N'Спагети с вонголе', 2)
GO
INSERT [dbo].[Meals] ([Id], [Name], [MealTypeId]) VALUES (10, N'Риба меч в тиган с бяло вино', 2)
GO
INSERT [dbo].[Meals] ([Id], [Name], [MealTypeId]) VALUES (11, N'Банофи', 3)
GO
INSERT [dbo].[Meals] ([Id], [Name], [MealTypeId]) VALUES (12, N'Бонбон с моркови, фурми и орехи', 3)
GO
INSERT [dbo].[Meals] ([Id], [Name], [MealTypeId]) VALUES (13, N'Домашен бонбон с боровинки и кокос', 3)
GO
INSERT [dbo].[Meals] ([Id], [Name], [MealTypeId]) VALUES (14, N'Домашен шоколадов трюфел', 3)
GO
INSERT [dbo].[Meals] ([Id], [Name], [MealTypeId]) VALUES (15, N'Сладък салам', 3)
GO
SET IDENTITY_INSERT [dbo].[Meals] OFF
GO
SET IDENTITY_INSERT [dbo].[MealTypes] ON 
GO
INSERT [dbo].[MealTypes] ([Id], [Name]) VALUES (1, N'Предястие')
GO
INSERT [dbo].[MealTypes] ([Id], [Name]) VALUES (2, N'Основно ястие')
GO
INSERT [dbo].[MealTypes] ([Id], [Name]) VALUES (3, N'Десерт')
GO
SET IDENTITY_INSERT [dbo].[MealTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderMeals] ON 
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (1, 1, 2)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (2, 1, 7)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (3, 1, 14)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (4, 2, 2)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (5, 2, 7)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (6, 2, 14)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (7, 2, 15)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (8, 3, 2)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (9, 3, 8)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (10, 3, 14)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (14, 6, 2)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (15, 6, 8)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (16, 6, 14)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (17, 7, 1)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (18, 7, 9)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (19, 7, 11)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (20, 8, 1)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (21, 8, 6)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (22, 8, 12)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (23, 11, 2)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (24, 11, 8)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (25, 11, 13)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (26, 12, 14)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (27, 13, 15)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (28, 13, 15)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (29, 14, 1)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (30, 14, 7)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (31, 14, 12)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (32, 15, 1)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (33, 15, 7)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (34, 15, 11)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (35, 16, 1)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (36, 16, 6)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (37, 16, 12)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (38, 16, 14)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (39, 17, 1)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (40, 17, 6)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (41, 17, 13)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (42, 18, 8)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (43, 19, 2)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (44, 19, 7)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (45, 19, 12)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (46, 20, 3)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (47, 21, 1)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (48, 21, 7)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (49, 21, 12)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (50, 22, 1)
GO
INSERT [dbo].[OrderMeals] ([Id], [OrderId], [MealId]) VALUES (51, 23, 3)
GO
SET IDENTITY_INSERT [dbo].[OrderMeals] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 
GO
INSERT [dbo].[Orders] ([Id], [ClientId], [OrderDate], [IsCancelled]) VALUES (1, 1, CAST(N'2018-05-20' AS Date), 1)
GO
INSERT [dbo].[Orders] ([Id], [ClientId], [OrderDate], [IsCancelled]) VALUES (2, 1, CAST(N'2018-05-21' AS Date), 0)
GO
INSERT [dbo].[Orders] ([Id], [ClientId], [OrderDate], [IsCancelled]) VALUES (3, 3, CAST(N'2018-05-20' AS Date), 0)
GO
INSERT [dbo].[Orders] ([Id], [ClientId], [OrderDate], [IsCancelled]) VALUES (6, 1, CAST(N'2018-05-22' AS Date), 1)
GO
INSERT [dbo].[Orders] ([Id], [ClientId], [OrderDate], [IsCancelled]) VALUES (7, 1, CAST(N'2018-05-23' AS Date), 0)
GO
INSERT [dbo].[Orders] ([Id], [ClientId], [OrderDate], [IsCancelled]) VALUES (8, 3, CAST(N'2018-05-23' AS Date), 1)
GO
INSERT [dbo].[Orders] ([Id], [ClientId], [OrderDate], [IsCancelled]) VALUES (11, 1, CAST(N'2018-05-23' AS Date), 0)
GO
INSERT [dbo].[Orders] ([Id], [ClientId], [OrderDate], [IsCancelled]) VALUES (12, 14, CAST(N'2018-05-20' AS Date), 0)
GO
INSERT [dbo].[Orders] ([Id], [ClientId], [OrderDate], [IsCancelled]) VALUES (13, 14, CAST(N'2018-05-21' AS Date), 0)
GO
INSERT [dbo].[Orders] ([Id], [ClientId], [OrderDate], [IsCancelled]) VALUES (14, 14, CAST(N'2018-05-23' AS Date), 1)
GO
INSERT [dbo].[Orders] ([Id], [ClientId], [OrderDate], [IsCancelled]) VALUES (15, 14, CAST(N'2018-05-23' AS Date), 0)
GO
INSERT [dbo].[Orders] ([Id], [ClientId], [OrderDate], [IsCancelled]) VALUES (16, 1, CAST(N'2018-05-23' AS Date), 0)
GO
INSERT [dbo].[Orders] ([Id], [ClientId], [OrderDate], [IsCancelled]) VALUES (17, 3, CAST(N'2018-05-23' AS Date), 0)
GO
INSERT [dbo].[Orders] ([Id], [ClientId], [OrderDate], [IsCancelled]) VALUES (18, 1, CAST(N'2018-05-11' AS Date), 0)
GO
INSERT [dbo].[Orders] ([Id], [ClientId], [OrderDate], [IsCancelled]) VALUES (19, 1, CAST(N'2018-05-19' AS Date), 1)
GO
INSERT [dbo].[Orders] ([Id], [ClientId], [OrderDate], [IsCancelled]) VALUES (20, 1, CAST(N'2018-05-19' AS Date), 0)
GO
INSERT [dbo].[Orders] ([Id], [ClientId], [OrderDate], [IsCancelled]) VALUES (21, 3, CAST(N'2018-05-10' AS Date), 0)
GO
INSERT [dbo].[Orders] ([Id], [ClientId], [OrderDate], [IsCancelled]) VALUES (22, 3, CAST(N'2018-04-30' AS Date), 1)
GO
INSERT [dbo].[Orders] ([Id], [ClientId], [OrderDate], [IsCancelled]) VALUES (23, 1, CAST(N'2018-04-30' AS Date), 0)
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Clients_Username]    Script Date: 5/23/2018 5:29:05 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ_Clients_Username] ON [dbo].[Clients]
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_IsCancelled]  DEFAULT ((0)) FOR [IsCancelled]
GO
ALTER TABLE [dbo].[Clients]  WITH CHECK ADD  CONSTRAINT [FK_Clients_ClientTypes] FOREIGN KEY([ClientTypeId])
REFERENCES [dbo].[ClientTypes] ([Id])
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [FK_Clients_ClientTypes]
GO
ALTER TABLE [dbo].[Meals]  WITH CHECK ADD  CONSTRAINT [FK_Meals_MealTypes] FOREIGN KEY([MealTypeId])
REFERENCES [dbo].[MealTypes] ([Id])
GO
ALTER TABLE [dbo].[Meals] CHECK CONSTRAINT [FK_Meals_MealTypes]
GO
ALTER TABLE [dbo].[OrderMeals]  WITH CHECK ADD  CONSTRAINT [FK_OrderMeals_Meals] FOREIGN KEY([MealId])
REFERENCES [dbo].[Meals] ([Id])
GO
ALTER TABLE [dbo].[OrderMeals] CHECK CONSTRAINT [FK_OrderMeals_Meals]
GO
ALTER TABLE [dbo].[OrderMeals]  WITH CHECK ADD  CONSTRAINT [FK_OrderMeals_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[OrderMeals] CHECK CONSTRAINT [FK_OrderMeals_Orders]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Clients_Id] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Clients_Id]
GO
ALTER TABLE [dbo].[Clients]  WITH CHECK ADD  CONSTRAINT [CK_Clients_Username] CHECK  ((len([Username])>=(5)))
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [CK_Clients_Username]
GO
USE [master]
GO
ALTER DATABASE [LocalPub] SET  READ_WRITE 
GO
