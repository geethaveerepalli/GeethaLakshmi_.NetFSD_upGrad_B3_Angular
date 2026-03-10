CREATE DATABASE SalesDB;

USE SalesDB;

CREATE TABLE Stores
(
    store_id INT PRIMARY KEY,
    store_name VARCHAR(50),
    city VARCHAR(50)
);

CREATE TABLE Products
(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    list_price DECIMAL(10,2)
);

CREATE TABLE Orders
(
    order_id INT PRIMARY KEY,
    store_id INT,
    customer_id INT,
    order_date DATE,
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

    FOREIGN KEY (order_id) REFERENCES Orders(order_id),
    FOREIGN KEY (product_id) REFERENCES Products(product_id)
);

--inserting data----
INSERT INTO Stores VALUES(1,'City Store','Hyderabad'),(2,'Central Store','Delhi'),(3,'Metro Store','Mumbai');
INSERT INTO Products VALUES(101,'Laptop',60000),(102,'Mobile',20000),(103,'Headphones',2000),(104,'Keyboard',1500),(105,'Mouse',800);
INSERT INTO Orders VALUES(1,1,201,'2023-01-10',4),(2,1,202,'2023-02-15',4),(3,2,203,'2023-03-20',4),(4,3,204,'2023-04-18',4);
INSERT INTO Order_Items VALUES(1,1,101,1,60000,0.10),(2,1,103,2,2000,0.05),(3,2,102,1,20000,0.15),(4,3,105,3,800,0.00),(5,4,104,2,1500,0.05);
GO

--- Create a stored procedure to generate total sales amount per store.

CREATE PROCEDURE sp_TotalSalesPerStore
    @StoreID INT
AS
BEGIN
    SELECT 
        s.store_name,
        SUM(oi.quantity * oi.list_price * (1 - ISNULL(oi.discount,0))) AS TotalSales
    FROM Stores s
    JOIN Orders o ON s.store_id = o.store_id
    JOIN Order_Items oi ON o.order_id = oi.order_id
    WHERE s.store_id = @StoreID
    GROUP BY s.store_name;
END;
GO

--Create a stored procedure to retrieve orders by date range.
CREATE PROCEDURE sp_GetOrdersByDateRange
@StartDate DATE,
@EndDate DATE
AS
BEGIN
SELECT order_id, customer_id, order_date
FROM Orders
WHERE order_date BETWEEN @StartDate AND @EndDate;
END;

EXEC sp_GetOrdersByDateRange '2023-01-01','2023-12-31';
GO

--- Create a scalar function to calculate total price after discount.
CREATE FUNCTION fn_TotalPriceAfterDiscount
(
@Price DECIMAL(10,2),
@Qty INT,
@Discount DECIMAL(4,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
RETURN(@Price * @Qty) * (1 - ISNULL(@Discount, 0));
END;
GO

SELECT dbo.fn_TotalPriceAfterDiscount(2000,2,0.10) AS FinalPrice;
GO

--- Create a table-valued function to return top 5 selling products.
CREATE FUNCTION fn_Top5SellingProducts()
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 5
        p.product_name,
        SUM(oi.quantity) AS TotalSold
    FROM Products p
    JOIN Order_Items oi
        ON p.product_id = oi.product_id
    GROUP BY p.product_name
    ORDER BY TotalSold DESC
);
GO

SELECT * FROM dbo.fn_Top5SellingProducts();