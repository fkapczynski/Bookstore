CREATE TABLE [dbo].[Books]
(
	[BookId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [QunatityInStore] INT NOT NULL,
	[PublisherId] INT NOT NULL,
	[AuthorID] INT NOT NULL,
	[CategoryID] INT NULL,
	[SeriesID] INT NULL, 
    [Title] NVARCHAR(MAX) NOT NULL, 
    [Price] FLOAT NOT NULL,
)
