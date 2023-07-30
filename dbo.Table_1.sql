CREATE TABLE [Chats]
(
	[ChatID] INT NOT NULL PRIMARY KEY, 
    [Username] VARCHAR(50) NOT NULL,
    [ChatHistory] VARCHAR(MAX) NULL, 
    CONSTRAINT [FK_Chats_ToTable] FOREIGN KEY ([Username]) REFERENCES [usertable]([Username])
)
