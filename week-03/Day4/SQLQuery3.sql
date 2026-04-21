CREATE DATABASE StorePerformance;

USE StorePerformance;

CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100)
);

CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    list_price DECIMAL(10,2)
);

CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    store_id INT,
    order_date DATE,
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

CREATE TABLE order_items (
    order_item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(10,2),
    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

CREATE TABLE stocks (
    store_id INT,
    product_id INT,
    quantity INT,
    PRIMARY KEY (store_id, product_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

--inserting data
INSERT INTO stores VALUES(1,'Hyderabad Store'),(2,'Chennai Store'),(3,'Bangalore Store');
INSERT INTO products VALUES(101,'Mountain Bike',50000),(102,'Road Bike',45000),(103,'Helmet',1500),(104,'Gloves',800);
INSERT INTO orders VALUES(201,1,'2023-01-10'),(202,2,'2023-02-15'),(203,3,'2023-03-20');
INSERT INTO order_items VALUES(301,201,101,2,50000,2000),(302,201,103,1,1500,100),(303,202,102,1,45000,500),(304,203,104,3,800,50);
INSERT INTO stocks VALUES(1,101,5),(1,103,0),(2,102,3),(3,104,0);

---1. Identify products sold in each store using nested queries.
SELECT 
    s.store_name,
    p.product_name
FROM stores s
JOIN orders o 
    ON s.store_id = o.store_id
JOIN order_items oi 
    ON o.order_id = oi.order_id
JOIN products p 
    ON oi.product_id = p.product_id
WHERE oi.product_id IN
(
    SELECT product_id 
    FROM order_items
);

--2. Compare sold products with current stock using INTERSECT and EXCEPT operators.
SELECT product_id
FROM order_items

INTERSECT

SELECT product_id
FROM stocks;
----------------------
SELECT product_id
FROM order_items

EXCEPT

SELECT product_id
FROM stocks
WHERE quantity > 0;

---3. Display store_name, product_name, total quantity sold.

SELECT 
    s.store_name,
    p.product_name,
    SUM(oi.quantity) AS total_quantity_sold
FROM stores s
JOIN orders o 
    ON s.store_id = o.store_id
JOIN order_items oi 
    ON o.order_id = oi.order_id
JOIN products p 
    ON oi.product_id = p.product_id
GROUP BY 
    s.store_name,
    p.product_name;


---4. Calculate total revenue per product (quantity × list_price – discount).
SELECT 
    s.store_name,
    p.product_name,
    SUM(oi.quantity) AS total_quantity_sold
FROM stores s
JOIN orders o 
    ON s.store_id = o.store_id
JOIN order_items oi 
    ON o.order_id = oi.order_id
JOIN products p 
    ON oi.product_id = p.product_id
GROUP BY 
    s.store_name,
    p.product_name;

--5.Update stock quantity to 0 for discontinued products (simulation).
UPDATE stocks
SET quantity = 0
WHERE product_id IN
(
    SELECT product_id
    FROM products
    WHERE product_name = 'Helmet'
);