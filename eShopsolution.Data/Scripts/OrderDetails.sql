CREATE TABLE OrderDetails (
    Id INT PRIMARY KEY IDENTITY(1,1), 
    OrderId INT NOT NULL,                      
    ProductId INT NOT NULL,                    
    Quantity INT NOT NULL,                     
    Price DECIMAL(18, 2) NOT NULL,             
    Total DECIMAL(18, 2) NOT NULL,              
    FOREIGN KEY (OrderId) REFERENCES Orders(Id),  
    FOREIGN KEY (ProductId) REFERENCES Product(Id)
);
