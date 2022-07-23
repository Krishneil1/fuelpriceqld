/****** Object:  Table [dbo].[SitePrices]    Script Date: 24/07/2022 9:31:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SitePrices](
	[PriceId] [int] NOT NULL,
	[SiteId] [int] NOT NULL,
	[FuelId] [int] NOT NULL,
	[CollectionMethod] [nvarchar](max) NULL,
	[TransactionDateUtc] [datetime2](7) NOT NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_SitePrices] PRIMARY KEY CLUSTERED 
(
	[PriceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
