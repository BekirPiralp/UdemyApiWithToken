Create database UdemyApiWithToken;
use UdemyApiWithToken;

Create table Product(
Id int identity(1,1) primary key not null ,
Name nvarchar(50) null,
Category nvarchar(50) null,
Price money null
);

Create table [User](
Id int identity(1,1) primary key not null,
Email nvarchar(100) null,
Password nvarchar(8) null,
Name nvarchar(50) null,
SurName nvarchar(50) null,
RefreshToken nvarchar(500) null,
RefreshTokenEndDate datetime null
);
