IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Category' AND xtype='U')
BEGIN
    CREATE TABLE Category
    (
        ID INT IDENTITY(1,1) PRIMARY KEY,
        [Name] VARCHAR(255) NOT NULL
    )
END;

INSERT INTO Category ([Name])
VALUES 
('Electronics'),
('Clothing'),
('Books'),
('Home & Kitchen'),
('Toys & Games'),
('Sports & Outdoors'),
('Health & Personal Care'),
('Automotive'),
('Beauty'),
('Garden & Outdoor');

IF NOT EXISTS (SELECT * FROM syscolumns WHERE id=object_id('Product') AND name='CategoryId')
BEGIN
    ALTER TABLE Product
    ADD CategoryId INT;

    ALTER TABLE Product
    ADD CONSTRAINT FK_Product_Category
    FOREIGN KEY (CategoryId) REFERENCES Category(ID)
    ON DELETE SET NULL;  -- Khi xóa một category, giá trị CategoryId trong Product sẽ thành NULL
END;

UPDATE Product
SET CategoryId = (
    SELECT TOP 1 ID
    FROM Category
    ORDER BY NEWID()
);

