create database FYPPortal

use FYPPortal

create table Country
(
CountryID int primary key identity(1,1) not null,
CountryName varchar(50) unique
)

create table City
(
CityID int primary key identity(1,1) not null,
CityName varchar(50) unique,
CountryID int foreign key references Country(CountryID)
)

create table Roles
(
RoleID int primary key identity(1,1) not null,
RoleName varchar(50) unique
)

insert into Roles(RoleName)
values
('Administrator'),
('Faculty'),
('Student');

select * from Roles

create table Gender
(
GenderID int primary key identity(1,1) not null,
GenderName varchar(20) unique
)

insert into Gender(GenderName)
values
('Male'),
('Female'),
('Rather Not Mention');

select * from Gender


create table FYP
(
FYPID int primary key identity (1,1) not null,
FYPTitle nvarchar(10) unique
)

insert into FYP(FYPTitle)
values
('FYP I'),
('FYP II'),
('FYP III');

select * from FYP


create table Position
(
PosID int primary key identity(1,1) not null,
PosTitle varchar(50) unique,
PosIsActive bit null
)

create table Expertise
(
ExpID int primary key identity(1,1) not null,
ExpTitle varchar(50) unique,
Abbreviation varchar(50),
ExpIsActive bit null
)

create table Qualification
(
QualID int primary key identity(1,1) not null,
QualTitle varchar(50) unique,
QualIsActive bit null
)

create table Organization
(
OrgID int primary key identity(1,1) not null,
OrgName varchar(50),
OrgPhoneNo nvarchar(20) unique,
OrgEmail nvarchar(50) unique,
CountryID int foreign key references Country(CountryID),
CityID int foreign key references City(CityID),
OrgAddress nvarchar(max),
OrgLogo nvarchar(max) null,
OrgIsActive bit null
)

create table Department
(
DeptID int primary key identity(1,1) not null,
DeptName varchar(50),
OrgID int foreign key references Organization(OrgID),
DeptIsActive bit null
)

create table Faculty
(
FaclID int primary key identity(1,1) not null,
FaclFirstName varchar(50),
FaclLastName varchar(50),
GenderID int foreign key references Gender(GenderID),
FaclCNIC nvarchar(15) unique,
FaclPhoneNo nvarchar(20) unique,
FaclEmail nvarchar(50) unique,
CountryID int foreign key references Country(CountryID),
CityID int foreign key references City(CityID),
FaclAddress nvarchar(max),
FaclLastJob nvarchar(max) null,
FaclExperience nvarchar(max) null,
PosID int foreign key references Position(PosID),
QualID int foreign key references Qualification(QualID),
OrgID int foreign key references Organization(OrgID),
DeptID int foreign key references Department(DeptID),
FaclImage nvarchar(max) null,
FaclIsActive bit null
)

create table FacultyExpertise
(
FEID int primary key identity (1,1) not null,
FaclID int foreign key references Faculty(FaclID),
ExpID int foreign key references Expertise(ExpID),
FEIsActive bit null
)

create table Users
(
UserID int primary key identity (1,1) not null,
UserEmail nvarchar(50) unique,
UserPassword nvarchar(30),
RoleID int foreign key references Roles(RoleID),
UserIsActive bit null
)

create table Student
(
StdID int primary key identity (1,1) not null,
StdFirstName varchar(50),
StdLastName varchar(50),
GenderID int foreign key references Gender(GenderID),
StdCNIC nvarchar(15) unique,
StdPhoneNo nvarchar(20) unique,
StdEmail nvarchar(50) unique,
CountryID int foreign key references Country(CountryID),
CityID int foreign key references City(CityID),
StdAddress nvarchar(max),
StdLastEducation nvarchar(50) null,
OrgID int foreign key references Organization(OrgID),
DeptID int foreign key references Department(DeptID),
StdImage nvarchar(max) null,
StdIsActive bit null
)


create table StudentGroup
(
SgID int primary key identity (1,1) not null,
SgName nvarchar(50),
StdID int unique foreign key references Student(StdID),
SgIsActive bit null
)


create table StudentGroupMembers
(
SgmID int primary key identity (1,1) not null,
StdID int unique foreign key references Student(StdID),
SgID int foreign key references StudentGroup(SgID),
SgIsLeader bit null,
SgmIsActive bit null
)

create table Projects
(
ProjID int primary key identity (1,1) not null,
ProjTitle nvarchar(80) unique,
ProjDetails nvarchar(max),
FaclID int foreign key references Faculty(FaclID)
)


create table FypStatus
(
FYPStatusID int primary key identity (1,1) not null,
FYPID int foreign key references Fyp(FypID),
ProjID int foreign key references Projects(ProjID),
ProjStartDate DateTime,
ProjEndDate DateTime,
FYPStatusIsActive bit
)


create table Supervisor
(
SupID int primary key identity (1,1) not null,
FaclID int foreign key references Faculty(FaclID),
SupIsActive bit
)






create proc Sp_SaveCountry
@CountryName varchar(50)
as
begin
insert into Country(CountryName) 
values (@CountryName)
end

create proc Sp_GetCountry
as 
begin
select * from Country
end

create proc Sp_GetCountryByID
@CountryID int
as 
begin
select * from Country
where CountryID = @CountryID
end

create procedure Sp_EditCountry
@CountryID int,
@CountryName varchar(50)
as 
begin
update Country
set CountryName = @CountryName
where CountryID = @CountryID
end

create proc Sp_DeleteCountry
@CountryID int
as 
begin
delete from Country where CountryID = @CountryID
end



create proc Sp_SaveCity
@CityName varchar(50),
@CountryID int
as
begin
insert into City(CityName, CountryID) 
values (@CityName,@CountryID)
end

create view vWGetCity
as
select CityID, CityName, CountryName
from City
join Country
on City.CountryID = Country.CountryID

create proc Sp_GetCity
as 
begin
select * from vWGetCity
end

create proc Sp_GetCityByID
@CityID int
as 
begin
select * from City
where CityID = @CityID
end

create proc Sp_GetCityByCountry
@CountryID int
as 
begin
select * from City
where CountryID = @CountryID
end

create procedure Sp_EditCity
@CityID int,
@CityName varchar(50),
@CountryID int
as 
begin
update City
set CityName = @CityName, CountryID = @CountryID
where CityID = @CityID
end

create proc Sp_DeleteCity
@CityID int
as 
begin
delete from City where CityID = @CityID
end




create proc Sp_SaveRoles
@RoleName varchar(50)
as
begin
insert into Roles(RoleName) 
values (@RoleName)
end

create proc Sp_GetRoles
as 
begin
select * from Roles
end

create proc Sp_GetRolesByID
@RoleID int
as 
begin
select * from Roles
where RoleID = @RoleID
end

create procedure Sp_EditRoles
@RoleID int,
@RoleName varchar(50)
as 
begin
update Roles
set RoleName = @RoleName
where RoleID = @RoleID
end

create proc Sp_DeleteRoles
@RoleID int
as 
begin
delete from Roles where RoleID = @RoleID
end




create proc Sp_SaveGender
@GenderName varchar(20)
as
begin
insert into Gender(GenderName) 
values (@GenderName)
end

create proc Sp_GetGender
as 
begin
select * from Gender
end

create proc Sp_GetGenderByID
@GenderID int
as 
begin
select * from Gender
where GenderID = @GenderID
end

create procedure Sp_EditGender
@GenderID int,
@GenderName varchar(20)
as 
begin
update Gender
set GenderName = @GenderName
where GenderID = @GenderID
end

create proc Sp_DeleteGender
@GenderID int
as 
begin
delete from Gender where GenderID = @GenderID
end




create proc Sp_SaveFYP
@FYPTitle nvarchar(10)
as
begin
insert into FYP(FYPTitle) 
values (@FYPTitle)
end

create proc Sp_GetFYP
as 
begin
select * from FYP
end

create proc Sp_GetFYPByID
@FYPID int
as 
begin
select * from FYP
where FYPID = @FYPID
end

create procedure Sp_EditFYP
@FYPID int,
@FYPTitle nvarchar(10)
as 
begin
update FYP
set FYPTitle = @FYPTitle
where FYPID = @FYPID
end

create proc Sp_DeleteFYP
@FYPID int
as 
begin
delete from FYP where FYPID = @FYPID
end








create proc Sp_SavePos
@PosTitle varchar(50),
@PosIsActive bit
as
begin
insert into Position(PosTitle, PosIsActive) 
values (@PosTitle, @PosIsActive)
end

create proc Sp_GetPos
as 
begin
select * from Position
end

create proc Sp_GetPosByID
@PosID int
as 
begin
select * from Position
where PosID = @PosID
end

create procedure Sp_EditPos
@PosID int,
@PosTitle varchar(50),
@PosIsActive bit
as 
begin
update Position
set PosTitle = @PosTitle, PosIsActive = @PosIsActive
where PosID=@PosID
end

create proc Sp_DeletePos
@PosID int
as 
begin
delete from Position where PosID=@PosID
end





create proc Sp_SaveExp
@ExpTitle varchar(50),
@Abbreviation varchar(50),
@ExpIsActive bit
as
begin
insert into Expertise(ExpTitle, Abbreviation, ExpIsActive) 
values (@ExpTitle, @Abbreviation, @ExpIsActive)
end

create proc Sp_GetExp
as 
begin
select * from Expertise
end

create proc Sp_GetExpByID
@ExpID int
as 
begin
select * from Expertise
where ExpID = @ExpID
end

create procedure Sp_EditExp
@ExpID int,
@ExpTitle varchar(50),
@Abbreviation varchar(50),
@ExpIsActive bit
as 
begin
update Expertise
set ExpTitle = @ExpTitle, Abbreviation = @Abbreviation, ExpIsActive = @ExpIsActive
where ExpID=@ExpID
end

create proc Sp_DeleteExp
@ExpID int
as 
begin
delete from Expertise where ExpID=@ExpID
end





create proc Sp_SaveQual
@QualTitle varchar(50),
@QualIsActive bit
as
begin
insert into Qualification(QualTitle, QualIsActive) 
values (@QualTitle, @QualIsActive)
end

create proc Sp_GetQual
as 
begin
select * from Qualification
end

create proc Sp_GetQualByID
@QualID int
as 
begin
select * from Qualification
where QualID = @QualID
end

create procedure Sp_EditQual
@QualID int,
@QualTitle varchar(50),
@QualIsActive bit
as 
begin
update Qualification
set QualTitle = @QualTitle, QualIsActive = @QualIsActive
where QualID=@QualID
end

create proc Sp_DeleteQual
@QualID int
as 
begin
delete from Qualification where QualID=@QualID
end




create proc Sp_SaveOrg
@OrgName varchar(50),
@OrgPhoneNo nvarchar(20),
@OrgEmail nvarchar(50),
@CountryID int,
@CityID int,
@OrgAddress nvarchar(max),
@OrgLogo nvarchar(max),
@OrgIsActive bit
as
begin
insert into Organization(OrgName, OrgPhoneNo, OrgEmail, CountryID, CityID, OrgAddress, OrgLogo, OrgIsActive) 
values (@OrgName, @OrgPhoneNo, @OrgEmail, @CountryID, @CityID, @OrgAddress, @OrgLogo, @OrgIsActive)
end

create view vWGetOrg
as
select OrgID, OrgName, OrgPhoneNo, OrgEmail, ctry.CountryName, cty.CityName, OrgAddress, OrgLogo, OrgIsActive
from Organization as org
join Country as ctry
on org.CountryID = ctry.CountryID
join City as cty
on org.CityID = cty.CityID


create proc Sp_GetOrg
as 
begin
select * from vWGetOrg
end

create proc Sp_GetOrgByID
@OrgID int
as 
begin
select * from Organization
where OrgID = @OrgID
end

create procedure Sp_EditOrg
@OrgID int,
@OrgName varchar(50),
@OrgPhoneNo nvarchar(20),
@OrgEmail nvarchar(50),
@CountryID int,
@CityID int,
@OrgAddress nvarchar(max),
@OrgLogo nvarchar(max),
@OrgIsActive bit
as 
begin
update Organization
set OrgName = @OrgName, OrgPhoneNo = @OrgPhoneNo, OrgEmail = @OrgEmail, CountryID = @CountryID, CityID = @CityID,
	OrgAddress = @OrgAddress, OrgLogo = @OrgLogo, OrgIsActive = @OrgIsActive
where OrgID=@OrgID
end

create proc Sp_DeleteOrg
@OrgID int
as 
begin
delete from Organization where OrgID=@OrgID
end




create proc Sp_SaveDept
@DeptName varchar(50),
@OrgID int,
@DeptIsActive bit
as
begin
insert into Department(DeptName, OrgID, DeptIsActive) 
values (@DeptName, @OrgID, @DeptIsActive)
end

create view vWGetDept
as
select DeptID, DeptName, org.OrgName, DeptIsActive
from Department as dept
join Organization as org
on dept.OrgID = org.OrgID


create proc Sp_GetDept
as 
begin
select * from vWGetDept
end

create proc Sp_GetDeptByID
@DeptID int
as 
begin
select * from Department
where DeptID = @DeptID
end

create proc Sp_GetDeptByOrg
@OrgID int
as 
begin
select * from Department
where OrgID = @OrgID
end


create procedure Sp_EditDept
@DeptID int,
@DeptName varchar(50),
@OrgID int,
@DeptIsActive bit
as 
begin
update Department
set DeptName = @DeptName, OrgID = @OrgID, DeptIsActive = @DeptIsActive
where DeptID=@DeptID
end


create proc Sp_DeleteDept
@DeptID int
as 
begin
delete from Department where DeptID=@DeptID
end





create proc Sp_SaveFacl
@FaclFirstName varchar(50),
@FaclLastName varchar(50),
@GenderID int,
@FaclCNIC nvarchar(15),
@FaclPhoneNo nvarchar(20),
@FaclEmail nvarchar(50),
@CountryID int,
@CityID int,
@FaclAddress nvarchar(max),
@FaclLastJob nvarchar(max) null,
@FaclExperience nvarchar(max) null,
@PosID int,
@QualID int,
@OrgID int,
@DeptID int,
@FaclImage nvarchar(max) null,
@FaclIsActive bit null
as
begin
insert into Faculty(FaclFirstName, FaclLastName, GenderID, FaclCNIC, FaclPhoneNo, FaclEmail, CountryID, CityID, 
	FaclAddress, FaclLastJob, FaclExperience, PosID, QualID, OrgID, DeptID, FaclImage, FaclIsActive) 
values (@FaclFirstName, @FaclLastName, @GenderID, @FaclCNIC, @FaclPhoneNo, @FaclEmail, @CountryID, @CityID, 
	@FaclAddress, @FaclLastJob, @FaclExperience, @PosID, @QualID, @OrgID, @DeptID, @FaclImage, @FaclIsActive) 
end


create view vWGetFacl
as
select FaclID, FaclFirstName, FaclLastName, gen.GenderName, FaclCNIC, FaclPhoneNo, FaclEmail, ctry.CountryName, cty.CityName, 
	FaclAddress, FaclLastJob, FaclExperience, pos.PosTitle, qual.QualTitle, org.OrgName, dept.DeptName, FaclImage, FaclIsActive
from Faculty as facl
join Gender as gen on facl.GenderID = gen.GenderID
join Country as ctry on facl.CountryID = ctry.CountryID
join City as cty on facl.CityID = cty.CityID
join Position as pos on facl.PosID = pos.PosID
join Qualification as qual on facl.QualID = qual.QualID
join Organization as org on facl.OrgID = org.OrgID
join Department as dept on facl.DeptID = dept.DeptID


create proc Sp_GetFacl
as 
begin
select * from vWGetFacl
end

create proc Sp_GetFaclByID
@FaclID int
as 
begin
select * from Faculty
where FaclID = @FaclID
end

create procedure Sp_EditFacl
@FaclID int,
@FaclFirstName varchar(50),
@FaclLastName varchar(50),
@GenderID int,
@FaclCNIC nvarchar(15),
@FaclPhoneNo nvarchar(20),
@FaclEmail nvarchar(50),
@CountryID int,
@CityID int,
@FaclAddress nvarchar(max),
@FaclLastJob nvarchar(max) null,
@FaclExperience nvarchar(max) null,
@PosID int,
@QualID int,
@OrgID int,
@DeptID int,
@FaclImage nvarchar(max) null,
@FaclIsActive bit null
as 
begin
update Faculty
set FaclFirstName = @FaclFirstName, FaclLastName = @FaclLastName, GenderID = @GenderID, FaclCNIC = @FaclCNIC, 
	FaclPhoneNo = @FaclPhoneNo, FaclEmail = @FaclEmail, CountryID = @CountryID, CityID = @CityID, FaclAddress = @FaclAddress, 
	FaclLastJob = @FaclLastJob, FaclExperience = @FaclExperience, PosID = @PosID, QualID = @QualID, OrgID = @OrgID,
	DeptID = @DeptID, FaclImage = @FaclImage, FaclIsActive = @FaclIsActive
where FaclID = @FaclID
end

create proc Sp_DeleteFacl
@FaclID int
as 
begin
delete from Faculty where FaclID=@FaclID
end




create proc Sp_SaveUser
@UserEmail nvarchar(50),
@UserPassword nvarchar(30),
@RoleID int,
@UserIsActive bit null
as
begin
insert into Users(UserEmail, UserPassword, RoleID, UserIsActive) 
values (@UserEmail, @UserPassword, @RoleID, @UserIsActive)
end

create view vWGetUser
as
select UserID, UserEmail, UserPassword, rl.RoleName, UserIsActive
from Users as usr
join Roles as rl
on usr.RoleID = rl.RoleID


create proc Sp_GetUser
as 
begin
select * from vWGetUser
end

create proc Sp_GetUserByID
@UserID int
as 
begin
select * from Users
where UserID = @UserID
end


create procedure Sp_EditUser
@UserID int,
@UserEmail nvarchar(50),
@UserPassword nvarchar(30),
@RoleID int,
@UserIsActive bit null
as 
begin
update Users
set UserEmail = @UserEmail, UserPassword = @UserPassword, RoleID = @RoleID, UserIsActive = @UserIsActive
where UserID = @UserID
end

create proc Sp_DeleteUser
@UserID int
as 
begin
delete from Users where UserID = @UserID
end




create proc Sp_SaveStd
@StdFirstName varchar(50),
@StdLastName varchar(50),
@GenderID int,
@StdCNIC nvarchar(15),
@StdPhoneNo nvarchar(20),
@StdEmail nvarchar(50),
@CountryID int,
@CityID int,
@StdAddress nvarchar(max),
@StdLastEducation nvarchar(max) null,
@OrgID int,
@DeptID int,
@StdImage nvarchar(max) null,
@StdIsActive bit null
as
begin
insert into Student(StdFirstName, StdLastName, GenderID, StdCNIC, StdPhoneNo, StdEmail, CountryID, CityID, 
	StdAddress, StdLastEducation, OrgID, DeptID, StdImage, StdIsActive) 
values (@StdFirstName, @StdLastName, @GenderID, @StdCNIC, @StdPhoneNo, @StdEmail, @CountryID, @CityID, 
	@StdAddress, @StdLastEducation, @OrgID, @DeptID, @StdImage, @StdIsActive) 
end


create view vWGetStd
as
select StdID, StdFirstName, StdLastName, gen.GenderName, StdCNIC, StdPhoneNo, StdEmail, ctry.CountryName, cty.CityName, 
	StdAddress, StdLastEducation, org.OrgName, dept.DeptName, StdImage, StdIsActive
from Student as std
join Gender as gen on std.GenderID = gen.GenderID
join Country as ctry on std.CountryID = ctry.CountryID
join City as cty on std.CityID = cty.CityID
join Organization as org on std.OrgID = org.OrgID
join Department as dept on std.DeptID = dept.DeptID


create proc Sp_GetStd
as 
begin
select * from vWGetStd
end

create proc Sp_GetStdByID
@StdID int
as 
begin
select * from Student
where StdID = @StdID
end

create proc Sp_GetStdByEmail
@StdEmail nvarchar(50)
as 
begin
select * from Student
where StdEmail = @StdEmail
end

create procedure Sp_EditStd
@StdID int,
@StdFirstName varchar(50),
@StdLastName varchar(50),
@GenderID int,
@StdCNIC nvarchar(15),
@StdPhoneNo nvarchar(20),
@StdEmail nvarchar(50),
@CountryID int,
@CityID int,
@StdAddress nvarchar(max),
@StdLastEducation nvarchar(max) null,
@OrgID int,
@DeptID int,
@StdImage nvarchar(max) null,
@StdIsActive bit null
as 
begin
update Student
set StdFirstName = @StdFirstName, StdLastName = @StdLastName, GenderID = @GenderID, StdCNIC = @StdCNIC, 
	StdPhoneNo = @StdPhoneNo, StdEmail = @StdEmail, CountryID = @CountryID, CityID = @CityID, StdAddress = @StdAddress, 
	StdLastEducation = @StdLastEducation, OrgID = @OrgID,
	DeptID = @DeptID, StdImage = @StdImage, StdIsActive = @StdIsActive
where StdID = @StdID
end

create proc Sp_DeleteStd
@StdID int
as 
begin
delete from Student where StdID=@StdID
end



--DELETE FROM Country
--DBCC CHECKIDENT ('FYPPortal.dbo.Country', RESEED, 0)


--DELETE FROM City
--DBCC CHECKIDENT ('FYPPortal.dbo.City', RESEED, 0)


--DELETE FROM Roles
--DBCC CHECKIDENT ('FYPPortal.dbo.Roles', RESEED, 0)


--DELETE FROM Position
--DBCC CHECKIDENT ('FYPPortal.dbo.Position', RESEED, 0)


--DELETE FROM Expertise
--DBCC CHECKIDENT ('FYPPortal.dbo.Expertise', RESEED, 0)


--DELETE FROM Qualification
--DBCC CHECKIDENT ('FYPPortal.dbo.Qualification', RESEED, 0)


--DELETE FROM Organization
--DBCC CHECKIDENT ('FYPPortal.dbo.Organization', RESEED, 0)


--DELETE FROM Department
--DBCC CHECKIDENT ('FYPPortal.dbo.Department', RESEED, 0)


--DELETE FROM Faculty
--DBCC CHECKIDENT ('FYPPortal.dbo.Faculty', RESEED, 0)


--create table StudentGroupMembers
--(
--SgmID int primary key identity (1,1) not null,
--StdID int unique foreign key references Student(StdID),
--SgID int foreign key references StudentGroup(SgID),
--SgIsLeader bit null,
--SgmIsActive bit null
--)



create proc Sp_SaveSGroup
@SgName nvarchar(50),
@StdID int,
@SgIsActive bit null
as
begin
insert into StudentGroup(SgName, StdID, SgIsActive) 
values (@SgName, @StdID, @SgIsActive)
end

create view vWGetSGroup
as
select SgID, SgName, std.StdFirstName, std.StdLastName, SgIsActive
from StudentGroup as sg
join Student as std
on sg.StdID = std.StdID


create proc Sp_GetSGroup
as 
begin
select * from vWGetSGroup
end

create proc Sp_GetSGroupByID
@SgID int
as 
begin
select * from StudentGroup
where SgID = @SgID
end


create procedure Sp_EditSGroup
@SgID int,
@SgName nvarchar(50),
@StdID int,
@SgIsActive bit null
as 
begin
update StudentGroup
set SgName = @SgName, StdID = @StdID, SgIsActive = @SgIsActive
where SgID = @SgID
end

create proc Sp_DeleteSGroup
@SgID int
as 
begin
delete from StudentGroup where SgID = @SgID
end


