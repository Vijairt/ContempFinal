# Team Project API

**IT3045C Final Project** — ASP.NET Core Web API with Entity Framework Core and SQL Server.

---

## Team Members
| Name | Email | Program | Year |
|------|-------|---------|------|
| Rohit Vijai | vijairt@mail.uc.edu | Information Technology | Senior |
| Jack Baker | baker5j5@mail.uc.edu | Information Technology | Senior |

---

## Project Overview
A fully functional RESTful Web API that manages 4 resources with complete CRUD (Create, Read, Update, Delete) operations. The API uses Entity Framework Core to communicate with a SQL Server database and is documented with Swagger UI.

---

## Tech Stack
- **Framework:** ASP.NET Core (.NET 8)
- **ORM:** Entity Framework Core
- **Database:** SQL Server
- **Documentation:** NSwag / Swagger UI
- **Testing:** xUnit with In-Memory Database

---

## Resources and Models

### BreakfastFood
| Field | Type | Description |
|-------|------|-------------|
| id | int | Primary key (auto-generated) |
| name | string | Name of the breakfast food |
| cuisine | string | Cuisine type (e.g. American, Mexican) |
| calories | int | Calorie count |
| isVegetarian | bool | Whether the food is vegetarian |
| preparationTime | string | Time to prepare (e.g. 20 mins) |

### Hobby
| Field | Type | Description |
|-------|------|-------------|
| id | int | Primary key (auto-generated) |
| name | string | Name of the hobby |
| category | string | Category (e.g. Outdoor, Indoor, Creative) |
| description | string | Brief description |
| skillLevel | int | Skill level required (1-5) |
| requiresEquipment | bool | Whether equipment is needed |

### Movie
| Field | Type | Description |
|-------|------|-------------|
| id | int | Primary key (auto-generated) |
| title | string | Movie title |
| genre | string | Genre (e.g. Sci-Fi, Drama) |
| releaseYear | int | Year released |
| director | string | Directors name |
| rating | double | Rating out of 10 |

### TeamMember
| Field | Type | Description |
|-------|------|-------------|
| id | int | Primary key (auto-generated) |
| fullName | string | Full name of the team member |
| birthdate | DateTime | Date of birth |
| collegeProgram | string | Enrolled college program |
| yearInProgram | string | Year in program (e.g. Junior) |
| email | string | UC email address |

---

## API Endpoints

Each resource follows the same CRUD pattern:

| Method | Endpoint | Description | Response |
|--------|----------|-------------|----------|
| GET | /api/{resource} | Get first 5 records | 200 OK |
| GET | /api/{resource}?id={id} | Get record by ID | 200 OK / 404 Not Found |
| POST | /api/{resource} | Create a new record | 201 Created |
| PUT | /api/{resource}/{id} | Update a record by ID | 204 No Content |
| DELETE | /api/{resource}/{id} | Delete a record by ID | 204 No Content |

Resources: BreakfastFoods, Hobbies, Movies, TeamMembers

---

## How to Run

### Prerequisites
- .NET 8 SDK
- SQL Server (LocalDB or full instance)
- Visual Studio 2022

### Steps
1. Clone the repository: git clone https://github.com/Vijairt/ContempFinal.git
2. Navigate to the project folder: cd fnl/TeamProjectAPI
3. Restore NuGet packages: dotnet restore
4. Apply database migrations: dotnet ef database update
5. Run the project: dotnet run
6. Open Swagger UI at https://localhost:5001/swagger

---

## Running Tests

Run: dotnet test

32 tests across all 4 controllers, all passing.

| Test Class | Tests |
|------------|-------|
| BreakfastFoodsControllerTests | 8 |
| HobbiesControllerTests | 8 |
| MoviesControllerTests | 8 |
| TeamMembersControllerTests | 8 |

Tests use xUnit and an in-memory database to test each CRUD operation in isolation.

---

## HTTP Status Codes Used
| Code | Meaning |
|------|---------|
| 200 OK | Successful GET request |
| 201 Created | Successful POST request |
| 204 No Content | Successful PUT or DELETE request |
| 400 Bad Request | ID mismatch on PUT |
| 404 Not Found | Record does not exist |
