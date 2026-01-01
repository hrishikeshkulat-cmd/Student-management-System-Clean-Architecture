🚀 Student Management System – RESTful API
ASP.NET Core Web API • EF Core • JWT Authentication • Clean Architecture

![.NET](https://img.shields.io/badge/.NET-8.0-purple?style=for-the-badge)

![C#](https://img.shields.io/badge/C%23-Language-blue?style=for-the-badge)

![EFCore](https://img.shields.io/badge/Entity%20Framework-Core-green?style=for-the-badge)

![JWT](https://img.shields.io/badge/JWT-Authentication-orange?style=for-the-badge)

![Swagger](https://img.shields.io/badge/Swagger-API%20Docs-brightgreen?style=for-the-badge)

![ASP.NET Web API](https://img.shields.io/badge/ASP.NET-Web%20API-indigo?style=for-the-badge)
![REST API](https://img.shields.io/badge/REST-API-black?style=for-the-badge)

![Repository Pattern](https://img.shields.io/badge/Repository-Pattern-darkgreen?style=for-the-badge)
![DTO](https://img.shields.io/badge/DTO-Pattern-yellow?style=for-the-badge)
![Clean Architecture](https://img.shields.io/badge/Clean-Architecture-teal?style=for-the-badge)


A production-ready Student Management System backend built with ASP.NET Core Web API, following clean architecture principles and real-world backend practices.

This project is part of my full-stack .NET learning journey, where I focused on building first, understanding deeply, and scaling features step-by-step instead of copy-paste development.

📌 Key Features
🔹 Core Backend

✔️ Clean RESTful APIs with standard HTTP status codes

✔️ Controller → Service → Repository architecture

✔️ Entity Framework Core (Code First) with SQL Server

✔️ Async-first database operations

✔️ DTO-based request & response models

✔️ Input validation using Data Annotations

🔹 Domain Modules Implemented
🏢 Departments

Create, update, delete, and fetch departments

One-to-many relationship with Students

👨‍🎓 Students

Full CRUD operations

Student linked to Department

Get student with department details (JOIN)

Pagination & sorting support for listing APIs

📚 Courses

Full CRUD operations

Designed for scalable many-to-many relations

🔗 Enrollment (Many-to-Many)

Explicit Enrollment entity (Student ↔ Course)

Composite primary key

Prevents duplicate enrollments

APIs to:

Enroll student in a course

Unenroll student

Get courses for a student

Get students in a course

🔐 Authentication & Security (JWT)

User registration & login

Password hashing using ASP.NET Identity utilities

JWT token generation & validation

Role-based authorization support (Admin / User)

[Authorize] applied on business controllers

Clean separation of Auth vs Domain logic

🔧 Developer Experience

✔️ Swagger (OpenAPI) documentation

✔️ Clean and readable codebase

✔️ Modular, extensible structure

✔️ Resume-ready real-world backend design

📁 Project Structure
/StudentManagementSystem
├── Controllers/
│   ├── AuthController
│   ├── DepartmentController
│   ├── StudentController
│   ├── CourseController
│   └── EnrollmentController
│
├── Services/
│   ├── AuthService
│   ├── TokenService
│   ├── DepartmentService
│   ├── StudentService
│   ├── CourseService
│   └── EnrollmentService
│
├── Repositories/
│   ├── DepartmentRepository
│   ├── StudentRepository
│   ├── CourseRepository
│   └── EnrollmentRepository
│
├── Models/
│   ├── Entities
│   └── DTOs
│
├── Data/
│   ├── AppDbContext
│   └── Migrations
│
├── Program.cs
└── README.md

🛠 Tech Stack
Layer	Technology
Backend	ASP.NET Core Web API (.NET 8)
Language	C#
ORM	Entity Framework Core
Database	SQL Server
Authentication	JWT (JSON Web Token)
Architecture	Controller → Service → Repository
API Docs	Swagger (Swashbuckle)
🚀 How to Run Locally
1️⃣ Clone the repository
git clone https://github.com/YOUR-USERNAME/YOUR-REPO.git

2️⃣ Open in Visual Studio / VS Code

Restore dependencies automatically.

3️⃣ Update Database
dotnet ef database update

4️⃣ Run the project
dotnet run

5️⃣ Open Swagger
https://localhost:<PORT>/swagger/index.html

🔥 Sample API Endpoints
🔐 Authentication
Method	Endpoint	Description
POST	/api/auth/register	Register new user
POST	/api/auth/login	Login & get JWT
🏢 Departments

| GET | /api/departments |
| POST | /api/departments |

👨‍🎓 Students

| GET | /api/students |
| GET | /api/students/{id} |
| POST | /api/students |
| PUT | /api/students/{id} |
| DELETE | /api/students/{id} |

📚 Courses

| GET | /api/courses |
| POST | /api/courses |

🔗 Enrollment

| POST | /api/enrollment |
| DELETE | /api/enrollment/{studentId}/{courseId} |
| GET | /api/students/{id}/courses |
| GET | /api/courses/{id}/students |

🧠 What This Project Demonstrates

Real-world backend design

Clean separation of concerns

Correct use of EF Core relationships

JWT authentication without mixing domain logic

Scalable architecture suitable for enterprise apps

This project was built incrementally with deep understanding, not generated from templates.

🔮 Future Enhancements

🔜 Angular frontend (Full-stack)

🔜 Role-based UI (Admin vs User)

🔜 Global exception handling middleware

🔜 Unit testing (xUnit)

🔜 Refresh tokens

👤 Author

Hrishikesh kulat 🌞
Backend-focused .NET Developer
Learning by building real-world systems.
🔜 Logging with Serilog

🤝 Contributing
Feel free to fork, improve, and submit a PR.
If you find bugs or want to suggest features — open an issue.

