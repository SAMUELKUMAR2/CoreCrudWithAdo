# SamuelCoreAdo Database README

This README provides the details of the `SamuelCoreAdo` database, its schema, stored procedures, and example queries for managing employees, countries, and states.

---

## Database Setup

```sql
-- Create Database
CREATE DATABASE SamuelCoreAdo;

-- Use Database
USE SamuelCoreAdo;

-- Create Table: tblEmployee
CREATE TABLE tblEmployee (
    EmpId INT PRIMARY KEY IDENTITY,
    Name VARCHAR(50),
    Age INT,
    Gender VARCHAR(50),
    Country VARCHAR(50),
    State VARCHAR(50)
);

-- Create Table: tblCountry
CREATE TABLE tblCountry (
    cid INT PRIMARY KEY IDENTITY,
    cname VARCHAR(50)
);

-- Insert Data into tblCountry
INSERT INTO tblCountry VALUES ('India'), ('Pakistan');

-- Create Table: tblState
CREATE TABLE tblState (
    sid INT PRIMARY KEY IDENTITY,
    sname VARCHAR(50),
    cid INT
);

-- Insert Data into tblState
INSERT INTO tblState VALUES
('Uttar-Pradesh', 1),
('Madhya-Pradesh', 1),
('Bihar', 1),
('Karachi', 2),
('Lebnan', 2);

-- Insert Data into tblEmployee
INSERT INTO tblEmployee VALUES ('Aman', 23, 'Male', '1', '1');

-- View Data
SELECT * FROM tblCountry;
SELECT * FROM tblState;
SELECT * FROM tblEmployee;

-- Delete Employee Record
DELETE FROM tblEmployee WHERE EmpId = 14;

-- Update Employee Data
UPDATE tblEmployee
SET Name = 'Binod', Age = 32, Gender = 'Male', Country = '1', State = '1'
WHERE EmpId = 2;
