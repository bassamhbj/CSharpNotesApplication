# CSharpNotesApplication

This is a Notes application written in C#. 
Basically you can create a short memo and classify them by title.

Before use it, need to create a data base file in the same directory than executable.

DATA BASE QUERY:
CREATE TABLE [dbo].[MemoTable] (
    [date]  DATETIME       NOT NULL,
    [title] NVARCHAR (50)  NULL,
    [body]  NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([date] ASC)
);
