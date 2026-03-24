CREATE DATABASE ProductDB;
USE ProductDB;

CREATE TABLE Products (
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10,2)
);
GO

---insert stored procedures

CREATE PROCEDURE sp_InsertProduct
    @ProductName VARCHAR(100),
    @Category VARCHAR(50),
    @Price DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Products(ProductName, Category, Price)
    VALUES(@ProductName, @Category, @Price)
END
GO

--VIEW Stored Procedure
CREATE PROCEDURE sp_GetAllProducts
AS
BEGIN
    SELECT * FROM Products
END
GO

---UPDATE Stored Procedure

CREATE PROCEDURE sp_UpdateProduct
    @ProductId INT,
    @ProductName VARCHAR(100),
    @Category VARCHAR(50),
    @Price DECIMAL(10,2)
AS
BEGIN
    UPDATE Products
    SET ProductName = @ProductName,
        Category = @Category,
        Price = @Price
    WHERE ProductId = @ProductId
END
GO


---DELETE Stored Procedure
CREATE PROCEDURE sp_DeleteProduct
    @ProductId INT
AS
BEGIN
    DELETE FROM Products
    WHERE ProductId = @ProductId
END
GO

CREATE PROCEDURE GetProductById
    @ProductId INT
AS
BEGIN
    SELECT * FROM Products
    WHERE ProductId = @ProductId;
END
GO

EXEC GetProductById @ProductId = 1;

EXEC sp_InsertProduct 'Pen', 'Stationery', 10.50;
SELECT * FROM Products;

