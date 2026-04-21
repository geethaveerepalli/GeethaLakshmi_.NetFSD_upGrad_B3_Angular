USE BankAppDb;
GO

ALTER TABLE Orders
ADD order_status INT;

UPDATE Orders
SET order_status = 2;

BEGIN TRY

    BEGIN TRANSACTION;

    -- Savepoint
    SAVE TRANSACTION RestoreStockPoint;

    -- Restore stock
    UPDATE p
    SET p.stock_quantity = p.stock_quantity + oi.quantity
    FROM Products p
    JOIN Order_Items oi
    ON p.product_id = oi.product_id
    WHERE oi.order_id = 101;

    -- Update order status
    UPDATE Orders
    SET order_status = 3
    WHERE order_id = 101;

    -- Commit if everything works
    COMMIT TRANSACTION;

    PRINT 'Order cancelled and stock restored successfully';

END TRY

BEGIN CATCH

    -- Rollback to savepoint if error occurs
    ROLLBACK TRANSACTION RestoreStockPoint;

    PRINT 'Error occurred while restoring stock';

END CATCH;

SELECT * FROM Products;
SELECT * FROM Orders;
SELECT * FROM Order_Items;