USE [master]
GO
/****** Object:  Database [HallManagementSystem]    Script Date: 17-04-22 11:10:19 AM ******/
CREATE DATABASE [HallManagementSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HallManagementSystem', FILENAME = N'D:\Program\SQL\HallManagementSystem\HallManagementSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HallManagementSystem_log', FILENAME = N'D:\Program\SQL\HallManagementSystem\HallManagementSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [HallManagementSystem] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HallManagementSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HallManagementSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HallManagementSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HallManagementSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HallManagementSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HallManagementSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [HallManagementSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HallManagementSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HallManagementSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HallManagementSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HallManagementSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HallManagementSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HallManagementSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HallManagementSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HallManagementSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HallManagementSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HallManagementSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HallManagementSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HallManagementSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HallManagementSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HallManagementSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HallManagementSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HallManagementSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HallManagementSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HallManagementSystem] SET  MULTI_USER 
GO
ALTER DATABASE [HallManagementSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HallManagementSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HallManagementSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HallManagementSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HallManagementSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HallManagementSystem] SET QUERY_STORE = OFF
GO
USE [HallManagementSystem]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [HallManagementSystem]
GO
/****** Object:  Table [dbo].[AdminDetails]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminDetails](
	[AdminID] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [varchar](50) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[PhoneNo] [varchar](10) NOT NULL,
	[Gender] [varchar](10) NULL,
	[BirthDate] [varchar](50) NULL,
	[PhotoPath] [varchar](500) NULL,
 CONSTRAINT [PK_AdminDetails] PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Area]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area](
	[AreaID] [int] IDENTITY(1,1) NOT NULL,
	[AreaName] [varchar](500) NOT NULL,
	[AreaAddress] [varchar](500) NOT NULL,
	[AreaPincode] [int] NOT NULL,
	[CityID] [int] NOT NULL,
 CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED 
(
	[AreaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[CityID] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [varchar](500) NOT NULL,
	[CityCode] [int] NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[CityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hall]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hall](
	[HallID] [int] IDENTITY(1,1) NOT NULL,
	[HallName] [varchar](50) NOT NULL,
	[HallAddress] [varchar](500) NOT NULL,
	[HallPeopleCapacity] [int] NOT NULL,
	[HallVechileCapacity] [int] NOT NULL,
	[HallPrice] [int] NOT NULL,
	[ManagerID] [int] NULL,
	[AreaID] [int] NULL,
	[CityID] [int] NULL,
 CONSTRAINT [PK_Hall] PRIMARY KEY CLUSTERED 
(
	[HallID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HallPhotos]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HallPhotos](
	[HallPhotoID] [int] IDENTITY(1,1) NOT NULL,
	[HallID] [int] NOT NULL,
	[Photo1] [varchar](500) NULL,
	[Photo2] [varchar](500) NULL,
	[Photo3] [varchar](500) NULL,
	[Photo4] [varchar](500) NULL,
	[Photo5] [varchar](500) NULL,
	[Photo6] [varchar](500) NULL,
 CONSTRAINT [PK_HallPhotos] PRIMARY KEY CLUSTERED 
(
	[HallPhotoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manager]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manager](
	[ManagerID] [int] IDENTITY(1,1) NOT NULL,
	[ManagerName] [varchar](50) NOT NULL,
	[ManagerEmail] [varchar](100) NOT NULL,
	[ManagerPhoneNo] [varchar](10) NOT NULL,
	[ManagerGender] [varchar](10) NOT NULL,
	[ManagerSalary] [int] NOT NULL,
 CONSTRAINT [PK_Manager] PRIMARY KEY CLUSTERED 
(
	[ManagerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [varchar](50) NOT NULL,
	[EndDate] [varchar](50) NOT NULL,
	[TotalDays] [int] NOT NULL,
	[TotalAmount] [int] NOT NULL,
	[Status] [varchar](100) NOT NULL,
	[HallID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[BookingDate] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDetails]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDetails](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[DisplayName] [varchar](50) NULL,
	[Email] [varchar](50) NOT NULL,
	[PhoneNo] [varchar](10) NULL,
	[Gender] [varchar](10) NULL,
	[BirthDate] [varchar](50) NULL,
	[PhotoPath] [varchar](500) NULL,
 CONSTRAINT [PK_UserDetails] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AdminDetails] ADD  CONSTRAINT [DF_AdminDetails_PhotoPath]  DEFAULT ('~/Content/AdminPanel/Assets/img/AdminPhotos/default.jpg') FOR [PhotoPath]
GO
ALTER TABLE [dbo].[HallPhotos] ADD  CONSTRAINT [DF_HallPhotos_Photo1]  DEFAULT ('~/Content/AdminPanel/Assets/img/HallPhotos/default.jpeg') FOR [Photo1]
GO
ALTER TABLE [dbo].[HallPhotos] ADD  CONSTRAINT [DF_HallPhotos_Photo2]  DEFAULT ('~/Content/AdminPanel/Assets/img/HallPhotos/default.jpeg') FOR [Photo2]
GO
ALTER TABLE [dbo].[HallPhotos] ADD  CONSTRAINT [DF_HallPhotos_Photo3]  DEFAULT ('~/Content/AdminPanel/Assets/img/HallPhotos/default.jpeg') FOR [Photo3]
GO
ALTER TABLE [dbo].[HallPhotos] ADD  CONSTRAINT [DF_HallPhotos_Photo4]  DEFAULT ('~/Content/AdminPanel/Assets/img/HallPhotos/default.jpeg') FOR [Photo4]
GO
ALTER TABLE [dbo].[HallPhotos] ADD  CONSTRAINT [DF_HallPhotos_Photo5]  DEFAULT ('~/Content/AdminPanel/Assets/img/HallPhotos/default.jpeg') FOR [Photo5]
GO
ALTER TABLE [dbo].[HallPhotos] ADD  CONSTRAINT [DF_HallPhotos_Photo6]  DEFAULT ('~/Content/AdminPanel/Assets/img/HallPhotos/default.jpeg') FOR [Photo6]
GO
ALTER TABLE [dbo].[UserDetails] ADD  CONSTRAINT [DF_UserDetails_PhotoPath]  DEFAULT ('~/Content/FrontPanel/Assets/img/UserPhotos/default.jpg') FOR [PhotoPath]
GO
ALTER TABLE [dbo].[Area]  WITH CHECK ADD  CONSTRAINT [FK_Area_City] FOREIGN KEY([CityID])
REFERENCES [dbo].[City] ([CityID])
GO
ALTER TABLE [dbo].[Area] CHECK CONSTRAINT [FK_Area_City]
GO
ALTER TABLE [dbo].[Hall]  WITH CHECK ADD  CONSTRAINT [FK_Hall_Area] FOREIGN KEY([AreaID])
REFERENCES [dbo].[Area] ([AreaID])
GO
ALTER TABLE [dbo].[Hall] CHECK CONSTRAINT [FK_Hall_Area]
GO
ALTER TABLE [dbo].[Hall]  WITH CHECK ADD  CONSTRAINT [FK_Hall_City] FOREIGN KEY([CityID])
REFERENCES [dbo].[City] ([CityID])
GO
ALTER TABLE [dbo].[Hall] CHECK CONSTRAINT [FK_Hall_City]
GO
ALTER TABLE [dbo].[Hall]  WITH CHECK ADD  CONSTRAINT [FK_Hall_Manager] FOREIGN KEY([ManagerID])
REFERENCES [dbo].[Manager] ([ManagerID])
GO
ALTER TABLE [dbo].[Hall] CHECK CONSTRAINT [FK_Hall_Manager]
GO
ALTER TABLE [dbo].[HallPhotos]  WITH CHECK ADD  CONSTRAINT [FK_HallPhotos_Hall] FOREIGN KEY([HallID])
REFERENCES [dbo].[Hall] ([HallID])
GO
ALTER TABLE [dbo].[HallPhotos] CHECK CONSTRAINT [FK_HallPhotos_Hall]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Hall] FOREIGN KEY([HallID])
REFERENCES [dbo].[Hall] ([HallID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Hall]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_UserDetails] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserDetails] ([UserID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_UserDetails]
GO
/****** Object:  StoredProcedure [dbo].[PR_AdminDetails_SelectAll]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_AdminDetails_SelectAll]
AS
SELECT
	[dbo].[AdminDetails].[AdminID],
	[dbo].[AdminDetails].[DisplayName],
	[dbo].[AdminDetails].[Username],
	[dbo].[AdminDetails].[Email],
	[dbo].[AdminDetails].[PhoneNo],
	[dbo].[AdminDetails].[BirthDate],
	[dbo].[AdminDetails].[Gender],
	[dbo].[AdminDetails].[PhotoPath]
FROM [dbo].[AdminDetails]
GO
/****** Object:  StoredProcedure [dbo].[PR_AdminDetails_SelectByEmail]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_AdminDetails_SelectByEmail]
	@Email varchar(50)
AS
SELECT
	[dbo].[AdminDetails].[AdminID],
	[dbo].[AdminDetails].[Username],
	[dbo].[AdminDetails].[DisplayName],
	[dbo].[AdminDetails].[Email],
	[dbo].[AdminDetails].[Password]
FROM [dbo].[AdminDetails]
WHERE [dbo].[AdminDetails].[Email]=@Email
GO
/****** Object:  StoredProcedure [dbo].[PR_AdminDetails_SelectByPK]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_AdminDetails_SelectByPK]
	@AdminID int
AS
SELECT
	[dbo].[AdminDetails].[AdminID],
	[dbo].[AdminDetails].[DisplayName],
	[dbo].[AdminDetails].[Username],
	[dbo].[AdminDetails].[Password],
	[dbo].[AdminDetails].[Email],
	[dbo].[AdminDetails].[PhoneNo],
	[dbo].[AdminDetails].[Gender],
	[dbo].[AdminDetails].[BirthDate],
	[dbo].[AdminDetails].[PhotoPath]
FROM [dbo].[AdminDetails]
WHERE [dbo].[AdminDetails].[AdminID]=@AdminID
GO
/****** Object:  StoredProcedure [dbo].[PR_AdminDetails_SelectByUsernamePassword]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_AdminDetails_SelectByUsernamePassword]
	@Username varchar(50),
	@Password varchar(50)
AS
SELECT
	[dbo].[AdminDetails].[AdminID],
	[dbo].[AdminDetails].[DisplayName],
	[dbo].[AdminDetails].[PhotoPath]
FROM [dbo].[AdminDetails]
WHERE [dbo].[AdminDetails].[Username]=@Username
AND [dbo].[AdminDetails].[Password]=@Password
GO
/****** Object:  StoredProcedure [dbo].[PR_AdminDetails_UpdateByPK]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_AdminDetails_UpdateByPK]
	@AdminID int,
	@DisplayName varchar(50),
	@Username varchar(50),
	@Password varchar(50),
	@Email varchar(50),
	@PhoneNo varchar(10),
	@Gender varchar(10),
	@BirthDate varchar(50)
AS
UPDATE [dbo].[AdminDetails]
SET
	[DisplayName]=@DisplayName,
	[Username]=@Username,
	[Password]=@Password,
	[Email]=@Email,
	[PhoneNo]=@PhoneNo,
	[Gender]=@Gender,
	[BirthDate]=@BirthDate

WHERE [dbo].[AdminDetails].[AdminID]=@AdminID
GO
/****** Object:  StoredProcedure [dbo].[PR_AdminDetails_UpdatePhotoPathByPK]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_AdminDetails_UpdatePhotoPathByPK]
	@AdminID int,
	@PhotoPath varchar(500)
AS
UPDATE [dbo].[AdminDetails]
SET
	[PhotoPath]=@PhotoPath

WHERE [dbo].[AdminDetails].[AdminID]=@AdminID
GO
/****** Object:  StoredProcedure [dbo].[PR_Area_DeleteByPK]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Area_DeleteByPK]
	@AreaID int
AS
DELETE FROM [dbo].[Area]
WHERE [dbo].[Area].[AreaID]=@AreaID
GO
/****** Object:  StoredProcedure [dbo].[PR_Area_Insert]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Area_Insert]
	@AreaID int OUTPUT,
	@AreaName varchar(500),
	@AreaAddress varchar(500),
	@AreaPincode int,
	@CityID int
AS
INSERT INTO [dbo].[Area]
(
	[AreaName],
	[AreaAddress],
	[AreaPincode],
	[CityID]
)
VALUES
(
	@AreaName,
	@AreaAddress,
	@AreaPincode,
	@CityID
)
SET @AreaID = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[PR_Area_SelectAll]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Area_SelectAll]
AS
SELECT
	[dbo].[Area].[AreaID],
	[dbo].[Area].[AreaName],
	[dbo].[Area].[AreaAddress],
	[dbo].[Area].[AreaPincode],
	[dbo].[City].[CityID],
	[dbo].[City].[CityName],
	[dbo].[City].[CityCode]
FROM [dbo].[Area]
INNER JOIN [dbo].[City]
ON [dbo].[City].[CityID]=[dbo].[Area].[CityID]
ORDER BY [dbo].[Area].[AreaName], [dbo].[City].[CityName]
GO
/****** Object:  StoredProcedure [dbo].[PR_Area_SelectByPK]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Area_SelectByPK]
	@AreaID int
AS
SELECT
	[dbo].[Area].[AreaID],
	[dbo].[Area].[AreaName],
	[dbo].[Area].[AreaAddress],
	[dbo].[Area].[AreaPincode],
	[dbo].[City].[CityID],
	[dbo].[City].[CityName],
	[dbo].[City].[CityCode]
FROM [dbo].[Area]
INNER JOIN [dbo].[City]
ON [dbo].[City].[CityID]=[dbo].[Area].[CityID]
WHERE [dbo].[Area].[AreaID]=@AreaID
GO
/****** Object:  StoredProcedure [dbo].[PR_Area_SelectForDropDownListByCityID]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_Area_SelectForDropDownListByCityID]
	@CityID int
AS
SELECT
	[dbo].[Area].[AreaID],
	[dbo].[Area].[AreaName]
FROM [dbo].[Area]
WHERE [dbo].[Area].[CityID]=@CityID
ORDER BY [dbo].[Area].[AreaName]
GO
/****** Object:  StoredProcedure [dbo].[PR_Area_UpdateByPK]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Area_UpdateByPK]
	@AreaID int,
	@AreaName varchar(500),
	@AreaAddress varchar(500),
	@AreaPincode int,
	@CityID int
AS
UPDATE [dbo].[Area]
SET
	[AreaName]=@AreaName,
	[AreaAddress]=@AreaAddress,
	[AreaPincode]=@AreaPincode,
	[CityID]=@CityID

WHERE [dbo].[Area].[AreaID]=@AreaID
GO
/****** Object:  StoredProcedure [dbo].[PR_City_DeleteByPK]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_City_DeleteByPK]
	@CityID int
AS
DELETE FROM [dbo].[City]
WHERE [dbo].[City].[CityID]=@CityID
GO
/****** Object:  StoredProcedure [dbo].[PR_City_Insert]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_City_Insert]
	@CityID int OUTPUT,
	@CityName varchar(500),
	@CityCode int
AS
INSERT INTO [dbo].[City]
(
	[CityName],
	[CityCode]
)
VALUES
(
	@CityName,
	@CityCode
)
SET @CityID = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[PR_City_SelectAll]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_City_SelectAll]
AS
SELECT
	[dbo].[City].[CityID],
	[dbo].[City].[CityName],
	[dbo].[City].[CityCode]
FROM [dbo].[City]
ORDER BY [dbo].[City].[CityName]
GO
/****** Object:  StoredProcedure [dbo].[PR_City_SelectByPK]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_City_SelectByPK]
	@CityID int
AS
SELECT
	[dbo].[City].[CityID],
	[dbo].[City].[CityName],
	[dbo].[City].[CityCode]
FROM [dbo].[City]
WHERE [dbo].[City].[CityID]=@CityID
GO
/****** Object:  StoredProcedure [dbo].[PR_City_SelectForDropDownList]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_City_SelectForDropDownList]
AS
SELECT
	[dbo].[City].[CityID],
	[dbo].[City].[CityName]
FROM [dbo].[City]
ORDER BY [dbo].[City].[CityName]
GO
/****** Object:  StoredProcedure [dbo].[PR_City_UpdateByPK]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_City_UpdateByPK]
	@CityID int,
	@CityName varchar(500),
	@CityCode int
AS

UPDATE [dbo].[City]
SET [CityName]=@CityName,
	[CityCode]=@CityCode

WHERE [dbo].[City].[CityID]=@CityID
GO
/****** Object:  StoredProcedure [dbo].[PR_Hall_DeleteByPK]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Hall_DeleteByPK]
	@HallID int
AS
DELETE FROM [dbo].[Hall]
WHERE [dbo].[Hall].[HallID]=@HallID
GO
/****** Object:  StoredProcedure [dbo].[PR_Hall_Insert]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Hall_Insert]
	@HallID int OUTPUT,
	@HallName varchar(50),
	@HallAddress varchar(500),
	@HallPeopleCapacity int,
	@HallVechileCapacity int,
	@HallPrice int,
	@ManagerID int,
	@AreaID int,
	@CityID int
AS
INSERT INTO [dbo].[Hall]
(
	[HallName],
	[HallAddress],
	[HallPeopleCapacity],
	[HallVechileCapacity],
	[HallPrice],
	[ManagerID],
	[AreaID],
	[CityID]
)
VALUES
(
	@HallName,
	@HallAddress,
	@HallPeopleCapacity,
	@HallVechileCapacity,
	@HallPrice,
	@ManagerID,
	@AreaID,
	@CityID
)
SET @HallID = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[PR_Hall_SelectAll]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Hall_SelectAll]
AS
SELECT
	[dbo].[Hall].[HallID],
	[dbo].[Hall].[HallName],
	[dbo].[Hall].[HallAddress],
	[dbo].[Hall].[HallPeopleCapacity],
	[dbo].[Hall].[HallVechileCapacity],
	[dbo].[Hall].[HallPrice],
	[dbo].[Manager].[ManagerID],
	[dbo].[Manager].[ManagerName],
	[dbo].[Manager].[ManagerEmail],
	[dbo].[Manager].[ManagerPhoneNo],
	[dbo].[Area].[AreaID],
	[dbo].[Area].[AreaName],
	[dbo].[City].[CityID],
	[dbo].[City].[CityName],
	[dbo].[HallPhotos].[HallPhotoID],
	[dbo].[HallPhotos].[Photo1],
	[dbo].[HallPhotos].[Photo2],
	[dbo].[HallPhotos].[Photo3],
	[dbo].[HallPhotos].[Photo4],
	[dbo].[HallPhotos].[Photo5],
	[dbo].[HallPhotos].[Photo6]
FROM [dbo].[Hall]
LEFT JOIN [dbo].[Manager]
ON [dbo].[Hall].[ManagerID]=[dbo].[Manager].[ManagerID]
LEFT JOIN [dbo].[Area]
ON [dbo].[Hall].[AreaID]=[dbo].[Area].[AreaID]
LEFT JOIN [dbo].[City]
ON [dbo].[Hall].[CityID]=[dbo].[City].[CityID]
LEFT JOIN [dbo].[HallPhotos]
ON [dbo].[Hall].[HallID]=[dbo].[HallPhotos].[HallID]
ORDER BY [dbo].[Hall].[HallName]
GO
/****** Object:  StoredProcedure [dbo].[PR_Hall_SelectAllSortByPeople]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Hall_SelectAllSortByPeople]
AS
SELECT
	[dbo].[Hall].[HallID],
	[dbo].[Hall].[HallName],
	[dbo].[Hall].[HallAddress],
	[dbo].[Hall].[HallPeopleCapacity],
	[dbo].[Hall].[HallVechileCapacity],
	[dbo].[Hall].[HallPrice],
	[dbo].[Manager].[ManagerID],
	[dbo].[Manager].[ManagerName],
	[dbo].[Manager].[ManagerEmail],
	[dbo].[Manager].[ManagerPhoneNo],
	[dbo].[Area].[AreaID],
	[dbo].[Area].[AreaName],
	[dbo].[City].[CityID],
	[dbo].[City].[CityName],
	[dbo].[HallPhotos].[HallPhotoID],
	[dbo].[HallPhotos].[Photo1],
	[dbo].[HallPhotos].[Photo2],
	[dbo].[HallPhotos].[Photo3],
	[dbo].[HallPhotos].[Photo4],
	[dbo].[HallPhotos].[Photo5],
	[dbo].[HallPhotos].[Photo6]
FROM [dbo].[Hall]
LEFT JOIN [dbo].[Manager]
ON [dbo].[Hall].[ManagerID]=[dbo].[Manager].[ManagerID]
LEFT JOIN [dbo].[Area]
ON [dbo].[Hall].[AreaID]=[dbo].[Area].[AreaID]
LEFT JOIN [dbo].[City]
ON [dbo].[Hall].[CityID]=[dbo].[City].[CityID]
LEFT JOIN [dbo].[HallPhotos]
ON [dbo].[Hall].[HallID]=[dbo].[HallPhotos].[HallID]
ORDER BY [dbo].[Hall].[HallPeopleCapacity]
GO
/****** Object:  StoredProcedure [dbo].[PR_Hall_SelectAllSortByPrice]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Hall_SelectAllSortByPrice]
AS
SELECT
	[dbo].[Hall].[HallID],
	[dbo].[Hall].[HallName],
	[dbo].[Hall].[HallAddress],
	[dbo].[Hall].[HallPeopleCapacity],
	[dbo].[Hall].[HallVechileCapacity],
	[dbo].[Hall].[HallPrice],
	[dbo].[Manager].[ManagerID],
	[dbo].[Manager].[ManagerName],
	[dbo].[Manager].[ManagerEmail],
	[dbo].[Manager].[ManagerPhoneNo],
	[dbo].[Area].[AreaID],
	[dbo].[Area].[AreaName],
	[dbo].[City].[CityID],
	[dbo].[City].[CityName],
	[dbo].[HallPhotos].[HallPhotoID],
	[dbo].[HallPhotos].[Photo1],
	[dbo].[HallPhotos].[Photo2],
	[dbo].[HallPhotos].[Photo3],
	[dbo].[HallPhotos].[Photo4],
	[dbo].[HallPhotos].[Photo5],
	[dbo].[HallPhotos].[Photo6]
FROM [dbo].[Hall]
LEFT JOIN [dbo].[Manager]
ON [dbo].[Hall].[ManagerID]=[dbo].[Manager].[ManagerID]
LEFT JOIN [dbo].[Area]
ON [dbo].[Hall].[AreaID]=[dbo].[Area].[AreaID]
LEFT JOIN [dbo].[City]
ON [dbo].[Hall].[CityID]=[dbo].[City].[CityID]
LEFT JOIN [dbo].[HallPhotos]
ON [dbo].[Hall].[HallID]=[dbo].[HallPhotos].[HallID]
ORDER BY [dbo].[Hall].[HallPrice]
GO
/****** Object:  StoredProcedure [dbo].[PR_Hall_SelectAllSortByVechile]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Hall_SelectAllSortByVechile]
AS
SELECT
	[dbo].[Hall].[HallID],
	[dbo].[Hall].[HallName],
	[dbo].[Hall].[HallAddress],
	[dbo].[Hall].[HallPeopleCapacity],
	[dbo].[Hall].[HallVechileCapacity],
	[dbo].[Hall].[HallPrice],
	[dbo].[Manager].[ManagerID],
	[dbo].[Manager].[ManagerName],
	[dbo].[Manager].[ManagerEmail],
	[dbo].[Manager].[ManagerPhoneNo],
	[dbo].[Area].[AreaID],
	[dbo].[Area].[AreaName],
	[dbo].[City].[CityID],
	[dbo].[City].[CityName],
	[dbo].[HallPhotos].[HallPhotoID],
	[dbo].[HallPhotos].[Photo1],
	[dbo].[HallPhotos].[Photo2],
	[dbo].[HallPhotos].[Photo3],
	[dbo].[HallPhotos].[Photo4],
	[dbo].[HallPhotos].[Photo5],
	[dbo].[HallPhotos].[Photo6]
FROM [dbo].[Hall]
LEFT JOIN [dbo].[Manager]
ON [dbo].[Hall].[ManagerID]=[dbo].[Manager].[ManagerID]
LEFT JOIN [dbo].[Area]
ON [dbo].[Hall].[AreaID]=[dbo].[Area].[AreaID]
LEFT JOIN [dbo].[City]
ON [dbo].[Hall].[CityID]=[dbo].[City].[CityID]
LEFT JOIN [dbo].[HallPhotos]
ON [dbo].[Hall].[HallID]=[dbo].[HallPhotos].[HallID]
ORDER BY [dbo].[Hall].[HallVechileCapacity]
GO
/****** Object:  StoredProcedure [dbo].[PR_Hall_SelectByPK]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Hall_SelectByPK]
	@HallID int
AS
SELECT
	[dbo].[Hall].[HallID],
	[dbo].[Hall].[HallName],
	[dbo].[Hall].[HallAddress],
	[dbo].[Hall].[HallPeopleCapacity],
	[dbo].[Hall].[HallVechileCapacity],
	[dbo].[Hall].[HallPrice],
	[dbo].[Manager].[ManagerID],
	[dbo].[Manager].[ManagerName],
	[dbo].[Manager].[ManagerEmail],
	[dbo].[Manager].[ManagerPhoneNo],
	[dbo].[Area].[AreaID],
	[dbo].[Area].[AreaName],
	[dbo].[City].[CityID],
	[dbo].[City].[CityName]
FROM [dbo].[Hall]
LEFT JOIN [dbo].[Manager]
ON [dbo].[Hall].[ManagerID]=[dbo].[Manager].[ManagerID]
LEFT JOIN [dbo].[Area]
ON [dbo].[Hall].[AreaID]=[dbo].[Area].[AreaID]
LEFT JOIN [dbo].[City]
ON [dbo].[Hall].[CityID]=[dbo].[City].[CityID]
WHERE [dbo].[Hall].[HallID]=@HallID
GO
/****** Object:  StoredProcedure [dbo].[PR_Hall_UpdateByPK]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Hall_UpdateByPK]
	@HallID int,
	@HallName varchar(50),
	@HallAddress varchar(500),
	@HallPeopleCapacity int,
	@HallVechileCapacity int,
	@HallPrice int,
	@ManagerID int,
	@AreaID int,
	@CityID int
AS
UPDATE [dbo].[Hall]
SET
	[HallName]=@HallName,
	[HallAddress]=@HallAddress,
	[HallPeopleCapacity]=@HallPeopleCapacity,
	[HallVechileCapacity]=@HallVechileCapacity,
	[HallPrice]=@HallPrice,
	[ManagerID]=@ManagerID,
	[AreaID]=@AreaID,
	[CityID]=@CityID

WHERE [dbo].[Hall].[HallID]=@HallID
GO
/****** Object:  StoredProcedure [dbo].[PR_HallPhotos_DeleteByHallID]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_HallPhotos_DeleteByHallID]
	@HallID int
AS
DELETE FROM [dbo].[HallPhotos]
WHERE [dbo].[HallPhotos].[HallID]=@HallID
GO
/****** Object:  StoredProcedure [dbo].[PR_HallPhotos_Insert]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_HallPhotos_Insert]
	@HallPhotosID int OUTPUT,
	@HallID int 
AS
INSERT INTO [dbo].[HallPhotos]
(
	[HallID]
)
VALUES
(
	@HallID
)
SET @HallPhotosID = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[PR_HallPhotos_SelectByHallID]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_HallPhotos_SelectByHallID]
	@HallID int
AS
SELECT
	[dbo].[HallPhotos].[HallID],
	[dbo].[HallPhotos].[HallPhotoID],
	[dbo].[HallPhotos].[Photo1],
	[dbo].[HallPhotos].[Photo2],
	[dbo].[HallPhotos].[Photo3],
	[dbo].[HallPhotos].[Photo4],
	[dbo].[HallPhotos].[Photo5],
	[dbo].[HallPhotos].[Photo6]
FROM [dbo].[HallPhotos]
WHERE [dbo].[HallPhotos].[HallID]=@HallID
GO
/****** Object:  StoredProcedure [dbo].[PR_HallPhotos_SelectByPK]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_HallPhotos_SelectByPK]
	@HallPhotoID int
AS
SELECT
	[dbo].[Hall].[HallID],
	[dbo].[Hall].[HallName],
	[dbo].[Hall].[HallAddress],
	[dbo].[HallPhotos].[HallPhotoID],
	[dbo].[HallPhotos].[Photo1],
	[dbo].[HallPhotos].[Photo2],
	[dbo].[HallPhotos].[Photo3],
	[dbo].[HallPhotos].[Photo4],
	[dbo].[HallPhotos].[Photo5],
	[dbo].[HallPhotos].[Photo6]
FROM [dbo].[Hall]
LEFT JOIN [dbo].[HallPhotos]
ON [dbo].[HallPhotos].[HallID]=[dbo].[Hall].[HallID]
WHERE [dbo].[HallPhotos].[HallPhotoID]=@HallPhotoID
GO
/****** Object:  StoredProcedure [dbo].[PR_HallPhotos_UpdateByPK]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_HallPhotos_UpdateByPK]
	@HallPhotoID int,
	@Photo1 varchar(500),
	@Photo2 varchar(500),
	@Photo3 varchar(500),
	@Photo4 varchar(500),
	@Photo5 varchar(500),
	@Photo6 varchar(500)
AS
UPDATE [dbo].[HallPhotos]
SET [Photo1]=@Photo1,
    [Photo2]=@Photo2,
    [Photo3]=@Photo3,
    [Photo4]=@Photo4,
    [Photo5]=@Photo5,
    [Photo6]=@Photo6
WHERE [dbo].[HallPhotos].[HallPhotoID]=@HallPhotoID
GO
/****** Object:  StoredProcedure [dbo].[PR_Manager_DeleteByPK]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Manager_DeleteByPK]
	@ManagerID int
AS
DELETE FROM [dbo].[Manager]
WHERE [dbo].[Manager].[ManagerID]=@ManagerID
GO
/****** Object:  StoredProcedure [dbo].[PR_Manager_Insert]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Manager_Insert]
	@ManagerID int OUTPUT,
	@ManagerName varchar(50),
	@ManagerEmail varchar(100),
	@ManagerPhoneNo varchar(10),
	@ManagerGender varchar(10),
	@ManagerSalary int
AS
INSERT INTO [dbo].[Manager]
(
	[ManagerName],
	[ManagerEmail],
	[ManagerPhoneNo],
	[ManagerGender],
	[ManagerSalary]
)
VALUES
(
	@ManagerName,
	@ManagerEmail,
	@ManagerPhoneNo,
	@ManagerGender,
	@ManagerSalary
)
SET @ManagerID = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[PR_Manager_SelectAll]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Manager_SelectAll]
AS
SELECT
	[dbo].[Manager].[ManagerID],
	[dbo].[Manager].[ManagerName],
	[dbo].[Manager].[ManagerEmail],
	[dbo].[Manager].[ManagerPhoneNo],
	[dbo].[Manager].[ManagerGender],
	[dbo].[Manager].[ManagerSalary]
FROM [dbo].[Manager]
ORDER BY [dbo].[Manager].[ManagerName]
GO
/****** Object:  StoredProcedure [dbo].[PR_Manager_SelectByPK]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Manager_SelectByPK]
	@ManagerID int
AS
SELECT
	[dbo].[Manager].[ManagerID],
	[dbo].[Manager].[ManagerName],
	[dbo].[Manager].[ManagerEmail],
	[dbo].[Manager].[ManagerPhoneNo],
	[dbo].[Manager].[ManagerGender],
	[dbo].[Manager].[ManagerSalary]
FROM [dbo].[Manager]
WHERE [dbo].[Manager].[ManagerID]=@ManagerID
GO
/****** Object:  StoredProcedure [dbo].[PR_Manager_SelectForDropDownList]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_Manager_SelectForDropDownList]
AS
SELECT
	[dbo].[Manager].[ManagerID],
	[dbo].[Manager].[ManagerName]
FROM [dbo].[Manager]
ORDER BY [dbo].[Manager].[ManagerName]
GO
/****** Object:  StoredProcedure [dbo].[PR_Manager_UpdateByPK]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Manager_UpdateByPK]
	@ManagerID int,
	@ManagerName varchar(50),
	@ManagerEmail varchar(100),
	@ManagerPhoneNo varchar(10),
	@ManagerGender varchar(10),
	@ManagerSalary int
AS
UPDATE [dbo].[Manager]
SET
	[ManagerName]=@ManagerName,
	[ManagerEmail]=@ManagerEmail,
	[ManagerPhoneNo]=@ManagerPhoneNo,
	[ManagerGender]=@ManagerGender,
	[ManagerSalary]=@ManagerSalary

WHERE [dbo].[Manager].[ManagerID]=@ManagerID
GO
/****** Object:  StoredProcedure [dbo].[PR_Order_DeleteByUserID]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Order_DeleteByUserID]
	@UserID int
AS
DELETE FROM [dbo].[Order]
WHERE [dbo].[Order].[UserID]=@UserID
GO
/****** Object:  StoredProcedure [dbo].[PR_Order_DeleteByUserIDByPK]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Order_DeleteByUserIDByPK]
	@UserID int,
	@OrderID int
AS
DELETE FROM [dbo].[Order]
WHERE [dbo].[Order].[OrderID]=@OrderID
AND [dbo].[Order].[UserID]=@UserID
GO
/****** Object:  StoredProcedure [dbo].[PR_Order_InsertByUserID]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Order_InsertByUserID]
	@OrderID int OUTPUT,
	@StartDate varchar(50),
	@EndDate varchar(50),
	@BookingDate varchar(50),
	@TotalDays int,
	@TotalAmount int,
	@Status varchar(100),
	@HallID int,
	@UserID int
AS
INSERT INTO [dbo].[Order]
(
	[StartDate],
	[EndDate],
	[TotalDays],
	[TotalAmount],
	[Status],
	[HallID],
	[UserID],
	[BookingDate]
)
VALUES
(
	@StartDate,
	@EndDate,
	@TotalDays,
	@TotalAmount,
	@Status,
	@HallID,
	@UserID,
	@BookingDate
)
SET @OrderID = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[PR_Order_SelectAll]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PR_Order_SelectAll]
AS
SELECT
	*
FROM [dbo].[Order]
INNER JOIN [dbo].[Hall]
ON [dbo].[Order].[HallID]=[dbo].[Hall].[HallID]
INNER JOIN [dbo].[UserDetails]
ON [dbo].[Order].[UserID]=[dbo].[UserDetails].[UserID]
ORDER BY [dbo].[Order].[BookingDate] DESC
GO
/****** Object:  StoredProcedure [dbo].[PR_Order_SelectAllByUserID]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Order_SelectAllByUserID]
	@UserID int
AS
SELECT
	*
FROM [dbo].[Order]
INNER JOIN [dbo].[Hall]
ON [dbo].[Order].[HallID]=[dbo].[Hall].[HallID]
INNER JOIN [dbo].[UserDetails]
ON [dbo].[Order].[UserID]=[dbo].[UserDetails].[UserID]
WHERE [dbo].[Order].[UserID]=@UserID
ORDER BY [dbo].[Order].[BookingDate] DESC,
[dbo].[Hall].[HallName]
GO
/****** Object:  StoredProcedure [dbo].[PR_Order_SelectByPK]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Order_SelectByPK]
	@OrderID int
AS
SELECT
	*
FROM [dbo].[Order]
INNER JOIN [dbo].[Hall]
ON [dbo].[Order].[HallID]=[dbo].[Hall].[HallID]
INNER JOIN [dbo].[UserDetails]
ON [dbo].[Order].[UserID]=[dbo].[UserDetails].[UserID]
WHERE [dbo].[Order].[OrderID]=@OrderID
GO
/****** Object:  StoredProcedure [dbo].[PR_Order_SelectByUserIDByPK]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Order_SelectByUserIDByPK]
	@UserID int,
	@OrderID int
AS
SELECT
	*
FROM [dbo].[Order]
INNER JOIN [dbo].[Hall]
ON [dbo].[Order].[HallID]=[dbo].[Hall].[HallID]
INNER JOIN [dbo].[UserDetails]
ON [dbo].[Order].[UserID]=[dbo].[UserDetails].[UserID]
WHERE [dbo].[Order].[OrderID]=@OrderID
AND [dbo].[Order].[UserID]=@UserID
GO
/****** Object:  StoredProcedure [dbo].[PR_Order_SelectStartEndDatesByHallID]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Order_SelectStartEndDatesByHallID]
	@HallID int
AS
SELECT
	[dbo].[Order].[OrderID],
	[dbo].[Order].[StartDate],
	[dbo].[Order].[EndDate]
FROM [dbo].[Order]
WHERE [dbo].[Order].[HallID]=@HallID
GO
/****** Object:  StoredProcedure [dbo].[PR_Order_UpdateByUserIDByPK]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_Order_UpdateByUserIDByPK]
	@OrderID int,
	@StartDate varchar(50),
	@EndDate varchar(50),
	@TotalDays int,
	@TotalAmount int,
	@Status varchar(100),
	@HallID int,
	@UserID int,
	@BookingDate varchar(50)
AS
UPDATE [dbo].[Order]
SET 
	[StartDate]=@StartDate,
	[EndDate]=@EndDate,
	[TotalDays]=@TotalDays,
	[TotalAmount]=@TotalAmount,
	[Status]=@Status,
	[BookingDate]=@BookingDate

WHERE [dbo].[Order].[OrderID]=@OrderID
AND [dbo].[Order].[UserID]=UserID
GO
/****** Object:  StoredProcedure [dbo].[PR_UserDetails_DeleteByPK]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_UserDetails_DeleteByPK]
	@UserID int
AS
DELETE FROM [dbo].[UserDetails]
WHERE [dbo].[UserDetails].[UserID]=@UserID
GO
/****** Object:  StoredProcedure [dbo].[PR_UserDetails_Insert]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_UserDetails_Insert]
	@Username VARCHAR(50),
	@Password VARCHAR(50),
	@Email VARCHAR(50)
AS
INSERT INTO [dbo].[UserDetails]
(
	[Username],
	[Password],
	[Email]
)
VALUES
(
	@Username,
	@Password,
	@Email
)
GO
/****** Object:  StoredProcedure [dbo].[PR_UserDetails_SelectAll]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_UserDetails_SelectAll]
AS
SELECT
	[dbo].[UserDetails].[UserID],
	[dbo].[UserDetails].[DisplayName],
	[dbo].[UserDetails].[Username],
	[dbo].[UserDetails].[Email],
	[dbo].[UserDetails].[PhoneNo],
	[dbo].[UserDetails].[BirthDate],
	[dbo].[UserDetails].[Gender],
	[dbo].[UserDetails].[PhotoPath]
FROM [dbo].[UserDetails]
GO
/****** Object:  StoredProcedure [dbo].[PR_UserDetails_SelectByEmail]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_UserDetails_SelectByEmail]
	@Email varchar(50)
AS
SELECT
	[dbo].[UserDetails].[UserID],
	[dbo].[UserDetails].[Username],
	[dbo].[UserDetails].[DisplayName],
	[dbo].[UserDetails].[Email],
	[dbo].[UserDetails].[Password]
FROM [dbo].[UserDetails]
WHERE [dbo].[UserDetails].[Email]=@Email
GO
/****** Object:  StoredProcedure [dbo].[PR_UserDetails_SelectByPK]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_UserDetails_SelectByPK]
	@UserID int
AS
SELECT
	[dbo].[UserDetails].[UserID],
	[dbo].[UserDetails].[DisplayName],
	[dbo].[UserDetails].[Username],
	[dbo].[UserDetails].[Password],
	[dbo].[UserDetails].[Email],
	[dbo].[UserDetails].[PhoneNo],
	[dbo].[UserDetails].[Gender],
	[dbo].[UserDetails].[BirthDate],
	[dbo].[UserDetails].[PhotoPath]
FROM [dbo].[UserDetails]
WHERE [dbo].[UserDetails].[UserID]=@UserID
GO
/****** Object:  StoredProcedure [dbo].[PR_UserDetails_SelectByUsernamePassword]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_UserDetails_SelectByUsernamePassword]
	@Username varchar(50),
	@Password varchar(50)
AS
SELECT
	[dbo].[UserDetails].[UserID],
	[dbo].[UserDetails].[Username],
	[dbo].[UserDetails].[DisplayName],
	[dbo].[UserDetails].[PhotoPath]
FROM [dbo].[UserDetails]
WHERE [dbo].[UserDetails].[Username]=@Username
AND [dbo].[UserDetails].[Password]=@Password
GO
/****** Object:  StoredProcedure [dbo].[PR_UserDetails_UpdateByPK]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_UserDetails_UpdateByPK]
	@UserID int,
	@DisplayName varchar(50),
	@Username varchar(50),
	@Password varchar(50),
	@Email varchar(50),
	@PhoneNo varchar(10),
	@Gender varchar(10),
	@BirthDate varchar(50)
AS
UPDATE [dbo].[UserDetails]
SET
	[DisplayName]=@DisplayName,
	[Username]=@Username,
	[Password]=@Password,
	[Email]=@Email,
	[PhoneNo]=@PhoneNo,
	[Gender]=@Gender,
	[BirthDate]=@BirthDate

WHERE [dbo].[UserDetails].[UserID]=@UserID
GO
/****** Object:  StoredProcedure [dbo].[PR_UserDetails_UpdatePhotoPathByPK]    Script Date: 17-04-22 11:10:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PR_UserDetails_UpdatePhotoPathByPK]
	@UserID int,
	@PhotoPath varchar(500)
AS
UPDATE [dbo].[UserDetails]
SET
	[PhotoPath]=@PhotoPath

WHERE [dbo].[UserDetails].[UserID]=@UserID
GO
USE [master]
GO
ALTER DATABASE [HallManagementSystem] SET  READ_WRITE 
GO
