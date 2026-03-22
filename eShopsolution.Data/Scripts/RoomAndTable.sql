CREATE TABLE RoomAndTable (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Area NVARCHAR(255),
    Quantity INT NOT NULL,
    StatusId INT,  
    Note NVARCHAR(500),
    OrdinalNumber INT NOT NULL,
    CONSTRAINT FK_RoomAndTable_Status FOREIGN KEY (StatusId) REFERENCES Status(StatusId)
);

INSERT INTO RoomAndTable (Name, Area, Quantity, StatusId, Note, OrdinalNumber)
VALUES 
('Room A', 'East', 10, 1, 'VIP room', 1),         
('Room B', 'West', 8, 1, 'Standard room', 2),     
('Room C', 'North', 12, 2, 'Meeting room', 3),     
('Room D', 'South', 15, 2, 'Conference room', 4), 
('Room E', 'Center', 5, 1, 'Small room', 5);       
