insert into Event (CreateDateTime, Title) values 
    (GETDATE(), 'Jornadas dotnet')

insert into Edition (CreateDateTime, DateInit, DateEnd, EventId) values 
    (GETDATE(), '2023-01-01', '2023-02-02', 1)

insert into Activity (CreateDateTime, Title, Places, StatusId, TypeId, EditionId, TimeSlotId) values
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