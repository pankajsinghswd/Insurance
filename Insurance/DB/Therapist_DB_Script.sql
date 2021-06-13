
GO
/****** Object:  Database [Therapist]    Script Date: 2021-03-22 09:51:32 ******/
CREATE DATABASE [Therapist]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Therapist', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.ASHWIN\MSSQL\DATA\Therapist.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Therapist_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.ASHWIN\MSSQL\DATA\Therapist_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Therapist] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Therapist].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Therapist] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Therapist] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Therapist] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Therapist] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Therapist] SET ARITHABORT OFF 
GO
ALTER DATABASE [Therapist] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Therapist] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Therapist] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Therapist] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Therapist] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Therapist] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Therapist] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Therapist] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Therapist] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Therapist] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Therapist] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Therapist] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Therapist] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Therapist] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Therapist] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Therapist] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Therapist] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Therapist] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Therapist] SET  MULTI_USER 
GO
ALTER DATABASE [Therapist] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Therapist] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Therapist] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Therapist] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Therapist] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Therapist] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Therapist] SET QUERY_STORE = OFF
GO
USE [Therapist]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 2021-03-22 09:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2021-03-22 09:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2021-03-22 09:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2021-03-22 09:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2021-03-22 09:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2021-03-22 09:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblAppointment]    Script Date: 2021-03-22 09:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAppointment](
	[AppointmentId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[DOB] [nvarchar](10) NULL,
	[Gender] [nvarchar](10) NULL,
	[ParentsNames] [nvarchar](50) NULL,
	[Address] [nvarchar](200) NULL,
	[Phone] [nvarchar](12) NULL,
	[Email] [nvarchar](50) NULL,
	[TherapistTypeId] [int] NULL,
	[AppointmentDate] [datetime] NULL,
	[MobileNo] [nvarchar](50) NULL,
	[ConsultationTypeId] [int] NULL,
	[TherapistTo] [nvarchar](50) NULL,
	[AssignedDate] [datetime] NULL,
	[FromTime] [nvarchar](10) NULL,
	[ToTime] [nvarchar](10) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[IsAppointmentDone] [bit] NULL,
 CONSTRAINT [PK__tblAppoi__8ECDFCC2E40459D0] PRIMARY KEY CLUSTERED 
(
	[AppointmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblConsultationType]    Script Date: 2021-03-22 09:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblConsultationType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblEducationType]    Script Date: 2021-03-22 09:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEducationType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProfile]    Script Date: 2021-03-22 09:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProfile](
	[ProfileId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NULL,
	[Gender] [nvarchar](10) NULL,
	[Email] [nvarchar](50) NULL,
	[Mobile] [nvarchar](12) NULL,
	[SpecialityIDs] [nvarchar](50) NULL,
	[EducationId] [int] NULL,
	[CollegeName] [nvarchar](max) NULL,
	[PassingYear] [int] NULL,
	[RegistrationDetails] [nvarchar](200) NULL,
	[ExperienceInYear] [int] NULL,
	[EarnedUnit] [numeric](18, 2) NULL,
	[ProfilePath] [nvarchar](50) NULL,
	[Timing] [nvarchar](200) NULL,
	[ConsultationFee] [nvarchar](50) NULL,
	[AboutDoctor] [nvarchar](max) NULL,
	[AspNetUserId] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[IsBlocked] [bit] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK__tblProfi__290C88E4D629D479] PRIMARY KEY CLUSTERED 
(
	[ProfileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSessionDurationByTherapist]    Script Date: 2021-03-22 09:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSessionDurationByTherapist](
	[DurationId] [int] IDENTITY(1,1) NOT NULL,
	[TherapistId] [nvarchar](50) NULL,
	[DurationFrom] [datetime] NULL,
	[DurationTo] [datetime] NULL,
	[PatientId] [int] NULL,
	[UnitEarned] [numeric](18, 2) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[DurationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSpecializations]    Script Date: 2021-03-22 09:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSpecializations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK__tblSpeci__3214EC07A3767A17] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTherapistType]    Script Date: 2021-03-22 09:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTherapistType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTimeMaster]    Script Date: 2021-03-22 09:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTimeMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Time] [varchar](10) NULL,
	[Display_order] [int] NULL,
	[IsActive] [bit] NULL
) ON [PRIMARY]
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'202103160823542_Initial', N'adminlte.Migrations.Configuration', 0x1F8B0800000000000400DD5C5B6FE3B6127E3FC0F90F829E7A0E522B97B38B6D60EF2275929EA09B0BD6D9A26F0B5AA21D62254A95A83441D15FD687FEA4FE850E254A9678D1C5566CA758601191C36F86C321391C0EFDD71F7F8E3F3C05BEF588E3848474621F8D0E6D0B5337F4085D4EEC942DBE7D677F78FFEF7F8D2FBCE0C9FAA9A03BE174D0922613FB81B1E8D47112F70107281905C48DC3245CB0911B060EF242E7F8F0F03BE7E8C8C100610396658D3FA5949100671FF0390DA98B239622FF3AF4B09F8872A89965A8D60D0A701221174F6CE40584FA0C8F7252DB3AF309023166D85FD816A23464888190A79F133C63714897B3080A907FFF1C61A05B203FC142F8D31579D77E1C1EF37E38AB8605949B262C0C7A021E9D08C53872F3B5D46B978A03D55D808AD933EF75A6BE897DE5E1ACE853E883026486A7533FE6C413FBBA6471964437988D8A86A31CF23206B85FC3F8EBA88A7860756E77501AD2F1E890FF3BB0A6A9CFD2184F284E598CFC03EB2E9DFBC4FD113FDF875F319D9C1CCD1727EFDEBC45DEC9DBFFE19337D59E425F81AE560045777118E11864C38BB2FFB6E5D4DB3972C3B259A54DAE15B0259813B6758D9E3E62BA640F305B8EDFD9D62579C25E51228CEB33253085A0118B53F8BC497D1FCD7D5CD63B8D3CF9FF0D5C8FDFBC1D84EB0D7A24CB6CE825FE30716298579FB09FD5260F24CAA7576DBCBF08B2CB380CF877DDBEF2DA2FB3308D5DDE99D048728FE2256675E9C6CECA783B9934871ADEAC0BD4FD376D2EA96ADE5A52DEA1756642C162DBB3A190F765F976B6B8B32882C1CB4C8B6BA4C9E0A49D6A24353DB00A8295D11C75351A0A9DF927AF81170122FE008B60072EE07C2C481CE0B297DF87607288F696F90E2509AC01DEFF51F2D0203AFC3980E833ECA63198E68CA1207A716E770F21C5376930E716BF3D5E830DCDFDAFE1257259185F50DE6A63BC8FA1FB354CD905F5CE11C39F995B00F2CF7B12740718449C33D7C5497209C68CBD6908BE75017845D9C9716F38BE3AEDDA0999FA88047A2F445A47BF14A42B4F444FA1782306329D47D224EAC770496837510B52B3A83945ABA882ACAFA81CAC9BA482D22C6846D02A674E35988F978DD0F04E5E06BBFF5EDE669BB7692DA8A871062B24FE01531CC332E6DD21C6704C5723D065DDD885B3900D1F67FAE27B53C6E927E4A743B35A6B36648BC0F0B32183DDFFD9908909C58FC4E35E4987A34F410CF09DE8F5A7AAF6392749B6EDE950EBE6B6996F670D304D97B324095D92CD024DD04B842CEAF2830F67B5C72FF2DEC83110E818183AE15B1E9440DF6CD9A86EE939F631C3D6999B0705A7287191A7AA113AE4F510ACD8513582AD622175E1FEABF0044BC7316F84F8212881994A2853A705A12E8990DFAA25A965C72D8CF7BDE421D79CE30853CEB055135D98EB431F5C80928F34286D1A1A3B158B6B364483D76A1AF336177635EE4A44622B36D9E23B1BEC52F86F2F6298CD1ADB827136ABA48B00C630DE2E0C549C55BA1A807C70D93703954E4C0603152ED5560CB4AEB11D18685D25AFCE40F3236AD7F197CEABFB669EF583F2F6B7F54675EDC0366BFAD833D3CC7D4F68C3A0058E55F33C9FF34AFCC434873390539CCF12E1EACA26C2C16798D543362B7F57EB873ACD20B2113501AE0CAD05545C002A40CA84EA215C11CB6B944E78113D608BB85B23AC58FB25D88A0DA8D8D58BD00AA1F9BA5436CE4EA78FB267A5352846DEE9B050C1D11884BC78D53BDE4129A6B8ACAA982EBE701F6FB8D23131180D0A6AF15C0D4A2A3A33B8960AD36CD792CE21EBE3926DA425C97D3268A9E8CCE05A1236DAAE248D53D0C32DD84845F52D7CA0C956443ACADDA6AC1B3B79729428183B862CAAF1358A22429795AC2A5162CDF294AAE9B7B3FEE946418EE1B88926EBA894B6E4C4C2182DB1540BAC41D24B1227EC1C3134473CCE33F502854CBBB71A96FF826575FB5407B1D8070A6AFE77DE42BEB6AF6DB4AA2722002EA17B017767B218BA66F0F5CD2D9EE2867C146BC2F6D3D04F036AF6AECCADF3CBBB6AFBBC4445183B92FC8AF7A4A84AF171EB7AEF342AEA8C1862844ACF65FD51324398745DF89D556D9B7C51334A119AAAA298C2553B1B35930BD37DA464D7B0FF40B522BCCC8C12F928550051D413A392D2A08055EABAA3D6B34EAA98F59AEE88526A491552AAEA21653581A42664B5622D3C8346F514DD39A829235574B5B63BB22679A40AADA95E035B23B35CD71D55935F5205D65477C75E259BC82BE81EEF59C603CB7A9B567EA0DD6CD73260BCCC7238CCA657B9B7AF02558A7B62899B79054C94EFA529194F75EB99521EC4D8CC940C18E635A776DD5D5F721AEFE8CD98B53BECDAB2DE74876FC6EB67B02F6A16CA894E2629B997273BE9043716A7A9F6C732CAF12A27B1AD428DB0A53F270C07234E309AFDE24F7D82F9025E105C234A16386179DE867D7C78742C3DB9D99FE72F4E9278BEE6346A7A03531FB32DA460D14714BB0F28561322367822B2025562CD57D4C34F13FBB7ACD56916B6E07F65C507D655F299925F52A8B88F536CFDAE26780E9332DF7CB6DAD3070EDDB57AF5F397BCE981751BC38C39B50E255DAE33C2F5670FBDA4C99B6E20CDDA8F215EEF84AABD37D0A24A1362FDE70573C206795A5048F94D809EFED35734EDF3818D10354F0486C21B4485A62700EB6019D3FF3DF86459FA7FBFCEEA9F03AC239AF12900A1FDC1E48700DD97A1A2E50EB71ACD81681B4B52A6E7D644EA8DB22A77BD3729F9D61B4D7435A7BA07DC0679D36B58C62B4B391E6C77D464140F86BD4BD37EF134E27DC91C5EE574EC3661789B39C20DB741FFA8D4E03D4866D324E7EC3E0178DBB6660AE2EE791665BF34DF3D333691B2B5FB64DE6D1B9B29CCBBE7C6D62B6577CF6C6D57FBE78E2DADF316BAF3045C3597C87019A38B05B725D8E6817338E1CF433082DCA3CCDF45EA33BA9AB2515B18AE48CC4CCDA964326365E2287C158A66B6FDFA2A36FCC6CE0A9A66B68604CC26DE62FD6FE42D689A791BD21A77911AAC4D2CD4A56BB7AC634DB94FAF2915B8D69396CCF3369FB5F166FD3565FE0EA294DAEC31DC11BF9E44DF415432E4D4E991D8AB5EF7C2DE59F90545D8BF13B25C41F0DF53A4D8ADED9A25CD155D84C5E62D49549048119A6BCC90075BEA59CCC802B90CAA798C397BD89DC5EDF84DC71C7B57F4366551CAA0CB3898FBB5801777029AF867D9CB7599C7B751F61B25437401C4243C367F4BBF4F89EF95725F6A62420608EE5D88882E1F4BC623BBCBE712E926A41D8184FA4AA7E81E07910F60C92D9DA147BC8E6C607E1FF112B9CFAB08A009A47D20EA6A1F9F13B48C5190088C557BF8041BF682A7F77F036A04E34B48540000, N'6.1.3-40302')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'Admin')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2', N'HR')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'4', N'Patient')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3', N'Therapist')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'222fcdf6-b3e5-48ea-ae81-75a4d7559ddfg', N'1')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b167d35c-4804-43a0-b6d5-7ac28706b587', N'3')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'222fcdf6-b3e5-48ea-ae81-75a4d7559ddfg', N'ashwini.yadav@wildnettechnologies.com', 0, N'APkvrz4JGJAiwo5aBjSZhBl7rFgSAqqy20yV1wQS1V7ofNaDKv20Ds7JujoA6+XU8Q==', N'abab559a-0a96-48fa-b646-181b751fe0fa', NULL, 0, 0, NULL, 1, 0, N'ashwini.yadav@wildnettechnologies.com')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b167d35c-4804-43a0-b6d5-7ac28706b587', N'ashwinsoft475@gmail.com', 0, N'APi0tpnEzYjcEtbTXfeurms+BsPNHOYKw9TSYHnupStb5B2k1t6B2Ypj343FZj9fjg==', N'81acafb7-e563-46fd-9beb-28f44a3be5c4', N'7531884429', 0, 0, NULL, 1, 0, N'ashwinsoft475@gmail.com')
GO
SET IDENTITY_INSERT [dbo].[tblAppointment] ON 
GO
INSERT [dbo].[tblAppointment] ([AppointmentId], [FirstName], [MiddleName], [LastName], [DOB], [Gender], [ParentsNames], [Address], [Phone], [Email], [TherapistTypeId], [AppointmentDate], [MobileNo], [ConsultationTypeId], [TherapistTo], [AssignedDate], [FromTime], [ToTime], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy], [IsActive], [IsAppointmentDone]) VALUES (1, N'Walter', NULL, N'White', N'15/05/1993', N'Male', NULL, N'4567 Hay Lake Road S, Eagan, MN, 55123, USA', NULL, NULL, 1, CAST(N'2021-03-20T00:00:00.000' AS DateTime), NULL, 1, NULL, CAST(N'2021-03-19T00:00:00.000' AS DateTime), N'11:00am', N'11:15am', CAST(N'2021-03-19T00:00:00.000' AS DateTime), NULL, NULL, NULL, 1, 0)
GO
INSERT [dbo].[tblAppointment] ([AppointmentId], [FirstName], [MiddleName], [LastName], [DOB], [Gender], [ParentsNames], [Address], [Phone], [Email], [TherapistTypeId], [AppointmentDate], [MobileNo], [ConsultationTypeId], [TherapistTo], [AssignedDate], [FromTime], [ToTime], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy], [IsActive], [IsAppointmentDone]) VALUES (2, N'Sam', NULL, N'Karan', N'15/05/1994', N'Male', NULL, N'4567 Hay Lake Road S, Eagan, MN, 55123, USA', NULL, NULL, 1, CAST(N'2021-03-21T00:00:00.000' AS DateTime), NULL, 1, NULL, CAST(N'2021-03-19T00:00:00.000' AS DateTime), N'11:15am', N'11:30am', CAST(N'2021-03-19T00:00:00.000' AS DateTime), NULL, NULL, NULL, 1, 0)
GO
INSERT [dbo].[tblAppointment] ([AppointmentId], [FirstName], [MiddleName], [LastName], [DOB], [Gender], [ParentsNames], [Address], [Phone], [Email], [TherapistTypeId], [AppointmentDate], [MobileNo], [ConsultationTypeId], [TherapistTo], [AssignedDate], [FromTime], [ToTime], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy], [IsActive], [IsAppointmentDone]) VALUES (3, N'Jason', NULL, N'Holder', N'15/05/1995', N'Male', NULL, N'4567 Hay Lake Road S, Eagan, MN, 55123, USA', NULL, NULL, 1, CAST(N'2021-03-21T00:00:00.000' AS DateTime), NULL, 1, NULL, CAST(N'2021-03-19T00:00:00.000' AS DateTime), N'11:30am', N'11:45am', CAST(N'2021-03-19T00:00:00.000' AS DateTime), NULL, NULL, NULL, 1, 0)
GO
INSERT [dbo].[tblAppointment] ([AppointmentId], [FirstName], [MiddleName], [LastName], [DOB], [Gender], [ParentsNames], [Address], [Phone], [Email], [TherapistTypeId], [AppointmentDate], [MobileNo], [ConsultationTypeId], [TherapistTo], [AssignedDate], [FromTime], [ToTime], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy], [IsActive], [IsAppointmentDone]) VALUES (4, N'Angila', NULL, N'Roy', N'15/05/1996', N'Female', NULL, N'4567 Hay Lake Road S, Eagan, MN, 55123, USA', NULL, NULL, 1, CAST(N'2021-03-20T00:00:00.000' AS DateTime), NULL, 1, NULL, CAST(N'2021-03-19T00:00:00.000' AS DateTime), N'12:00pm', N'12:15pm', CAST(N'2021-03-19T00:00:00.000' AS DateTime), NULL, NULL, NULL, 1, 0)
GO
INSERT [dbo].[tblAppointment] ([AppointmentId], [FirstName], [MiddleName], [LastName], [DOB], [Gender], [ParentsNames], [Address], [Phone], [Email], [TherapistTypeId], [AppointmentDate], [MobileNo], [ConsultationTypeId], [TherapistTo], [AssignedDate], [FromTime], [ToTime], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy], [IsActive], [IsAppointmentDone]) VALUES (5, N'Kasmira', NULL, N'Sahgal', N'15/05/1997', N'Female', NULL, N'4567 Hay Lake Road S, Eagan, MN, 55123, USA', NULL, NULL, 1, CAST(N'2021-03-22T00:00:00.000' AS DateTime), NULL, 1, NULL, CAST(N'2021-03-19T00:00:00.000' AS DateTime), N'12:00pm', N'12:15pm', CAST(N'2021-03-19T00:00:00.000' AS DateTime), NULL, NULL, NULL, 1, 0)
GO
INSERT [dbo].[tblAppointment] ([AppointmentId], [FirstName], [MiddleName], [LastName], [DOB], [Gender], [ParentsNames], [Address], [Phone], [Email], [TherapistTypeId], [AppointmentDate], [MobileNo], [ConsultationTypeId], [TherapistTo], [AssignedDate], [FromTime], [ToTime], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy], [IsActive], [IsAppointmentDone]) VALUES (6, N'Paul', NULL, N'Walker', N'15/05/1998', N'Male', NULL, N'4567 Hay Lake Road S, Eagan, MN, 55123, USA', NULL, NULL, 1, CAST(N'2021-03-20T00:00:00.000' AS DateTime), NULL, 1, NULL, CAST(N'2021-03-19T00:00:00.000' AS DateTime), N'12:15pm', N'12:30pm', CAST(N'2021-03-19T00:00:00.000' AS DateTime), NULL, NULL, NULL, 1, 0)
GO
INSERT [dbo].[tblAppointment] ([AppointmentId], [FirstName], [MiddleName], [LastName], [DOB], [Gender], [ParentsNames], [Address], [Phone], [Email], [TherapistTypeId], [AppointmentDate], [MobileNo], [ConsultationTypeId], [TherapistTo], [AssignedDate], [FromTime], [ToTime], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy], [IsActive], [IsAppointmentDone]) VALUES (7, N'Kitti', NULL, N'Mittle', N'15/05/1999', N'Female', NULL, N'4567 Hay Lake Road S, Eagan, MN, 55123, USA', NULL, NULL, 1, CAST(N'2021-03-20T00:00:00.000' AS DateTime), NULL, 1, NULL, CAST(N'2021-03-19T00:00:00.000' AS DateTime), N'12:30pm', N'12:45pm', CAST(N'2021-03-19T00:00:00.000' AS DateTime), NULL, NULL, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[tblAppointment] OFF
GO
SET IDENTITY_INSERT [dbo].[tblConsultationType] ON 
GO
INSERT [dbo].[tblConsultationType] ([Id], [Name], [IsActive]) VALUES (1, N'Clinic Visit', 1)
GO
INSERT [dbo].[tblConsultationType] ([Id], [Name], [IsActive]) VALUES (2, N'Community', 1)
GO
INSERT [dbo].[tblConsultationType] ([Id], [Name], [IsActive]) VALUES (3, N'Home Visit', 1)
GO
INSERT [dbo].[tblConsultationType] ([Id], [Name], [IsActive]) VALUES (4, N'School', 1)
GO
INSERT [dbo].[tblConsultationType] ([Id], [Name], [IsActive]) VALUES (5, N'Telehelp', 1)
GO
SET IDENTITY_INSERT [dbo].[tblConsultationType] OFF
GO
SET IDENTITY_INSERT [dbo].[tblProfile] ON 
GO
INSERT [dbo].[tblProfile] ([ProfileId], [FullName], [Gender], [Email], [Mobile], [SpecialityIDs], [EducationId], [CollegeName], [PassingYear], [RegistrationDetails], [ExperienceInYear], [EarnedUnit], [ProfilePath], [Timing], [ConsultationFee], [AboutDoctor], [AspNetUserId], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy], [IsBlocked], [IsActive]) VALUES (1, N'Dr. Laura Bailey', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'b167d35c-4804-43a0-b6d5-7ac28706b587', NULL, NULL, NULL, NULL, 0, 1)
GO
SET IDENTITY_INSERT [dbo].[tblProfile] OFF
GO
SET IDENTITY_INSERT [dbo].[tblSpecializations] ON 
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (1, N'Bariatrics Surgery', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (2, N'Bone Marrow Transplant', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (3, N'Cardio Thoracic Surgeon', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (4, N'Cardiologist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (5, N'Clinical Genetics', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (6, N'Dentist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (7, N'Dermatologist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (8, N'Dietitian Nutritionist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (9, N'Endocrinologist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (10, N'Ent Specialist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (11, N'Fetal Medicine', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (12, N'General Surgeon', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (13, N'Geriatrician', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (14, N'Gyneconcology', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (15, N'Infectious Disease Specialist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (16, N'Infertility Laproscopy Gynecologist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (17, N'Internal Medicine Physician', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (18, N'Interventional Cardiology Vascular Interventionalist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (19, N'Liver Transplant Surgeon', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (20, N'Medical Gastroenterologist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (21, N'Medical Oncologist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (22, N'Neonatologist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (23, N'Nephrologist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (24, N'Neuro Anaesthesia Pain Management', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (25, N'Neurologist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (26, N'Neurosurgeon', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (27, N'Obstetrician &amp; Gynecologist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (28, N'Opthalmologist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (29, N'Orthopaedic Surgeon', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (30, N'Pediatric Cardio Thoracic Surgeon', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (31, N'Pediatric Cardiologist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (32, N'Pediatric Endocrinologist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (33, N'Pediatric Gastroenterologist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (34, N'Pediatric Haemato Oncology Specialist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (35, N'Pediatric Intensive Care', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (36, N'Pediatric Nephrologist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (37, N'Pediatric Neurologist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (38, N'Pediatric Oncology', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (39, N'Pediatric Orthopaedician', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (40, N'Pediatric Urology Surgeon', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (41, N'Pediatrician', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (42, N'Pediatrics Cardiac Intinsivist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (43, N'Physiotherapist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (44, N'Plastic Cosmetic Surgery', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (45, N'Plastic Surgeon', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (46, N'Psychiatrist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (47, N'Psychologist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (48, N'Radiation Oncologist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (49, N'Renal Transplant Surgeon', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (50, N'Respiratory Medicine Specialist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (51, N'Rheumatologist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (52, N'Spine Surgeon', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (53, N'Spine Surgery Neurosurgery', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (54, N'Surgical Gastroenterologist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (55, N'Surgical Gastroenterology Bariatric Surgery', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (56, N'Surgical Oncologist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (57, N'Thoracic Vascular Surgery', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (58, N'Urologist', 1)
GO
INSERT [dbo].[tblSpecializations] ([Id], [Name], [IsActive]) VALUES (59, N'Vascular Surgeon', 1)
GO
SET IDENTITY_INSERT [dbo].[tblSpecializations] OFF
GO
SET IDENTITY_INSERT [dbo].[tblTherapistType] ON 
GO
INSERT [dbo].[tblTherapistType] ([Id], [Name], [IsActive]) VALUES (1, N'Fever & Cold', 1)
GO
SET IDENTITY_INSERT [dbo].[tblTherapistType] OFF
GO
SET IDENTITY_INSERT [dbo].[tblTimeMaster] ON 
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (1, N'12:00AM', 1, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (2, N'12:15AM', 2, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (3, N'12:30AM', 3, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (4, N'12:45AM', 4, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (5, N'1:00AM', 5, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (6, N'1:15AM', 6, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (7, N'1:30AM', 7, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (8, N'1:45AM', 8, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (9, N'2:00AM', 9, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (10, N'2:15AM', 10, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (11, N'2:30AM', 11, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (12, N'2:45AM', 12, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (13, N'3:00AM', 13, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (14, N'3:15AM', 14, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (15, N'3:30AM', 15, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (16, N'3:45AM', 16, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (17, N'4:00AM', 17, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (18, N'4:15AM', 18, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (19, N'4:30AM', 19, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (20, N'4:45AM', 20, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (21, N'5:00AM', 21, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (22, N'5:15AM', 22, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (23, N'5:30AM', 23, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (24, N'5:45AM', 24, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (25, N'6:00AM', 25, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (26, N'12:30PM', 26, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (27, N'1:00PM', 27, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (28, N'1:30PM', 28, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (29, N'2:00PM', 29, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (30, N'2:30PM', 30, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (31, N'3:00PM', 31, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (32, N'3:30PM', 32, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (33, N'4:00PM', 33, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (34, N'4:30PM', 34, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (35, N'5:00PM', 35, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (36, N'5:30PM', 36, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (37, N'6:00PM', 37, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (38, N'6:30PM', 38, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (39, N'7:00PM', 39, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (40, N'7:30PM', 40, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (41, N'8:00PM', 41, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (42, N'8:30PM', 42, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (43, N'9:00PM', 43, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (44, N'9:30PM', 44, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (45, N'10:00PM', 45, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (46, N'10:30PM', 46, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (47, N'11:00PM', 47, 1)
GO
INSERT [dbo].[tblTimeMaster] ([Id], [Time], [Display_order], [IsActive]) VALUES (48, N'11:30PM', 48, 1)
GO
SET IDENTITY_INSERT [dbo].[tblTimeMaster] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 2021-03-22 09:51:33 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 2021-03-22 09:51:33 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 2021-03-22 09:51:33 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleId]    Script Date: 2021-03-22 09:51:33 ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 2021-03-22 09:51:33 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 2021-03-22 09:51:33 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblAppointment] ADD  CONSTRAINT [DF__tblAppoin__Creat__5165187F]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[tblAppointment] ADD  CONSTRAINT [DF__tblAppoin__IsAct__534D60F1]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[tblAppointment] ADD  DEFAULT ((0)) FOR [IsAppointmentDone]
GO
ALTER TABLE [dbo].[tblConsultationType] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[tblEducationType] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[tblProfile] ADD  CONSTRAINT [DF__tblProfil__IsBlo__75A278F5]  DEFAULT ((0)) FOR [IsBlocked]
GO
ALTER TABLE [dbo].[tblProfile] ADD  CONSTRAINT [DF__tblProfil__IsAct__76969D2E]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[tblSessionDurationByTherapist] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[tblSpecializations] ADD  CONSTRAINT [DF__tblSpecia__IsAct__6FE99F9F]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[tblTherapistType] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[tblTimeMaster] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[tblAppointment]  WITH CHECK ADD  CONSTRAINT [FK__tblAppoin__Consu__5070F446] FOREIGN KEY([ConsultationTypeId])
REFERENCES [dbo].[tblConsultationType] ([Id])
GO
ALTER TABLE [dbo].[tblAppointment] CHECK CONSTRAINT [FK__tblAppoin__Consu__5070F446]
GO
ALTER TABLE [dbo].[tblAppointment]  WITH CHECK ADD  CONSTRAINT [FK__tblAppoin__Thera__4F7CD00D] FOREIGN KEY([TherapistTypeId])
REFERENCES [dbo].[tblTherapistType] ([Id])
GO
ALTER TABLE [dbo].[tblAppointment] CHECK CONSTRAINT [FK__tblAppoin__Thera__4F7CD00D]
GO
ALTER TABLE [dbo].[tblProfile]  WITH CHECK ADD  CONSTRAINT [FK__tblProfil__Educa__787EE5A0] FOREIGN KEY([EducationId])
REFERENCES [dbo].[tblEducationType] ([Id])
GO
ALTER TABLE [dbo].[tblProfile] CHECK CONSTRAINT [FK__tblProfil__Educa__787EE5A0]
GO
ALTER TABLE [dbo].[tblSessionDurationByTherapist]  WITH CHECK ADD  CONSTRAINT [FK_PatientIdFromAppointmentTable] FOREIGN KEY([PatientId])
REFERENCES [dbo].[tblAppointment] ([AppointmentId])
GO
ALTER TABLE [dbo].[tblSessionDurationByTherapist] CHECK CONSTRAINT [FK_PatientIdFromAppointmentTable]
GO
/****** Object:  StoredProcedure [dbo].[spTherapist]    Script Date: 2021-03-22 09:51:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Ashwin>
-- Create date: <Create Date,,17 March 2021>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spTherapist]
	-- Add the parameters for the stored procedure here
	@Qtype INT = NuLL,
	@AspNetUserId NVARCHAR(50) = NuLL,
	@FirstName NVARCHAR(50) = NuLL,
    @MiddleName NVARCHAR(50) = NuLL,
    @LastName NVARCHAR(50) = NuLL,
	@FullName NVARCHAR(100) = NuLL,
    @DOB NVARCHAR(10) = NuLL,
    @Gender NVARCHAR(10) = NuLL,
    @ParentsNames NVARCHAR(50) = NuLL,
    @Address NVARCHAR(200) = NuLL,
    @Phone NVARCHAR(12) = NuLL,
    @Email NVARCHAR(50) = NuLL,
    @TherapistTypeId INT = NuLL,
    @AppointmentDate DATETIME = NuLL,
    @MobileNo NVARCHAR(50) = NuLL,
    @ConsultationTypeId INT = NuLL,
    @TherapistTo NVARCHAR(50) = NuLL,
    @AssignedDate DATETIME = NuLL,
    @CreatedBy NVARCHAR(50) = NuLL,
    @UpdatedBy NVARCHAR(50) = NuLL,
	@Type NVARCHAR(50) = NuLL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF(@Qtype = 1)
	 BEGIN
		SELECT		Id,Name 
		FROM		tblConsultationType
		WHERE		IsActive = 1
	 END
	ELSE IF(@Qtype = 2)
	 BEGIN
		SELECT		Id,Name AS Name 
		FROM		tblTherapistType
		WHERE		IsActive = 1
	 END
	ELSE IF(@Qtype = 3)
	 BEGIN
		SELECT		Id,Name 
		FROM		tblSpecializations
		WHERE		IsActive = 1
	 END
	ELSE IF(@Qtype = 4) -- Get Education type: Master Data
	 BEGIN
		SELECT		Id,Name 
		FROM		tblEducationType
		WHERE		IsActive = 1
	 END
	ELSE IF(@Qtype = 5) -- Get Time: Master Data
	 BEGIN
		SELECT		Id,Time AS Name
		FROM		tblTimeMaster
		WHERE		IsActive = 1
		ORDER BY	Display_order ASC
	 END
	ELSE IF(@Qtype = 6) --Insert an Appointment
	 BEGIN
		INSERT INTO [dbo].[tblAppointment]
           ([FirstName],[MiddleName],[LastName],[DOB],[Gender],[ParentsNames],[Address],[Phone],[Email],[TherapistTypeId],[AppointmentDate],[MobileNo],[ConsultationTypeId]
           ,[CreatedOn],[CreatedBy])
	   VALUES
           (@FirstName,@MiddleName,@LastName,@DOB,@Gender,@ParentsNames,@Address,@Phone,@Email,@TherapistTypeId,@AppointmentDate,@MobileNo,@ConsultationTypeId
            ,GETDATE(),@CreatedBy)
	 END
	ELSE IF(@Qtype = 7) --Get an Appointment
	 BEGIN
		SELECT		AppointmentId, FirstName + IsNuLL(MiddleName,'') + '  ' + LastName FullName,
					CAST(DATEDIFF(YEAR,CONVERT(DATETIME,CONVERT(VARCHAR(10), DOB),103),GETDATE()) AS NVARCHAR(10)) + ' years' Age,Gender,
					T.Name TherapistType,CONVERT(VARCHAR, AppointmentDate, 107) AppointmentDate,(FromTime +'-'+ ToTime) Timing,Address,
					TherapistTo
		FROM		tblAppointment A
		INNER JOIN	tblTherapistType T ON A.TherapistTypeId = T.Id
		--WHERE		AppointmentDate = ''
	 END
	ELSE IF(@Qtype = 8) --Insert an Profile
	 BEGIN
	  IF NoT EXISTS(SELECT AspNetUserId FROM tblProfile WHERE AspNetUserId = @AspNetUserId)
	   BEGIN
		INSERT INTO			tblProfile(AspNetUserId,FullName,CreatedBy,CreatedOn)
		VALUES				(@AspNetUserId,@FullName,@CreatedBy,GETDATE())

		SELECT @@IDENTITY
	   END
	 END
	ELSE IF(@Qtype = 9) --Get an Appointment
	 BEGIN
		SELECT			A.Id,A.Email,P.FullName,RR.Name RoleName,R.RoleId
		FROM			AspNetUsers A
		LEFT JOIN		tblProfile P ON A.Id = P.AspNetUserId
		INNER JOIN		AspNetUserRoles R ON A.Id = R.UserId
		INNER JOIN		AspNetRoles RR ON R.RoleId = RR.Id
		WHERE			A.Id = @AspNetUserId
	 END
END
GO
USE [master]
GO
ALTER DATABASE [Therapist] SET  READ_WRITE 
GO
