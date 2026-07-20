# Inventory Management API

A RESTful API for inventory management built with **ASP.NET Core Web API** and **C#**.
This project was developed to demonstrate backend development practices, including layered architecture, authentication, data persistence, validation, and clean code principles.

## 🚀 Features

* User registration and authentication
* JWT-based authentication and authorization
* Role-based access control
* Product management (CRUD)
* Category and supplier relationships
* Product search by name
* Product search by SKU
* Pagination support
* Product ordering
* Global exception handling
* Data validation
* Secure password hashing

---

# 🛠 Technologies

* **C#**
* **.NET 10**
* **ASP.NET Core Web API**
* **Entity Framework Core**
* **PostgreSQL**
* **JWT Authentication**
* **AutoMapper**
* **FluentValidation**
* **BCrypt.Net**
* **Swagger / OpenAPI**

---

# 🏗 Architecture

The project follows a layered architecture approach:

```
InventoryManagement.API

├── Controllers
│   └── API endpoints and HTTP requests
│
├── Services
│   └── Business logic layer
│
├── Repositories
│   └── Database access layer
│
├── Entities
│   └── Domain models
│
├── DTOs
│   └── Data transfer objects
│
├── Data
│   └── Entity Framework Core configuration
│
├── Mappings
│   └── AutoMapper profiles
│
├── Validators
│   └── FluentValidation rules
│
├── Middleware
│   └── Global exception handling
│
└── Configurations
    └── Application settings
```

---

# 🔐 Authentication

The API uses **JWT (JSON Web Token)** authentication.

Users can:

* Register an account
* Login and receive a JWT token
* Access protected endpoints using the Bearer token

Example:

```
Authorization: Bearer {your_token}
```

---

# 🗄 Database

The project uses **PostgreSQL** with Entity Framework Core.

Main entities:

* User
* Role
* Product
* Category
* Supplier
* Purchase Order

Entity relationships are managed using EF Core configurations and migrations.

---

# 📌 API Endpoints

## Authentication

### Register

```
POST /api/Auth/register
```

Creates a new user account.

---

### Login

```
POST /api/Auth/login
```

Authenticates the user and returns a JWT token.

---

# Products

### Get all products

```
GET /api/Products
```

### Get product by ID

```
GET /api/Products/{id}
```

### Create product

```
POST /api/Products
```

### Update product

```
PUT /api/Products/{id}
```

### Delete product

```
DELETE /api/Products/{id}
```

### Search products

```
GET /api/Products/search?name={name}
```

### Pagination

```
GET /api/Products/paged?page=1&pageSize=10
```

### Ordered products

```
GET /api/Products/ordered
```

---

# ▶️ How to Run

## Requirements

Before running the project, make sure you have:

* .NET SDK installed
* PostgreSQL installed
* Visual Studio 2022 or another compatible IDE

---

## Clone repository

```bash
git clone https://github.com/yourusername/InventoryManagement.API.git
```

---

## Configure database

Update the connection string in:

```
appsettings.json
```

Example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=InventoryManagement;Username=postgres;Password=yourpassword"
}
```

---

## Apply migrations

Run:

```bash
dotnet ef database update
```

---

## Run the application

```bash
dotnet run
```

The API will be available at:

```
https://localhost:7272
```

Swagger documentation:

```
https://localhost:7272/swagger
```

---

# 📚 Development Practices Used

This project applies:

* Repository Pattern
* Service Layer Pattern
* Dependency Injection
* DTO Pattern
* Separation of concerns
* Exception Middleware
* Input validation
* Secure authentication practices

---

# 👩‍💻 Author

**Vitória Lopes**

Backend Developer focused on **C#/.NET**, REST APIs, and software architecture.

LinkedIn:
https://www.linkedin.com/in/vitoria-lopes-1115b1179

GitHub:
https://github.com/vislopes

<img width="1362" height="637" alt="Captura de tela 2026-07-19 225953" src="https://github.com/user-attachments/assets/7ab9e8fd-cd7e-4ba8-99b7-6f4011d01613" />

