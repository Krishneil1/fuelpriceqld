
/****** Object:  Table [dbo].[GeographicRegions]    Script Date: 24/07/2022 9:30:30 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[GeographicRegions](
	[GeographicRegionId] [int] NOT NULL,
	[GeoRegionLevel] [int] NOT NULL,
	[GeoRegionId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Abbrev] [nvarchar](max) NULL,
	[GeoRegionParentId] [nvarchar](max) NULL,
 CONSTRAINT [PK_GeographicRegions] PRIMARY KEY CLUSTERED 
(
	[GeographicRegionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


