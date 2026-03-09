CREATE DATABASE RevenueDB;
USE RevenueDB;

CREATE TABLE Stores
(
    store_id INT PRIMARY KEY,
    store_name VARCHAR(50)
);

CREATE TABLE Orders
(
    order_id INT PRIMARY KEY,
    store_id INT,
    order_status INT,
    FOREIGN KEY (store_id) REFERENCES Stores(store_id)
);

CREATE TABLE Order_Items
(
    order_item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(4,2),
    FOREIGN KEY (order_id) REFERENCES Orders(order_id)
);

INSERT INTO Stores VALUES(1,'City Store'),(2,'Central Store');
INSERT INTO Orders VALUES(1,1,4),(2,1,4),(3,2,4),(4,2,2);
INSERT INTO Order_Items VALUES(1,1,101,2,1000,0.10),(2,1,102,1,500,0.05),(3,2,103,3,700,0.10),(4,3,104,1,2000,0.20);

------ Display store-wise revenue summary.------
CREATE TABLE #RevenueTemp
(
 store_id INT,
 order_id INT,
 revenue DECIMAL(10,2)
);

DECLARE @OrderID INT, @StoreID INT, @Revenue DECIMAL(10,2)

DECLARE OrderCursor CURSOR FOR
SELECT order_id, store_id
FROM Orders
WHERE order_status = 4;

BEGIN TRY
BEGIN TRANSACTION

OPEN OrderCursor
FETCH NEXT FROM OrderCursor INTO @OrderID, @StoreID

WHILE @@FETCH_STATUS = 0
BEGIN
    SELECT @Revenue =
    SUM(quantity * list_price * (1 - discount))
    FROM Order_Items
    WHERE order_id = @OrderID

    INSERT INTO #RevenueTemp VALUES (@StoreID, @OrderID, @Revenue)

    FETCH NEXT FROM OrderCursor INTO @OrderID, @StoreID
END

COMMIT TRANSACTION
END TRY

BEGIN CATCH
ROLLBACK TRANSACTION
PRINT 'Error in revenue calculation'
END CATCH

CLOSE OrderCursor
DEALLOCATE OrderCursor

SELECT store_id, SUM(revenue) AS TotalRevenue
FROM #RevenueTemp
GROUP BY store_id;

