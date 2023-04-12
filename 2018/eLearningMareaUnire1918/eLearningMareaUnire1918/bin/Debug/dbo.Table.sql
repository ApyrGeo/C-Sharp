CREATE TABLE [dbo].[Tabela Utilizatori] (
    [IdUtilizator]          INT  IDENTITY (1, 1) NOT NULL,
    [NumePrenumeUtilizator] NVARCHAR(MAX) NULL,
    [ParolaUtilizator]      NVARCHAR(MAX) NULL,
    [EmailUtilizator]       NVARCHAR(MAX) NULL,
    [ClasaUtilizator]       VARCHAR(MAX) NULL,
    PRIMARY KEY CLUSTERED ([IdUtilizator] ASC)
);

