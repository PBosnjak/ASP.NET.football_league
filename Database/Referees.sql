SET IDENTITY_INSERT [dbo].[Referees] ON
INSERT INTO [dbo].[Referees]
([Id],[Firstname],[Lastname])
VALUES
    (1,N'Ivan',N'Bebek'),
    (2,N'Fran',N'Jović'),
    (3,N'Igor',N'Pajač');
SET IDENTITY_INSERT [dbo].[Referees] OFF
