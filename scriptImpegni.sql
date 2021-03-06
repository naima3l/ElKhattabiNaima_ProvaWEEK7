USE [master]
GO
/****** Object:  Database [Impegni]    Script Date: 8/27/2021 12:24:11 PM ******/
CREATE DATABASE [Impegni]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Impegni', FILENAME = N'C:\Users\naima.el.khattabi\Impegni.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Impegni_log', FILENAME = N'C:\Users\naima.el.khattabi\Impegni_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Impegni] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Impegni].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Impegni] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Impegni] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Impegni] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Impegni] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Impegni] SET ARITHABORT OFF 
GO
ALTER DATABASE [Impegni] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Impegni] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Impegni] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Impegni] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Impegni] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Impegni] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Impegni] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Impegni] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Impegni] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Impegni] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Impegni] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Impegni] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Impegni] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Impegni] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Impegni] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Impegni] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Impegni] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Impegni] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Impegni] SET  MULTI_USER 
GO
ALTER DATABASE [Impegni] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Impegni] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Impegni] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Impegni] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Impegni] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Impegni] SET QUERY_STORE = OFF
GO
USE [Impegni]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Impegni]
GO
/****** Object:  Table [dbo].[Impegno]    Script Date: 8/27/2021 12:24:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Impegno](
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[ExpirationDate] [date] NOT NULL,
	[Importance] [int] NOT NULL,
	[Status] [bit] NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Impegno] ON 

INSERT [dbo].[Impegno] ([Title], [Description], [ExpirationDate], [Importance], [Status], [Id]) VALUES (N'Visita', N'Ortopedica', CAST(N'2021-10-10' AS Date), 3, 1, 1)
INSERT [dbo].[Impegno] ([Title], [Description], [ExpirationDate], [Importance], [Status], [Id]) VALUES (N'Tesi', N'Consegna tesi di laurea', CAST(N'2021-09-30' AS Date), 1, 0, 3)
INSERT [dbo].[Impegno] ([Title], [Description], [ExpirationDate], [Importance], [Status], [Id]) VALUES (N'Dentista', N'Visita dentista Rossi', CAST(N'2021-09-01' AS Date), 1, 0, 4)
INSERT [dbo].[Impegno] ([Title], [Description], [ExpirationDate], [Importance], [Status], [Id]) VALUES (N'Ripetizioni', N'Ripetizioni Mario', CAST(N'2021-09-09' AS Date), 2, 0, 5)
INSERT [dbo].[Impegno] ([Title], [Description], [ExpirationDate], [Importance], [Status], [Id]) VALUES (N'Vaccino', N'Vaccinazione', CAST(N'2021-09-04' AS Date), 1, 0, 6)
INSERT [dbo].[Impegno] ([Title], [Description], [ExpirationDate], [Importance], [Status], [Id]) VALUES (N'Ricevimento', N'Ricevimento studenti prof.Neri', CAST(N'2021-10-01' AS Date), 3, 0, 7)
INSERT [dbo].[Impegno] ([Title], [Description], [ExpirationDate], [Importance], [Status], [Id]) VALUES (N'Analisi', N'Esami del sangue', CAST(N'2021-12-20' AS Date), 3, 0, 8)
INSERT [dbo].[Impegno] ([Title], [Description], [ExpirationDate], [Importance], [Status], [Id]) VALUES (N'Avis', N'Donazione AVIS', CAST(N'2022-01-10' AS Date), 3, 0, 9)
INSERT [dbo].[Impegno] ([Title], [Description], [ExpirationDate], [Importance], [Status], [Id]) VALUES (N'Homework', N'Consegna homework', CAST(N'2021-10-10' AS Date), 2, 1, 10)
INSERT [dbo].[Impegno] ([Title], [Description], [ExpirationDate], [Importance], [Status], [Id]) VALUES (N'Visita', N'Ginecologica', CAST(N'2021-10-10' AS Date), 2, 0, 11)
SET IDENTITY_INSERT [dbo].[Impegno] OFF
GO
ALTER TABLE [dbo].[Impegno] ADD  CONSTRAINT [DF_Impegno_Status]  DEFAULT ((0)) FOR [Status]
GO
USE [master]
GO
ALTER DATABASE [Impegni] SET  READ_WRITE 
GO
