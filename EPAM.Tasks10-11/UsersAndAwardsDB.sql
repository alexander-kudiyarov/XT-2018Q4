USE [master]
GO
/****** Object:  Database [UsersAndAwardsDB]    Script Date: 10.02.2019 21:58:57 ******/
CREATE DATABASE [UsersAndAwardsDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UsersAndAwardsDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER01\MSSQL\DATA\UsersAndAwardsDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UsersAndAwardsDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER01\MSSQL\DATA\UsersAndAwardsDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [UsersAndAwardsDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UsersAndAwardsDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UsersAndAwardsDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UsersAndAwardsDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UsersAndAwardsDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UsersAndAwardsDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UsersAndAwardsDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [UsersAndAwardsDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UsersAndAwardsDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UsersAndAwardsDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UsersAndAwardsDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UsersAndAwardsDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UsersAndAwardsDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UsersAndAwardsDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UsersAndAwardsDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UsersAndAwardsDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UsersAndAwardsDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UsersAndAwardsDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UsersAndAwardsDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UsersAndAwardsDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UsersAndAwardsDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UsersAndAwardsDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UsersAndAwardsDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UsersAndAwardsDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UsersAndAwardsDB] SET RECOVERY FULL 
GO
ALTER DATABASE [UsersAndAwardsDB] SET  MULTI_USER 
GO
ALTER DATABASE [UsersAndAwardsDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UsersAndAwardsDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UsersAndAwardsDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UsersAndAwardsDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UsersAndAwardsDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'UsersAndAwardsDB', N'ON'
GO
ALTER DATABASE [UsersAndAwardsDB] SET QUERY_STORE = OFF
GO
USE [UsersAndAwardsDB]
GO
/****** Object:  Table [dbo].[Awards]    Script Date: 10.02.2019 21:58:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Awards](
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Awards_1] PRIMARY KEY CLUSTERED 
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MyProgramUsers]    Script Date: 10.02.2019 21:58:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MyProgramUsers](
	[Name] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MyProgramUsers] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MyUsers]    Script Date: 10.02.2019 21:58:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MyUsers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[DateOfBirth] [date] NOT NULL,
	[Image] [binary](8000) NULL,
 CONSTRAINT [PK_MyUsers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersAndAwards]    Script Date: 10.02.2019 21:58:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersAndAwards](
	[UserID] [int] NOT NULL,
	[AwardTitle] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_UsersAndAwards] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[AwardTitle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_UsersAndAwards]    Script Date: 10.02.2019 21:58:58 ******/
CREATE NONCLUSTERED INDEX [IX_UsersAndAwards] ON [dbo].[UsersAndAwards]
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UsersAndAwards]  WITH CHECK ADD  CONSTRAINT [FK_UsersAndAwards_Awards] FOREIGN KEY([AwardTitle])
REFERENCES [dbo].[Awards] ([Title])
GO
ALTER TABLE [dbo].[UsersAndAwards] CHECK CONSTRAINT [FK_UsersAndAwards_Awards]
GO
ALTER TABLE [dbo].[UsersAndAwards]  WITH CHECK ADD  CONSTRAINT [FK_UsersAndAwards_MyUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[MyUsers] ([ID])
GO
ALTER TABLE [dbo].[UsersAndAwards] CHECK CONSTRAINT [FK_UsersAndAwards_MyUsers]
GO
/****** Object:  StoredProcedure [dbo].[AddAward]    Script Date: 10.02.2019 21:58:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddAward]
	@Title nvarchar(50)
AS
BEGIN
	INSERT INTO Awards(Title)
	VALUES(@Title)
END
GO
/****** Object:  StoredProcedure [dbo].[AddAwardToUser]    Script Date: 10.02.2019 21:58:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddAwardToUser]
	@UserID int,
	@AwardTitle nvarchar(50)
AS
BEGIN
	INSERT INTO UsersAndAwards(UserID, AwardTitle)
	VALUES(@UserID, @AwardTitle)
END
GO
/****** Object:  StoredProcedure [dbo].[AddProgramUser]    Script Date: 10.02.2019 21:58:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddProgramUser]
	@Name nvarchar(50),
	@Password nvarchar(50),
	@Role nvarchar(50)
AS
BEGIN
	INSERT INTO MyProgramUsers(Name, Password, Role)
	VALUES(@Name, @Password, @Role)
END
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 10.02.2019 21:58:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser]
	@FirstName nvarchar(50),
	@LastName nvarchar(50) = NULL,
	@DateOfBirth date,
	@Image binary(8000) = NULL
AS
BEGIN
	INSERT INTO MyUsers(FirstName, LastName, DateOfBirth, Image)
	VALUES(@FirstName, @LastName, @DateOfBirth, @Image)
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteAward]    Script Date: 10.02.2019 21:58:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteAward]
	@AwardTitle nvarchar(50)
AS
BEGIN
	DELETE FROM UsersAndAwards
	WHERE AwardTitle = @AwardTitle
	DELETE FROM Awards
	WHERE Title = @AwardTitle
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteProgramUser]    Script Date: 10.02.2019 21:58:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteProgramUser]
	@Name nvarchar(50)
AS
BEGIN
	DELETE FROM MyProgramUsers
	WHERE MyProgramUsers.Name = @Name
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 10.02.2019 21:58:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUser]
	@ID int
AS
BEGIN
	DELETE FROM UsersAndAwards
	WHERE UserID = @ID
	DELETE FROM MyUsers
	WHERE MyUsers.ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[EditProgramUser]    Script Date: 10.02.2019 21:58:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditProgramUser]
	@Name nvarchar(50),
	@Role nvarchar(50)
AS
BEGIN
	UPDATE MyProgramUsers
	SET
		Role = ISNULL(@Role, Role)
	WHERE
		Name = @Name
END
GO
/****** Object:  StoredProcedure [dbo].[EditUser]    Script Date: 10.02.2019 21:58:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditUser]
	@Id int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@DateOfBirth date
AS
BEGIN
	UPDATE MyUsers
	SET
		FirstName = ISNULL(@FirstName, FirstName),
		LastName = ISNULL(@LastName, LastName),
		DateOfBirth = ISNULL(@DateOfBirth, DateOfBirth)
	WHERE
		ID = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllProgramUsers]    Script Date: 10.02.2019 21:58:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllProgramUsers]

AS
BEGIN

	SET NOCOUNT ON;

	SELECT	U.Name,
			U.Password,
			U.Role
	FROM MyProgramUsers U
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 10.02.2019 21:58:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllUsers]
AS
BEGIN

	SET NOCOUNT ON;

	SELECT	U.ID,
			U.FirstName,
			U.LastName,
			U.DateOfBirth,
			U.Image
	FROM MyUsers U
END
GO
/****** Object:  StoredProcedure [dbo].[GetPassword]    Script Date: 10.02.2019 21:58:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPassword]
	@Name nvarchar(50)
AS
BEGIN
	SELECT Password FROM MyProgramUsers as U
WHERE U.Name = @Name
END
GO
/****** Object:  StoredProcedure [dbo].[GetRole]    Script Date: 10.02.2019 21:58:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRole]
	@Name nvarchar(50)
AS
BEGIN
	SELECT Role FROM MyProgramUsers as U
WHERE U.Name = @Name
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserAwards]    Script Date: 10.02.2019 21:58:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserAwards]
	@Id int
AS
BEGIN
	SELECT AwardTitle
	FROM UsersAndAwards
	WHERE UserID = @Id
END
GO
USE [master]
GO
ALTER DATABASE [UsersAndAwardsDB] SET  READ_WRITE 
GO
