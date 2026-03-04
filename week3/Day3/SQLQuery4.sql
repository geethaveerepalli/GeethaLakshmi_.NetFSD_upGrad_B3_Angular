CREATE DATABASE ProductStockSalesAnalysisDB;

USE ProductStockSalesAnalysisDB;

CREATE TABLE Products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100)
);

CREATE TABLE Stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100)
);

CREATE TABLE Stocks (
    stock_id INT PRIMARY KEY,
    store_id INT,
    product_id INT,
    quantity INT,
    FOREIGN KEY (store_id) REFERENCES Stores(store_id),
    FOREIGN KEY (product_id) REFERENCES Products(product_id)
);

CREATE TABLE Order_Items (
    item_id INT PRIMARY KEY,
    product_id INT,
    store_id INT,
    quantity INT,
    FOREIGN KEY (product_id) REFERENCES Products(product_id),
    FOREIGN KEY (store_id) REFERENCES Stores(store_id)
);

INSERT INTO Products VALUES(1, 'Laptop'),(2, 'Mobile'),(3, 'Tablet');
INSERT INTO Stores VALUES(1, 'Hyderabad Store'),(2, 'Bangalore Store');
INSERT INTO Stocks VALUES(1, 1, 1, 50),(2, 1, 2, 30),(3, 2, 1, 40),(4, 2, 3, 20);
INSERT INTO Order_Items VALUES(1, 1, 1, 10),(2, 1, 1, 5),(3, 2, 1, 8),(4, 1, 2, 7);

SELECT 
    p.product_name,
    s.store_name,
    st.quantity AS available_stock,
    ISNULL(SUM(oi.quantity), 0) AS total_quantity_sold
FROM Stocks st
INNER JOIN Products p
    ON st.product_id = p.product_id
INNER JOIN Stores s
    ON st.store_id = s.store_id
LEFT JOIN Order_Items oi
    ON st.product_id = oi.product_id
    AND st.store_id = oi.store_id
GROUP BY 
    p.product_name,
    s.store_name,
    st.quantity
ORDER BY p.product_name;