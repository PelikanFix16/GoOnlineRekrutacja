IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Tasks] (
    [Id] uniqueidentifier NOT NULL,
    [CreatedDate] datetimeoffset NULL,
    [ExpirationDate] datetimeoffset NULL,
    [Title] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NULL,
    [CompleteStatus] int NOT NULL,
    CONSTRAINT [PK_Tasks] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CompleteStatus', N'CreatedDate', N'Description', N'ExpirationDate', N'Title') AND [object_id] = OBJECT_ID(N'[Tasks]'))
    SET IDENTITY_INSERT [Tasks] ON;
INSERT INTO [Tasks] ([Id], [CompleteStatus], [CreatedDate], [Description], [ExpirationDate], [Title])
VALUES ('e74dc990-5488-4b39-aecc-28c1eecb011f', 0, '2022-04-25T23:34:08.0301904+02:00', NULL, '2022-05-03T23:34:08.0301901+02:00', N'Napic sie kawy');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CompleteStatus', N'CreatedDate', N'Description', N'ExpirationDate', N'Title') AND [object_id] = OBJECT_ID(N'[Tasks]'))
    SET IDENTITY_INSERT [Tasks] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CompleteStatus', N'CreatedDate', N'Description', N'ExpirationDate', N'Title') AND [object_id] = OBJECT_ID(N'[Tasks]'))
    SET IDENTITY_INSERT [Tasks] ON;
INSERT INTO [Tasks] ([Id], [CompleteStatus], [CreatedDate], [Description], [ExpirationDate], [Title])
VALUES ('ed4bf9d1-a7c4-4f89-8d0d-4fac1bf8f294', 0, '2022-04-25T23:34:08.0301859+02:00', N'Zrobic zakupy w sklepie, koszt bulek 0.40gr', '2022-04-26T23:34:08.0301811+02:00', N'Kupic bulki');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CompleteStatus', N'CreatedDate', N'Description', N'ExpirationDate', N'Title') AND [object_id] = OBJECT_ID(N'[Tasks]'))
    SET IDENTITY_INSERT [Tasks] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CompleteStatus', N'CreatedDate', N'Description', N'ExpirationDate', N'Title') AND [object_id] = OBJECT_ID(N'[Tasks]'))
    SET IDENTITY_INSERT [Tasks] ON;
INSERT INTO [Tasks] ([Id], [CompleteStatus], [CreatedDate], [Description], [ExpirationDate], [Title])
VALUES ('ef20f70e-4b78-45eb-9404-de3da9ff16dc', 0, '2022-04-25T23:34:08.0301898+02:00', NULL, '2022-04-27T23:34:08.0301895+02:00', N'Natankowac samochod');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CompleteStatus', N'CreatedDate', N'Description', N'ExpirationDate', N'Title') AND [object_id] = OBJECT_ID(N'[Tasks]'))
    SET IDENTITY_INSERT [Tasks] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220425213408_Init', N'6.0.4');
GO

COMMIT;
GO

