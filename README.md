
# 📚 School Management System – Clean Architecture

This project is a **School Management System** developed using **ASP.NET Core** and adheres to the principles of **Clean Architecture**. It emphasizes separation of concerns, scalability, and maintainability.

---

## 🏗️ Project Structure

The solution is organized into distinct layers:

* **CleanArchitecture.API**: Handles HTTP requests and responses.
* **CleanArchitecture.Core**: Contains business logic, domain entities, and interfaces.
* **CleanArchitecture.Data**: Manages data access, including Entity Framework Core configurations.
* **CleanArchitecture.Infrastructure**: Provides external services and configurations.
* **CleanArchitecture.Service**: Implements application services and business rules.([GitHub][1])

---

## 🚀 Features

* **User Management**: Registration, authentication, and role-based authorization.
* **Student & Instructor Management**: CRUD operations for students and instructors.
* **Department Management**: Organize and manage academic departments.
* **Role & Claim Management**: Assign roles and claims to users for fine-grained access control.
* **Validation**: Input validation using FluentValidation.
* **Localization**: Support for multiple languages using `IStringLocalizer`.
* **Logging**: Integrated logging with Serilog.([GitHub][2])

---

## 🛠️ Technologies Used

* **Framework**: .NET 6 / ASP.NET Core
* **Architecture**: Clean Architecture
* **ORM**: Entity Framework Core
* **Authentication**: ASP.NET Core Identity, JWT
* **Validation**: FluentValidation
* **Localization**: IStringLocalizer
* **Logging**: Serilog
* **Design Patterns**: Repository, Unit of Work, Mediator (MediatR)([GitHub][3], [GitHub][1])

---

## 🧪 Getting Started

### Prerequisites

* .NET 6 SDK
* SQL Server or any other supported database

### Setup Instructions

1. **Clone the repository**:

   ```bash
   git clone https://github.com/Marwa-m/SchoolProject.git
   ```



2. **Navigate to the project directory**:

   ```bash
   cd SchoolProject
   ```



3. **Update the database connection string** in `appsettings.json` to match your database configuration.

4. **Apply migrations and update the database**:

   ```bash
   dotnet ef database update
   ```



5. **Run the application**:

   ```bash
   dotnet run --project CleanArchitecture.API
   ```



6. **Access the API** at `https://localhost:5001` or `http://localhost:5000`.

---

## 📂 Folder Structure

```
SchoolProject/
├── CleanArchitecture.API/           # API layer
├── CleanArchitecture.Core/          # Domain entities and interfaces
├── CleanArchitecture.Data/          # Data access layer
├── CleanArchitecture.Infrastructure/ # External services
├── CleanArchitecture.Service/       # Business logic implementations
├── CleanArchitecture.sln            # Solution file
└── README.md                        # Project documentation
```



---

## 📌 Notes

* **Modular Design**: Each layer is independent, promoting testability and scalability.
* **Extensibility**: Easily extendable to include features like course management, scheduling, and more.
* **Security**: Implements role-based access control to secure endpoints.

---

## 🤝 Contributing

Contributions are welcome! Please fork the repository and submit a pull request for any enhancements or bug fixes.

---

## 📄 License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

