CREATE DATABASE StoreDB;

USE StoreDB;

CREATE TABLE Customers (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50)
);

CREATE TABLE Orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_date DATE,
    order_status INT,
    FOREIGN KEY (customer_id) REFERENCES Customers(customer_id)
);

INSERT INTO Customers VALUES(1, 'Geetha', 'Lakshmi'),(2, 'Chandhu', 'Reddy'),(3, 'Ayesha', 'Shaik'),(4, 'Meena', 'Iyer');
INSERT INTO Orders VALUES (101, 1, '2026-03-01', 1),(102, 2, '2026-03-02', 4),(103, 3, '2026-02-28', 2),(104, 1, '2026-03-03', 4),(105, 4, '2026-02-27', 1);

SELECT * FROM Customers;
SELECT * FROM Orders;

SELECT 
    c.first_name,
    c.last_name,
    o.order_id,
    o.order_date,
    o.order_status
FROM Customers c
INNER JOIN Orders o
    ON c.customer_id = o.customer_id;

SELECT 
    c.first_name,
    c.last_name,
    o.order_id,
    o.order_date,
    o.order_status
FROM Customers c
INNER JOIN Orders o
    ON c.customer_id = o.customer_id
WHERE o.order_status = 1 
   OR o.order_status = 4;


   SELECT 
    c.first_name,
    c.last_name,
    o.order_id,
    o.order_date,
    o.order_status
FROM Customers c
INNER JOIN Orders o
    ON c.customer_id = o.customer_id
ORDER BY o.order_date DESC;