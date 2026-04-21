CREATE DATABASE EcommDb;
USE EcommDb;

CREATE TABLE Categories(
    category_id INT PRIMARY KEY,
    category_name VARCHAR(50) NOT NULL
);

CREATE TABLE Brands(
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(50) NOT NULL
);

CREATE TABLE Stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100),
    city VARCHAR(50)
);
CREATE TABLE Customers(
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    city VARCHAR(50),
    phone VARCHAR(15),
    email VARCHAR(100)
);

CREATE TABLE Staffs (
    staff_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    store_id INT,
    FOREIGN KEY (store_id) REFERENCES Stores(store_id)
);

CREATE TABLE Products(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100) NOT NULL,
    brand_id INT,
    category_id INT,
    model_year INT,
    list_price DECIMAL(10,2),

    FOREIGN KEY (brand_id) REFERENCES Brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES Categories(category_id)
);

CREATE TABLE Orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    store_id INT,
    staff_id INT,
    order_date DATE,

    FOREIGN KEY (customer_id) REFERENCES Customers(customer_id),
    FOREIGN KEY (store_id) REFERENCES Stores(store_id),
    FOREIGN KEY (staff_id) REFERENCES Staffs(staff_id)
);



---inserting data-----

INSERT INTO Categories VALUES(1,'Mountain Bikes'),(2,'Road Bikes'),(3,'Electric Bikes'),(4,'Kids Bikes'),(5,'Accessories');

INSERT INTO Brands VALUES(1,'Trek'),(2,'Giant'),(3,'Specialized'),(4,'Cannondale'),(5,'Scott');

INSERT INTO Products VALUES(101,'Trek Marlin 7',1,1,2023,85000),(102,'Giant Defy Advanced',2,2,2022,120000),(103,'Specialized Turbo Vado',3,3,2024,250000),(104,'Cannondale Kids Trail',4,4,2023,25000),(105,'Scott Helmet',5,5,2022,3500);

INSERT INTO Customers VALUES(1,'Rahul','Sharma','Hyderabad','9876543210','rahul@gmail.com'),(2,'Priya','Reddy','Chennai','9876500000','priya@gmail.com'),(3,'Arjun','Kumar','Hyderabad','9876512345','arjun@gmail.com'),(4,'Sneha','Iyer','Bangalore','9876598765','sneha@gmail.com'),(5,'Kiran','Patel','Mumbai','9876588888','kiran@gmail.com');

INSERT INTO Stores VALUES(1,'AutoBike Store','Hyderabad'),(2,'Speed Wheels','Chennai'),(3,'Urban Riders','Bangalore'),(4,'Bike Zone','Mumbai'),(5,'Power Bikes','Delhi');

--- Write SELECT queries to retrieve all products with their brand and category names.
SELECT p.product_name,b.brand_name,c.category_name,p.model_year,p.list_price
FROM Products p
INNER JOIN Brands b
ON P.brand_id = b.brand_id
INNER JOIN Categories c
ON p.category_id = c.category_id;

---Retrieve all customers from a specific city.

SELECT * FROM Customers WHERE city='Hyderabad';

--- Display total number of products available in each category.
SELECT c.category_name,
COUNT(p.product_id) AS total_products
FROM Categories c
LEFT JOIN Products p
ON c.category_id = p.category_id
GROUP BY c.category_name;


