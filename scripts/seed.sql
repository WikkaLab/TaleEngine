insert into [TaleEngine].[dbo].[Event] (CreateDateTime, Title) values 
    (GETDATE(), 'Jornadas dotnet')

insert into [TaleEngine].[dbo].[Edition] (CreateDateTime, DateInit, DateEnd, EventId) values 
    (GETDATE(), '2023-01-01', '2023-02-02', 1)

insert into [TaleEngine].[dbo].[Activity] (CreateDateTime, Title, Places, StatusId, TypeId, EditionId, TimeSlotId) values
	(GETDATE(), 'Partida 1', 3, 2, 1, 1, 1),
	(GETDATE(), 'Partida 2', 4, 2, 1, 1, 1),
	(GETDATE(), 'Partida 3', 10, 1, 1, 1, 1),
	(GETDATE(), 'Partida 4', 10, 3, 1, 1, 1),
	(GETDATE(), 'Torneo 1', 5, 2, 3, 1, 1),
	(GETDATE(), 'Torneo 2', 2, 1, 3, 1, 1),
	(GETDATE(), 'Torneo 2', 2, 3, 3, 1, 1),
	(GETDATE(), 'LARP 1', 4, 2, 5, 1, 1),
	(GETDATE(), 'LARP 2', 4, 2, 5, 1, 1),
	(GETDATE(), 'LARP 3', 4, 1, 5, 1, 1),
	(GETDATE(), 'LARP 4', 4, 3, 5, 1, 1)

insert into [TaleEngine].[dbo].[User] (CreateDateTime, Name, Mail, StatusId, Username) values
	(GETDATE(), 'User1', 'user1@email.com', 2, 'SomeUser')

insert into [TaleEngine].[dbo].[FavActivities] (ActivitiesFavId, UsersFavId) values
    (1, 1),
    (5, 1),
    (8, 1)

--select * from [TaleEngine].[dbo].[Event]
--select * from [TaleEngine].[dbo].[Edition]
--select * from [TaleEngine].[dbo].[ActivityType]
--select * from [TaleEngine].[dbo].[ActivityStatus]
--select * from [TaleEngine].[dbo].[Activity]
--select * from [TaleEngine].[dbo].[User]
--select * from [TaleEngine].[dbo].[UserStatus]
--select * from [TaleEngine].[dbo].[FavActivities]