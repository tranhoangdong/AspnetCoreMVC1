
-- Kiểm tra và xóa rà   ng buộc mặc định trên cột IsDeleted nếu tồn tại
IF EXISTS (
    SELECT * 
    FROM sys.default_constraints 
    WHERE parent_object_id = OBJECT_ID('Product') 
    AND parent_column_id = COLUMNPROPERTY(OBJECT_ID('Product'), 'IsDeleted', 'ColumnId')
)
BEGIN
    DECLARE @constraintName NVARCHAR(128);
    SELECT @constraintName = name 
    FROM sys.default_constraints 
    WHERE parent_object_id = OBJECT_ID('Product') 
    AND parent_column_id = COLUMNPROPERTY(OBJECT_ID('Product'), 'IsDeleted', 'ColumnId');

    EXEC('ALTER TABLE Product DROP CONSTRAINT ' + @constraintName);
END

-- Kiểm tra và xóa cột IsDeleted nếu tồn tại
IF EXISTS (
    SELECT * 
    FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_NAME = 'Product' 
    AND COLUMN_NAME = 'IsDeleted'
)
BEGIN
    ALTER TABLE Product
    DROP COLUMN IsDeleted;
END

-- Thêm lại cột IsDeleted với giá trị mặc định là 0
ALTER TABLE Product
ADD IsDeleted BIT NOT NULL DEFAULT 0;
