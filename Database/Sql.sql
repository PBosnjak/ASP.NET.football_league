SET IDENTITY_INSERT [dbo].[Referees] ON
INSERT INTO [dbo].[Referees]
([Id],[Firstname],[Lastname])
VALUES
    (1,N'Ivan',N'Bebek'),
    (2,N'Fran',N'Jović'),
    (3,N'Igor',N'Pajač');
SET IDENTITY_INSERT [dbo].[Referees] OFF

SET IDENTITY_INSERT [dbo].[Clubs] ON

INSERT INTO [dbo].[Clubs]
([Id],[Name],[Country])
VALUES
    (1,N'Dinamo Zagreb',N'Croatia'),
    (2,N'Hajduk Split',N'Croatia'),
    (3,N'Osijek',N'Croatia'),
    (4,N'Rijeka',N'Croatia'),
    (5,N'Slaven Belupo',N'Croatia');

SET IDENTITY_INSERT [dbo].[Clubs] OFF

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

SET IDENTITY_INSERT [dbo].[Matches] ON

INSERT INTO [dbo].[Matches] ([Id], [Season], [Date], [HomeTeamId], [AwayTeamId], [HomeTeamGoals], [AwayTeamGoals],[RefereeId],[HomeTeamRedCards],[HomeTeamYellowCards],
[AwayTeamRedCards], [AwayTeamYellowCards] ) VALUES
    (1,N'2017/18','2018-02-11 00:00:00',1,2,1,1,1,0,2,1,1),
    (2,N'2017/18','2018-02-12 00:00:00',1,3,2,0,2,0,1,0,1),
    (3,N'2017/18','2018-02-13 00:00:00',1,4,3,1,3,0,0,0,0),
    (4,N'2017/18','2018-02-14 00:00:00',1,5,4,2,1,1,0,0,0),
    (5,N'2017/18','2018-02-15 00:00:00',2,1,1,3,2,0,0,0,0),
    (6,N'2017/18','2018-02-16 00:00:00',2,3,3,3,3,0,0,0,0),
    (7,N'2017/18','2018-02-17 00:00:00',2,4,4,2,1,0,0,0,0),
    (8,N'2017/18','2018-02-18 00:00:00',2,5,6,1,2,0,0,0,0),
    (9,N'2017/18','2018-02-19 00:00:00',3,1,4,1,3,1,0,0,0),
    (10,N'2017/18','2018-02-20 00:00:00',3,2,0,0,1,0,0,0,0),
    (11,N'2017/18','2018-02-21 00:00:00',3,4,0,3,2,0,1,1,1),
    (12,N'2017/18','2018-02-22 00:00:00',3,5,3,2,3,0,1,0,0),
    (13,N'2017/18','2018-02-23 00:00:00',4,1,0,0,1,0,1,0,0),
    (14,N'2017/18','2018-02-24 00:00:00',4,2,1,1,2,0,1,0,0),
    (15,N'2017/18','2018-02-25 00:00:00',4,3,3,2,3,0,0,0,1),
    (16,N'2017/18','2018-02-26 00:00:00',4,5,1,0,1,1,0,0,1),
    (17,N'2017/18','2018-02-27 00:00:00',5,1,0,4,2,0,0,0,0),
    (18,N'2017/18','2018-02-28 00:00:00',5,2,1,2,3,0,0,0,0),
    (19,N'2017/18','2018-03-01 00:00:00',5,3,1,1,1,0,0,0,0),
    (20,N'2017/18','2018-03-02 00:00:00',5,4,2,2,2,0,0,0,0);
SET IDENTITY_INSERT [dbo].[Matches] OFF

SET IDENTITY_INSERT [dbo].[Goals] ON
INSERT INTO [dbo].[Goals]
([Id],[MatchId],[PlayerId],[Minute],[Halftime])
VALUES
    (1,1,5,22,1),
    (2,1,9,35,1),
    (3,2,2,60,2),
    (4,2,3,89,2),
    (5,3,5,22,1),
    (6,3,4,35,1),
    (7,3,3,60,2),
    (8,3,20,89,2),
    (9,4,5,22,1),
    (10,4,5,35,1),
    (11,4,4,60,2),
    (12,4,2,89,2),
    (13,4,22,22,1),
    (14,4,25,35,1),
    (15,5,5,60,2),
    (16,5,5,89,2),
    (17,5,4,22,1),
    (18,5,9,35,1),
    (19,6,10,60,2),
    (20,6,10,89,2),
    (21,6,9,22,1),
    (22,6,15,35,1),
    (23,6,14,60,2),
    (24,6,12,89,2),
    (25,7,10,22,1),
    (26,7,9,35,1),
    (27,7,8,60,2),
    (28,7,7,89,2),
    (29,7,19,22,1),
    (30,7,19,35,1),
    (31,8,7,60,2),
    (32,8,8,89,2),
    (33,8,9,22,1),
    (34,8,10,35,1),
    (35,8,10,60,2),
    (36,8,10,89,2),
    (37,8,24,22,1),
    (38,9,5,35,1),
    (39,9,15,60,2),
    (40,9,13,89,2),
    (41,9,13,22,1),
    (42,9,14,35,1),
    (43,11,20,60,2),
    (44,11,19,89,2),
    (45,11,18,22,1),
    (46,12,15,35,1),
    (47,12,15,60,2),
    (48,12,12,89,2),
    (49,12,25,22,1),
    (50,12,23,35,1),
    (51,14,20,60,2),
    (52,14,10,89,2),
    (53,15,19,22,1),
    (54,15,19,35,1),
    (55,15,15,60,2),
    (56,15,20,89,2),
    (57,15,12,22,1),
    (58,16,17,35,1),
    (59,17,2,60,2),
    (60,17,3,89,2),
    (61,17,4,22,1),
    (62,17,5,35,1),
    (63,18,9,60,2),
    (64,18,23,89,2),
    (65,18,9,22,1),
    (66,19,23,35,1),
    (67,19,14,60,2),
    (68,20,25,89,2),
    (69,20,18,22,1),
    (70,20,20,35,1),
    (71,20,22,60,2);
SET IDENTITY_INSERT [dbo].[Goals] OFF

SET IDENTITY_INSERT [dbo].[Cards] ON
INSERT INTO [dbo].[Cards]
([Id],[MatchId],[PlayerId],[Type],[Minute])
VALUES
    (1,1,9,N'y',25),
    (2,1,2,N'y',45),
    (3,1,3,N'y',60),
    (4,1,6,N'r',77),
    (5,2,5,N'y',25),
    (6,2,12,N'y',45),
    (7,9,13,N'r',60),
    (8,11,11,N'y',77),
    (9,11,18,N'y',25),
    (10,11,16,N'r',45),
    (11,12,11,N'y',60),
    (12,13,20,N'y',77),
    (13,14,19,N'y',25),
    (14,15,12,N'y',45),
    (15,16,22,N'y',60),
    (16,16,17,N'r',77);
SET IDENTITY_INSERT [dbo].[Cards] OFF
