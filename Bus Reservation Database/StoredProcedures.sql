drop proc get_BusSelection

create proc proc_AdminLogin
as
begin
select username, password 
from Admin
end 

exec proc_AdminLogin

alter proc proc_AddBus(@BusNumber nvarchar(50), @DriverID int, @DriverPhone varchar(15),
@BusType nvarchar(20), @NumberOfSeats int, @BusAvailability bit)
as 
begin
insert into BusDetails values( @BusNumber, @DriverID, @DriverPhone,
@BusType, @NumberOfSeats, @BusAvailability)
end

exec proc_AddBus 'MH 05 AB 8123', 110, '+91-9623456719', 'AC', 40, 1

select * from BusDetails

create proc proc_AddDriver(@FirstName nvarchar(50), @LastName nvarchar(50), @PhoneNumber varchar(15))
as 
begin
insert into DriverDetails values( @FirstName, @LastName, @PhoneNumber)
end

exec proc_AddDriver 'Sham', 'Lal', '+91-9872916465'

select * from DriverDetails

create proc proc_AddTrip(@BusID int, @FromLocation varchar(50), @ToLocation varchar(50))
as 
begin
insert into Trip values( @BusID, @FromLocation, @ToLocation`
end

drop proc proc_AddTrip

exec proc_AddTrip 16 ,'Chennai', 'Bangalore'

select * from Trip

alter proc proc_AddRoute(@TripID int, @FromLocation varchar(50),
@ToLocation varchar(50), @FromDate date, @ToDate date, @FromTime varchar(10), 
@ToTime varchar(10), @FromDescription nvarchar(150), @ToDescription nvarchar(150), @Fare int, @NumberOfSeats int) 
as 
begin
insert into JourneyRoutes values( @TripID, default, @FromLocation, @ToLocation, @FromDate,
@ToDate, @FromTime, @ToTime, @FromDescription, @ToDescription, @Fare, @NumberOfSeats)
end

drop proc proc_AddRoute

exec proc_AddRoute 20, 'Chennai', 'Bangalore', '2020-08-14', '2020-08-14', '06:00', '12:30', 'Chennai ISBT', 'Bangalore ISBT', 550, 40

select * from JourneyRoutes

create proc proc_UpdateBus(@BusID int, @BusNumber nvarchar(50), @DriverID int, @DriverPhone varchar(15),
@BusType nvarchar(20), @NumberOfSeats int, @BusAvailability bit)
as
begin
update BusDetails
set BusNumber = @BusNumber, DriverID = @DriverID, DriverPhone = @DriverPhone,
BusType = @BusType, NumberOfSeats = @NumberOfSeats, BusAvailability = @BusAvailability
where BusId = @BusID
end

exec proc_UpdateBus 16, 'MH 05 HT 8335', 110, '+91-9623456719', 'AC', 40, 1

Select * from BusDetails

create proc proc_BusDetails
as
begin
Select * from BusDetails
end

exec proc_BusDetails

create proc proc_DriverDetails
as
begin
Select * from DriverDetails
end

exec proc_DriverDetails

create proc proc_TicketDetails(@BookingID int)
as
begin
Select * from Ticket
where BookingUserID = @BookingID AND FromDate >GETDATE() AND TicketBookingStatus = 1 
end

exec proc_TicketDetails 1001

select TripID, count(TripID) from JourneyRoutes group by TripID order by count(TripID) desc 

select TicketID from ticket where FromDate > GETDATE() 

--SELECT *
--FROM JourneyRoutes where TripID all MAX(select RouteID, TripId, CompanyName, FromLocation, ToLocation, FromDate, ToDate, FromTime, ToTime, FromDescription, ToDescription, Fare, NumberOFSeats, count(TripID) as tripcount from JourneyRoutes group by TripID order by RouteID, TripId, CompanyName, FromLocation, ToLocation, FromDate, ToDate, FromTime, ToTime, FromDescription, ToDescription, Fare, NumberOFSeats desc)

--select  from JourneyRoutes order by count(TripID)

SELECT  TripID, count(TripID) as tripcount from JourneyRoutes group by TripID

create proc proc_MostPreferedRoutes
as
begin
Select FromLocation, ToLocation, count(*) as routeCount from Ticket group by FromLocation, ToLocation order by routeCount desc
end

exec proc_MostPreferedRoutes

create proc proc_MostPreferedBusType
as
begin
select BusNumber, BusType, count(*) as buscount 
from Ticket t inner join BusDetails b on b.BusID = t.BusID 
group by BusType, BusNumber order by buscount desc
end

exec proc_MostPreferedBusType

create proc proc_ReservationDetailsofCustomer
as
begin
select TicketID, UID, FirstName, Lastname , BusID, FromLocation, ToLocation, FromDate, ToDate, FromTime, ToTime, TicketBookingStatus, NumberOfSeats, Fare, PaymentStatus
from GuestUserDetails g inner join UserDetails u on g.GID = u.GuestID
inner join Ticket t on t.BookingUserID = u.UID
order by FromDate
end

exec proc_ReservationDetailsofCustomer

create proc proc_UserNotBookedTicket
as
begin
select UID, FirstName, Lastname  
from GuestUserDetails g inner join UserDetails u on g.GID = u.GuestID
inner join Ticket t on t.BookingUserID = u.UID
where BookingUserID not in (UID)
order by FirstName desc, Lastname desc
end

alter proc proc_ProfitPercentage
as
begin
declare @operationalCost float
set @operationalCost = 800.8
select (sum(Fare)-(select (count(TicketID)*@operationalCost) from Ticket)) as Profit, 
(((sum(Fare)-(select (count(TicketID)*@operationalCost) from Ticket))/(select (count(TicketID)*@operationalCost) from Ticket)*100)) as ProfitPercentage from Ticket
end

exec proc_ProfitPercentage

create proc proc_Feedback(@PNR int, @JourneyRatings int, @Comments nvarchar(200))
as 
begin
insert into Feedback values(@PNR, @JourneyRatings, @Comments)
end

exec proc_Feedback 107201, 5, 'Very Good' 

select * from GuestUserDetails
select * from UserDetails
select * from Ticket
select * from Feedback

 --count(Routes)