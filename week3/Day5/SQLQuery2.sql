USE EcommDb;
GO

--- Create a view that shows product name, brand name, category name, model year and list price.
CREATE VIEW vw_ProductDetails AS
SELECT 
    p.product_name,
    b.brand_name,
    c.category_name,
    p.model_year,
    p.list_price
FROM Products p
JOIN Brands b ON p.brand_id = b.brand_id
JOIN Categories c ON p.category_id = c.category_id;
GO

SELECT * FROM vw_ProductDetails;
GO

--- Create a view that shows order details with customer name, store name and staff name.
CREATE VIEW vw_OrderDetails AS
SELECT 
    o.order_id,
    c.first_name + ' ' + c.last_name AS customer_name,
    s.store_name,
    st.first_name + ' ' + st.last_name AS staff_name,
    o.order_date
FROM Orders o
JOIN Customers c 
ON o.customer_id = c.customer_id
JOIN Stores s 
ON o.store_id = s.store_id
JOIN Staffs st 
ON o.staff_id = st.staff_id;
GO

SELECT * FROM vw_OrderDetails;
GO

--- Create appropriate indexes on foreign key columns.
CREATE INDEX idx_products_brand
ON Products(brand_id);

CREATE INDEX idx_products_category
ON Products(category_id);

CREATE INDEX idx_orders_customer
ON Orders(customer_id);

CREATE INDEX idx_orders_store
ON Orders(store_id);

CREATE INDEX idx_orders_staff
ON Orders(staff_id);

CREATE INDEX idx_staff_store
ON Staffs(store_id);
GO 

--- Test performance improvement using execution plan.
SELECT * 
FROM Products
WHERE brand_id = 1;