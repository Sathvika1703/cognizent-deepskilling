IF OBJECT_ID('dbo.Products', 'U') IS NOT NULL
    DROP TABLE dbo.Products;


CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);


INSERT INTO Products (ProductID, ProductName, Category, Price) VALUES
(1, 'Laptop', 'Electronics', 1200.00),
(2, 'Smartphone', 'Electronics', 800.00),
(3, 'Tablet', 'Electronics', 800.00), 
(4, 'Headphones', 'Electronics', 200.00),
(5, 'Monitor', 'Electronics', 300.00),
(6, 'Sofa', 'Furniture', 1500.00),
(7, 'Dining Table', 'Furniture', 1200.00),
(8, 'Chair', 'Furniture', 200.00),
(9, 'Bed', 'Furniture', 1200.00), 
(10, 'Bookshelf', 'Furniture', 500.00),
(11, 'Pen', 'Stationery', 5.00),
(12, 'Notebook', 'Stationery', 10.00),
(13, 'Marker', 'Stationery', 8.00),
(14, 'Diary', 'Stationery', 15.00),
(15, 'Folder', 'Stationery', 5.00);


SELECT
    ProductID,
    ProductName,
    Category,
    Price,
    ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum,
    RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS RankNum,
    DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRankNum
FROM
    Products
ORDER BY
    Category, Price DESC;


WITH RankedProducts AS (
    SELECT
        ProductID,
        ProductName,
        Category,
        Price,
        ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum
    FROM
        Products
)
SELECT *
FROM RankedProducts
WHERE RowNum <= 3
ORDER BY Category, Price DESC;


WITH RankedProducts AS (
    SELECT
        ProductID,
        ProductName,
        Category,
        Price,
        RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS RankNum
    FROM
        Products
)
SELECT *
FROM RankedProducts
WHERE RankNum <= 3
ORDER BY Category, Price DESC;


WITH RankedProducts AS (
    SELECT
        ProductID,
        ProductName,
        Category,
        Price,
        DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRankNum
    FROM
        Products
)
SELECT *
FROM RankedProducts
WHERE DenseRankNum <= 3
ORDER BY Category, Price DESC;

