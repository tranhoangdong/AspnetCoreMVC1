CREATE TABLE OrderDetail (
    Id INT PRIMARY KEY IDENTITY(1,1),  
    Name NVARCHAR(255) NOT NULL,       
    Quantity INT NOT NULL,            
    Price FLOAT NOT NULL,              
    Tongtien FLOAT NOT NULL           
);