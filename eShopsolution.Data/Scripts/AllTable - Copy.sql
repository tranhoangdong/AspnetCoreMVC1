USE [master]
GO
/****** Object:  Database [FirstWebAppCore]    Script Date: 5/19/2025 9:56:38 PM ******/
CREATE DATABASE [FirstWebAppCore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FirstWebAppCore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\FirstWebAppCore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FirstWebAppCore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\FirstWebAppCore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [FirstWebAppCore] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FirstWebAppCore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FirstWebAppCore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FirstWebAppCore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FirstWebAppCore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FirstWebAppCore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FirstWebAppCore] SET ARITHABORT OFF 
GO
ALTER DATABASE [FirstWebAppCore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FirstWebAppCore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FirstWebAppCore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FirstWebAppCore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FirstWebAppCore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FirstWebAppCore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FirstWebAppCore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FirstWebAppCore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FirstWebAppCore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FirstWebAppCore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FirstWebAppCore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FirstWebAppCore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FirstWebAppCore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FirstWebAppCore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FirstWebAppCore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FirstWebAppCore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FirstWebAppCore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FirstWebAppCore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FirstWebAppCore] SET  MULTI_USER 
GO
ALTER DATABASE [FirstWebAppCore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FirstWebAppCore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FirstWebAppCore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FirstWebAppCore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FirstWebAppCore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FirstWebAppCore] SET QUERY_STORE = OFF
GO
USE [FirstWebAppCore]
GO
/****** Object:  Schema [identity]    Script Date: 5/19/2025 9:56:39 PM ******/
CREATE SCHEMA [identity]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 5/19/2025 9:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 5/19/2025 9:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ContentType] [nvarchar](max) NULL,
	[Data] [varbinary](max) NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 5/19/2025 9:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 5/19/2025 9:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomAndTableId] [int] NOT NULL,
	[OrderTime] [datetime] NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[Note] [nvarchar](250) NULL,
	[IsPaid] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 5/19/2025 9:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Stock] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomAndTable]    Script Date: 5/19/2025 9:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomAndTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Area] [nvarchar](255) NULL,
	[Quantity] [int] NOT NULL,
	[StatusId] [int] NULL,
	[Note] [nvarchar](500) NULL,
	[OrdinalNumber] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 5/19/2025 9:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wishlists]    Script Date: 5/19/2025 9:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wishlists](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](50) NOT NULL,
	[ProductId] [int] NOT NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [identity].[Role]    Script Date: 5/19/2025 9:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [identity].[Role](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [identity].[RoleClaims]    Script Date: 5/19/2025 9:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [identity].[RoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_RoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [identity].[User]    Script Date: 5/19/2025 9:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [identity].[User](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[UsernameChangeLimit] [int] NOT NULL,
	[ProfilePicture] [varbinary](max) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [identity].[UserClaims]    Script Date: 5/19/2025 9:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [identity].[UserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [identity].[UserLogins]    Script Date: 5/19/2025 9:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [identity].[UserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_UserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [identity].[UserRoles]    Script Date: 5/19/2025 9:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [identity].[UserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [identity].[UserTokens]    Script Date: 5/19/2025 9:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [identity].[UserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name]) VALUES (1, N'Food')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (2, N'Drink')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (3, NULL)
INSERT [dbo].[Category] ([Id], [Name]) VALUES (4, NULL)
INSERT [dbo].[Category] ([Id], [Name]) VALUES (5, N'đông')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (6, N'đông')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (7, N'dongtest')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (8, N'dong1')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 

INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [Price], [Total]) VALUES (2, 4, 6, 1, CAST(12.00 AS Decimal(18, 2)), CAST(12.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [Price], [Total]) VALUES (3, 5, 6, 1, CAST(12.00 AS Decimal(18, 2)), CAST(12.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [Price], [Total]) VALUES (4, 5, 7, 1, CAST(12.00 AS Decimal(18, 2)), CAST(12.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [Price], [Total]) VALUES (5, 5, 8, 1, CAST(12.00 AS Decimal(18, 2)), CAST(12.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [Quantity], [Price], [Total]) VALUES (6, 6, 4, 1, CAST(3333.00 AS Decimal(18, 2)), CAST(3333.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [RoomAndTableId], [OrderTime], [TotalAmount], [Note], [IsPaid]) VALUES (3, 1, CAST(N'2024-10-31T15:04:07.177' AS DateTime), CAST(100.00 AS Decimal(18, 2)), NULL, 0)
INSERT [dbo].[Orders] ([Id], [RoomAndTableId], [OrderTime], [TotalAmount], [Note], [IsPaid]) VALUES (4, 1, CAST(N'2024-11-02T15:24:37.513' AS DateTime), CAST(12.00 AS Decimal(18, 2)), NULL, 0)
INSERT [dbo].[Orders] ([Id], [RoomAndTableId], [OrderTime], [TotalAmount], [Note], [IsPaid]) VALUES (5, 1, CAST(N'2024-11-02T15:25:04.643' AS DateTime), CAST(36.00 AS Decimal(18, 2)), NULL, 0)
INSERT [dbo].[Orders] ([Id], [RoomAndTableId], [OrderTime], [TotalAmount], [Note], [IsPaid]) VALUES (6, 1, CAST(N'2024-11-28T16:30:10.277' AS DateTime), CAST(3333.00 AS Decimal(18, 2)), NULL, 0)
SET IDENTITY_INSERT [dbo].[Orders] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (4, N'43423', CAST(3333.00 AS Decimal(18, 2)), 333, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (5, N'555', CAST(3333.00 AS Decimal(18, 2)), 333, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (6, N'Product1', CAST(111.00 AS Decimal(18, 2)), 111, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (7, N'Product2', CAST(111.00 AS Decimal(18, 2)), 111, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (8, N'Product3', CAST(1.00 AS Decimal(18, 2)), 1, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (9, N'Product4', CAST(2.00 AS Decimal(18, 2)), 2, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (10, N'Product5', CAST(2.00 AS Decimal(18, 2)), 2, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (11, N'Product6', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (12, N'Product7', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (13, N'Product8', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (14, N'Product9', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (15, N'Product10', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (16, N'Product11', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (17, N'Product12', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (18, N'Product13', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (19, N'Product14', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (20, N'Product15', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (21, N'Product16', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (22, N'Product17', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (23, N'Product18', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (24, N'Product19', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (25, N'Product20', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (26, N'Product21', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (27, N'Product22', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (28, N'Product23', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (29, N'Product24', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (30, N'Product25', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (31, N'Product26', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (32, N'Product27', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (33, N'Product28', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (34, N'Product29', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (35, N'Product30', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (36, N'Product31', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (37, N'Product32', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (38, N'Product33', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (39, N'Product34', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (40, N'Product35', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (41, N'Product36', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (42, N'Product37', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (43, N'Product38', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (44, N'Product39', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (45, N'Product40', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (46, N'Product41', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (47, N'Product42', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (48, N'Product43', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (49, N'Product44', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (50, N'Product45', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (51, N'Product46', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (52, N'Product47', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (53, N'Product48', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (54, N'Product49', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (55, N'Product50', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (56, N'Product51', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (57, N'Product52', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (58, N'Product53', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (59, N'Product54', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (60, N'Product55', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (61, N'Product56', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (62, N'Product57', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (63, N'Product58', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (64, N'Product59', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (65, N'Product60', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (66, N'Product61', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (67, N'Product62', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (68, N'Product63', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (69, N'Product64', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (70, N'Product65', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (71, N'Product66', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (72, N'Product67', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (73, N'Product68', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (74, N'Product69', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (75, N'Product70', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (76, N'Product71', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (77, N'Product72', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (78, N'Product73', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (79, N'Product74', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (80, N'Product75', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (81, N'Product76', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (82, N'Product77', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (83, N'Product78', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (84, N'Product79', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (85, N'Product80', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (86, N'Product81', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (87, N'Product82', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (88, N'Product83', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (89, N'Product84', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (90, N'Product85', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (91, N'Product86', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (92, N'Product87', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (93, N'Product88', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (94, N'Product89', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (95, N'Product90', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (96, N'Product91', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (97, N'Product92', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (98, N'Product93', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (99, N'Product94', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (100, N'Product95', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (101, N'Product96', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (102, N'Product97', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
GO
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (103, N'Product98', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (104, N'Product99', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (105, N'Product100', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (106, N'Product101', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (107, N'Product102', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (108, N'Product103', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (109, N'Product104', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (110, N'Product105', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (111, N'Product106', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (112, N'Product107', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (113, N'Product108', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (114, N'Product109', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (115, N'Product110', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (116, N'Product111', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (117, N'Product112', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (118, N'Product113', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (119, N'Product114', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (120, N'Product115', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (121, N'Product116', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (122, N'Product117', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (123, N'Product118', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (124, N'Product119', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (125, N'Product120', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (126, N'Product121', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (127, N'Product122', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (128, N'Product123', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (129, N'Product124', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (130, N'Product125', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (131, N'Product126', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (132, N'Product127', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (133, N'Product128', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (134, N'Product129', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (135, N'Product130', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (136, N'Product131', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (137, N'Product132', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (138, N'Product133', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (139, N'Product134', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (140, N'Product135', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (141, N'Product136', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (142, N'Product137', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (143, N'Product138', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (144, N'Product139', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (145, N'Product140', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (146, N'Product141', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (147, N'Product142', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (148, N'Product143', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (149, N'Product144', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (150, N'Product145', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (151, N'Product146', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (152, N'Product147', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (153, N'Product148', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (154, N'Product149', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (155, N'Product150', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (156, N'Product151', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (157, N'Product152', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (158, N'Product153', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (159, N'Product154', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (160, N'Product155', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (161, N'Product156', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (162, N'Product157', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (163, N'Product158', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (164, N'Product159', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (165, N'Product160', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (166, N'Product161', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (167, N'Product162', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (168, N'Product163', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (169, N'Product164', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (170, N'Product165', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (171, N'Product166', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (172, N'Product167', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (173, N'Product168', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (174, N'Product169', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (175, N'Product170', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (176, N'Product171', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (177, N'Product172', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (178, N'Product173', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (179, N'Product174', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (180, N'Product175', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (181, N'Product176', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (182, N'Product177', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (183, N'Product178', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (184, N'Product179', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (185, N'Product180', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (186, N'Product181', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (187, N'Product182', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (188, N'Product183', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (189, N'Product184', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (190, N'Product185', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (191, N'Product186', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (192, N'Product187', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (193, N'Product188', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (194, N'Product189', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (195, N'Product190', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (196, N'Product191', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (197, N'Product192', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (198, N'Product193', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (199, N'Product194', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (200, N'Product195', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (201, N'Product196', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (202, N'Product197', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
GO
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (203, N'Product198', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (204, N'Product199', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (205, N'Product200', CAST(12.00 AS Decimal(18, 2)), 10, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (206, N'test', CAST(111.00 AS Decimal(18, 2)), 111, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (207, N'test1', CAST(1.00 AS Decimal(18, 2)), 1, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (208, N'dong', CAST(1.00 AS Decimal(18, 2)), 1, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (209, N'đông11111', CAST(1.00 AS Decimal(18, 2)), 1, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (210, N'dongtest', CAST(111.00 AS Decimal(18, 2)), 111, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (212, N'nullll', CAST(1.00 AS Decimal(18, 2)), 1, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (213, N'dongnull', CAST(1.00 AS Decimal(18, 2)), 1, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (214, N'đông', CAST(1.00 AS Decimal(18, 2)), 1, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (215, N'đông', CAST(1.00 AS Decimal(18, 2)), 1, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (216, N'1', CAST(1.00 AS Decimal(18, 2)), 1, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (217, N'dongqqqqqq', CAST(1.00 AS Decimal(18, 2)), 1, 1, 0)
INSERT [dbo].[Product] ([ID], [Name], [Price], [Stock], [CategoryId], [IsDeleted]) VALUES (218, N'đông222', CAST(1.00 AS Decimal(18, 2)), 1, 1, 0)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[RoomAndTable] ON 

INSERT [dbo].[RoomAndTable] ([Id], [Name], [Area], [Quantity], [StatusId], [Note], [OrdinalNumber]) VALUES (1, N'Room A', N'East', 10, 1, N'VIP room', 1)
INSERT [dbo].[RoomAndTable] ([Id], [Name], [Area], [Quantity], [StatusId], [Note], [OrdinalNumber]) VALUES (2, N'Room B', N'West', 8, 1, N'Standard room', 2)
INSERT [dbo].[RoomAndTable] ([Id], [Name], [Area], [Quantity], [StatusId], [Note], [OrdinalNumber]) VALUES (3, N'Room C', N'North', 12, 2, N'Meeting room', 3)
INSERT [dbo].[RoomAndTable] ([Id], [Name], [Area], [Quantity], [StatusId], [Note], [OrdinalNumber]) VALUES (4, N'Room D', N'South', 15, 2, N'Conference room', 4)
INSERT [dbo].[RoomAndTable] ([Id], [Name], [Area], [Quantity], [StatusId], [Note], [OrdinalNumber]) VALUES (5, N'Room E', N'Center', 5, 1, N'Small room', 5)
INSERT [dbo].[RoomAndTable] ([Id], [Name], [Area], [Quantity], [StatusId], [Note], [OrdinalNumber]) VALUES (6, N'Room A', N'East', 10, 1, N'VIP room', 1)
INSERT [dbo].[RoomAndTable] ([Id], [Name], [Area], [Quantity], [StatusId], [Note], [OrdinalNumber]) VALUES (7, N'Room B', N'West', 8, 1, N'Standard room', 2)
INSERT [dbo].[RoomAndTable] ([Id], [Name], [Area], [Quantity], [StatusId], [Note], [OrdinalNumber]) VALUES (8, N'Room C', N'North', 12, 2, N'Meeting room', 3)
INSERT [dbo].[RoomAndTable] ([Id], [Name], [Area], [Quantity], [StatusId], [Note], [OrdinalNumber]) VALUES (9, N'Room D', N'South', 15, 2, N'Conference room', 4)
INSERT [dbo].[RoomAndTable] ([Id], [Name], [Area], [Quantity], [StatusId], [Note], [OrdinalNumber]) VALUES (10, N'Room E', N'Center', 5, 1, N'Small room', 5)
SET IDENTITY_INSERT [dbo].[RoomAndTable] OFF
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([Id], [Name]) VALUES (1, N'Đang hoạt động')
INSERT [dbo].[Status] ([Id], [Name]) VALUES (2, N'Ngừng hoạt động')
SET IDENTITY_INSERT [dbo].[Status] OFF
INSERT [identity].[User] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [UsernameChangeLimit], [ProfilePicture]) VALUES (N'0823a844-485f-4e9f-97b0-cc5894d9e5f3', N'dongtran1002981', N'DONGTRAN1002981', N'dongtran1002981@gmail.com', N'DONGTRAN1002981@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEERwbrLMsJ0eVRRoCOPJyh1K6ITBiTjVWECuvY0/kqeCMMmfNo4n8UEXtmdkKxmDkg==', N'M2B6FPCUPQVSRKLGNAYRBA4ZRMT54YPH', N'8571b2e7-b3d7-47be-a572-0ff21c437ce1', NULL, 0, 0, NULL, 1, 0, N'dong', N'dong', 10, NULL)
INSERT [identity].[User] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [UsernameChangeLimit], [ProfilePicture]) VALUES (N'1afdb126-a311-40e7-8456-e5991e0d61e9', N'dongth', N'DONGTH', N'dongth@nichietsuvn.com', N'DONGTH@NICHIETSUVN.COM', 0, N'AQAAAAEAACcQAAAAEPSSEzipjLRSmFZv/BwOzZOqJF/xrgGhTkSQYx97MISwyqTMLAoxHRM1STpTCMDHMw==', N'YMZ2UQUNNCKMI5WSWZJ4YYGIFNHO4U2Y', N'ebf779dc-8c23-482a-94e3-9a3e8761d2ce', NULL, 0, 0, NULL, 1, 0, N'dong1', N'dong1', 10, NULL)
INSERT [identity].[User] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [UsernameChangeLimit], [ProfilePicture]) VALUES (N'2306edd9-9afd-46f5-967c-33efcf33628d', N'dam', N'DAM', N'dam@gmail.com', N'DAM@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEKrC8j5eU9rhPy5bEzZtmS+1QRRbasbqwMQhE6PJE9fgN1S4TOLqeY0/NFPWBdqTVg==', N'K4H2U5EXX2NYU72ET2K2IEVGZZFNSBZT', N'ed88f318-9c5e-436b-ba8c-248bc716e50e', NULL, 0, 0, NULL, 1, 0, N'Trần', N'Đảm', 10, NULL)
INSERT [identity].[User] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [UsernameChangeLimit], [ProfilePicture]) VALUES (N'451d84dd-6283-4ac9-8de2-dba5761b126a', N'tran.quoc.dam.0607', N'TRAN.QUOC.DAM.0607', N'tran.quoc.dam.0607@gmail.com', N'TRAN.QUOC.DAM.0607@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEETpMnXLxnvCrjhXwTF42FWISIHb8pFtftds5SxJ4n7aIC0vUhzpO4DqxkNaHMoL6A==', N'STHMUL3OSWWZ5CMBT3Q2BMKTHALQE7JP', N'2be85e42-3ac6-4d03-b6b4-494e2df5aa04', NULL, 0, 0, NULL, 1, 0, N'Trần', N'Buôl', 10, NULL)
INSERT [identity].[User] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [UsernameChangeLimit], [ProfilePicture]) VALUES (N'8a2c182f-b200-4df6-9087-a1d34aaac2db', N'dam111', N'DAM111', N'dam111@gmail.com', N'DAM111@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEBMzFRDhWrVQG5yhA5vCjM5UVsy0NCZEDyZNdVVzKzlyh86c3gQEXXjfGlogN8p8Ig==', N'X6LVEJFR5A2FQT4YL3DN6IZO4PN7NS53', N'7fd4e1a7-4f0a-4fff-af08-bff018e51476', NULL, 0, 0, NULL, 1, 0, N'dam1111', N'1', 10, NULL)
INSERT [identity].[User] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [UsernameChangeLimit], [ProfilePicture]) VALUES (N'8ce52bf5-7031-48f4-9b31-857e11683e3d', N'dongtran100298', N'DONGTRAN100298', N'dongtran100298@gmail.com', N'DONGTRAN100298@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAELA91K3onmaKgrVqu2RtVjB4ZSGzrd/fiAXHFB9k+19WE+TOHuC2Qu+bPNrHMUvdsg==', N'6D4YEXYN5MHTCN2UWKJX2TU3YZ3XTF34', N'6cd6006c-9cc5-4748-8580-90bf56c41a5f', NULL, 0, 0, NULL, 1, 0, N'dong', N'dong', 10, NULL)
INSERT [identity].[User] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [UsernameChangeLimit], [ProfilePicture]) VALUES (N'959df6be-c64d-472f-8d21-47500c3bf4c5', N'dongtran123', N'DONGTRAN123', N'dongtran123@gmail.com', N'DONGTRAN123@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEB7JaWD7FG2FQcfHlPkJO9yAfXEKixsev8Xqx/lmnZYO9Z8S7Xz+r0f90cIkjoJkDg==', N'EDIWXB3AOMSQXRJMUV6UGIYRRPFY4F5Z', N'730e52bd-0ce7-4c55-92b2-a34514ea6b12', NULL, 0, 0, NULL, 1, 0, N'dong123', N'dong123', 10, NULL)
INSERT [identity].[User] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [UsernameChangeLimit], [ProfilePicture]) VALUES (N'c7f3ed2f-3798-4a53-8cf9-23ccf27120c9', N'tran.quoc.dam.0606', N'TRAN.QUOC.DAM.0606', N'tran.quoc.dam.0606@gmail.com', N'TRAN.QUOC.DAM.0606@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEGyV7r+/tDRIi7e3OInw/Y8JXE84eVBHMUzO42Bw1RqVG5EEabnVJ+Tar62zjjNqVg==', N'4LQXAXV2UTDBDQ6GEZADRWM7D4KETDNN', N'00ffba8d-9aa3-4cd6-9f87-c683c2a6a912', NULL, 0, 0, NULL, 1, 0, N'Tran', N'Dam', 10, NULL)
INSERT [identity].[User] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [UsernameChangeLimit], [ProfilePicture]) VALUES (N'e8401490-d65f-467f-a49d-ce041e83d4c4', N'may', N'MAY', N'may@gmail.com', N'MAY@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAELpo4G9ZdCnV3oa8FLHnGGAodZBcT2PJA/+422gtHwoEwYpdx4nmjdxCcu3Pm0KgQA==', N'WKAZBCRHJDTXIOU5W4IFVYXZTWFHKJOI', N'ad05c042-a731-4f6d-a887-4dec42ce0733', NULL, 0, 0, NULL, 1, 0, N'may', N'phuong', 10, NULL)
INSERT [identity].[User] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [UsernameChangeLimit], [ProfilePicture]) VALUES (N'f3c9a9c2-50f2-4c8c-b120-1082eaf4f51a', N'dong', N'DONG', N'dong@gmail.com', N'DONG@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEMKmeXYAEJp/BKQHXDEJfw5Mlj+ZcKMIrZTI+QlevfdoO+bhghU2Lf7JXSbMj3QNjw==', N'BPYDTBPMG3Q2DRQW5N3GWIWNSCA2F4VZ', N'd8e6ed23-8fac-42e7-9064-d6e59aa0c47e', NULL, 0, 0, NULL, 1, 0, N'tran', N'dong', 10, NULL)
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ((0)) FOR [IsPaid]
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Wishlists] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Image]  WITH CHECK ADD  CONSTRAINT [FK_Image_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Image] CHECK CONSTRAINT [FK_Image_Product_ProductId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([RoomAndTableId])
REFERENCES [dbo].[RoomAndTable] ([Id])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category_CategoryId]
GO
ALTER TABLE [dbo].[RoomAndTable]  WITH CHECK ADD  CONSTRAINT [FK_RoomAndTable_Status] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([Id])
GO
ALTER TABLE [dbo].[RoomAndTable] CHECK CONSTRAINT [FK_RoomAndTable_Status]
GO
ALTER TABLE [dbo].[Wishlists]  WITH CHECK ADD  CONSTRAINT [FK_Wishlists_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[Wishlists] CHECK CONSTRAINT [FK_Wishlists_Products]
GO
ALTER TABLE [identity].[RoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_RoleClaims_Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [identity].[Role] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [identity].[RoleClaims] CHECK CONSTRAINT [FK_RoleClaims_Role_RoleId]
GO
ALTER TABLE [identity].[UserClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserClaims_User_UserId] FOREIGN KEY([UserId])
REFERENCES [identity].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [identity].[UserClaims] CHECK CONSTRAINT [FK_UserClaims_User_UserId]
GO
ALTER TABLE [identity].[UserLogins]  WITH CHECK ADD  CONSTRAINT [FK_UserLogins_User_UserId] FOREIGN KEY([UserId])
REFERENCES [identity].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [identity].[UserLogins] CHECK CONSTRAINT [FK_UserLogins_User_UserId]
GO
ALTER TABLE [identity].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [identity].[Role] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [identity].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Role_RoleId]
GO
ALTER TABLE [identity].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_User_UserId] FOREIGN KEY([UserId])
REFERENCES [identity].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [identity].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_User_UserId]
GO
ALTER TABLE [identity].[UserTokens]  WITH CHECK ADD  CONSTRAINT [FK_UserTokens_User_UserId] FOREIGN KEY([UserId])
REFERENCES [identity].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [identity].[UserTokens] CHECK CONSTRAINT [FK_UserTokens_User_UserId]
GO
/****** Object:  StoredProcedure [dbo].[AddCategory]    Script Date: 5/19/2025 9:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddCategory]
    @Name NVARCHAR(255)
AS
BEGIN
    INSERT INTO Categories (Name)
    VALUES (@Name);
END;
GO
/****** Object:  StoredProcedure [dbo].[AddCategory1]    Script Date: 5/19/2025 9:56:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddCategory1]
    @Name NVARCHAR(255)
AS
BEGIN
    INSERT INTO Category (Name)
    VALUES (@Name);
END;
GO
USE [master]
GO
ALTER DATABASE [FirstWebAppCore] SET  READ_WRITE 
GO
