USE [ScheduleDB]
GO
/****** Object:  Table [dbo].[Restrictions]    Script Date: 2017-08-14 10:37:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Restrictions](
	[StudentID] [nvarchar](50) NOT NULL,
	[NoGapsBiggerThanOneHour] [bit] NOT NULL,
	[MustHaveOneHourBreaks] [bit] NOT NULL,
	[Timeslots] [nvarchar](4000) NULL,
 CONSTRAINT [PK_Restrictions] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Schedules]    Script Date: 2017-08-14 10:37:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedules](
	[StudentID] [nvarchar](50) NOT NULL,
	[SectionID] [int] NOT NULL,
 CONSTRAINT [PK_Schedules] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC,
	[SectionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sections]    Script Date: 2017-08-14 10:37:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sections](
	[SectionID] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [nvarchar](50) NOT NULL,
	[Timeslots] [nvarchar](4000) NOT NULL,
 CONSTRAINT [PK_Sections] PRIMARY KEY CLUSTERED 
(
	[SectionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 2017-08-14 10:37:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentID] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Program] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Restrictions] ([StudentID], [NoGapsBiggerThanOneHour], [MustHaveOneHourBreaks], [Timeslots]) VALUES (N'galjohn', 0, 1, N'[{"ClassTime":[0,0,16,20,0,0,0,0,0,0,0,0,0,0],"Professor":""}]')
SET IDENTITY_INSERT [dbo].[Sections] ON 

INSERT [dbo].[Sections] ([SectionID], [CourseName], [Timeslots]) VALUES (1025, N'Math', N'[{"ClassTime":[0,0,8,11,0,0,0,0,0,0,0,0,0,0],"Professor":"John"},{"ClassTime":[0,0,8,11,0,0,0,0,0,0,0,0,0,0],"Professor":"John"},{"ClassTime":[0,0,0,0,0,0,8,11,0,0,0,0,0,0],"Professor":"Jamie"},{"ClassTime":[0,0,0,0,0,0,0,0,8,11,0,0,0,0],"Professor":"Jamie"}]')
INSERT [dbo].[Sections] ([SectionID], [CourseName], [Timeslots]) VALUES (1029, N'Programming', N'[{"ClassTime":[0,0,0,0,0,0,12,15,0,0,0,0,0,0],"Professor":"Buck"},{"ClassTime":[0,0,0,0,0,0,0,0,11,14,0,0,0,0],"Professor":"Buck"},{"ClassTime":[0,0,12,15,0,0,0,0,0,0,0,0,0,0],"Professor":"Bob"},{"ClassTime":[0,0,0,0,0,0,0,0,11,14,0,0,0,0],"Professor":"Bob"},{"ClassTime":[0,0,11,14,0,0,0,0,11,14,0,0,0,0],"Professor":"Bill"}]')
INSERT [dbo].[Sections] ([SectionID], [CourseName], [Timeslots]) VALUES (1032, N'Database', N'[{"ClassTime":[0,0,0,0,11,14,0,0,0,0,0,0,0,0],"Professor":"Cid"},{"ClassTime":[0,0,0,0,0,0,11,14,0,0,0,0,0,0],"Professor":"Cid"},{"ClassTime":[0,0,15,18,0,0,0,0,0,0,0,0,0,0],"Professor":"Cid"},{"ClassTime":[0,0,15,18,0,0,0,0,0,0,0,0,0,0],"Professor":"Cole"},{"ClassTime":[0,0,0,0,0,0,0,0,0,0,14,17,0,0],"Professor":"Cole"}]')
INSERT [dbo].[Sections] ([SectionID], [CourseName], [Timeslots]) VALUES (1033, N'Business', N'[{"ClassTime":[0,0,0,0,0,0,0,0,0,0,11,14,0,0],"Professor":"Daniel"},{"ClassTime":[0,0,0,0,0,0,0,0,0,0,12,15,0,0],"Professor":"Dante"}]')
INSERT [dbo].[Sections] ([SectionID], [CourseName], [Timeslots]) VALUES (1034, N'Logic', N'[{"ClassTime":[0,0,0,0,0,0,0,0,0,0,8,11,0,0],"Professor":"Emir"},{"ClassTime":[0,0,0,0,0,0,8,11,0,0,0,0,0,0],"Professor":"Elton"}]')
INSERT [dbo].[Sections] ([SectionID], [CourseName], [Timeslots]) VALUES (1035, N'Elective', N'[{"ClassTime":[0,0,0,0,8,11,0,0,0,0,0,0,0,0],"Professor":"Emir"},{"ClassTime":[0,0,0,0,0,0,11,14,0,0,0,0,0,0],"Professor":"Emir"},{"ClassTime":[0,0,0,0,0,0,0,0,8,11,0,0,0,0],"Professor":"Elton"}]')
SET IDENTITY_INSERT [dbo].[Sections] OFF
INSERT [dbo].[Students] ([StudentID], [FirstName], [LastName], [Program], [Password]) VALUES (N'galjohn', N'John', N'Gallant', N'Computer Systems Technician', N'12345')
ALTER TABLE [dbo].[Restrictions]  WITH CHECK ADD  CONSTRAINT [FK_Restrictions_Students] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([StudentID])
GO
ALTER TABLE [dbo].[Restrictions] CHECK CONSTRAINT [FK_Restrictions_Students]
GO
ALTER TABLE [dbo].[Schedules]  WITH CHECK ADD  CONSTRAINT [FK_Schedules_Sections] FOREIGN KEY([SectionID])
REFERENCES [dbo].[Sections] ([SectionID])
GO
ALTER TABLE [dbo].[Schedules] CHECK CONSTRAINT [FK_Schedules_Sections]
GO
ALTER TABLE [dbo].[Schedules]  WITH CHECK ADD  CONSTRAINT [FK_Schedules_Students] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([StudentID])
GO
ALTER TABLE [dbo].[Schedules] CHECK CONSTRAINT [FK_Schedules_Students]
GO
