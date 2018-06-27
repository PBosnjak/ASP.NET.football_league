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
