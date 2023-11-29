Create database Unimax
Go

Use Unimax
Go


CREATE TABLE ToDoTasks (
    ToDoTaskId INT IDENTITY(1,1) PRIMARY KEY,
    Title VARCHAR(50) NOT NULL,
    Description VARCHAR(255),
    TargetDate DATE,
    PriorityId INT NOT NULL,
	CreatedDate DATE NOT NULL,
	CompletedDate DATE
);

INSERT INTO ToDoTasks
VALUES ('First Task', 'Open App', '2023-12-10', 1, GETDATE(), null);

INSERT INTO ToDoTasks
VALUES ('Second Task', 'Validate this app', '2023-12-10', 2, GETDATE(), null);