IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [AspNetRoles] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AspNetUsers] (
    [Id] nvarchar(450) NOT NULL,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [TCoalicion] (
    [IdCoalicion] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    [Siglas] nvarchar(max) NOT NULL,
    [Logo] nvarchar(max) NULL,
    CONSTRAINT [PK_TCoalicion] PRIMARY KEY ([IdCoalicion])
);

GO

CREATE TABLE [TDistrito] (
    [IdDistrito] int NOT NULL IDENTITY,
    [NoDistrito] int NOT NULL,
    [Nombre] nvarchar(max) NULL,
    [Integracion] nvarchar(max) NULL,
    CONSTRAINT [PK_TDistrito] PRIMARY KEY ([IdDistrito])
);

GO

CREATE TABLE [TMunicipio] (
    [IdMunicipio] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NULL,
    [CabMun] nvarchar(max) NULL,
    [NoEstado] int NOT NULL,
    [Estado] nvarchar(max) NULL,
    CONSTRAINT [PK_TMunicipio] PRIMARY KEY ([IdMunicipio])
);

GO

CREATE TABLE [TPartido] (
    [IdPartido] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    [Siglas] nvarchar(max) NOT NULL,
    [LogoURL] nvarchar(max) NULL,
    [Independiente] bit NOT NULL,
    [Prioridad] int NOT NULL,
    [PantoneF] nvarchar(max) NOT NULL,
    [PantoneL] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TPartido] PRIMARY KEY ([IdPartido])
);

GO

CREATE TABLE [TtipoCasilla] (
    [IdTipoCasilla] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    [Siglas] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TtipoCasilla] PRIMARY KEY ([IdTipoCasilla])
);

GO

CREATE TABLE [TtipoEleccion] (
    [idTipoEleccion] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    [Siglas] nvarchar(3) NOT NULL,
    CONSTRAINT [PK_TtipoEleccion] PRIMARY KEY ([idTipoEleccion])
);

GO

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(128) NOT NULL,
    [ProviderKey] nvarchar(128) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserRoles] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserTokens] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(128) NOT NULL,
    [Name] nvarchar(128) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [TDemarcacion] (
    [idDemarcacion] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    [noDemarcacion] int NOT NULL,
    [noDemarcacionLast] int NOT NULL,
    [Municipio] int NOT NULL,
    CONSTRAINT [PK_TDemarcacion] PRIMARY KEY ([idDemarcacion]),
    CONSTRAINT [FK_TDemarcacion_TMunicipio_Municipio] FOREIGN KEY ([Municipio]) REFERENCES [TMunicipio] ([IdMunicipio]) ON DELETE CASCADE
);

GO

CREATE TABLE [TtipoActa] (
    [IdActa] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    [TipoEleccion] int NOT NULL,
    CONSTRAINT [PK_TtipoActa] PRIMARY KEY ([IdActa]),
    CONSTRAINT [FK_TtipoActa_TtipoEleccion_TipoEleccion] FOREIGN KEY ([TipoEleccion]) REFERENCES [TtipoEleccion] ([idTipoEleccion]) ON DELETE CASCADE
);

GO

CREATE TABLE [TSeccion] (
    [idSeccion] int NOT NULL IDENTITY,
    [Distrito] int NOT NULL,
    [seccion] nvarchar(max) NOT NULL,
    [Demarcacion] int NOT NULL,
    [Municipio] int NOT NULL,
    [CabLocalidad] nvarchar(max) NOT NULL,
    [ListadoNominal] int NOT NULL,
    [Activo] bit NOT NULL,
    [PElectoral] int NOT NULL,
    CONSTRAINT [PK_TSeccion] PRIMARY KEY ([idSeccion]),
    CONSTRAINT [FK_TSeccion_TDemarcacion_Demarcacion] FOREIGN KEY ([Demarcacion]) REFERENCES [TDemarcacion] ([idDemarcacion]) ON DELETE CASCADE,
    CONSTRAINT [FK_TSeccion_TDistrito_Distrito] FOREIGN KEY ([Distrito]) REFERENCES [TDistrito] ([IdDistrito]) ON DELETE CASCADE,
    CONSTRAINT [FK_TSeccion_TMunicipio_Municipio] FOREIGN KEY ([Municipio]) REFERENCES [TMunicipio] ([IdMunicipio])
);

GO

CREATE TABLE [TCasillaDet] (
    [IdCasillaDet] int NOT NULL IDENTITY,
    [Seccion] int NOT NULL,
    [TipoCasilla] int NOT NULL,
    [NoCasilla] int NOT NULL,
    [ExtContigua] int NOT NULL,
    [ListadoNominal] int NOT NULL,
    [Activo] bit NOT NULL,
    CONSTRAINT [PK_TCasillaDet] PRIMARY KEY ([IdCasillaDet]),
    CONSTRAINT [FK_TCasillaDet_TSeccion_Seccion] FOREIGN KEY ([Seccion]) REFERENCES [TSeccion] ([idSeccion]) ON DELETE CASCADE,
    CONSTRAINT [FK_TCasillaDet_TtipoCasilla_TipoCasilla] FOREIGN KEY ([TipoCasilla]) REFERENCES [TtipoCasilla] ([IdTipoCasilla]) ON DELETE CASCADE
);

GO

CREATE TABLE [TCoaliciondet] (
    [IdCoalicionDet] int NOT NULL IDENTITY,
    [Partido] int NOT NULL,
    [Coalicion] int NOT NULL,
    [Activo] bit NOT NULL,
    CONSTRAINT [PK_TCoaliciondet] PRIMARY KEY ([IdCoalicionDet]),
    CONSTRAINT [FK_TCoaliciondet_TSeccion_Coalicion] FOREIGN KEY ([Coalicion]) REFERENCES [TSeccion] ([idSeccion]),
    CONSTRAINT [FK_TCoaliciondet_TSeccion_Partido] FOREIGN KEY ([Partido]) REFERENCES [TSeccion] ([idSeccion])
);

GO

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);

GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;

GO

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);

GO

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);

GO

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);

GO

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);

GO

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;

GO

CREATE INDEX [IX_TCasillaDet_Seccion] ON [TCasillaDet] ([Seccion]);

GO

CREATE INDEX [IX_TCasillaDet_TipoCasilla] ON [TCasillaDet] ([TipoCasilla]);

GO

CREATE INDEX [IX_TCoaliciondet_Coalicion] ON [TCoaliciondet] ([Coalicion]);

GO

CREATE INDEX [IX_TCoaliciondet_Partido] ON [TCoaliciondet] ([Partido]);

GO

CREATE INDEX [IX_TDemarcacion_Municipio] ON [TDemarcacion] ([Municipio]);

GO

CREATE INDEX [IX_TSeccion_Demarcacion] ON [TSeccion] ([Demarcacion]);

GO

CREATE INDEX [IX_TSeccion_Distrito] ON [TSeccion] ([Distrito]);

GO

CREATE INDEX [IX_TSeccion_Municipio] ON [TSeccion] ([Municipio]);

GO

CREATE INDEX [IX_TtipoActa_TipoEleccion] ON [TtipoActa] ([TipoEleccion]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200310163602_MigracionCompleta', N'3.1.2');

GO

ALTER TABLE [TCoaliciondet] DROP CONSTRAINT [FK_TCoaliciondet_TSeccion_Coalicion];

GO

ALTER TABLE [TCoaliciondet] DROP CONSTRAINT [FK_TCoaliciondet_TSeccion_Partido];

GO

CREATE TABLE [TCandidato] (
    [IdCandidato] int NOT NULL IDENTITY,
    [Nombres] nvarchar(max) NOT NULL,
    [ApellidoPat] nvarchar(max) NOT NULL,
    [ApellidoMat] nvarchar(max) NOT NULL,
    [Mote] nvarchar(max) NULL,
    [TipoEleccion] int NOT NULL,
    [Municipio] int NOT NULL,
    [Distrito] int NOT NULL,
    [Demarcacion] int NOT NULL,
    [Estado] int NOT NULL,
    [Coalicion] int NULL,
    [Partido] int NOT NULL,
    [Orden] int NOT NULL,
    [EsCoalicion] bit NOT NULL,
    [Activo] bit NOT NULL,
    CONSTRAINT [PK_TCandidato] PRIMARY KEY ([IdCandidato]),
    CONSTRAINT [FK_TCandidato_TCoalicion_Coalicion] FOREIGN KEY ([Coalicion]) REFERENCES [TCoalicion] ([IdCoalicion]) ON DELETE NO ACTION,
    CONSTRAINT [FK_TCandidato_TDemarcacion_Demarcacion] FOREIGN KEY ([Demarcacion]) REFERENCES [TDemarcacion] ([idDemarcacion]),
    CONSTRAINT [FK_TCandidato_TDistrito_Distrito] FOREIGN KEY ([Distrito]) REFERENCES [TDistrito] ([IdDistrito]),
    CONSTRAINT [FK_TCandidato_TMunicipio_Municipio] FOREIGN KEY ([Municipio]) REFERENCES [TMunicipio] ([IdMunicipio]),
    CONSTRAINT [FK_TCandidato_TPartido_Partido] FOREIGN KEY ([Partido]) REFERENCES [TPartido] ([IdPartido]),
    CONSTRAINT [FK_TCandidato_TtipoEleccion_TipoEleccion] FOREIGN KEY ([TipoEleccion]) REFERENCES [TtipoEleccion] ([idTipoEleccion])
);

GO

CREATE INDEX [IX_TCandidato_Coalicion] ON [TCandidato] ([Coalicion]);

GO

CREATE INDEX [IX_TCandidato_Demarcacion] ON [TCandidato] ([Demarcacion]);

GO

CREATE INDEX [IX_TCandidato_Distrito] ON [TCandidato] ([Distrito]);

GO

CREATE INDEX [IX_TCandidato_Municipio] ON [TCandidato] ([Municipio]);

GO

CREATE INDEX [IX_TCandidato_Partido] ON [TCandidato] ([Partido]);

GO

CREATE INDEX [IX_TCandidato_TipoEleccion] ON [TCandidato] ([TipoEleccion]);

GO

ALTER TABLE [TCoaliciondet] ADD CONSTRAINT [FK_TCoaliciondet_TCoalicion_Coalicion] FOREIGN KEY ([Coalicion]) REFERENCES [TCoalicion] ([IdCoalicion]) ON DELETE CASCADE;

GO

ALTER TABLE [TCoaliciondet] ADD CONSTRAINT [FK_TCoaliciondet_TPartido_Partido] FOREIGN KEY ([Partido]) REFERENCES [TPartido] ([IdPartido]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200312213808_MigracionCandidatos', N'3.1.2');

GO

CREATE TABLE [TRecepcionPaquetes] (
    [IdRecepcion] int NOT NULL IDENTITY,
    CONSTRAINT [PK_TRecepcionPaquetes] PRIMARY KEY ([IdRecepcion])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200319200845_RPaquetes', N'3.1.2');

GO

ALTER TABLE [TRecepcionPaquetes] ADD [Cargo] nvarchar(max) NULL;

GO

ALTER TABLE [TRecepcionPaquetes] ADD [Entrega] nvarchar(max) NULL;

GO

ALTER TABLE [TRecepcionPaquetes] ADD [Fecha] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [TRecepcionPaquetes] ADD [FechaReg] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [TRecepcionPaquetes] ADD [Hora] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [TRecepcionPaquetes] ADD [HoraReg] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [TRecepcionPaquetes] ADD [IdCasillaDet] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [TRecepcionPaquetes] ADD [Observaciones] nvarchar(max) NULL;

GO

ALTER TABLE [TRecepcionPaquetes] ADD [PaqueteElec] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [TRecepcionPaquetes] ADD [SobrePrep] int NOT NULL DEFAULT 0;

GO

CREATE TABLE [TActas] (
    [IdActa] int NOT NULL IDENTITY,
    [Sobrantes] int NOT NULL,
    [VotosCiu] int NOT NULL,
    [VotosRep] int NOT NULL,
    [TotalVotos] int NOT NULL,
    [VotosUrnas] int NOT NULL,
    [Incidentes] int NOT NULL,
    [DesIncidentes] nvarchar(max) NULL,
    [IdRecepcion] int NOT NULL,
    CONSTRAINT [PK_TActas] PRIMARY KEY ([IdActa]),
    CONSTRAINT [FK_TActas_TRecepcionPaquetes_IdRecepcion] FOREIGN KEY ([IdRecepcion]) REFERENCES [TRecepcionPaquetes] ([IdRecepcion]) ON DELETE CASCADE
);

GO

CREATE TABLE [TResultadosActas] (
    [IdResultadoActa] int NOT NULL IDENTITY,
    [IdPartido] int NOT NULL,
    [IdCoalicion] int NOT NULL,
    [IdCombinacion] int NOT NULL,
    [Nulos] int NOT NULL,
    [Total] int NOT NULL,
    [VotosRegistrados] int NOT NULL,
    [IdActa] int NOT NULL,
    CONSTRAINT [PK_TResultadosActas] PRIMARY KEY ([IdResultadoActa]),
    CONSTRAINT [FK_TResultadosActas_TActas_IdActa] FOREIGN KEY ([IdActa]) REFERENCES [TActas] ([IdActa]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_TRecepcionPaquetes_IdCasillaDet] ON [TRecepcionPaquetes] ([IdCasillaDet]);

GO

CREATE INDEX [IX_TActas_IdRecepcion] ON [TActas] ([IdRecepcion]);

GO

CREATE INDEX [IX_TResultadosActas_IdActa] ON [TResultadosActas] ([IdActa]);

GO

ALTER TABLE [TRecepcionPaquetes] ADD CONSTRAINT [FK_TRecepcionPaquetes_TCasillaDet_IdCasillaDet] FOREIGN KEY ([IdCasillaDet]) REFERENCES [TCasillaDet] ([IdCasillaDet]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200319212156_RActas', N'3.1.2');

GO

