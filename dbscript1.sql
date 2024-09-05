USE [master]
GO

/****** Object:  Database [contact-manager]    Script Date: 9/4/2024 5:25:06 PM ******/
DROP DATABASE IF EXISTS [contact-manager]
GO

/****** Object:  Database [contact-manager]    Script Date: 9/4/2024 5:25:06 PM ******/
CREATE DATABASE [contact-manager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'contact-manager', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\contact-manager.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'contact-manager_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\contact-manager_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

USE [contact-manager]
GO

/****** Object:  Table [dbo].[Contact]    Script Date: 9/4/2024 5:37:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

USE [contact-manager]
IF OBJECT_ID(N'dbo.Contact', N'U') IS NOT NULL
 DROP TABLE [dbo].[Contact];  
CREATE TABLE [dbo].[Contact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

