USE [master]
GO
/****** Object:  Database [UniversityCoursesAndResultDb]    Script Date: 09/01/2016 00:58:20 ******/
CREATE DATABASE [UniversityCoursesAndResultDb] ON  PRIMARY 
( NAME = N'UniversityCoursesAndResultDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\UniversityCoursesAndResultDb.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UniversityCoursesAndResultDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\UniversityCoursesAndResultDb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UniversityCoursesAndResultDb] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniversityCoursesAndResultDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniversityCoursesAndResultDb] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [UniversityCoursesAndResultDb] SET ANSI_NULLS OFF
GO
ALTER DATABASE [UniversityCoursesAndResultDb] SET ANSI_PADDING OFF
GO
ALTER DATABASE [UniversityCoursesAndResultDb] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [UniversityCoursesAndResultDb] SET ARITHABORT OFF
GO
ALTER DATABASE [UniversityCoursesAndResultDb] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [UniversityCoursesAndResultDb] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [UniversityCoursesAndResultDb] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [UniversityCoursesAndResultDb] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [UniversityCoursesAndResultDb] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [UniversityCoursesAndResultDb] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [UniversityCoursesAndResultDb] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [UniversityCoursesAndResultDb] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [UniversityCoursesAndResultDb] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [UniversityCoursesAndResultDb] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [UniversityCoursesAndResultDb] SET  DISABLE_BROKER
GO
ALTER DATABASE [UniversityCoursesAndResultDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [UniversityCoursesAndResultDb] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [UniversityCoursesAndResultDb] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [UniversityCoursesAndResultDb] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [UniversityCoursesAndResultDb] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [UniversityCoursesAndResultDb] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [UniversityCoursesAndResultDb] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [UniversityCoursesAndResultDb] SET  READ_WRITE
GO
ALTER DATABASE [UniversityCoursesAndResultDb] SET RECOVERY SIMPLE
GO
ALTER DATABASE [UniversityCoursesAndResultDb] SET  MULTI_USER
GO
ALTER DATABASE [UniversityCoursesAndResultDb] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [UniversityCoursesAndResultDb] SET DB_CHAINING OFF
GO
USE [UniversityCoursesAndResultDb]
GO
/****** Object:  Table [dbo].[t_designation]    Script Date: 09/01/2016 00:58:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_designation](
	[DesignationId] [int] IDENTITY(1,1) NOT NULL,
	[DesignationName] [varchar](100) NULL,
 CONSTRAINT [PK_t_designation] PRIMARY KEY CLUSTERED 
(
	[DesignationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_department]    Script Date: 09/01/2016 00:58:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_department](
	[Department_Id] [int] IDENTITY(1,1) NOT NULL,
	[Department_Code] [varchar](50) NULL,
	[Department_Name] [varchar](250) NULL,
 CONSTRAINT [PK_t_department] PRIMARY KEY CLUSTERED 
(
	[Department_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_t_department] ON [dbo].[t_department] 
(
	[Department_Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_t_department_1] ON [dbo].[t_department] 
(
	[Department_Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_day]    Script Date: 09/01/2016 00:58:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_day](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_t_day] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_semester]    Script Date: 09/01/2016 00:58:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_semester](
	[Semester_Id] [int] IDENTITY(1,1) NOT NULL,
	[Semester_Name] [varchar](50) NULL,
 CONSTRAINT [PK_t_semester] PRIMARY KEY CLUSTERED 
(
	[Semester_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_room]    Script Date: 09/01/2016 00:58:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_room](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_t_room] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_results]    Script Date: 09/01/2016 00:58:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_results](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NULL,
	[CourseId] [int] NULL,
	[GradeId] [int] NULL,
 CONSTRAINT [PK_t_results] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_grades]    Script Date: 09/01/2016 00:58:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_grades](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Grade] [varchar](50) NULL,
	[Point] [decimal](18, 2) NULL,
 CONSTRAINT [PK_t_grades] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_teacher]    Script Date: 09/01/2016 00:58:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_teacher](
	[TeacherId] [int] IDENTITY(1,1) NOT NULL,
	[TeacherName] [varchar](50) NULL,
	[Address] [varchar](250) NULL,
	[Email] [varchar](100) NULL,
	[ContactNo] [varchar](50) NULL,
	[DesignationId] [int] NULL,
	[DepartmentId] [int] NULL,
	[CreditTaken] [int] NULL,
	[RemainingCredit] [int] NULL,
 CONSTRAINT [PK_t_teacher] PRIMARY KEY CLUSTERED 
(
	[TeacherId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_t_teacher] ON [dbo].[t_teacher] 
(
	[Email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_student]    Script Date: 09/01/2016 00:58:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_student](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[StudentName] [varchar](50) NULL,
	[Email] [varchar](100) NULL,
	[ContactNo] [varchar](50) NULL,
	[RegistrationDate] [date] NULL,
	[Address] [varchar](250) NULL,
	[DepartmentId] [int] NULL,
	[RegistrationNo] [varchar](50) NULL,
 CONSTRAINT [PK_t_student] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_t_student] ON [dbo].[t_student] 
(
	[Email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_courses]    Script Date: 09/01/2016 00:58:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_courses](
	[Course_Id] [int] IDENTITY(1,1) NOT NULL,
	[Course_Name] [varchar](150) NULL,
	[Course_Code] [varchar](50) NULL,
	[Description] [varchar](500) NULL,
	[Credit] [float] NULL,
	[Semester_Id] [int] NULL,
	[Department_Id] [int] NULL,
	[Teacher_Id] [int] NULL,
 CONSTRAINT [PK_t_courses] PRIMARY KEY CLUSTERED 
(
	[Course_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_t_courses] ON [dbo].[t_courses] 
(
	[Course_Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_t_courses_1] ON [dbo].[t_courses] 
(
	[Course_Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_AssignCourse]    Script Date: 09/01/2016 00:58:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_AssignCourse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Teacher_Id] [int] NULL,
	[Course_Id] [int] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_t_AssignCourse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_allocateClassroom]    Script Date: 09/01/2016 00:58:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_allocateClassroom](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NULL,
	[CourseId] [int] NULL,
	[RoomId] [int] NULL,
	[DayId] [int] NULL,
	[TimeTo] [time](7) NULL,
	[TimeFrom] [time](7) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_t_allocateClassroom] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ResultView]    Script Date: 09/01/2016 00:58:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ResultView]
AS
SELECT        dbo.t_results.StudentId, dbo.t_courses.Course_Name, dbo.t_grades.Grade, dbo.t_courses.Course_Code
FROM            dbo.t_results INNER JOIN
                         dbo.t_courses ON dbo.t_results.CourseId = dbo.t_courses.Course_Id INNER JOIN
                         dbo.t_grades ON dbo.t_results.GradeId = dbo.t_grades.Id
GO
/****** Object:  Table [dbo].[t_EnrollStudent]    Script Date: 09/01/2016 00:58:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_EnrollStudent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[CourseId] [int] NOT NULL,
	[studentId] [int] NOT NULL,
	[EnrollDate] [date] NOT NULL,
 CONSTRAINT [PK_t_EnrollStudent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[ViewCourseWithSemester]    Script Date: 09/01/2016 00:58:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[ViewCourseWithSemester] as
select c.Course_Id,c.Course_Name,c.Course_Code,c.Department_Id,s.Semester_Name
from t_courses c Inner join t_semester s
on c.Semester_Id=s.Semester_Id
GO
/****** Object:  View [dbo].[ViewTeacherwithCourse]    Script Date: 09/01/2016 00:58:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[ViewTeacherwithCourse] as
select t.TeacherName,ac.Course_Id,ac.Status
from t_teacher t inner join t_AssignCourse ac
on t.TeacherId=ac.Teacher_Id
GO
/****** Object:  View [dbo].[ViewAllocateClassroom]    Script Date: 09/01/2016 00:58:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewAllocateClassroom]
AS
SELECT     D.Department_Id, C.Course_Code, C.Course_Name, R.Name AS RoomName, ACR.TimeFrom, ACR.TimeTo, ACR.Status, day.Name AS DayName
FROM         dbo.t_day AS day INNER JOIN
                      dbo.t_allocateClassroom AS ACR ON day.Id = ACR.DayId RIGHT OUTER JOIN
                      dbo.t_courses AS C LEFT OUTER JOIN
                      dbo.t_department AS D ON C.Department_Id = D.Department_Id ON ACR.CourseId = C.Course_Id LEFT OUTER JOIN
                      dbo.t_room AS R ON R.Id = ACR.RoomId
WHERE     (ACR.Status IS NULL) OR
                      (ACR.Status = 'true')
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "day"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 95
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "C"
            Begin Extent = 
               Top = 6
               Left = 235
               Bottom = 125
               Right = 397
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "D"
            Begin Extent = 
               Top = 96
               Left = 38
               Bottom = 200
               Right = 217
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "R"
            Begin Extent = 
               Top = 129
               Left = 237
               Bottom = 218
               Right = 397
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ACR"
            Begin Extent = 
               Top = 6
               Left = 436
               Bottom = 125
               Right = 596
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewAllocateClassroom'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewAllocateClassroom'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewAllocateClassroom'
GO
/****** Object:  View [dbo].[t_ViewEnrollCourse]    Script Date: 09/01/2016 00:58:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[t_ViewEnrollCourse]
AS
SELECT        dbo.t_courses.Course_Id, dbo.t_courses.Course_Name, dbo.t_EnrollStudent.studentId
FROM            dbo.t_EnrollStudent INNER JOIN
                         dbo.t_courses ON dbo.t_EnrollStudent.CourseId = dbo.t_courses.Course_Id
GO
/****** Object:  View [dbo].[ViewCourseStatics]    Script Date: 09/01/2016 00:58:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[ViewCourseStatics] as
select cs.Course_Code,cs.Course_Name,cs.Department_Id,cs.Semester_Name,tc.TeacherName,tc.Status
from ViewCourseWithSemester cs Left outer join ViewTeacherwithCourse tc
on cs.Course_Id=tc.Course_id
GO
/****** Object:  ForeignKey [FK_t_teacher_t_designation]    Script Date: 09/01/2016 00:58:22 ******/
ALTER TABLE [dbo].[t_teacher]  WITH CHECK ADD  CONSTRAINT [FK_t_teacher_t_designation] FOREIGN KEY([DesignationId])
REFERENCES [dbo].[t_designation] ([DesignationId])
GO
ALTER TABLE [dbo].[t_teacher] CHECK CONSTRAINT [FK_t_teacher_t_designation]
GO
/****** Object:  ForeignKey [FK_t_teacher_t_teacher]    Script Date: 09/01/2016 00:58:22 ******/
ALTER TABLE [dbo].[t_teacher]  WITH CHECK ADD  CONSTRAINT [FK_t_teacher_t_teacher] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[t_department] ([Department_Id])
GO
ALTER TABLE [dbo].[t_teacher] CHECK CONSTRAINT [FK_t_teacher_t_teacher]
GO
/****** Object:  ForeignKey [FK_t_student_t_department]    Script Date: 09/01/2016 00:58:22 ******/
ALTER TABLE [dbo].[t_student]  WITH CHECK ADD  CONSTRAINT [FK_t_student_t_department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[t_department] ([Department_Id])
GO
ALTER TABLE [dbo].[t_student] CHECK CONSTRAINT [FK_t_student_t_department]
GO
/****** Object:  ForeignKey [FK_t_courses_t_department]    Script Date: 09/01/2016 00:58:22 ******/
ALTER TABLE [dbo].[t_courses]  WITH CHECK ADD  CONSTRAINT [FK_t_courses_t_department] FOREIGN KEY([Department_Id])
REFERENCES [dbo].[t_department] ([Department_Id])
GO
ALTER TABLE [dbo].[t_courses] CHECK CONSTRAINT [FK_t_courses_t_department]
GO
/****** Object:  ForeignKey [FK_t_courses_t_semester]    Script Date: 09/01/2016 00:58:22 ******/
ALTER TABLE [dbo].[t_courses]  WITH CHECK ADD  CONSTRAINT [FK_t_courses_t_semester] FOREIGN KEY([Semester_Id])
REFERENCES [dbo].[t_semester] ([Semester_Id])
GO
ALTER TABLE [dbo].[t_courses] CHECK CONSTRAINT [FK_t_courses_t_semester]
GO
/****** Object:  ForeignKey [FK_t_courses_t_teacher]    Script Date: 09/01/2016 00:58:22 ******/
ALTER TABLE [dbo].[t_courses]  WITH CHECK ADD  CONSTRAINT [FK_t_courses_t_teacher] FOREIGN KEY([Teacher_Id])
REFERENCES [dbo].[t_teacher] ([TeacherId])
GO
ALTER TABLE [dbo].[t_courses] CHECK CONSTRAINT [FK_t_courses_t_teacher]
GO
/****** Object:  ForeignKey [FK_t_AssignCourse_t_courses]    Script Date: 09/01/2016 00:58:22 ******/
ALTER TABLE [dbo].[t_AssignCourse]  WITH CHECK ADD  CONSTRAINT [FK_t_AssignCourse_t_courses] FOREIGN KEY([Course_Id])
REFERENCES [dbo].[t_courses] ([Course_Id])
GO
ALTER TABLE [dbo].[t_AssignCourse] CHECK CONSTRAINT [FK_t_AssignCourse_t_courses]
GO
/****** Object:  ForeignKey [FK_t_AssignCourse_t_teacher]    Script Date: 09/01/2016 00:58:22 ******/
ALTER TABLE [dbo].[t_AssignCourse]  WITH CHECK ADD  CONSTRAINT [FK_t_AssignCourse_t_teacher] FOREIGN KEY([Teacher_Id])
REFERENCES [dbo].[t_teacher] ([TeacherId])
GO
ALTER TABLE [dbo].[t_AssignCourse] CHECK CONSTRAINT [FK_t_AssignCourse_t_teacher]
GO
/****** Object:  ForeignKey [FK_t_allocateClassroom_t_courses]    Script Date: 09/01/2016 00:58:22 ******/
ALTER TABLE [dbo].[t_allocateClassroom]  WITH CHECK ADD  CONSTRAINT [FK_t_allocateClassroom_t_courses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[t_courses] ([Course_Id])
GO
ALTER TABLE [dbo].[t_allocateClassroom] CHECK CONSTRAINT [FK_t_allocateClassroom_t_courses]
GO
/****** Object:  ForeignKey [FK_t_allocateClassroom_t_day]    Script Date: 09/01/2016 00:58:22 ******/
ALTER TABLE [dbo].[t_allocateClassroom]  WITH CHECK ADD  CONSTRAINT [FK_t_allocateClassroom_t_day] FOREIGN KEY([DayId])
REFERENCES [dbo].[t_day] ([Id])
GO
ALTER TABLE [dbo].[t_allocateClassroom] CHECK CONSTRAINT [FK_t_allocateClassroom_t_day]
GO
/****** Object:  ForeignKey [FK_t_allocateClassroom_t_department]    Script Date: 09/01/2016 00:58:22 ******/
ALTER TABLE [dbo].[t_allocateClassroom]  WITH CHECK ADD  CONSTRAINT [FK_t_allocateClassroom_t_department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[t_department] ([Department_Id])
GO
ALTER TABLE [dbo].[t_allocateClassroom] CHECK CONSTRAINT [FK_t_allocateClassroom_t_department]
GO
/****** Object:  ForeignKey [FK_t_allocateClassroom_t_room]    Script Date: 09/01/2016 00:58:22 ******/
ALTER TABLE [dbo].[t_allocateClassroom]  WITH CHECK ADD  CONSTRAINT [FK_t_allocateClassroom_t_room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[t_room] ([Id])
GO
ALTER TABLE [dbo].[t_allocateClassroom] CHECK CONSTRAINT [FK_t_allocateClassroom_t_room]
GO
/****** Object:  ForeignKey [FK_t_EnrollStudent_t_courses]    Script Date: 09/01/2016 00:58:23 ******/
ALTER TABLE [dbo].[t_EnrollStudent]  WITH CHECK ADD  CONSTRAINT [FK_t_EnrollStudent_t_courses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[t_courses] ([Course_Id])
GO
ALTER TABLE [dbo].[t_EnrollStudent] CHECK CONSTRAINT [FK_t_EnrollStudent_t_courses]
GO
/****** Object:  ForeignKey [FK_t_EnrollStudent_t_student]    Script Date: 09/01/2016 00:58:23 ******/
ALTER TABLE [dbo].[t_EnrollStudent]  WITH CHECK ADD  CONSTRAINT [FK_t_EnrollStudent_t_student] FOREIGN KEY([studentId])
REFERENCES [dbo].[t_student] ([StudentId])
GO
ALTER TABLE [dbo].[t_EnrollStudent] CHECK CONSTRAINT [FK_t_EnrollStudent_t_student]
GO
