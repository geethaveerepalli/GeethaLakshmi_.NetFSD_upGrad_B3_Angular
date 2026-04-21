-- Create a new database named BookMartDB
CREATE DATABASE BookMartDB;
GO


USE BookMartDB;
GO

CREATE TABLE Books
(
    BookID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(150) NOT NULL,
    Stock INT NOT NULL CHECK (Stock >= 0),
    Price DECIMAL(10,2) NOT NULL
);
GO


CREATE TABLE Orders
(
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    BookID INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    OrderDate DATETIME2 DEFAULT SYSDATETIME(),
    FOREIGN KEY (BookID) REFERENCES Books(BookID)
);
GO


CREATE PROCEDURE sp_AddNewBook
    @Title NVARCHAR(150),   
    @Stock INT,             
    @Price DECIMAL(10,2)   
AS
BEGIN
    BEGIN TRY

        INSERT INTO Books (Title, Stock, Price)
        VALUES (@Title, @Stock, @Price);
        PRINT 'Book added successfully';

    END TRY

    BEGIN CATCH
        PRINT 'Error: ' + ERROR_MESSAGE();

    END CATCH
END;
GO

CREATE PROCEDURE sp_PlaceOrder
    @BookID INT,        
    @Quantity INT      
AS
BEGIN
    SET XACT_ABORT ON;

    BEGIN TRY

        BEGIN TRANSACTION;
        IF NOT EXISTS
        (
            SELECT 1
            FROM Books
            WHERE BookID = @BookID
            AND Stock >= @Quantity
        )
        BEGIN
          
            RAISERROR('Not enough stock or book not found.',16,1);
        END

       
        UPDATE Books
        SET Stock = Stock - @Quantity
        WHERE BookID = @BookID;

       
        INSERT INTO Orders(BookID, Quantity)
        VALUES(@BookID, @Quantity);

       
        COMMIT TRANSACTION;
        PRINT 'Order placed successfully.';

    END TRY

    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        PRINT 'Error: ' + ERROR_MESSAGE();

    END CATCH

END;
GO

EXEC sp_AddNewBook 'SQL Basics', 10, 500;
EXEC sp_AddNewBook 'C# Programming', 5, 650;
EXEC sp_AddNewBook 'Python for Beginners', 8, 450;
GO



SELECT * FROM Books;
GO


EXEC sp_PlaceOrder 1, 2;
GO


SELECT * FROM Books;
SELECT * FROM Orders;
GO



EXEC sp_PlaceOrder 2, 50;
GO



EXEC sp_PlaceOrder 100, 1;
GO