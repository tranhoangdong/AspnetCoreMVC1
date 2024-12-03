CREATE TABLE Wishlists (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId NVARCHAR(50) NOT NULL,    
    ProductId INT NOT NULL,        
    CreatedAt DATETIME DEFAULT GETDATE(), 
    CONSTRAINT FK_Wishlists_Products FOREIGN KEY (ProductId) REFERENCES Product(Id)
);
