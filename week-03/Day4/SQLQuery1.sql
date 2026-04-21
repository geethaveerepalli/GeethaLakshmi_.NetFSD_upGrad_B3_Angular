CREATE DATABASE ProductAnalysis;

USE ProductAnalysis;

CREATE TABLE Categories(
category_id INT PRIMARY KEY IDENTITY(1,1),
category_name VARCHAR(100) NOT NULL
);

CREATE TABLE Products(
product_id INT PRIMARY KEY IDENTITY(1,1),
product_name VARCHAR(200) NOT NULL,
model_year INT NOT NULL,
list_price DECIMAL(10,2) NOT NULL,
category_id INT,
FOREIGN KEY(category_id) REFERENCES Categories(category_id)
);

--inserting data

INSERT INTO Categories(category_name) VALUES('Mountain Bikes'),('Road Bikes'),('Electric Bikes');

INSERT INTO Products (product_name, model_year, list_price, category_id) VALUES
('Trail Bike', 2017, 1200.00, 1),
('Mountain Pro', 2018, 1800.00, 1),
('Speed Road 200', 2017, 1500.00, 2),
('Road Elite', 2018, 2200.00, 2),
('Electric X', 2019, 3000.00, 3),
('Electric Lite', 2019, 2500.00, 3);

SELECT * FROM Categories;
SELECT * FROM Products;

---1. Retrieve product details (product_name, model_year, list_price).

SELECT product_name, model_year, list_price FROM Products;

----2. Compare each product’s price with the average price of products in the same category using a nested query.

SELECT product_name, model_year, list_price 
FROM Products p
WHERE list_price >(SELECT AVG(list_price) 
FROM Products
WHERE category_id = p.category_id);

---3.Display only products whose price is greater than category average
SELECT product_name, model_year, list_price
FROM Products p
WHERE list_price >
(
    SELECT AVG(list_price)
    FROM Products
    WHERE category_id = p.category_id
);

---4. Show calculated difference between product price and category average.
SELECT 
product_name,
model_year,
list_price,
list_price -
(
    SELECT AVG(list_price)
    FROM Products
    WHERE category_id = p.category_id
) AS price_difference
FROM Products p;

---5. Concatenate product name and model year as a single column (e.g., 'ProductName (2017)').

SELECT 
CONCAT(product_name, ' (', model_year, ')') AS Product_Details,
list_price
FROM Products;