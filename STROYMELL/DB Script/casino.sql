USE [master]
GO
/****** Object:  Database [casino]    Script Date: 24.09.2024 15:10:39 ******/
CREATE DATABASE [casino]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'casino', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\casino.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'casino_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\casino_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [casino] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [casino].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [casino] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [casino] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [casino] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [casino] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [casino] SET ARITHABORT OFF 
GO
ALTER DATABASE [casino] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [casino] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [casino] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [casino] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [casino] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [casino] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [casino] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [casino] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [casino] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [casino] SET  DISABLE_BROKER 
GO
ALTER DATABASE [casino] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [casino] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [casino] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [casino] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [casino] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [casino] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [casino] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [casino] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [casino] SET  MULTI_USER 
GO
ALTER DATABASE [casino] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [casino] SET DB_CHAINING OFF 
GO
ALTER DATABASE [casino] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [casino] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [casino] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [casino] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'casino', N'ON'
GO
ALTER DATABASE [casino] SET QUERY_STORE = OFF
GO
USE [casino]
GO
/****** Object:  Table [dbo].[FundsDeposits]    Script Date: 24.09.2024 15:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FundsDeposits](
	[ID_FundsDeposit] [int] IDENTITY(1,1) NOT NULL,
	[TypeTransaction] [nvarchar](50) NULL,
	[Amount] [float] NULL,
	[ID_Transaction] [int] NULL,
 CONSTRAINT [PK_FundsDeposits] PRIMARY KEY CLUSTERED 
(
	[ID_FundsDeposit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FundsWithdrawals]    Script Date: 24.09.2024 15:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FundsWithdrawals](
	[ID_FundsWithdrawl] [int] IDENTITY(1,1) NOT NULL,
	[TypeTransaction] [nvarchar](50) NULL,
	[Amount] [float] NULL,
	[ID_Transaction] [int] NULL,
 CONSTRAINT [PK_FundsWithdrawals] PRIMARY KEY CLUSTERED 
(
	[ID_FundsWithdrawl] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HistoryRounds]    Script Date: 24.09.2024 15:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistoryRounds](
	[ID_HistoryRound] [int] IDENTITY(1,1) NOT NULL,
	[Bet] [float] NULL,
	[Reward] [float] NULL,
	[Сoefficient] [float] NULL,
	[Outcome] [nvarchar](40) NULL,
	[ID_Round] [int] NULL,
	[ID_HistoryMatch] [int] NULL,
 CONSTRAINT [PK_HistoryRounds] PRIMARY KEY CLUSTERED 
(
	[ID_HistoryRound] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HostoryMatches]    Script Date: 24.09.2024 15:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HostoryMatches](
	[ID_HistoryMatch] [int] IDENTITY(1,1) NOT NULL,
	[TotalWins] [float] NULL,
	[ID_User] [int] NULL,
	[ID_Match] [int] NULL,
 CONSTRAINT [PK_HostoryMatches] PRIMARY KEY CLUSTERED 
(
	[ID_HistoryMatch] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Matches]    Script Date: 24.09.2024 15:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Matches](
	[ID_Match] [int] IDENTITY(1,1) NOT NULL,
	[QuantityRounds] [int] NULL,
	[Deposit] [float] NULL,
	[TotalWin] [float] NULL,
	[CreatedAt] [datetime] NULL,
 CONSTRAINT [PK_Matches] PRIMARY KEY CLUSTERED 
(
	[ID_Match] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reports]    Script Date: 24.09.2024 15:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reports](
	[ID_Report] [int] IDENTITY(1,1) NOT NULL,
	[ReportType] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NULL,
	[ID_User] [int] NULL,
 CONSTRAINT [PK_Reports] PRIMARY KEY CLUSTERED 
(
	[ID_Report] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 24.09.2024 15:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ID_Role] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[ID_Role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rounds]    Script Date: 24.09.2024 15:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rounds](
	[ID_Round] [int] IDENTITY(1,1) NOT NULL,
	[Bet] [float] NULL,
	[Сoefficient] [float] NULL,
	[Outcome] [nvarchar](40) NULL,
	[Reward] [float] NULL,
	[ID_Match] [int] NULL,
 CONSTRAINT [PK_Rounds] PRIMARY KEY CLUSTERED 
(
	[ID_Round] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 24.09.2024 15:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[ID_Transaction] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime] NULL,
	[ID_User] [int] NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[ID_Transaction] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 24.09.2024 15:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID_User] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](40) NULL,
	[Password] [nvarchar](40) NULL,
	[Balance] [float] NULL,
	[CreatedAt] [datetime] NULL,
	[ID_Role] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID_User] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FundsDeposits] ON 

INSERT [dbo].[FundsDeposits] ([ID_FundsDeposit], [TypeTransaction], [Amount], [ID_Transaction]) VALUES (3, N'Пополнение', 10000, 5)
INSERT [dbo].[FundsDeposits] ([ID_FundsDeposit], [TypeTransaction], [Amount], [ID_Transaction]) VALUES (4, N'Пополнение', 10000, 7)
SET IDENTITY_INSERT [dbo].[FundsDeposits] OFF
GO
SET IDENTITY_INSERT [dbo].[FundsWithdrawals] ON 

INSERT [dbo].[FundsWithdrawals] ([ID_FundsWithdrawl], [TypeTransaction], [Amount], [ID_Transaction]) VALUES (3, N'Вывод', 5000, 6)
SET IDENTITY_INSERT [dbo].[FundsWithdrawals] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([ID_Role], [Title]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([ID_Role], [Title]) VALUES (2, N'Default')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Transactions] ON 

INSERT [dbo].[Transactions] ([ID_Transaction], [CreatedAt], [ID_User]) VALUES (5, CAST(N'2024-09-24T00:00:00.000' AS DateTime), 8)
INSERT [dbo].[Transactions] ([ID_Transaction], [CreatedAt], [ID_User]) VALUES (6, CAST(N'2024-09-24T00:00:00.000' AS DateTime), 8)
INSERT [dbo].[Transactions] ([ID_Transaction], [CreatedAt], [ID_User]) VALUES (7, CAST(N'2024-09-24T00:00:00.000' AS DateTime), 9)
SET IDENTITY_INSERT [dbo].[Transactions] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID_User], [Login], [Password], [Balance], [CreatedAt], [ID_Role]) VALUES (8, N'admin', N'admin', 8550, CAST(N'2024-09-24T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Users] ([ID_User], [Login], [Password], [Balance], [CreatedAt], [ID_Role]) VALUES (9, N'user', N'user', 10000, CAST(N'2024-09-24T00:00:00.000' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Reports] ADD  CONSTRAINT [DF_Reports_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Balance]  DEFAULT ((0)) FOR [Balance]
GO
ALTER TABLE [dbo].[FundsDeposits]  WITH CHECK ADD  CONSTRAINT [FK_FundsDeposits_Transactions] FOREIGN KEY([ID_Transaction])
REFERENCES [dbo].[Transactions] ([ID_Transaction])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[FundsDeposits] CHECK CONSTRAINT [FK_FundsDeposits_Transactions]
GO
ALTER TABLE [dbo].[FundsWithdrawals]  WITH CHECK ADD  CONSTRAINT [FK_FundsWithdrawals_Transactions] FOREIGN KEY([ID_Transaction])
REFERENCES [dbo].[Transactions] ([ID_Transaction])
GO
ALTER TABLE [dbo].[FundsWithdrawals] CHECK CONSTRAINT [FK_FundsWithdrawals_Transactions]
GO
ALTER TABLE [dbo].[HistoryRounds]  WITH CHECK ADD  CONSTRAINT [FK_HistoryRounds_HostoryMatches] FOREIGN KEY([ID_HistoryMatch])
REFERENCES [dbo].[HostoryMatches] ([ID_HistoryMatch])
GO
ALTER TABLE [dbo].[HistoryRounds] CHECK CONSTRAINT [FK_HistoryRounds_HostoryMatches]
GO
ALTER TABLE [dbo].[HistoryRounds]  WITH CHECK ADD  CONSTRAINT [FK_HistoryRounds_Rounds] FOREIGN KEY([ID_Round])
REFERENCES [dbo].[Rounds] ([ID_Round])
GO
ALTER TABLE [dbo].[HistoryRounds] CHECK CONSTRAINT [FK_HistoryRounds_Rounds]
GO
ALTER TABLE [dbo].[HostoryMatches]  WITH CHECK ADD  CONSTRAINT [FK_HostoryMatches_Matches] FOREIGN KEY([ID_Match])
REFERENCES [dbo].[Matches] ([ID_Match])
GO
ALTER TABLE [dbo].[HostoryMatches] CHECK CONSTRAINT [FK_HostoryMatches_Matches]
GO
ALTER TABLE [dbo].[HostoryMatches]  WITH CHECK ADD  CONSTRAINT [FK_HostoryMatches_Users] FOREIGN KEY([ID_User])
REFERENCES [dbo].[Users] ([ID_User])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HostoryMatches] CHECK CONSTRAINT [FK_HostoryMatches_Users]
GO
ALTER TABLE [dbo].[Reports]  WITH CHECK ADD  CONSTRAINT [FK_Reports_Users] FOREIGN KEY([ID_User])
REFERENCES [dbo].[Users] ([ID_User])
GO
ALTER TABLE [dbo].[Reports] CHECK CONSTRAINT [FK_Reports_Users]
GO
ALTER TABLE [dbo].[Rounds]  WITH CHECK ADD  CONSTRAINT [FK_Rounds_Matches] FOREIGN KEY([ID_Match])
REFERENCES [dbo].[Matches] ([ID_Match])
GO
ALTER TABLE [dbo].[Rounds] CHECK CONSTRAINT [FK_Rounds_Matches]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Users] FOREIGN KEY([ID_User])
REFERENCES [dbo].[Users] ([ID_User])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([ID_Role])
REFERENCES [dbo].[Roles] ([ID_Role])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
USE [master]
GO
ALTER DATABASE [casino] SET  READ_WRITE 
GO
