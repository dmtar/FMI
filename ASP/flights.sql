USE [Flights]
GO
/****** Object:  Table [dbo].[AirportInfo]    Script Date: 06/08/2014 18:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AirportInfo](
	[AirportID] [int] NOT NULL,
	[Code] [nvarchar](50) NULL,
	[AirportPhone] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[Fax] [nchar](10) NULL,
	[City] [nvarchar](50) NULL,
	[Street] [nvarchar](50) NULL,
	[Postalcode] [nvarchar](50) NULL,
	[AirportWebsite] [nvarchar](50) NULL,
	[Airport] [nvarchar](50) NULL,
 CONSTRAINT [PK_AirportInfo] PRIMARY KEY CLUSTERED 
(
	[AirportID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Airline]    Script Date: 06/08/2014 18:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Airline](
	[AirlineID] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[AirlineCountry] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Website] [nvarchar](50) NULL,
	[OnlineCheckIN] [nvarchar](5) NULL,
	[HotelBooking] [nvarchar](5) NULL,
	[CarRental] [nvarchar](5) NULL,
 CONSTRAINT [PK_Airline] PRIMARY KEY CLUSTERED 
(
	[AirlineID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Aircraft]    Script Date: 06/08/2014 18:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aircraft](
	[AircraftID] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[FirstDate] [nvarchar](50) NULL,
	[Length] [nvarchar](50) NULL,
	[Height] [nvarchar](50) NULL,
	[Wingspan] [nvarchar](50) NULL,
	[Diameter] [nvarchar](50) NULL,
	[Speed] [nvarchar](50) NULL,
	[Manufacturer] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[Capacity] [nvarchar](8) NULL,
	[Engines] [nvarchar](5) NULL,
 CONSTRAINT [PK_Aircraft] PRIMARY KEY CLUSTERED 
(
	[AircraftID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 06/08/2014 18:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[MemberID] [int] NOT NULL,
	[MemberName] [nvarchar](50) NOT NULL,
	[Position] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[Age] [nvarchar](50) NULL,
	[Years] [nvarchar](50) NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flight]    Script Date: 06/08/2014 18:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flight](
	[FlightID] [int] NOT NULL,
	[Date] [nvarchar](50) NULL,
	[FlightNumber] [nvarchar](50) NULL,
	[DepTime] [nvarchar](50) NULL,
	[ArrvTime] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[GroundOp] [nvarchar](50) NULL,
	[AirlineID] [int] NOT NULL,
	[AircraftID] [int] NOT NULL,
 CONSTRAINT [PK_Flight] PRIMARY KEY CLUSTERED 
(
	[FlightID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flights2Members]    Script Date: 06/08/2014 18:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flights2Members](
	[FlightID] [int] NOT NULL,
	[MemberID] [int] NOT NULL,
 CONSTRAINT [PK_Flights2Members] PRIMARY KEY CLUSTERED 
(
	[FlightID] ASC,
	[MemberID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flights2Airports]    Script Date: 06/08/2014 18:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flights2Airports](
	[FlightID] [int] NOT NULL,
	[AirportID] [int] NOT NULL,
 CONSTRAINT [PK_Flights2Airports] PRIMARY KEY CLUSTERED 
(
	[FlightID] ASC,
	[AirportID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Check [CK_Member]    Script Date: 06/08/2014 18:59:49 ******/
ALTER TABLE [dbo].[Member]  WITH CHECK ADD  CONSTRAINT [CK_Member] CHECK  (([Position]='стюард' OR [Position]='пилот'))
GO
ALTER TABLE [dbo].[Member] CHECK CONSTRAINT [CK_Member]
GO
/****** Object:  ForeignKey [FK_Flight_Aircraft]    Script Date: 06/08/2014 18:59:49 ******/
ALTER TABLE [dbo].[Flight]  WITH CHECK ADD  CONSTRAINT [FK_Flight_Aircraft] FOREIGN KEY([AircraftID])
REFERENCES [dbo].[Aircraft] ([AircraftID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Flight] CHECK CONSTRAINT [FK_Flight_Aircraft]
GO
/****** Object:  ForeignKey [FK_Flight_Airline]    Script Date: 06/08/2014 18:59:49 ******/
ALTER TABLE [dbo].[Flight]  WITH CHECK ADD  CONSTRAINT [FK_Flight_Airline] FOREIGN KEY([AirlineID])
REFERENCES [dbo].[Airline] ([AirlineID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Flight] CHECK CONSTRAINT [FK_Flight_Airline]
GO
/****** Object:  ForeignKey [FK_Flights2Airports_AirportInfo]    Script Date: 06/08/2014 18:59:49 ******/
ALTER TABLE [dbo].[Flights2Airports]  WITH CHECK ADD  CONSTRAINT [FK_Flights2Airports_AirportInfo] FOREIGN KEY([AirportID])
REFERENCES [dbo].[AirportInfo] ([AirportID])
GO
ALTER TABLE [dbo].[Flights2Airports] CHECK CONSTRAINT [FK_Flights2Airports_AirportInfo]
GO
/****** Object:  ForeignKey [FK_Flights2Airports_Flight]    Script Date: 06/08/2014 18:59:49 ******/
ALTER TABLE [dbo].[Flights2Airports]  WITH CHECK ADD  CONSTRAINT [FK_Flights2Airports_Flight] FOREIGN KEY([FlightID])
REFERENCES [dbo].[Flight] ([FlightID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Flights2Airports] CHECK CONSTRAINT [FK_Flights2Airports_Flight]
GO
/****** Object:  ForeignKey [FK_Flights2Members_Flight]    Script Date: 06/08/2014 18:59:49 ******/
ALTER TABLE [dbo].[Flights2Members]  WITH CHECK ADD  CONSTRAINT [FK_Flights2Members_Flight] FOREIGN KEY([FlightID])
REFERENCES [dbo].[Flight] ([FlightID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Flights2Members] CHECK CONSTRAINT [FK_Flights2Members_Flight]
GO
/****** Object:  ForeignKey [FK_Flights2Members_Member]    Script Date: 06/08/2014 18:59:49 ******/
ALTER TABLE [dbo].[Flights2Members]  WITH CHECK ADD  CONSTRAINT [FK_Flights2Members_Member] FOREIGN KEY([MemberID])
REFERENCES [dbo].[Member] ([MemberID])
GO
ALTER TABLE [dbo].[Flights2Members] CHECK CONSTRAINT [FK_Flights2Members_Member]
GO
