Inventory Management System
Overview
This project is an Inventory Management System built with an ASP.NET Web API backend and an Angular frontend. It supports basic CRUD operations for managing inventory items.

Backend
Technology Stack:

ASP.NET Web API
SQL Server
Entity Framework Core
API Endpoints:

GET /api/items: Retrieve all inventory items
GET /api/items/{id}: Retrieve an inventory item by ID
POST /api/items: Create a new inventory item
PUT /api/items/{id}: Update an existing inventory item
DELETE /api/items/{id}: Delete an inventory item
Database Schema
InventoryItems Table:

ItemID (Primary Key): Unique identifier for each item
Name: Name of the item
Description: Description of the item
Quantity: Quantity of the item in stock
Price: Price of the item
Setup and Installation
Clone the repository:

bash
Copy code
git clone [repository-url]
Backend Setup:

Open the solution file in Visual Studio.
Restore NuGet packages.
Update the appsettings.json file with your SQL Server connection string.
Run migrations to set up the database.
Frontend Setup:

Navigate to the frontend folder.
Install dependencies using npm:
bash
Copy code
npm install
Serve the Angular application:
bash
Copy code
ng serve
Running the Application
Start the backend API by running the project in Visual Studio.
Start the Angular application using ng serve.
Access the frontend application at http://localhost:4200 and the API at http://localhost:7164/api/items.
Testing
The backend includes unit tests for the API endpoints.
The frontend includes basic tests for component functionality.
