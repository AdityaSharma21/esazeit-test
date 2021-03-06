USE [demo]
GO
/****** Object:  Table [dbo].[mst_student]    Script Date: 10/5/2017 8:07:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mst_student](
	[student_id] [bigint] IDENTITY(1,1) NOT NULL,
	[student_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_mst_student] PRIMARY KEY CLUSTERED 
(
	[student_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[mst_subjectmarks]    Script Date: 10/5/2017 8:07:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mst_subjectmarks](
	[subject_id] [bigint] IDENTITY(1,1) NOT NULL,
	[student_id] [bigint] NOT NULL,
	[subject_name] [nvarchar](100) NOT NULL,
	[marks] [numeric](10, 2) NOT NULL,
 CONSTRAINT [PK_mst_subjectmarks] PRIMARY KEY CLUSTERED 
(
	[subject_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[mst_subjectmarks]  WITH CHECK ADD  CONSTRAINT [FK_mst_subjectmarks_mst_student] FOREIGN KEY([student_id])
REFERENCES [dbo].[mst_student] ([student_id])
GO
ALTER TABLE [dbo].[mst_subjectmarks] CHECK CONSTRAINT [FK_mst_subjectmarks_mst_student]
GO
