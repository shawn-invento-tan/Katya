USE [katya_loyalty]
GO
ALTER TABLE [dbo].[receipt_item] DROP CONSTRAINT [DF_receipt_item_total]
GO
ALTER TABLE [dbo].[receipt_item] DROP CONSTRAINT [DF_receipt_item_quantity]
GO
ALTER TABLE [dbo].[receipt] DROP CONSTRAINT [DF_receipt_total]
GO
ALTER TABLE [dbo].[ocr_receipt_item] DROP CONSTRAINT [DF_ocr_receipt_item_total]
GO
ALTER TABLE [dbo].[ocr_receipt_item] DROP CONSTRAINT [DF_ocr_receipt_item_quantity]
GO
/****** Object:  Index [UX_customer_token_identifier]    Script Date: 24/11/2020 9:39:19 PM ******/
DROP INDEX [UX_customer_token_identifier] ON [dbo].[customer_token]
GO
/****** Object:  Index [UX_customer_token_customer_id_token_type_id]    Script Date: 24/11/2020 9:39:19 PM ******/
DROP INDEX [UX_customer_token_customer_id_token_type_id] ON [dbo].[customer_token]
GO
/****** Object:  Index [UX_customer_phone_country_code_phone_number]    Script Date: 24/11/2020 9:39:19 PM ******/
DROP INDEX [UX_customer_phone_country_code_phone_number] ON [dbo].[customer]
GO
/****** Object:  Index [UX_customer_email]    Script Date: 24/11/2020 9:39:19 PM ******/
DROP INDEX [UX_customer_email] ON [dbo].[customer]
GO
/****** Object:  Table [dbo].[reward]    Script Date: 24/11/2020 9:39:19 PM ******/
DROP TABLE [dbo].[reward]
GO
/****** Object:  Table [dbo].[receipt_item]    Script Date: 24/11/2020 9:39:19 PM ******/
DROP TABLE [dbo].[receipt_item]
GO
/****** Object:  Table [dbo].[receipt]    Script Date: 24/11/2020 9:39:19 PM ******/
DROP TABLE [dbo].[receipt]
GO
/****** Object:  Table [dbo].[ocr_receipt_item]    Script Date: 24/11/2020 9:39:19 PM ******/
DROP TABLE [dbo].[ocr_receipt_item]
GO
/****** Object:  Table [dbo].[ocr_receipt]    Script Date: 24/11/2020 9:39:19 PM ******/
DROP TABLE [dbo].[ocr_receipt]
GO
/****** Object:  Table [dbo].[customer_token]    Script Date: 24/11/2020 9:39:19 PM ******/
DROP TABLE [dbo].[customer_token]
GO
/****** Object:  Table [dbo].[customer_profile]    Script Date: 24/11/2020 9:39:19 PM ******/
DROP TABLE [dbo].[customer_profile]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 24/11/2020 9:39:19 PM ******/
DROP TABLE [dbo].[customer]
GO
/****** Object:  Table [dbo].[company]    Script Date: 24/11/2020 9:39:19 PM ******/
DROP TABLE [dbo].[company]
GO
/****** Object:  Table [dbo].[company]    Script Date: 24/11/2020 9:39:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[company](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[login_code] [varchar](50) NOT NULL,
 CONSTRAINT [PK_company] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[customer]    Script Date: 24/11/2020 9:39:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[customer_profile]    Script Date: 24/11/2020 9:39:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[customer_token]    Script Date: 24/11/2020 9:39:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ocr_receipt]    Script Date: 24/11/2020 9:39:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ocr_receipt](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[customer_id] [bigint] NOT NULL,
	[file_name] [varchar](max) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[ocr_receipt_status_id] [int] NOT NULL,
	[receipt_issuer_id] [int] NULL,
	[receipt_number] [varchar](100) NULL,
	[receipt_date] [datetime] NULL,
	[store_code] [varchar](100) NULL,
	[total] [decimal](19, 2) NULL,
 CONSTRAINT [PK_ocr_receipt] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ocr_receipt_item]    Script Date: 24/11/2020 9:39:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ocr_receipt_item](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[ocr_receipt_id] [bigint] NOT NULL,
	[sku] [varchar](100) NULL,
	[item_name] [varchar](255) NULL,
	[quantity] [decimal](19, 2) NULL,
	[total] [decimal](19, 2) NULL,
 CONSTRAINT [PK_ocr_receipt_item] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[receipt]    Script Date: 24/11/2020 9:39:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[receipt](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[customer_id] [bigint] NOT NULL,
	[created_date] [datetime] NOT NULL,
	[receipt_issuer_id] [int] NOT NULL,
	[receipt_number] [varchar](100) NOT NULL,
	[receipt_date] [datetime] NOT NULL,
	[store_code] [varchar](100) NULL,
	[total] [decimal](19, 2) NOT NULL,
 CONSTRAINT [PK_receipt] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[receipt_item]    Script Date: 24/11/2020 9:39:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[receipt_item](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[receipt_id] [bigint] NOT NULL,
	[sku] [varchar](100) NOT NULL,
	[item_name] [varchar](255) NULL,
	[quantity] [decimal](19, 2) NOT NULL,
	[total] [decimal](19, 2) NOT NULL,
 CONSTRAINT [PK_receipt_item] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[reward]    Script Date: 24/11/2020 9:39:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[reward](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[company_id] [bigint] NOT NULL,
	[name] [varchar](255) NOT NULL,
	[description] [varchar](255) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[reward_status_id] [int] NOT NULL,
	[effective_date] [datetime] NULL,
	[expiry_date] [datetime] NULL,
 CONSTRAINT [PK_reward] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UX_customer_email]    Script Date: 24/11/2020 9:39:19 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_customer_email] ON [dbo].[customer]
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UX_customer_phone_country_code_phone_number]    Script Date: 24/11/2020 9:39:19 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_customer_phone_country_code_phone_number] ON [dbo].[customer]
(
	[phone_country_code] ASC,
	[phone_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UX_customer_token_customer_id_token_type_id]    Script Date: 24/11/2020 9:39:19 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_customer_token_customer_id_token_type_id] ON [dbo].[customer_token]
(
	[customer_id] ASC,
	[token_type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UX_customer_token_identifier]    Script Date: 24/11/2020 9:39:19 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_customer_token_identifier] ON [dbo].[customer_token]
(
	[identifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ocr_receipt_item] ADD  CONSTRAINT [DF_ocr_receipt_item_quantity]  DEFAULT ((0)) FOR [quantity]
GO
ALTER TABLE [dbo].[ocr_receipt_item] ADD  CONSTRAINT [DF_ocr_receipt_item_total]  DEFAULT ((0)) FOR [total]
GO
ALTER TABLE [dbo].[receipt] ADD  CONSTRAINT [DF_receipt_total]  DEFAULT ((0)) FOR [total]
GO
ALTER TABLE [dbo].[receipt_item] ADD  CONSTRAINT [DF_receipt_item_quantity]  DEFAULT ((0)) FOR [quantity]
GO
ALTER TABLE [dbo].[receipt_item] ADD  CONSTRAINT [DF_receipt_item_total]  DEFAULT ((0)) FOR [total]
GO
