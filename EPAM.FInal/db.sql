USE [master]
GO
/****** Object:  Database [EPAM.Final.Forum]    Script Date: 16.04.2019 18:27:33 ******/
CREATE DATABASE [EPAM.Final.Forum]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EPAM.Final.Forum', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\EPAM.Final.Forum.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EPAM.Final.Forum_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\EPAM.Final.Forum_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [EPAM.Final.Forum] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EPAM.Final.Forum].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EPAM.Final.Forum] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EPAM.Final.Forum] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EPAM.Final.Forum] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EPAM.Final.Forum] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EPAM.Final.Forum] SET ARITHABORT OFF 
GO
ALTER DATABASE [EPAM.Final.Forum] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EPAM.Final.Forum] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EPAM.Final.Forum] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EPAM.Final.Forum] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EPAM.Final.Forum] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EPAM.Final.Forum] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EPAM.Final.Forum] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EPAM.Final.Forum] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EPAM.Final.Forum] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EPAM.Final.Forum] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EPAM.Final.Forum] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EPAM.Final.Forum] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EPAM.Final.Forum] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EPAM.Final.Forum] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EPAM.Final.Forum] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EPAM.Final.Forum] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EPAM.Final.Forum] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EPAM.Final.Forum] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EPAM.Final.Forum] SET  MULTI_USER 
GO
ALTER DATABASE [EPAM.Final.Forum] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EPAM.Final.Forum] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EPAM.Final.Forum] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EPAM.Final.Forum] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EPAM.Final.Forum] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EPAM.Final.Forum] SET QUERY_STORE = OFF
GO
USE [EPAM.Final.Forum]
GO
/****** Object:  Table [dbo].[ForumPosts]    Script Date: 16.04.2019 18:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ForumPosts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[text] [nvarchar](4000) NOT NULL,
	[userId] [int] NOT NULL,
	[threadId] [int] NOT NULL,
	[publishDate] [datetime] NOT NULL,
	[editDate] [datetime] NULL,
 CONSTRAINT [PK_ForumMessages] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ForumThreads]    Script Date: 16.04.2019 18:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ForumThreads](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[subject] [nvarchar](128) NOT NULL,
	[userId] [int] NOT NULL,
	[lastMessage] [datetime] NOT NULL,
 CONSTRAINT [PK_ForumThreads_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ForumUserRoles]    Script Date: 16.04.2019 18:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ForumUserRoles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[role] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_ForumUserRoles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ForumUsers]    Script Date: 16.04.2019 18:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ForumUsers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](32) NOT NULL,
	[password] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_ForumUsers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersAndRoles]    Script Date: 16.04.2019 18:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersAndRoles](
	[userId] [int] NOT NULL,
	[roleId] [int] NOT NULL,
 CONSTRAINT [PK_UsersAndRoles] PRIMARY KEY CLUSTERED 
(
	[userId] ASC,
	[roleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ForumThreads]    Script Date: 16.04.2019 18:27:33 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_ForumThreads] ON [dbo].[ForumThreads]
(
	[subject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ForumUsers]    Script Date: 16.04.2019 18:27:33 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_ForumUsers] ON [dbo].[ForumUsers]
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ForumPosts]  WITH CHECK ADD  CONSTRAINT [FK_ForumPosts_ForumThreads] FOREIGN KEY([threadId])
REFERENCES [dbo].[ForumThreads] ([id])
GO
ALTER TABLE [dbo].[ForumPosts] CHECK CONSTRAINT [FK_ForumPosts_ForumThreads]
GO
ALTER TABLE [dbo].[ForumPosts]  WITH CHECK ADD  CONSTRAINT [FK_ForumPosts_ForumUsers] FOREIGN KEY([userId])
REFERENCES [dbo].[ForumUsers] ([id])
GO
ALTER TABLE [dbo].[ForumPosts] CHECK CONSTRAINT [FK_ForumPosts_ForumUsers]
GO
ALTER TABLE [dbo].[ForumThreads]  WITH CHECK ADD  CONSTRAINT [FK_ForumThreads_ForumUsers] FOREIGN KEY([userId])
REFERENCES [dbo].[ForumUsers] ([id])
GO
ALTER TABLE [dbo].[ForumThreads] CHECK CONSTRAINT [FK_ForumThreads_ForumUsers]
GO
ALTER TABLE [dbo].[ForumUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_ForumUserRoles_ForumUserRoles] FOREIGN KEY([id])
REFERENCES [dbo].[ForumUserRoles] ([id])
GO
ALTER TABLE [dbo].[ForumUserRoles] CHECK CONSTRAINT [FK_ForumUserRoles_ForumUserRoles]
GO
ALTER TABLE [dbo].[UsersAndRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsersAndRoles_ForumUserRoles] FOREIGN KEY([roleId])
REFERENCES [dbo].[ForumUserRoles] ([id])
GO
ALTER TABLE [dbo].[UsersAndRoles] CHECK CONSTRAINT [FK_UsersAndRoles_ForumUserRoles]
GO
ALTER TABLE [dbo].[UsersAndRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsersAndRoles_ForumUsers] FOREIGN KEY([userId])
REFERENCES [dbo].[ForumUsers] ([id])
GO
ALTER TABLE [dbo].[UsersAndRoles] CHECK CONSTRAINT [FK_UsersAndRoles_ForumUsers]
GO
/****** Object:  StoredProcedure [dbo].[Authentication]    Script Date: 16.04.2019 18:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Authentication]
	@username NVARCHAR(32)
AS
BEGIN
	SELECT	password
	FROM	ForumUsers
	WHERE	username = @username
END
GO
/****** Object:  StoredProcedure [dbo].[DeletePost]    Script Date: 16.04.2019 18:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeletePost]
	@id INT
AS
BEGIN
	DELETE
	FROM	ForumPosts
	WHERE	id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteThread]    Script Date: 16.04.2019 18:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteThread]
	@id INT
AS
BEGIN
	DELETE
	FROM	ForumPosts
	WHERE	threadId = @id
	DELETE
	FROM	ForumThreads
	WHERE	id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 16.04.2019 18:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteUser]
	@id INT
AS
BEGIN
	DELETE
	FROM	ForumPosts
	WHERE	userId = @id

	DELETE	P
	FROM	ForumPosts as P
	JOIN	ForumThreads as T
	ON		P.threadId = T.id
	WHERE	T.userId = @id

	DELETE
	FROM	ForumThreads
	WHERE	userId = @id

	DELETE
	FROM	UsersAndRoles
	WHERE	userId = @id

	DELETE
	FROM	ForumUsers
	WHERE	id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[EditPost]    Script Date: 16.04.2019 18:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditPost]
	@id INT,
	@text NVARCHAR(4000),
	@editDate DATETIME
AS
BEGIN
	UPDATE	ForumPosts
	SET		text = @text,
			editDate = @editDate
	WHERE	id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[EditThread]    Script Date: 16.04.2019 18:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditThread]
	@id INT,
	@newSubject NVARCHAR(128)
AS
BEGIN
	UPDATE	ForumThreads
	SET		subject = @newSubject
	WHERE	id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[EditUser]    Script Date: 16.04.2019 18:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditUser]
	@id INT,
	@newUsername NVARCHAR(32),
	@newPassword NVARCHAR(64)
AS
BEGIN
	UPDATE	ForumUsers
	SET		username = ISNULL(@newUsername, username),
			password = ISNULL(@newPassword, password)
	WHERE	id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[EditUserRole]    Script Date: 16.04.2019 18:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditUserRole]
	@userId INT,
	@newRoleId INT
AS
BEGIN
	IF	@newRoleId = 2 OR @newRoleId = 3
	BEGIN
		UPDATE	UsersAndRoles
		SET		roleId = @newRoleId
		WHERE	userId = @userId AND roleId != 4
	END

	IF	@newRoleId = 4
	BEGIN
		INSERT
		INTO	UsersAndRoles (userId, roleId)
		VALUES	(@userId,@newRoleId)
	END

	IF	@newRoleId = 5
	BEGIN
		DELETE
		FROM	UsersAndRoles
		WHERE	userId = @userId AND roleId = 4
	END
END
GO
/****** Object:  StoredProcedure [dbo].[GetPost]    Script Date: 16.04.2019 18:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetPost]
	@id INT
AS
BEGIN
	SELECT	P.id as postId, P.text, T.subject, U.username, U.id as userId, P.publishDate, P.editDate
	FROM	ForumPosts as P
	JOIN	ForumThreads as T
	ON		P.threadId = T.id
	JOIN	ForumUsers as U
	ON		P.userId = U.id
	WHERE	P.id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[GetPostsByThread]    Script Date: 16.04.2019 18:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetPostsByThread]
	@id INT
AS
BEGIN
	SELECT	P.id as postId, P.text, T.subject, U.username, U.id as userId, P.publishDate, P.editDate
	FROM	ForumPosts as P
	JOIN	ForumThreads as T
	ON		P.threadId = T.id
	JOIN	ForumUsers as U
	ON		P.userId = U.id
	WHERE	T.id = @id
	ORDER BY	P.publishDate
END
GO
/****** Object:  StoredProcedure [dbo].[GetPostsByUser]    Script Date: 16.04.2019 18:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetPostsByUser]
	@id INT
AS
BEGIN
	SELECT	P.id as postId, P.text, T.subject, U.username, U.id as userId, P.publishDate, P.editDate
	FROM	ForumPosts as P
	JOIN	ForumThreads as T
	ON		P.threadId = T.id
	JOIN	ForumUsers as U
	ON		P.userId = U.id
	WHERE	U.id = @id
	ORDER BY P.publishDate DESC
END
GO
/****** Object:  StoredProcedure [dbo].[GetRole]    Script Date: 16.04.2019 18:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetRole]
	@username NVARCHAR(32)
AS
BEGIN
	SELECT	R.role
	FROM	ForumUsers as U
	JOIN	UsersAndRoles as X
	ON		U.id = X.userId
	JOIN	ForumUserRoles as R
	ON		X.roleId = R.id
	WHERE	username = @username
END
GO
/****** Object:  StoredProcedure [dbo].[GetThread]    Script Date: 16.04.2019 18:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetThread]
	@id INT
AS
BEGIN
	SELECT	T.id as threadId,
			subject,
			username,
			U.id as userId,
			lastMessage
	FROM	ForumThreads as T
	JOIN	ForumUsers as U
	ON		T.userId = U.id
	WHERE	T.id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[GetThreadId]    Script Date: 16.04.2019 18:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetThreadId]
	@threadName NVARCHAR(128)
AS
BEGIN
	SELECT	id
	FROM	ForumThreads as T
	WHERE	T.subject = @threadName
END
GO
/****** Object:  StoredProcedure [dbo].[GetThreads]    Script Date: 16.04.2019 18:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetThreads]
AS
BEGIN
	SELECT	T.id as threadId,
			subject,
			username,
			U.id as userId,
			lastMessage
	FROM	ForumThreads as T JOIN ForumUsers as U
	ON		T.userId = U.id
	ORDER BY lastMessage DESC
END
GO
/****** Object:  StoredProcedure [dbo].[GetThreadsByUser]    Script Date: 16.04.2019 18:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetThreadsByUser]
	@id INT
AS
BEGIN
	SELECT	T.id as threadId,
			subject,
			username,
			U.id as userId,
			lastMessage
	FROM	ForumThreads as T JOIN ForumUsers as U
	ON		T.userId = U.id
	WHERE	U.id = @id
	ORDER BY T.lastMessage DESC
END
GO
/****** Object:  StoredProcedure [dbo].[GetUser]    Script Date: 16.04.2019 18:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUser]
	@id INT
AS
BEGIN
	SELECT	id,
			username
	FROM	ForumUsers
	WHERE	id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserId]    Script Date: 16.04.2019 18:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserId]
	@username NVARCHAR(32)
AS
BEGIN
	SELECT	id
	FROM	ForumUsers
	WHERE	username = @username
END
GO
/****** Object:  StoredProcedure [dbo].[GetUsers]    Script Date: 16.04.2019 18:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUsers]

AS
BEGIN
	SELECT	id,
			username
	FROM	ForumUsers
	ORDER BY username
END
GO
/****** Object:  StoredProcedure [dbo].[NewPost]    Script Date: 16.04.2019 18:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[NewPost]
	@text NVARCHAR(4000),
	@threadId INT,
	@username NVARCHAR(32),
	@publishDate DATETIME
AS
BEGIN
	INSERT
	INTO	ForumPosts(text, threadId, userId, publishDate)
	SELECT	@text, @threadId, U.id, @publishDate
	FROM	ForumUsers as U
	WHERE	U.username = @username

	UPDATE	ForumThreads
	SET		lastMessage = @publishDate
	WHERE	id = @threadId
END
GO
/****** Object:  StoredProcedure [dbo].[NewThread]    Script Date: 16.04.2019 18:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[NewThread]
	@username NVARCHAR(32),
	@subject NVARCHAR(128),
	@lastMessage DateTime
AS
BEGIN
	INSERT
	INTO	ForumThreads(subject, userId, lastMessage)
	SELECT	@subject, U.id, @lastMessage
	FROM	ForumUsers as U
	WHERE	U.username = @username
END
GO
/****** Object:  StoredProcedure [dbo].[NewUser]    Script Date: 16.04.2019 18:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[NewUser]
	@username NVARCHAR(32),
	@password NVARCHAR(64)
AS
BEGIN
	INSERT
	INTO	ForumUsers(username, password)
	VALUES	(@username, @password)
	INSERT
	INTO	UsersAndRoles(userId,roleId)
	SELECT	id, 3
	FROM	ForumUsers
	WHERE	username = @username
END
GO
USE [master]
GO
ALTER DATABASE [EPAM.Final.Forum] SET  READ_WRITE 
GO
