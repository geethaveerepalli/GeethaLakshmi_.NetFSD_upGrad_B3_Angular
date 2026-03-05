CREATE DATABASE CustomerActivity;

USE CustomerActivity;

CREATE TABLE Customers (
    customer_id INT PRIMARY KEY IDENTITY(1,1),
    first_name VARCHAR(50),
    last_name VARCHAR(50)
);

CREATE TABLE Orders (
    order_id INT PRIMARY KEY IDENTITY(1,1),
    customer_id INT,
    order_date DATE,
    FOREIGN KEY (customer_id) REFERENCES Customers(customer_id)
);

CREATE TABLE Order_Items (
    order_item_id INT PRIMARY KEY IDENTITY(1,1),
    order_id INT,
    quantity INT,
    list_price DECIMAL(10,2),
    FOREIGN KEY (order_id) REFERENCES Orders(order_id)
);

--inserting data----
INSERT INTO Customers(first_name,last_name) VALUES
('John','Smith'),
('Alice','Brown'),
('David','Miller'),
('Emma','Wilson');

INSERT INTO Orders(customer_id,order_date) VALUES
(1,'2023-01-10'),
(2,'2023-02-12'),
(1,'2023-03-05');

INSERT INTO Order_Items(order_id,quantity,list_price) VALUES
(1,2,3000),
(1,1,2000),
(2,3,2500),
(3,1,6000);

----1. Use nested query to calculate total order value per customer.
SELECT 
c.customer_id,
c.first_name,
c.last_name,
(
    SELECT SUM(oi.quantity * oi.list_price)
    FROM Orders o
    JOIN Order_Items oi 
    ON o.order_id = oi.order_id
    WHERE o.customer_id = c.customer_id
) AS total_order_value
FROM Customers c;

---2. Classify customers using conditional logic:
SELECT 
c.first_name + ' ' + c.last_name AS Full_Name,
(
    SELECT SUM(oi.quantity * oi.list_price)
    FROM Orders o
    JOIN Order_Items oi 
    ON o.order_id = oi.order_id
    WHERE o.customer_id = c.customer_id
) AS total_order_value,

CASE
    WHEN (
        SELECT SUM(oi.quantity * oi.list_price)
        FROM Orders o
        JOIN Order_Items oi 
        ON o.order_id = oi.order_id
        WHERE o.customer_id = c.customer_id
    ) > 10000 THEN 'Premium'

    WHEN (
        SELECT SUM(oi.quantity * oi.list_price)
        FROM Orders o
        JOIN Order_Items oi 
        ON o.order_id = oi.order_id
        WHERE o.customer_id = c.customer_id
    ) BETWEEN 5000 AND 10000 THEN 'Regular'

    ELSE 'Basic'
END AS Customer_Type
FROM Customers c;

---3. Use UNION to display customers with orders and customers without orders.

SELECT 
c.first_name + ' ' + c.last_name AS Full_Name
FROM Customers c
JOIN Orders o
ON c.customer_id = o.customer_id

UNION

SELECT 
first_name + ' ' + last_name AS Full_Name
FROM Customers
WHERE customer_id NOT IN
(
SELECT customer_id FROM Orders
);

---4. Display full name using string concatenation.
SELECT 
first_name + ' ' + last_name AS Full_Name
FROM Customers;

---5. Handle NULL cases appropriately.
SELECT 
c.first_name + ' ' + c.last_name AS Full_Name,
ISNULL((
        SELECT SUM(oi.quantity * oi.list_price)
        FROM Orders o
        JOIN Order_Items oi 
        ON o.order_id = oi.order_id
        WHERE o.customer_id = c.customer_id
      ),0) AS total_order_value
FROM Customers c;