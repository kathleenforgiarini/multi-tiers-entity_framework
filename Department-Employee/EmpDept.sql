IF db_id('EmpDept') IS NULL CREATE DATABASE EmpDept;
GO

USE EmpDept;

CREATE TABLE Departments 
 (DeptId INT NOT NULL, 
 Name VARCHAR(50) NOT NULL,
 PRIMARY KEY (DeptId));

CREATE TABLE Employees 
 (EmpId INT NOT NULL, 
 Name VARCHAR(50) NOT NULL,
 Salary Decimal(10,2) NOT NULL,
 DeptId INT NOT NULL,
 PRIMARY KEY (EmpId),
 FOREIGN KEY (DeptId) REFERENCES
 Departments(DeptId)
 ON DELETE NO ACTION 
 ON UPDATE CASCADE);


GO


INSERT INTO Departments (DeptId, Name) 
VALUES (1, 'Marketing'),
(2, 'Accounting'),
(3, 'Finance'),
(4, 'IT');

INSERT INTO Employees (EmpId, Name, Salary, DeptId) 
VALUES  (1, 'Mary', 90,000, 3),
(3, 'John', 90,000, 1),
(7, 'Brian', 80,000, 2),
(14, 'Anne', 95,000, 4),
(32, 'James', 85,000, 1);

GO