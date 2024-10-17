CREATE TABLE Orders (
    Id INT PRIMARY KEY IDENTITY(1,1), 
    RoomAndTableId INT NOT NULL,          
    OrderTime DATETIME NOT NULL,           
    TotalAmount DECIMAL(18, 2) NOT NULL,   
    Status NVARCHAR(50) NOT NULL,          
    Note NVARCHAR(250),                    
    FOREIGN KEY (RoomAndTableId) REFERENCES RoomAndTable(Id) 
);