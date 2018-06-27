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
