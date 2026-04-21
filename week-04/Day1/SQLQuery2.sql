CREATE DATABASE InventoryDB;

USE InventoryDB;

CREATE TABLE Products
(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100)
);

CREATE TABLE Stocks
(
    product_id INT PRIMARY KEY,
    quantity INT,
    FOREIGN KEY (product_id) REFERENCES Products(product_id)
);

CREATE TABLE Order_Items
(
    order_item_id INT PRIMARY KEY,
    product_id INT,
    quantity INT,
    FOREIGN KEY (product_id) REFERENCES Products(product_id)
);

--insertting data---
INSERT INTO Products VALUES(101,'Laptop'),(102,'Mobile'),(103,'Headphones');
INSERT INTO Stocks VALUES(101,10),(102,20),(103,15);
GO

----Create an AFTER INSERT trigger on order_items.

CREATE TRIGGER trg_UpdateStock
ON Order_Items
AFTER INSERT
AS
BEGIN
    BEGIN TRY

        -- Check if stock is insufficient
        IF EXISTS
        (
            SELECT *
            FROM inserted i
            JOIN Stocks s
            ON i.product_id = s.product_id
            WHERE s.quantity < i.quantity
        )
        BEGIN
            RAISERROR('Stock is insufficient for this product.',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Reduce stock quantity
        UPDATE s
        SET s.quantity = s.quantity - i.quantity
        FROM Stocks s
        JOIN inserted i
        ON s.product_id = i.product_id;

    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION;
        PRINT 'Error occurred while updating stock.';
    END CATCH
END;

---Valid order----
INSERT INTO Order_Items VALUES(1,101,2);

SELECT * FROM Stocks;

----invalid order-----
INSERT INTO Order_Items VALUES(2,101,20);
SELECT * FROM Stocks;

