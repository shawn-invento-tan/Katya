USE [katya_loyalty]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 11/17/2020 9:27:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[email] [varchar](255) NOT NULL,
	[phone_country_code] [varchar](10) NOT NULL,
	[phone_number] [varchar](50) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[password_salt] [varchar](max) NULL,
	[password_hash] [varchar](max) NULL,
 CONSTRAINT [PK_customer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customer_profile]    Script Date: 11/17/2020 9:27:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer_profile](
	[customer_id] [bigint] NOT NULL,
	[first_name] [varchar](255) NOT NULL,
	[middle_name] [varchar](255) NULL,
	[last_name] [varchar](255) NULL,
	[birth_date] [datetime] NULL,
	[gender] [bit] NULL,
 CONSTRAINT [PK_customer_profile] PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[customer_token]    Script Date: 11/17/2020 9:27:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer_token](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[customer_id] [bigint] NOT NULL,
	[token_type_id] [smallint] NOT NULL,
	[identifier] [varchar](64) NOT NULL,
	[private_key] [varchar](128) NULL,
	[checksum] [varchar](128) NULL,
	[expiry_date] [datetime] NULL,
 CONSTRAINT [PK_customer_token] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_customer_email]    Script Date: 11/17/2020 9:27:36 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_customer_email] ON [dbo].[customer]
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_customer_phone_country_code_phone_number]    Script Date: 11/17/2020 9:27:36 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_customer_phone_country_code_phone_number] ON [dbo].[customer]
(
	[phone_country_code] ASC,
	[phone_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UX_customer_token_customer_id_token_type_id]    Script Date: 11/17/2020 9:27:36 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_customer_token_customer_id_token_type_id] ON [dbo].[customer_token]
(
	[customer_id] ASC,
	[token_type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UX_customer_token_identifier]    Script Date: 11/17/2020 9:27:36 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_customer_token_identifier] ON [dbo].[customer_token]
(
	[identifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
