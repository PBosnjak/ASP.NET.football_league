﻿SET IDENTITY_INSERT [dbo].[Matches] ON

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
