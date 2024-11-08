CREATE PROCEDURE AddCategory
    @Name NVARCHAR(255)
AS
BEGIN
    INSERT INTO Categories (Name)
    VALUES (@Name);
END;

EXEC AddCategory @Name = 'Electronics';