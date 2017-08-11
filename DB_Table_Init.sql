USE [ScheduleDB]
GO

ALTER TABLE [dbo].[Schedule] DROP CONSTRAINT [FK_Schedule_Students]
GO

ALTER TABLE [dbo].[Schedule] DROP CONSTRAINT [FK_Schedule_Sections]
GO

/****** Object:  Table [dbo].[Students]    Script Date: 2017-08-11 8:46:01 AM ******/
DROP TABLE [dbo].[Students]
GO

/****** Object:  Table [dbo].[Students]    Script Date: 2017-08-11 8:46:01 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Students](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Program] [nvarchar](50) NOT NULL,
	[Restrictions] [nvarchar](150) NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [ScheduleDB]
GO

/****** Object:  Table [dbo].[Sections]    Script Date: 2017-08-11 8:45:56 AM ******/
DROP TABLE [dbo].[Sections]
GO

/****** Object:  Table [dbo].[Sections]    Script Date: 2017-08-11 8:45:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sections](
	[SectionID] [int] NOT NULL,
	[CourseName] [nvarchar](50) NOT NULL,
	[Professor] [nvarchar](100) NULL,
	[CourseTimes] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_Sections] PRIMARY KEY CLUSTERED 
(
	[SectionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [ScheduleDB]
GO

/****** Object:  Table [dbo].[Schedule]    Script Date: 2017-08-11 8:45:49 AM ******/
DROP TABLE [dbo].[Schedule]
GO

/****** Object:  Table [dbo].[Schedule]    Script Date: 2017-08-11 8:45:49 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Schedule](
	[StudentID] [int] NOT NULL,
	[SectionID] [int] NOT NULL,
 CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC,
	[SectionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Sections] FOREIGN KEY([SectionID])
REFERENCES [dbo].[Sections] ([SectionID])
GO

ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_Sections]
GO

ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Students] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([StudentID])
GO

ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_Students]
GO




