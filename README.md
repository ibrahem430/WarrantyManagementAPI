# Warranty Management System

A RESTful ASP.NET Core Web API for managing products, customers, sales, warranties, and warranty claims.

The project follows **Clean Architecture** principles and is built using **ASP.NET Core Web API**, **Entity Framework Core**, and **SQL Server**.

---

## Features

- Product Management
- Customer Management
- Sales Management
- Automatic Warranty Generation
- Warranty Validation
- Warranty Claim Management
- Claim Status Workflow
- RESTful API Design

---

## Business Rules

### Warranty

- A warranty can only be created for an existing sale.
- The warranty period is calculated automatically based on the product warranty duration.
- Duplicate warranties for the same sale are prevented.
- Products without a warranty period cannot generate warranties.

### Warranty Claims

- Claims can only be created for active warranties.
- Only one warranty claim is allowed per warranty.
- Claim workflow:

```
Pending
   │
   ▼
Approved
   │
   ▼
InRepair
   │
   ▼
Completed
```

or

```
Pending
   │
   ▼
Rejected
```

---

## Project Structure

```
WarrantyManagement
│
├── WarrantyManagement.Api
├── WarrantyManagement.Application
├── WarrantyManagement.Domain
└── WarrantyManagement.Infrastructure
```

---

## Technologies

- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Clean Architecture
- Repository Pattern
- Dependency Injection
- RESTful API
- Git

---

## Architecture

```
Controller
      │
      ▼
Service
      │
      ▼
Repository
      │
      ▼
Entity Framework Core
      │
      ▼
SQL Server
```

---

## Modules

- Products
- Customers
- Sales
- Warranties
- Warranty Claims

---

## Current Status

Core functionality has been completed.

### Planned Improvements

- FluentValidation
- Global Exception Handling
- Swagger Documentation
- JWT Authentication
- Role-Based Authorization
- Unit Testing

---

## Author

**Ibrahem Mahmoud Habboush**

GitHub:
https://github.com/ibrahem430

LinkedIn:
https://linkedin.com/in/ibrahem-habboush-3b1821298
