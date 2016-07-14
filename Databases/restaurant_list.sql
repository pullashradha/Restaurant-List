USE [master]
GO
/****** Object:  Database [restaurant_list]    Script Date: 7/14/2016 8:43:26 AM ******/
CREATE DATABASE [restaurant_list]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'restaurant_list', FILENAME = N'C:\Users\epicodus\restaurant_list.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'restaurant_list_log', FILENAME = N'C:\Users\epicodus\restaurant_list_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [restaurant_list] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [restaurant_list].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [restaurant_list] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [restaurant_list] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [restaurant_list] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [restaurant_list] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [restaurant_list] SET ARITHABORT OFF 
GO
ALTER DATABASE [restaurant_list] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [restaurant_list] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [restaurant_list] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [restaurant_list] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [restaurant_list] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [restaurant_list] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [restaurant_list] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [restaurant_list] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [restaurant_list] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [restaurant_list] SET  ENABLE_BROKER 
GO
ALTER DATABASE [restaurant_list] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [restaurant_list] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [restaurant_list] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [restaurant_list] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [restaurant_list] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [restaurant_list] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [restaurant_list] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [restaurant_list] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [restaurant_list] SET  MULTI_USER 
GO
ALTER DATABASE [restaurant_list] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [restaurant_list] SET DB_CHAINING OFF 
GO
ALTER DATABASE [restaurant_list] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [restaurant_list] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [restaurant_list] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [restaurant_list] SET QUERY_STORE = OFF
GO
USE [restaurant_list]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [restaurant_list]
GO
/****** Object:  Table [dbo].[cuisines]    Script Date: 7/14/2016 8:43:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cuisines](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[restaurants]    Script Date: 7/14/2016 8:43:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[restaurants](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[address] [varchar](255) NULL,
	[phone_number] [varchar](255) NULL,
	[description] [varchar](255) NULL,
	[cuisine_id] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [restaurant_list] SET  READ_WRITE 
GO
