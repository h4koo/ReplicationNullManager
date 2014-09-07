CREATE TABLE [dbo].[Replica] (
    [idReplica]           INT        IDENTITY (1, 1) NOT NULL,
    [SourceEngine]        INT        NOT NULL,
    [SourceIPAddress]     NCHAR (16) NOT NULL,
    [SourcePort]          INT        NOT NULL,
    [SourceUser]          NCHAR (20) NOT NULL,
    [SourcePassword]      NCHAR (20) NOT NULL,
    [SourceDatabase]      NCHAR (20) NOT NULL,
    [SourceTable]         NCHAR (20) NOT NULL,
    [TerminalEngine]      INT        NOT NULL,
    [TerminalIPAddress]   NCHAR (16) NOT NULL,
    [TerminalPort]        INT        NOT NULL,
    [TerminalUser]        NCHAR (20) NOT NULL,
    [TerminalPassword]    NCHAR (20) NOT NULL,
    [TerminalDatabase]    NCHAR (20) NOT NULL,
    [Enable]              BIT        CONSTRAINT [DF_Replica_Enable] DEFAULT ((1)) NOT NULL,
    [Created]             DATETIME   CONSTRAINT [DF_Replica_Created] DEFAULT (getdate()) NOT NULL,
    [LastCheckOnSource]   DATETIME   NULL,
    [LastCheckOnTerminal] DATETIME   NULL,
    CONSTRAINT [PK_Replica] PRIMARY KEY CLUSTERED ([idReplica] ASC),
    CONSTRAINT [FK_Replica_SoruceEngine] FOREIGN KEY ([SourceEngine]) REFERENCES [dbo].[Engine] ([idEngine]),
    CONSTRAINT [FK_Replica_TerminalEngine] FOREIGN KEY ([TerminalEngine]) REFERENCES [dbo].[Engine] ([idEngine])
);

