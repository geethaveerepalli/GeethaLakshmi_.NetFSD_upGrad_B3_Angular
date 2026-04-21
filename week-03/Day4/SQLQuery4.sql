CREATE DATABASE OrderMaintenance;

USE OrderMaintenance;

CREATE TABLE customers (
    customer_id INT PRIMARY KEY,
    customer_name VARCHAR(100)
);

CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_status INT,
    order_date DATE,
    required_date DATE,
    shipped_date DATE,
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
);

CREATE TABLE archived_orders (
    order_id INT,
    customer_id INT,
    order_status INT,
    order_date DATE,
    required_date DATE,
    shipped_date DATE
);

--Inserting data
INSERT INTO customers VALUES(1,'John Smith'),(2,'Alice Brown'),(3,'David Miller');
INSERT INTO orders VALUES(101,1,4,'2023-01-10','2023-01-15','2023-01-14'),(102,1,3,'2022-02-10','2022-02-15','2022-02-20'),(103,2,4,'2023-03-12','2023-03-18','2023-03-17'),(104,3,2,'2023-04-05','2023-04-10','2023-04-12');
INSERT INTO archived_orders VALUES(201,1,3,'2022-01-10','2022-01-15','2022-01-18'),(202,2,3,'2021-05-12','2021-05-18','2021-05-20');

---1. Insert archived records into a new table (archived_orders) using INSERT INTO SELECT.
INSERT INTO archived_orders
SELECT * FROM orders
WHERE order_status = 3;

--2. Delete orders where order_status = 3 (Rejected) and older than 1 year.
DELETE FROM orders
WHERE order_status = 3
AND order_date < DATEADD(YEAR, -1, GETDATE());

--3. Use nested query to identify customers whose all orders are completed.
SELECT customer_id, customer_name
FROM customers 
WHERE customer_id NOT IN(
SELECT customer_id
FROM orders
WHERE order_status<>4
);

--4. Display order processing delay (DATEDIFF between shipped_date and order_date).
SELECT order_id,order_date,shipped_date,
DATEDIFF(DAY, order_date, shipped_date) AS processing_delay
FROM orders;

--5. Mark orders as 'Delayed' or 'On Time' using CASE expression based on required_date.
SELECT order_id, required_date, shipped_date,
CASE
WHEN shipped_date > required_date THEN 'Delayed'
ELSE 'On Time'
END AS order_status_result
FROM orders;