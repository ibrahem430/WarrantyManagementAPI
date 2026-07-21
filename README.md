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
- JWT Authentication
- Refresh Token Authentication
- Role-Based Authorization
- FluentValidation
- Global Exception Handling
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

Claim workflow:

```text
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

```text
Pending
   │
   ▼
Rejected
```

---

## Project Structure

```text
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
- FluentValidation
- JWT Authentication
- RESTful API
- Git

---

## Architecture

```text
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
- Authentication

---

## Authentication

The API uses JWT Authentication with Refresh Tokens.

Features include:

- User Registration
- User Login
- JWT Access Tokens
- Refresh Tokens
- Logout
- Role-Based Authorization

---

## Future Improvements

- Swagger Documentation
- Unit Testing
- Pagination
- Search & Filtering
- Docker Support

---

## Author

**Ibrahem Mahmoud Habboush**

GitHub:
https://github.com/ibrahem430

LinkedIn:
https://linkedin.com/in/ibrahem-habboush-3b1821298
