USE [master] 
GO
ALTER DATABASE [HMS] COLLATE ARABIC_CI_AS
GO



USE [HMS]  
GO
CREATE TABLE [dbo].[users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[uname] [nvarchar](50) NOT NULL UNIQUE,
	[upass] [nvarchar](MAX) NOT NULL,
	[ugroup] [nvarchar](MAX) NOT NULL,
	[ustat] [nvarchar](MAX) NOT NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



USE [HMS]  
GO
CREATE TABLE [dbo].[services](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[scode] [nvarchar](50) NOT NULL UNIQUE,
	[snamear] [nvarchar](MAX) NOT NULL,
	[snameen] [nvarchar](MAX) NOT NULL,
	[dept] [nvarchar](MAX) NOT NULL,
	[sprice] [float] NOT NULL,
 CONSTRAINT [PK_services] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



USE [HMS]  
GO
CREATE TABLE [dbo].[check](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[pid] [int] NOT NULL,
	[pname] [nvarchar](MAX) NOT NULL,
	[chdate] datetime NOT NULL,
	[dept] [nvarchar](MAX) NOT NULL,
	[doctor] [nvarchar](MAX) NOT NULL,
	[chtype] [nvarchar](MAX) NOT NULL,
	[total] [float] NOT NULL,
	[user] [nvarchar](MAX) NOT NULL,
	[invno] [int] NOT NULL UNIQUE,
	[invstat] [nvarchar](MAX) NOT NULL,
 CONSTRAINT [PK_check] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



USE [HMS]  
GO
CREATE TABLE [dbo].[patients](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[pid] [int] NOT NULL UNIQUE,
	[pname] [nvarchar](MAX) NULL,
	[pident] [nvarchar](100) NOT NULL,
	[pbdate] datetime NULL,
	[pbdatehij] [nvarchar](MAX) NULL,
	[pgender] [nvarchar](MAX) NULL,
	[pnat] [nvarchar](MAX) NULL,
	[preg] [nvarchar](MAX) NULL,
	[pmstat] [nvarchar](MAX) NULL,
	[pjob] [nvarchar](MAX) NULL,
	[pbg] [nvarchar](MAX) NULL,
	[paddress] [nvarchar](MAX) NULL,
	[pwplace] [nvarchar](MAX) NULL,
	[poldid] [nvarchar](MAX) NULL,
	[pphone] [nvarchar](MAX) NULL,
	[page] [int] NULL,
	[pinscomp] [nvarchar](MAX) NULL,
	[pcardid] [nvarchar](MAX) NULL,
	[pcardissue] date NULL,
	[pcardexp] date NULL,
	[pcardcat] [nvarchar](MAX) NULL,
	[pstat] [nvarchar](MAX) NULL,
	[ppic] [image] NULL,
	[memno] [nvarchar](MAX) NULL,
	[code] [nvarchar](MAX) NULL,
 CONSTRAINT [PK_patients] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



USE [HMS]
GO
CREATE TABLE [dbo].[useract](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[uname] [nvarchar](MAX) NULL,
	[details] [nvarchar](MAX) NULL,
	[acdate] [datetime] NULL,
 CONSTRAINT [PK_useract] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



USE [HMS]  
GO
CREATE TABLE [dbo].[depts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[dept] [nvarchar](100) NULL UNIQUE,
 CONSTRAINT [PK_depts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



USE [HMS]  
GO
CREATE TABLE [dbo].[taxes](
	[tax] [int] NULL,
	[taxno] [bigint] NULL
) 
GO



USE [HMS]  
GO
INSERT INTO [dbo].[taxes]([tax], [taxno] ) VALUES (0,0)
GO



USE [HMS]  
GO
INSERT INTO [dbo].[users]([uname], [upass], [ugroup], [ustat]) VALUES ('Admin', '12345', 'Admins', 'Active')
GO



USE [HMS]  
GO
CREATE TABLE [dbo].[checkdetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[pid] [int] NULL,
	[pname] [nvarchar](MAX) NULL,
	[scode] [nvarchar](MAX) NULL,
	[sname] [nvarchar](MAX) NULL,
	[sprice] [float] NULL,
	[sqty] [int] NULL,
	[stax] [float] NULL,
	[sdiscount] [float] NULL,
	[stotal] [float] NULL,
	[insu] [float] NULL,
	[pat] [float] NULL,
	[invno] [int] NULL,
 CONSTRAINT [PK_checkdetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



USE [HMS]
GO
CREATE TABLE [dbo].[images](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[pid] [int] NULL,
	[imgname] [nvarchar](100) NULL,
	[img] [image] NULL,
	[imginfo] [nvarchar](MAX) NULL,
 CONSTRAINT [PK_images] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__images__7A4C4988F86BA3B8] UNIQUE NONCLUSTERED 
(
	[imgname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO



USE [HMS]
GO
CREATE TABLE [dbo].[doctorimgs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[did] [int] NULL,
	[imgname] [nvarchar](100) NULL,
	[img] [image] NULL,
	[imginfo] [nvarchar](MAX) NULL,
 CONSTRAINT [PK_doctorimgs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__doctorimgs__7A4C4988F86BA3B8] UNIQUE NONCLUSTERED 
(
	[imgname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO



USE [HMS]
GO
CREATE TABLE [dbo].[technicianimgs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[did] [int] NULL,
	[imgname] [nvarchar](100) NULL,
	[img] [image] NULL,
	[imginfo] [nvarchar](MAX) NULL,
 CONSTRAINT [PK_technicianimgs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__technicianimgs__7A4C4988F86BA3B8] UNIQUE NONCLUSTERED 
(
	[imgname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO



USE [HMS]  
GO
CREATE TABLE [dbo].[doctors](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[did] [int] NULL UNIQUE,
	[dname] [nvarchar](MAX) NULL,
	[dept] [nvarchar](MAX) NULL,
	[clinic] [nvarchar](MAX) NULL,
	[dident] [nvarchar](100) NOT NULL,
	[dgender] [nvarchar](MAX) NULL,
	[dnat] [nvarchar](MAX) NULL,
	[dreg] [nvarchar](MAX) NULL,
	[dmstat] [nvarchar](MAX) NULL,
	[dspec] [nvarchar](MAX) NULL,
	[daddress] [nvarchar](MAX) NULL,
	[dphone] [nvarchar](MAX) NULL,
	[dstat] [nvarchar](MAX) NULL,
	[uname] [nvarchar](50) NULL UNIQUE,
 CONSTRAINT [PK_doctors] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



USE [HMS]  
GO
CREATE TABLE [dbo].[clinics](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[cname] [nvarchar](100) NULL UNIQUE,
	[dept] [nvarchar](MAX) NULL,
 CONSTRAINT [PK_clinics] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



USE [HMS]
GO
CREATE TABLE [dbo].[nats](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nat] [nvarchar](50) NULL UNIQUE,
	[naten] [nvarchar](50) NULL UNIQUE,
 CONSTRAINT [PK_nats] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



USE [HMS]  
GO
CREATE TABLE [dbo].[invpays](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[pid] [int] NULL,
	[pname] [nvarchar](MAX) NULL,
	[invno] [int] NULL,
	[cash] [float] NULL,
	[net] [float] NULL,
	[pdate] [datetime] NULL,
	[user] [nvarchar](MAX),
	[doctor] [nvarchar](MAX),
	[tax] [float] NULL,
 CONSTRAINT [PK_invpays] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



USE [HMS]  
GO
CREATE TABLE [dbo].[insurance](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[iid] [int] NULL UNIQUE,
	[inamear] [nvarchar](MAX) NULL,
	[inameen] [nvarchar](MAX) NULL,
	[sname] [nvarchar](MAX) NULL,
	[regno] [nvarchar](MAX) NULL,
	[mregno] [nvarchar](MAX) NULL,
	[tregno] [nvarchar](MAX) NULL,
	[contdate] [date] NULL,
	[contexp] [date] NULL,
	[phone] [nvarchar](MAX) NULL,
	[fax] [nvarchar](MAX) NULL,
	[address] [nvarchar](MAX) NULL,
	[email] [nvarchar](MAX) NULL,
	[empname] [nvarchar](MAX) NULL,
	[job] [nvarchar](MAX) NULL,
	[empmobile] [nvarchar](MAX) NULL,
	[empemail] [nvarchar](MAX) NULL,
	[empphone] [nvarchar](MAX) NULL,
	[empfax] [nvarchar](MAX) NULL,
	[istat] [nvarchar](MAX) NULL,
 CONSTRAINT [PK_insurance] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



USE [HMS]
GO
CREATE TABLE [dbo].[insurfiles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[iid] [int] NULL,
	[filename] [nvarchar](100) NULL,
	[file] [varbinary](MAX) NULL,
	[fileinfo] [nvarchar](MAX) NULL,
	[fileext] [nvarchar](MAX) NULL,
 CONSTRAINT [PK_insurfiles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__insurfiles__7A4C4988F86BA3B8] UNIQUE NONCLUSTERED 
(
	[filename] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



USE [HMS]  
GO
CREATE TABLE [dbo].[waitlist](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[pid] [int] NULL,
	[pname] [nvarchar](MAX) NULL,
	[invno] [int] NULL,
	[chdate] [date] NULL,
	[wstat] [nvarchar](MAX) NULL,
	[doctor] [nvarchar](MAX) NULL,
 CONSTRAINT [PK_waitlist] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



USE [HMS]  
GO
CREATE TABLE [dbo].[medrep](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[pid] [int] NULL,
	[pname] [nvarchar](MAX) NULL,
	[mdate] [date] NULL,
	[mstat] [nvarchar](MAX) NULL,
	[mneed] [nvarchar](MAX) NULL,
	[doctor] [nvarchar](MAX) NULL,
	[medmng] [nvarchar](MAX) NULL,
 CONSTRAINT [PK_medrep] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



USE [HMS]  
GO
CREATE TABLE [dbo].[clinic](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[cid] [int] NULL UNIQUE,
	[pid] [int] NULL,
	[pname] [nvarchar](MAX) NULL,
	[teeth] [nvarchar] (MAX),
	[problem] [nvarchar](MAX) NULL,
	[diag] [nvarchar](MAX) NULL,
	[action] [nvarchar](MAX) NULL,
	[note] [nvarchar](MAX) NULL,
	[cdate] [date] NULL,
	[doctor] [nvarchar](MAX) NULL,
	[aorc] [nvarchar](MAX) NULL,
 CONSTRAINT [PK_clinic] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO




CREATE TABLE [dbo].[lab](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[pid] [int] NULL,
	[un] [nvarchar](max) NULL,
	[ldate] [datetime] NULL,
	[request] [nvarchar](max) NULL,
	[lstat] [int] NULL,
 CONSTRAINT [PK_lab] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO



USE [HMS]
GO
CREATE TABLE [dbo].[clinicimgs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[cid] [int] NULL,
	[pid] [int] NULL,
	[imgname] [nvarchar](100) NULL,
	[img] [image] NULL,
	[imginfo] [nvarchar](MAX) NULL,
 CONSTRAINT [PK_clinicimgs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__clinicimgs__7A4C4988F86BA3B8] UNIQUE NONCLUSTERED 
(
	[imgname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO




USE [HMS]  
GO
CREATE TABLE [dbo].[categories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[cat] [nvarchar](100) NULL UNIQUE,
 CONSTRAINT [PK_categories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO




USE [HMS]  
GO
CREATE TABLE [dbo].[items](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[iname] [nvarchar](100) NOT NULL UNIQUE,
	[icat] [nvarchar](100) NOT NULL,
	[idesc] [nvarchar](MAX) NULL,
	[iprice] [float] NOT NULL,
	[ino] [nvarchar](100) NULL,
	[itax] [int] NULL,
	 CONSTRAINT [PK_items] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO




USE [HMS]  
GO
CREATE TABLE [dbo].[stock](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL UNIQUE,
	[qty] [numeric] NULL,
 CONSTRAINT [PK_stock] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO




USE [HMS]  
GO
CREATE TABLE [dbo].[opstock](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL UNIQUE,
	[qty] [numeric] NULL,
 CONSTRAINT [PK_opstock] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO




CREATE TABLE [dbo].[stockreq](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[un] [nvarchar](max) NULL,
	[request] [nvarchar](max) NULL,
	[rdate] [datetime] NULL,
	[rstat] [int] NULL,
 CONSTRAINT [PK_stockreq] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO




CREATE TABLE [dbo].[sentreq](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[dname] [nvarchar](max) NULL,
	[sdate] [datetime] NULL,
	[user] [nvarchar](max) NULL,
	[invno] [int] NULL,
	[total] [float] NOT NULL,
 CONSTRAINT [PK_sentreq] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO




CREATE TABLE [dbo].[sentreqdet](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[invno] [int] NOT NULL,
	[iname] [nvarchar](100) NOT NULL,
	[iqty] [int] NOT NULL,
	[iprice] [float] NOT NULL,
 CONSTRAINT [PK_sentreqdet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO




CREATE TABLE [dbo].[purchases](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[sdate] [datetime] NULL,
	[user] [nvarchar](max) NULL,
	[invno] [int] NULL,
	[total] [float] NOT NULL,
	[impname] [nvarchar](max) NULL,
	[impinvno] [nvarchar](max) NULL,
 CONSTRAINT [PK_purchases] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO




CREATE TABLE [dbo].[purchasesdet](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[invno] [int] NOT NULL,
	[iname] [nvarchar](100) NOT NULL,
	[iprice] [float] NOT NULL,
	[iqty] [int] NOT NULL,
	[ino] [nvarchar](100) NULL,
	[itax] [int] NULL,
 CONSTRAINT [PK_purchasesdet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO




CREATE TABLE [dbo].[masrofat](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[odate] [date] NOT NULL,
	[ovalue] [float] NOT NULL,
	[oinfo] [nvarchar](MAX) NOT NULL,
	[un] [nvarchar](100),
 CONSTRAINT [PK_masrofat] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO




USE [HMS]  
GO
CREATE TABLE [dbo].[importers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[iid] [int] NULL UNIQUE,
	[inamear] [nvarchar](MAX) NULL,
	[inameen] [nvarchar](MAX) NULL,
	[ino] [nvarchar](MAX) NULL,
	[phone] [nvarchar](MAX) NULL,
	[fax] [nvarchar](MAX) NULL,
	[email] [nvarchar](MAX) NULL,
	[website] [nvarchar](MAX) NULL,
	[address] [nvarchar](MAX) NULL,
	[empname] [nvarchar](MAX) NULL,
	[empident] [nvarchar](MAX) NULL,
	[empmobile] [nvarchar](MAX) NULL,
	[empemail] [nvarchar](MAX) NULL,
	[empphone] [nvarchar](MAX) NULL,
	[empfax] [nvarchar](MAX) NULL,
	[istat] [nvarchar](MAX) NULL,
	[refno] [nvarchar](MAX) NULL,
	[ibal] [float] NULL,
 CONSTRAINT [PK_importers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO




USE [HMS]
GO
CREATE TABLE [dbo].[impfiles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[iid] [int] NULL,
	[filename] [nvarchar](100) NULL,
	[file] [varbinary](MAX) NULL,
	[fileinfo] [nvarchar](MAX) NULL,
	[fileext] [nvarchar](MAX) NULL,
 CONSTRAINT [PK_impfiles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__impfiles__7A4C4988F86BA3B8] UNIQUE NONCLUSTERED 
(
	[filename] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO




CREATE TABLE [dbo].[imppays](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[iid] [int] NOT NULL,
	[odate] [date] NOT NULL,
	[ovalue] [float] NOT NULL,
	[otype] [nvarchar](MAX) NOT NULL,
	[oinfo] [nvarchar](MAX) NOT NULL,
	[un] [nvarchar](100),
 CONSTRAINT [PK_imppays] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



USE [HMS]  
GO
CREATE TABLE [dbo].[labservices](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[scode] [nvarchar](50) NOT NULL UNIQUE,
	[snamear] [nvarchar](MAX) NOT NULL,
	[snameen] [nvarchar](MAX) NOT NULL,
	[dept] [nvarchar](MAX) NOT NULL,
	[sprice] [float] NOT NULL,
 CONSTRAINT [PK_labservices] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



USE [HMS]  
GO
CREATE TABLE [dbo].[labrequests](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rid] [int] NOT NULL,
	[pid] [int] NOT NULL,
	[dname] [nvarchar](100) NOT NULL,
	[tname] [nvarchar](max) NOT NULL,
	[cdate] [datetime] NULL,
	[sdate] [datetime] NULL,
	[rdate] [datetime] NULL,
	[tdate] [datetime] NULL,
	[frdate] [datetime] NULL,
	[status] [nvarchar](max) NULL,
	[aorc] [nvarchar] (100) NULL,
 CONSTRAINT [PK_labrequests] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO



USE [HMS]  
GO
CREATE TABLE [dbo].[reqdetails](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rid] [int] NOT NULL,
	[teeth] [nvarchar](max) NOT NULL,
	[scode] [nvarchar](50) NOT NULL,
	[color] [nvarchar](100) NOT NULL,
	[note] [nvarchar](max) NULL,
 CONSTRAINT [PK_reqdetails] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO



USE [HMS]  
GO
CREATE TABLE [dbo].[drugs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[dcode] [nvarchar](50) NOT NULL UNIQUE,
	[dname] [nvarchar](MAX) NOT NULL,
	[dformat] [nvarchar](MAX) NOT NULL,
	[dcon] [nvarchar](MAX) NOT NULL,
 CONSTRAINT [PK_drugs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



USE [HMS]  
GO
CREATE TABLE [dbo].[technicians](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[tid] [int] NULL UNIQUE,
	[tname] [nvarchar](MAX) NULL,
	[dept] [nvarchar](MAX) NULL,
	[tident] [nvarchar](100) NOT NULL,
	[tgender] [nvarchar](MAX) NULL,
	[tnat] [nvarchar](MAX) NULL,
	[treg] [nvarchar](MAX) NULL,
	[tmstat] [nvarchar](MAX) NULL,
	[tspec] [nvarchar](MAX) NULL,
	[taddress] [nvarchar](MAX) NULL,
	[tphone] [nvarchar](MAX) NULL,
	[tstat] [nvarchar](MAX) NULL,
	[uname] [nvarchar](50) NULL UNIQUE,
 CONSTRAINT [PK_technicians] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



USE [HMS]  
GO
CREATE TABLE [dbo].[colors](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[color] [nvarchar](100) NULL UNIQUE,
 CONSTRAINT [PK_colors] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



USE [HMS]  
GO
CREATE TABLE [dbo].[prescriptions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[did] [int] NOT NULL UNIQUE,
	[pid] [nvarchar](MAX) NOT NULL,
	[doctor] [nvarchar](MAX) NOT NULL,
	[ddate] [datetime] NOT NULL,
	[dstat] [int] NOT NULL,
 CONSTRAINT [PK_prescriptions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



USE [HMS]  
GO
CREATE TABLE [dbo].[predetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[did] [int] NOT NULL,
	[dcode] [nvarchar](50) NOT NULL,
	[dos] [nvarchar](MAX),
	[note] [nvarchar](MAX),
 CONSTRAINT [PK_predetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO