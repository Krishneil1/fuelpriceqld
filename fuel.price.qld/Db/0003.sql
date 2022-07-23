﻿/****** Object:  Table [dbo].[FuelTypes]    Script Date: 24/07/2022 9:29:38 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FuelTypes](
	[FuelId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_FuelTypes] PRIMARY KEY CLUSTERED 
(
	[FuelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


