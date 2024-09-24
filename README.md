# ECommerceApp

## **Still In Development**

ECommerceApp is a learning-focused, simplified e-commerce platform designed to help users manage their shopping experience, including adding products to the cart, updating quantities, managing categories, and processing orders. This project is built using **ASP.NET Core** and **Entity Framework** with a clean architecture and RESTful APIs for seamless integration.

## Table of Contents
- [Features](#features)
- [Technologies](#technologies)
- [Getting Started](#getting-started)
- [API Endpoints](#api-endpoints)
- [Contributing](#contributing)

## Features
- **User registration and authentication** (Work in Progress)
- **Shopping Cart Management**
  - Add products to the shopping cart
  - Update the quantity of items in the cart
  - Remove items or clear the entire cart
- **Product Management**
  - View products by category
  - Manage product categories
- **Order Processing**
  - Place an order from the shopping cart
  - Retrieve past orders for users
- **RESTful API**
  - Full API to support interaction with the e-commerce functionality
- **Swagger Integration** for easy API testing and documentation

## Technologies
- **ASP.NET Core** - The primary framework for building the application.
- **Entity Framework Core** - For database interactions.
- **SQL Server** - Database for storing products, users, orders, etc.
- **RESTful API** - For interaction between the frontend and backend services.
- **Swagger** - For API documentation and testing.

## Getting Started

To get a local copy up and running, follow these steps:

### Prerequisites
Before you begin, ensure you have the following installed:
- [.NET 6 SDK or higher](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Git](https://git-scm.com/)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/ECommerceApp.git
   cd ECommerceApp
2. **Install NuGet Packages Inside the project directory, run:**
   ```bash
   dotnet restore
3. **Set up the database Ensure SQL Server is running locally, and modify the appsettings.json file to point to your database server.**
4. **Run database migrations**
   ```bash
   dotnet ef database update
5. **Run the application After setting up the database, run the application:**
   ```bash
   dotnet run
6. **Access Swagger Documentation!!!**

## Api-Endpoints

## Contributing

Contributions are what make the open-source community such an amazing place to learn, inspire, and create. Any contributions you make are greatly appreciated.
