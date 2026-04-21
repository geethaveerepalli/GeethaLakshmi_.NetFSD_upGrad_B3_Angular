USE  BankAppDb;

CREATE TABLE Products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    stock_quantity INT NOT NULL
);

CREATE TABLE Orders (
    order_id INT PRIMARY KEY,
    order_date DATE,
    customer_id INT
);

CREATE TABLE Order_Items (
    order_item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    price DECIMAL(10,2),

    FOREIGN KEY(order_id) REFERENCES Orders(order_id),
    FOREIGN KEY(product_id) REFERENCES Products(product_id)
);

INSERT INTO Products VALUES(1,'Laptop',10),(2,'Mouse',50),(3,'Keyboard',30);
GO

--- Check stock availability before confirming order.
--Create a trigger to reduce stock quantity after order insertion.*/

CREATE TRIGGER trg_UpdateStock
ON Order_Items
AFTER INSERT
AS
BEGIN

    -- Check stock availability
    IF EXISTS (
        SELECT 1
        FROM Products p
        JOIN inserted i
        ON p.product_id = i.product_id
        WHERE p.stock_quantity < i.quantity
    )
    BEGIN
        PRINT 'Stock not sufficient';
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Update stock
    UPDATE p
    SET p.stock_quantity = p.stock_quantity - i.quantity
    FROM Products p
    JOIN inserted i
    ON p.product_id = i.product_id;

END;

----- Rollback transaction if stock quantity is insufficient.

BEGIN TRY

BEGIN TRANSACTION

-- Insert Order
INSERT INTO Orders VALUES
(101, GETDATE(), 1);

-- Insert Order Items
INSERT INTO Order_Items VALUES
(1,101,1,2,60000),
(2,101,2,5,500);

COMMIT TRANSACTION

PRINT 'Order placed successfully';

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION

PRINT 'Transaction Failed. Order Cancelled';

END CATCH;



SELECT * FROM Products;

