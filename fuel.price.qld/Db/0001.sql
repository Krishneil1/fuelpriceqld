SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FullSiteDetails](
	[SiteId] [int] NOT NULL,
	[Address] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[BrandId] [int] NOT NULL,
	[PostCode] [int] NOT NULL,
	[GeoRegionId] [int] NOT NULL,
	[GeoRegionParentId] [int] NOT NULL,
	[GeoRegionParentId3] [int] NOT NULL,
	[GeoRegionParentId4] [int] NOT NULL,
	[GeoRegionParentId5] [int] NOT NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_FullSiteDetails] PRIMARY KEY CLUSTERED 
(
	[SiteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
