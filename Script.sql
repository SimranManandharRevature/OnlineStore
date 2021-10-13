CREATE database OnlineStoreDB;

CREATE TABLE Products(
ProductId INT PRIMARY KEY IDENTITY,
Name varchar(50) NOT NULL,
Picture varchar(8000) NOT NULL,
Price decimal(19,4) NOT NULL,
StoreId INT NOT NULL FOREIGN KEY REFERENCES Stores(StoreId) ON DELETE CASCADE,
);

CREATE TABLE Stores(
StoreId INT PRIMARY KEY IDENTITY,
Name varchar(50) NOT NULL,
Picture varchar(8000) NOT NULL,
);

CREATE TABLE Orders(
OrderId INT PRIMARY KEY IDENTITY,
CustomerId INT NOT NULL FOREIGN KEY REFERENCES Customers(CustomerId) ON DELETE CASCADE,
OrderDate DATETIME DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE ProductOrder(
ProductOrderId INT PRIMARY KEY IDENTITY,
ProductId INT NOT NULL FOREIGN KEY REFERENCES Products(ProductId) ON DELETE CASCADE,
OrderId INT NOT NULL FOREIGN KEY REFERENCES Orders(OrderId) ON DELETE CASCADE,
Quantity Int NOT NULL
);

CREATE TABLE Customers(
CustomerId INT PRIMARY KEY IDENTITY,
Name varchar(50) NOT NULL,
Email varchar(50) NOT NULL
);


INSERT INTO Customers 
(Name,Email)
VALUES ('john@mail.com', 'John');

INSERT INTO Stores 
(Name,Picture)
values ('Apple','https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS-kOobBslQW_hXhBpLhQAeZ9syaapI1uem6Q&usqp=CAU'),
('Samsung', 'https://pisces.bbystatic.com/image2/BestBuy_US/dam/samsung-logo-white-215744-7a5c47cc-7f1f-4898-ba68-a4823f712173.png;maxHeight=56;maxWidth=342'),
('HP','https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTrRqQdsQIqcNmDG2pgUpZOVj8tcSEF8kdMxQ&usqp=CAU');

INSERT INTO Products
 (Name,Price,Picture,Quantity,StoreId)
VALUES ('Keyboard',99.99, 'https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6421/6421508_sd.jpg;maxHeight=300;maxWidth=450', 100, 3),
('Wireless Mouse',89.99, 'https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6442/6442132_sd.jpg;maxHeight=300;maxWidth=450', 100, 3),
('Headset',129.99, 'https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6398/6398130_rd.jpg;maxHeight=300;maxWidth=450', 100, 3);

--Making an order (part 1)
INSERT INTO Orders (CustomerId)
VALUES(
(SELECT CustomerId FROM Customers WHERE Name = 'John'));

--Making an order (part 2)
INSERT INTO ProductOrder (OrderId, ProductId,Quantity)
VALUES(
(SELECT OrderId FROM Orders WHERE OrderId = (SELECT MAX(OrderId) FROM Orders)),
(SELECT ProductId FROM Products WHERE Name = 'Mac'), 1);


