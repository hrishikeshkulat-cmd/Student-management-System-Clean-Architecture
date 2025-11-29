# CRUD Operations using RESTful API (ASP.NET Core Web API)

A clean and beginner-friendly RESTful API built using **ASP.NET Core Web API**, demonstrating complete **CRUD operations**, **DTOs**, **Model Validation**, **Routing**, and a **Service Layer Architecture**.

This project is part of my backend development learning journey, focusing on writing clean, scalable, and industry-level API code.

---

## 🚀 Features

### ✔ Complete CRUD Operations
- **GET** → Fetch all students or a single student  
- **POST** → Add new student  
- **PUT** → Update existing student  
- **DELETE** → Remove student  

### ✔ RESTful API Standards
- Proper HTTP verbs  
- Clean URL routing  
- Standard status codes (200, 201, 204, 404)  
- Consistent JSON responses  

### ✔ Service Layer Architecture
Business logic is handled in a dedicated **Service Layer**, keeping controllers clean and maintainable.

### ✔ DTOs (Data Transfer Objects)
Secure and structured data transfer between client and server.

### ✔ Model Validation
Using attributes like:
- `[Required]`
- `[MinLength]`
- `[MaxLength]`
- `[Range]`

### ✔ In-Memory Database
Simulated database using a static list before integrating with EF Core.

### ✔ Swagger UI Integration
Interactive API testing with auto-generated documentation.

---

## 🏗️ Project Structure

RestfulApi/
│
├── Controllers/
│ └── StudentController.cs
│
├── Services/
│ ├── IStudentService.cs
│ └── StudentService.cs
│
├── Models/
│ ├── Student.cs
│ └── UpdateStudentDto.cs
│
├── FakeDb/
│ └── FakeDb.cs
│
└── Program.cs

yaml
Copy code

---

## 📌 Technologies Used

- **ASP.NET Core Web API (.NET 8)**
- **C#**
- **Swagger / Swashbuckle**
- **In-Memory List as Fake Database**
- **Service Layer Pattern**
- **DTO Validation**

---

## 🔧 How to Run the Project

### 1️⃣ Clone the Repository
```bash
git clone https://github.com/hrishikeshkulat-cmd/Crud-operations-using-Restful-api.git
2️⃣ Open in Visual Studio or VS Code
3️⃣ Restore Dependencies
.NET automatically restores packages on build.

4️⃣ Run the Application
bash
Copy code
dotnet run
5️⃣ Open Swagger UI
Navigate to the URL displayed in console, usually:

bash
Copy code
https://localhost:7047/swagger/index.html
You can now test all CRUD endpoints interactively.

📬 API Endpoints
GET — Get All Students
bash
Copy code
GET /api/student
GET — Get Student by ID
bash
Copy code
GET /api/student/{id}
POST — Add New Student
bash
Copy code
POST /api/student
PUT — Update Student
bash
Copy code
PUT /api/student/{id}
DELETE — Remove Student
bash
Copy code
DELETE /api/student/{id}
🧠 What I Learned
How RESTful API works at a deeper level

Why DTOs protect the entity

How to keep controllers clean

Why 204 NoContent is the correct response for PUT and DELETE

Model validation and error handling

How a service layer improves scalability

🚀 Next Steps (Upcoming Enhancements)
Adding Repository Layer

Integrating EF Core + SQL Database

Async programming

Automapper

JWT Authentication

Global Exception Handling

Clean Architecture

🤝 Contributing
Feel free to fork the repo, create a feature branch, and submit a PR.

📄 License
This project is open-source and available under the MIT License.

⭐ Support
If this project helped you, please consider giving it a ⭐ on GitHub!


---

If you want a **README with images + shields (badges)** OR an **ultra-advanced portfolio version**, I can create it next.
