# TaskAPI

Queries:

-- Create the User table
CREATE TABLE [User] (
    Id INT IDENTITY(1,1) PRIMARY KEY,   -- Auto-incrementing primary key
    Username NVARCHAR(100) NOT NULL,   -- Username of the user
    Email NVARCHAR(255) NOT NULL UNIQUE, -- Unique email address
    Password NVARCHAR(255) NOT NULL,   -- Password (hashed)
    CreatedAt DATETIME DEFAULT GETDATE() -- Timestamp for when the user was created
);

-- Create the Task table
CREATE TABLE Task (
    Id INT IDENTITY(1,1) PRIMARY KEY,  -- Auto-incrementing primary key
    Title NVARCHAR(200) NOT NULL,      -- Task title
    Description NVARCHAR(MAX) NULL,   -- Optional task description
    DueDate DATETIME NOT NULL,         -- Due date for the task
    UserId INT NOT NULL,               -- Foreign key to the User table
    CreatedAt DATETIME DEFAULT GETDATE(), -- Timestamp for when the task was created
    CONSTRAINT FK_Task_User FOREIGN KEY (UserId) REFERENCES [User](Id) ON DELETE CASCADE
);

-----

Realizar migracion con entity framework

----

No pude completar todo el proyecto por temas de tiempos pero igual lo envio