insert into [TaleEngine].[dbo].[Event] (CreateDateTime, Title) values 
    (GETDATE(), 'Jornadas dotnet'),
    (GETDATE(), 'FlutterConf Málaga')

insert into [TaleEngine].[dbo].[Edition] (CreateDateTime, DateInit, DateEnd, EventId) values 
    (GETDATE(), '2023-01-01', '2023-02-02', 1),
    (GETDATE(), '2022-01-01', '2022-02-02', 2),
    (GETDATE(), '2024-01-01', '2024-02-02', 2)

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
	(GETDATE(), 'LARP 4', 4, 3, 5, 1, 1),

    (GETDATE(), 'Partida 2.1', 3, 2, 1, 2, 1),
	(GETDATE(), 'Partida 2.2', 4, 2, 1, 2, 1),
	(GETDATE(), 'Torneo 2.1', 5, 2, 3, 2, 1),
	(GETDATE(), 'LARP 2.1', 4, 2, 5, 2, 1),

     (GETDATE(), 'Partida 3.1', 3, 2, 1, 3, 1),
	(GETDATE(), 'Partida 3.2', 4, 2, 1, 3, 1),
	(GETDATE(), 'Torneo 3.1', 5, 2, 3, 3, 1),
	(GETDATE(), 'LARP 3.1', 4, 2, 5, 3, 1)

insert into [TaleEngine].[dbo].[User] (CreateDateTime, Name, Mail, StatusId, Username) values
	(GETDATE(), 'User1', 'user1@email.com', 2, 'SomeUser'),
	(GETDATE(), 'User2', 'user2@email.com', 2, 'AnotherUser'),
	(GETDATE(), 'User3', 'user3@email.com', 2, 'ExUser'),
	(GETDATE(), 'User4', 'user4@email.com', 1, 'AUser'),
	(GETDATE(), 'User5', 'user5@email.com', 3, 'SomewhatUser'),
	(GETDATE(), 'User6', 'user6@email.com', 4, 'SuperUser'),
	(GETDATE(), 'User7', 'user7@email.com', 5, 'TheUser'),
	(GETDATE(), 'User8', 'user8@email.com', 2, 'DaUser'),
	(GETDATE(), 'User9', 'user9@email.com', 2, 'UserSomething'),
	(GETDATE(), 'User10', 'user10@email.com', 2, 'ThingyUser'),

insert into [TaleEngine].[dbo].[FavActivities] (ActivitiesFavId, UsersFavId) values
    (1, 8),
    (1, 9),
    (5, 9),
    (8, 10)

insert into [TaleEngine].[dbo].[ActivityCreators] (ActivitiesCreateId, UsersCreateId) values
    (1, 1),
    (1, 2),
    (2, 1),
    (3, 1),
    (4, 2),
    (5, 2),
    (6, 2),
    (7, 2),
    (8, 3),
    (8, 2),
    (9, 3),
    (10, 3),
    (11, 3),

--select * from [TaleEngine].[dbo].[Event]
--select * from [TaleEngine].[dbo].[Edition]
--select * from [TaleEngine].[dbo].[ActivityType]
--select * from [TaleEngine].[dbo].[ActivityStatus]
--select * from [TaleEngine].[dbo].[Activity]
--select * from [TaleEngine].[dbo].[User]
--select * from [TaleEngine].[dbo].[UserStatus]
--select * from [TaleEngine].[dbo].[FavActivities]