SET IDENTITY_INSERT [dbo].[Players] ON
INSERT INTO [dbo].[Players] ([Id],[Firstname],[Lastname],[ClubId],[Nationality],[Position])

VALUES
    (1,N'Dominik',N'Livaković',1,N'Croatian',N'gk'),
    (2,N'Marin',N'Leovac',1,N'Croatian',N'd'),
    (3,N'Arijan',N'Ademi',1,N'Macedonian',N'm'),
    (4,N'El Arbi',N'Soudani',1,N'Algerian',N'o'),
    (5,N'Ante',N'Čorić',1,N'Croatian',N'm'),
    (6,N'Karlo',N'Letica',2,N'Croatian',N'gk'),
    (7,N'Fran',N'Tudor',2,N'Croatian',N'd'),
    (8,N'Mijo',N'Caktaš',2,N'Croatian',N'm'),
    (9,N'Josip ',N'Radošević',2,N'Croatian',N'm'),
    (10,N'Ivan',N'Delić',2,N'Croatian',N'o'),
    (11,N'Marko ',N'Malenica',3,N'Croatian',N'gk'),
    (12,N'Borna',N'Barišić',3,N'Croatian',N'd'),
    (13,N'Petar',N'Bočkaj ',3,N'Croatian',N'm'),
    (14,N'Tomislav',N'Šorša',3,N'Croatian',N'm'),
    (15,N'Muzafer',N'Ejupi',3,N'Macedonian',N'o'),
    (16,N'Andrej',N'Prskalo',4,N'Croatian',N'gk'),
    (17,N'Luka',N'Capan',4,N'Croatian',N'd'),
    (18,N'Filip',N'Bradarić',4,N'Croatian',N'm'),
    (19,N'Leonard',N'Žuta',4,N'Macedonian',N'm'),
    (20,N'Zoran',N'Kvržić',4,N'Bosnian',N'o'),
    (21,N'Damjan',N'Kurtanjek',5,N'Croatian',N'gk'),
    (22,N'Božo',N'Musa',5,N'Croatian',N'd'),
    (23,N'David',N'Arap',5,N'Croatian',N'm'),
    (24,N'Arijan',N'Brković',5,N'Croatian',N'm'),
    (25,N'Mateas',N'Delić',5,N'Croatian',N'o');
SET IDENTITY_INSERT [dbo].[Players] OFF
