CREATE DATABASE OrdeDB;
USE OrdeDB;

CREATE TABLE Orders
(
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_date DATE,
    shipped_date DATE,
    order_status INT
);

INSERT INTO Orders VALUES(1,101,'2024-01-10',NULL,1),(2,102,'2024-02-15','2024-02-18',3),(3,103,'2024-03-20',NULL,2);
GO

---Create AFTER UPDATE Trigger on Orders
CREATE TRIGGER trg_OrderStatusValidation
ON Orders
AFTER UPDATE
AS
BEGIN
    BEGIN TRY

        IF EXISTS
        (
            SELECT *
            FROM inserted
            WHERE order_status = 4
            AND shipped_date IS NULL
        )
        BEGIN
            RAISERROR('Cannot set order to Completed without shipped date.',16,1);
            ROLLBACK TRANSACTION;
        END

    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION;
        PRINT 'Error while updating order.';
    END CATCH
END;

--validate check---
UPDATE Orders
SET shipped_date = '2024-04-10',
    order_status = 4
WHERE order_id = 1;

SELECT * FROM Orders;

---invalid check---
UPDATE Orders
SET shipped_date = NULL,
    order_status = 1
WHERE order_id = 1;



