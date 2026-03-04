CREATE DATABASE StoreWiseSalesSummaryDB;

USE StoreWiseSalesSummaryDB;

CREATE TABLE Stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100)
);

CREATE TABLE Orders (
    order_id INT PRIMARY KEY,
    store_id INT,
    order_status INT,
    FOREIGN KEY (store_id) REFERENCES Stores(store_id)
);

CREATE TABLE Order_Items (
    item_id INT PRIMARY KEY,
    order_id INT,
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(4,2),
    FOREIGN KEY (order_id) REFERENCES Orders(order_id)
);

-- Insert Data into Stores
INSERT INTO Stores VALUES(1, 'Hyderabad Store'),(2, 'Bangalore Store'),(3, 'Chennai Store');

-- Insert Data into Orders
INSERT INTO Orders VALUES(101, 1, 4),(102, 2, 4),(103, 1, 2), (104, 3, 4);

-- Insert Data into Order_Items
INSERT INTO Order_Items VALUES(1, 101, 2, 1000, 0.10),(2, 101, 1, 500, 0.05),(3, 102, 3, 800, 0.00),(4, 103, 1, 1200, 0.15),(5, 104, 4, 600, 0.10);

SELECT 
    s.store_name,
    SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_sales
FROM Stores s
INNER JOIN Orders o
    ON s.store_id = o.store_id
INNER JOIN Order_Items oi
    ON o.order_id = oi.order_id
WHERE o.order_status = 4
GROUP BY s.store_name
ORDER BY total_sales DESC;
