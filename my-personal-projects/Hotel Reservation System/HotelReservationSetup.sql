USE [master]
GO
/****** Object:  Database [HotelReservationManagement]    Script Date: 6/4/2025 5:36:48 PM ******/
CREATE DATABASE [HotelReservationManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HotelReservationManagement', FILENAME = N'C:\Users\Igor\HotelReservationManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HotelReservationManagement_log', FILENAME = N'C:\Users\Igor\HotelReservationManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HotelReservationManagement] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HotelReservationsManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HotelReservationManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HotelReservationManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HotelReservationManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HotelReservationManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HotelReservationManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [HotelReservationManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HotelReservationManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HotelReservationManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HotelReservationManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HotelReservationManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HotelReservationManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HotelReservationManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HotelReservationManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HotelReservationManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HotelReservationManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HotelReservationManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HotelReservationManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HotelReservationManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HotelReservationManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HotelReservationManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HotelReservationManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HotelReservationManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HotelReservationManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HotelReservationManagement] SET  MULTI_USER 
GO
ALTER DATABASE [HotelReservationManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HotelReservationManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HotelReservationManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HotelReservationManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HotelReservationManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HotelReservationManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [HotelReservationManagement] SET QUERY_STORE = OFF
GO
USE [HotelReservationManagement]
GO
/****** Object:  Table [dbo].[Guest]    Script Date: 6/4/2025 5:36:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guest](
	[idGuest] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[surname] [varchar](50) NOT NULL,
	[email] [varchar](300) NOT NULL,
	[phoneNumber] [varchar](20) NULL,
	[idLocation] [bigint] NOT NULL,
 CONSTRAINT [PK_Guest] PRIMARY KEY CLUSTERED 
(
	[idGuest] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotel]    Script Date: 6/4/2025 5:36:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[idHotel] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[email] [varchar](300) NOT NULL,
	[phoneNumber] [varchar](20) NOT NULL,
	[address] [varchar](100) NOT NULL,
	[website] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Hotel] PRIMARY KEY CLUSTERED 
(
	[idHotel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReviewInstitution]    Script Date: 6/4/2025 5:36:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReviewInstitution](
	[idReviewInstitution] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](500) NULL,
 CONSTRAINT [PK_ReviewInstitution] PRIMARY KEY CLUSTERED 
(
	[idReviewInstitution] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 6/4/2025 5:36:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[idLocation] [bigint] IDENTITY(1,1) NOT NULL,
	[address] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[idLocation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HotelReview]    Script Date: 6/4/2025 5:36:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelReview](
	[idHotel] [bigint] NOT NULL,
	[idReviewInstitution] [bigint] NOT NULL,
	[stars] [smallint] NOT NULL,
	[date] [datetime] NOT NULL,
	[comment] [varchar](2500) NOT NULL,
 CONSTRAINT [PK_HotelReview] PRIMARY KEY CLUSTERED 
(
	[idHotel] ASC,
	[idReviewInstitution] ASC,
	[date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 6/4/2025 5:36:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[idReservation] [bigint] IDENTITY(1,1) NOT NULL,
	[totalPriceInDinars] [real] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[idHotel] [bigint] NOT NULL,
	[idGuest] [bigint] NOT NULL,
 CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED 
(
	[idReservation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 6/4/2025 5:36:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[idRoom] [bigint] IDENTITY(1,1) NOT NULL,
	[roomNumber] [varchar](50) NOT NULL,
	[roomType] [varchar](50) NOT NULL,
	[nightPriceInDinars] [real] NOT NULL,
	[surfaceInm2] [int] NOT NULL,
	[idHotel] [bigint] NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[idRoom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservationItem]    Script Date: 6/4/2025 5:36:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservationItem](
	[idReservation] [bigint] NOT NULL,
	[no] [bigint] IDENTITY(1,1) NOT NULL,
	[startingDate] [datetime] NOT NULL,
	[endingDate] [datetime] NOT NULL,
	[nights] [int] NOT NULL,
	[reservationItemPriceInDinars] [real] NOT NULL,
	[idRoom] [bigint] NOT NULL,
 CONSTRAINT [PK_ReservationItem] PRIMARY KEY CLUSTERED 
(
	[idReservation] ASC,
	[no] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomType]    Script Date: 6/4/2025 5:36:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomType](
	[roomType] [varchar](50) NOT NULL,
 CONSTRAINT [PK_roomType] PRIMARY KEY CLUSTERED 
(
	[roomType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 6/4/2025 5:36:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[idEmployee] [bigint] IDENTITY(1,1) NOT NULL,
	[email] [varchar](300) NOT NULL,
	[phoneNumber] [varchar](20) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](100) NOT NULL,
	[idHotel] [bigint] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[idEmployee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Guest]  WITH CHECK ADD  CONSTRAINT [FK_Guest_Location] FOREIGN KEY([idLocation])
REFERENCES [dbo].[Location] ([idLocation])
GO
ALTER TABLE [dbo].[Guest] CHECK CONSTRAINT [FK_Guest_Location]
GO
ALTER TABLE [dbo].[HotelReview]  WITH CHECK ADD  CONSTRAINT [FK_HotelReview_Hotel] FOREIGN KEY([idHotel])
REFERENCES [dbo].[Hotel] ([idHotel])
GO
ALTER TABLE [dbo].[HotelReview] CHECK CONSTRAINT [FK_HotelReview_Hotel]
GO
ALTER TABLE [dbo].[HotelReview]  WITH CHECK ADD  CONSTRAINT [FK_HotelReview_ReviewInstitution] FOREIGN KEY([idReviewInstitution])
REFERENCES [dbo].[ReviewInstitution] ([idReviewInstitution])
GO
ALTER TABLE [dbo].[HotelReview] CHECK CONSTRAINT [FK_HotelReview_ReviewInstitution]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Guest] FOREIGN KEY([idGuest])
REFERENCES [dbo].[Guest] ([idGuest])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Guest]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Hotel] FOREIGN KEY([idHotel])
REFERENCES [dbo].[Hotel] ([idHotel])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Hotel]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_Hotel] FOREIGN KEY([idHotel])
REFERENCES [dbo].[Hotel] ([idHotel])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_Hotel]
GO
ALTER TABLE [dbo].[ReservationItem]  WITH CHECK ADD  CONSTRAINT [FK_ReservationItem_Reservation] FOREIGN KEY([idReservation])
REFERENCES [dbo].[Reservation] ([idReservation])
GO
ALTER TABLE [dbo].[ReservationItem] CHECK CONSTRAINT [FK_ReservationItem_Reservation]
GO
ALTER TABLE [dbo].[ReservationItem]  WITH CHECK ADD  CONSTRAINT [FK_ReservationItem_Room] FOREIGN KEY([idRoom])
REFERENCES [dbo].[Room] ([idRoom])
GO
ALTER TABLE [dbo].[ReservationItem] CHECK CONSTRAINT [FK_ReservationItem_Room]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Hotel] FOREIGN KEY([idHotel])
REFERENCES [dbo].[Hotel] ([idHotel])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Hotel]
GO
ALTER TABLE [dbo].[Guest]  WITH CHECK ADD  CONSTRAINT [guestEmailValid] CHECK  (([email] like '%@%'))
GO
ALTER TABLE [dbo].[Guest] CHECK CONSTRAINT [guestEmailValid] 
GO
ALTER TABLE [dbo].[Hotel]  WITH CHECK ADD  CONSTRAINT [hotelPhoneNumberValid] CHECK  (([phoneNumber] like '011[0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[Hotel] CHECK CONSTRAINT [hotelPhoneNumberValid]
GO
ALTER TABLE [dbo].[Hotel]  WITH CHECK ADD  CONSTRAINT [hotelEmailValid] CHECK  (([email] like '%@%'))
GO
ALTER TABLE [dbo].[Hotel] CHECK CONSTRAINT [hotelEmailValid]
GO
ALTER TABLE [dbo].[HotelReview]  WITH CHECK ADD  CONSTRAINT [hotelStarsValid] CHECK  (([stars]<=(5)))
GO
ALTER TABLE [dbo].[HotelReview] CHECK CONSTRAINT [hotelStarsValid]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [totalReservationPriceValid] CHECK  (([totalPriceInDinars]>(0)))
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [totalReservationPriceValid]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [nightPriceValid] CHECK  [nightPriceInDinars]>(0)))
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [nightPriceValid]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [RoomSurfaceValid] CHECK  (([surfaceInm2]>(0)))
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [RoomSurfaceValid]
GO
ALTER TABLE [dbo].[ReservationItem]  WITH CHECK ADD  CONSTRAINT [nightsReservationItemValid] CHECK  (([nights]>(0)))
GO
ALTER TABLE [dbo].[ReservationItem] CHECK CONSTRAINT [nightsReservationItemValid] 
GO
ALTER TABLE [dbo].[ReservationItem]  WITH CHECK ADD  CONSTRAINT [ReservationItemPriceValid] CHECK  (([reservationItemPriceInDinars]>(0)))
GO
ALTER TABLE [dbo].[ReservationItem] CHECK CONSTRAINT [ReservationItemPriceValid] 
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [phoneNumberEmployeeValid] CHECK  (([phoneNumber] like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [phoneNumberEmployeeValid]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [employeeEmailValid] CHECK  (([email] like '%@%.%'))
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [employeeEmailValid] 
GO
USE [master]
GO
ALTER DATABASE [HotelReservationManagement] SET  READ_WRITE 
GO
