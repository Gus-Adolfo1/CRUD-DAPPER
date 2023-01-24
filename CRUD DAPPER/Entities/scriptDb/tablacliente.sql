 CREATE DATABASE [CRUD_DAPPER]
 GO
 

 USE [CRUD_DAPPER] 
GO

/****** Object:  Table [dbo].[Cliente]    Script Date: 24/1/2023 11:12:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[CreationDate] [datetime] NULL,
	[ModificationDate] [datetime] NULL,
	[ModifyBy] [nvarchar](25) NULL,
	[CreateBy] [nvarchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Cliente] ADD  DEFAULT (getdate()) FOR [CreationDate]
GO

ALTER TABLE [dbo].[Cliente] ADD  DEFAULT (getdate()) FOR [ModificationDate]
GO

