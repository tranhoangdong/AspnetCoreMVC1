CREATE TABLE Status (
    StatusId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);


INSERT INTO Status (Name)
VALUES 
('Đang hoạt động'),
('Ngừng hoạt động');