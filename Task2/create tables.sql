USE [Task2]
GO

/****** Object:  Table [dbo].[ClientContacts]    Script Date: 4/6/2025 1:52:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ClientContacts](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ClientId] [bigint] NOT NULL,
	[ContactType] [nvarchar](255) NOT NULL,
	[ContactValue] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [Task2]
GO

/****** Object:  Table [dbo].[Clients]    Script Date: 4/6/2025 1:52:31 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Clients](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ClientName] [nvarchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


