USE [Student]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 19.03.2025 11:48:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Familia] [nchar](50) NOT NULL,
	[Ima] [nchar](50) NOT NULL,
	[Otchestvo] [nchar](50) NOT NULL,
	[idZachetnoKinigi] [int] NOT NULL,
	[ChivetVObchaga] [bit] NULL,
	[IdGruppa] [int] NOT NULL,
	[Math] [bit] NULL,
	[History] [bit] NULL,
	[Informatic] [bit] NULL,
	[PhysicalEdication] [bit] NULL,
	[English] [bit] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
