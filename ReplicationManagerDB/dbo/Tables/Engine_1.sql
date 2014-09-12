CREATE TABLE [dbo].[Engine] (
    [idEngine] INT        IDENTITY (1, 1) NOT NULL,
    [Name]     NCHAR (20) NOT NULL,
    CONSTRAINT [PK_Engine] PRIMARY KEY CLUSTERED ([idEngine] ASC)
);

