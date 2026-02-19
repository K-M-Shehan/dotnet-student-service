# StudentService Microservice

A simple ASP.NET Core Web API microservice providing CRUD operations for **Student** entities, backed by an **EF Core In-Memory database**.

## Project Structure

```
.
├── Controllers/
│   └── StudentsController.cs   # CRUD API endpoints
├── Data/
│   └── AppDbContext.cs         # EF Core DbContext
├── Models/
│   └── Student.cs              # Student entity
├── Program.cs                  # App entry point & DI setup
└── StudentService.csproj
```

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

### Run the API

```bash
dotnet run --project StudentService.csproj
```

The API will start on `http://localhost:5000` (and `https://localhost:5001`).

---

## API Endpoints

| Method | Endpoint              | Description             |
|--------|-----------------------|-------------------------|
| GET    | `/api/students`       | Get all students        |
| GET    | `/api/students/{id}`  | Get a student by ID     |
| POST   | `/api/students`       | Create a new student    |
| PUT    | `/api/students/{id}`  | Update a student by ID  |
| DELETE | `/api/students/{id}`  | Delete a student by ID  |

---

## Example Requests

### Create a Student (POST)

```bash
curl -X POST http://localhost:5000/api/students \
  -H "Content-Type: application/json" \
  -d '{
    "firstName": "Jane",
    "lastName": "Doe",
    "email": "jane.doe@example.com",
    "age": 21,
    "major": "Computer Science"
  }'
```

### Get All Students (GET)

```bash
curl http://localhost:5000/api/students
```

### Update a Student (PUT)

```bash
curl -X PUT http://localhost:5000/api/students/1 \
  -H "Content-Type: application/json" \
  -d '{
    "id": 1,
    "firstName": "Jane",
    "lastName": "Smith",
    "email": "jane.smith@example.com",
    "age": 22,
    "major": "Software Engineering"
  }'
```

### Delete a Student (DELETE)

```bash
curl -X DELETE http://localhost:5000/api/students/1
```

---

## Notes

- Data is stored **in-memory** and will be **reset on every restart**.
- To switch to a persistent database, replace `UseInMemoryDatabase` in `Program.cs` with a provider like SQL Server or SQLite.
