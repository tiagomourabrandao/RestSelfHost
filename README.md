# RestSelfHost

This a implementation of a Self Hosted API using OWIN, OData, Authentication with immutable Key and SQL Server Database.


### Prerequisities

This is our Database script:

```
USE [master]
GO

/****** Object:  Database [selfhostwebapi]    Script Date: 19/07/2016 12:34:24 ******/
CREATE DATABASE [selfhostwebapi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'selfhostwebapi', FILENAME = N'C:\Users\Public\selfhostwebapi.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'selfhostwebapi_log', FILENAME = N'C:\Users\Public\selfhostwebapi_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [selfhostwebapi] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [selfhostwebapi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [selfhostwebapi] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [selfhostwebapi] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [selfhostwebapi] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [selfhostwebapi] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [selfhostwebapi] SET ARITHABORT OFF 
GO

ALTER DATABASE [selfhostwebapi] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [selfhostwebapi] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [selfhostwebapi] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [selfhostwebapi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [selfhostwebapi] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [selfhostwebapi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [selfhostwebapi] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [selfhostwebapi] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [selfhostwebapi] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [selfhostwebapi] SET  DISABLE_BROKER 
GO

ALTER DATABASE [selfhostwebapi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [selfhostwebapi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [selfhostwebapi] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [selfhostwebapi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [selfhostwebapi] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [selfhostwebapi] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [selfhostwebapi] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [selfhostwebapi] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [selfhostwebapi] SET  MULTI_USER 
GO

ALTER DATABASE [selfhostwebapi] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [selfhostwebapi] SET DB_CHAINING OFF 
GO

ALTER DATABASE [selfhostwebapi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [selfhostwebapi] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [selfhostwebapi] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [selfhostwebapi] SET  READ_WRITE 
GO

```

And our Invoice Table

```
CREATE TABLE [dbo].[invoice](
	[CreatedAt] [datetime] NOT NULL,
	[ReferenceMonth] [int] NOT NULL,
	[ReferenceYear] [int] NOT NULL,
	[Document] [varchar](14) NOT NULL,
	[Description] [varchar](256) NOT NULL,
	[Amount] [decimal](16, 2) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DeactiveAt] [datetime] NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_invoice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
```

## API Usage

We accept only ```GET```, ```POST``` and ```DELETE``` verbs. If you try a ```PUT``` verb, you will receive a 405.

### Example

Insert a ```Authorization``` Header with ```restSelfHostToken``` value. Then:

```
GET http://localhost:5000/api/v1/invoice/75
```

```
GET http://localhost:5000/api/v1/invoice
```

```
POST http://localhost:5000/api/v1/invoice

Body:
{
  "CreatedAt" : "2016-02-15",
  "ReferenceMonth" : 4,
  "ReferenceYear" : 2016,
  "Document" : "05454",
  "Description" : "VAMOS COM TUDO!",
  "Amount" : 10,
  "IsActive" : true
}
```

```
DELETE http://localhost:5000/api/v1/invoice/1
```
### Filtering, Sorting and Pagination

We use OData to make that hard work for us!

```
GET localhost:5000/api/v1/invoice?$filter=Id ge 70
```

```
GET localhost:5000/api/v1/invoice?$orderby=ReferenceMonth desc, Id asc
```

```
GET localhost:5000/api/v1/invoice?$top=10&$skip=20
```

For more examples, see the [ODAta Official Website](http://www.odata.org/documentation/odata-version-2-0/uri-conventions/#SystemQueryOptions).


## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/tiagomourabrandao/RestSelfHost/tags). 

## Author

* **Tiago Brandão**  *aka Tiago Potência* - [LinkedIn](https://br.linkedin.com/in/tiagomourabrandao)