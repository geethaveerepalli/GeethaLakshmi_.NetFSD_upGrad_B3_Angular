CREATE DATABASE ProductPriceListingDB;

USE ProductPriceListingDB;

CREATE TABLE Brands (
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(50)
);

CREATE TABLE Categories (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(50)
);

CREATE TABLE Products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    brand_id INT,
    category_id INT,
    model_year INT,
    list_price DECIMAL(10,2),
    FOREIGN KEY (brand_id) REFERENCES Brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES Categories(category_id)
);

INSERT INTO Brands VALUES(1, 'Nike'),(2, 'Adidas'),(3, 'Puma');

INSERT INTO Categories VALUES(1, 'Shoes'),(2, 'Clothing'),(3, 'Accessories');

INSERT INTO Products VALUES(101, 'Running Shoes', 1, 1, 2023, 800),(102, 'Sports T-Shirt', 2, 2, 2022, 450),(103, 'Cap', 3, 3, 2023, 300),(104, 'Sneakers', 2, 1, 2024, 1200),(105, 'Jacket', 1, 2, 2023, 1500);

SELECT * FROM Brands;
SELECT * FROM Categories;
SELECT * FROM Products;


SELECT 
    p.product_name,
    b.brand_name,
    c.category_name,
    p.model_year,
    p.list_price
FROM Products p
INNER JOIN Brands b
    ON p.brand_id = b.brand_id
INNER JOIN Categories c
    ON p.category_id = c.category_id;



SELECT 
    p.product_name,
    b.brand_name,
    c.category_name,
    p.model_year,
    p.list_price
FROM Products p
INNER JOIN Brands b
    ON p.brand_id = b.brand_id
INNER JOIN Categories c
    ON p.category_id = c.category_id
WHERE p.list_price > 500;



SELECT 
    p.product_name,
    b.brand_name,
    c.category_name,
    p.model_year,
    p.list_price
FROM Products p
INNER JOIN Brands b
    ON p.brand_id = b.brand_id
INNER JOIN Categories c
    ON p.category_id = c.category_id
ORDER BY p.list_price ASC;