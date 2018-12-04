# RSSWebAppGenerali

## The things you need:
1. Microsoft Visual Studio Community 2017 Version 15.7.4
1. Microsoft .NET Framework Version 4.7.03056
1. Microsoft SQL Server 2017 (RTM) - 14.0.1000.169

## In Visual Studio:
 * ASP.NET and web development Workload
 * ##### With NuGet Package Manager:
    * Dapper version 1.50.5

## Setting Up Sql
Connect your Database:  
	Open your Web.config file, search for connectionStrings tag and 
  where name="DefaultConnection", set connectionString attribute to
  match your database connectionString.
  
## After setting is done execute the followin script in your database:

```
/****** Object:  Table [dbo].[AspNetFeedLinks]    Script Date: 2018. 12. 04. 22:41:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetFeedLinks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](400) NULL,
	[Link] [nvarchar](400) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRSSItems]    Script Date: 2018. 12. 04. 22:41:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRSSItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](400) NULL,
	[Description] [nvarchar](400) NULL,
	[Link] [nvarchar](400) NULL,
	[Guid] [nvarchar](400) NULL,
	[Category] [nvarchar](400) NULL,
	[PubDate] [nvarchar](400) NULL,
	[IsItRead] [bit] NOT NULL,
	[IsItFavourite] [bit] NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[IdUrl] [nvarchar](400) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRSSItems] ADD  DEFAULT ((0)) FOR [IsItRead]
GO
ALTER TABLE [dbo].[AspNetRSSItems] ADD  DEFAULT ((0)) FOR [IsItFavourite]
GO
ALTER TABLE [dbo].[AspNetFeedLinks]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetRSSItems]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
```
