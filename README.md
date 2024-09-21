
# Workout Tracker API

## Overview

The Workout Tracker API is a backend system designed to help users manage and track their workouts. The API allows users to sign up, log in, create workout plans, log their progress, and generate reports on past workouts. The API is built using ASP.NET Core 8, following Clean Architecture principles, and leverages Entity Framework Core for data access, MediatR for CQRS, and AutoMapper for object mapping.

## Table of Contents

- [Features](#features)
- [Architecture](#architecture)
- [Technologies](#technologies)
- [Getting Started](#getting-started)
- [Database Schema](#database-schema)
- [API Endpoints](#api-endpoints)

## Features

- **User Authentication**: Users can sign up, log in, and log out using JWT-based authentication.
- **Workout Management**: Users can create, update, delete, and schedule workout plans.
- **Exercise Tracking**: Users can log their workout progress, including sets, reps, and weights used.
- **Reporting**: Generate reports on past workouts and track progress over time.
- **Data Seeding**: Predefined exercises are seeded into the database for easy use.

## Architecture

The Workout Tracker API follows Clean Architecture principles, which ensure that the core business logic is isolated from external concerns like UI, databases, or third-party services. The solution is divided into the following projects:

- **WorkoutTracker.Api**: The entry point for the API. It handles HTTP requests and responses.
- **WorkoutTracker.Application**: Contains the application's business logic, including CQRS commands and queries.
- **WorkoutTracker.Domain**: Contains the core domain entities and value objects.
- **WorkoutTracker.Infrastructure**: Contains infrastructure services like JWT authentication and logging.

## Technologies

- **ASP.NET Core 8**: For building the API.
- **Entity Framework Core**: For data access and ORM.
- **MediatR**: For implementing CQRS.
- **AutoMapper**: For object mapping.
- **JWT**: For user authentication and authorization.
- **SQL Server**: As the database provider (can be swapped for another DB provider if needed).

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or another database provider)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

### Installation

1. **Clone the repository:**

   ```bash
   git clone https://github.com/your-username/workout-tracker-api.git
   cd workout-tracker-api
   ```

2. **Set up the database connection:**

   Update the connection string in the `appsettings.json` file in the `WorkoutTracker.Api` project:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=your_server_name;Database=WorkoutTrackerDb;User Id=your_user_id;Password=your_password;"
   }
   ```

3. **Apply migrations and seed the database:**

   ```bash
   dotnet ef database update --project WorkoutTracker.Infrastructure
   ```

4. **Run the application:**

   ```bash
   dotnet run --project WorkoutTracker.Api
   ```

   The API will be available at `https://localhost:5001` or `http://localhost:5000`.

## Database Schema

The database schema includes the following tables:

- **Users**: Stores user information.
- **Exercises**: Stores predefined exercises.
- **WorkoutPlans**: Stores user-created workout plans.
- **WorkoutExercises**: Stores the exercises associated with a workout plan.
- **WorkoutProgress**: Logs the progress of a workout.

## API Endpoints

### **Authentication**

- **POST /api/auth/signup**: Register a new user.
- **POST /api/auth/login**: Log in a user and receive a JWT token.
- **POST /api/auth/logout**: Log out a user (optional, based on token invalidation strategy).

### **Exercises**

- **GET /api/exercises**: Retrieve a list of all exercises.

### **Workout Plans**

- **POST /api/workouts**: Create a new workout plan.
- **GET /api/workouts**: Retrieve a list of workout plans for the authenticated user.
- **GET /api/workouts/{id}**: Retrieve details of a specific workout plan.
- **PUT /api/workouts/{id}**: Update an existing workout plan.
- **DELETE /api/workouts/{id}**: Delete a workout plan.

### **Workout Progress**

- **POST /api/workouts/{id}/progress**: Log workout progress.
- **GET /api/workouts/reports**: Generate a report on past workouts.

## Testing

To test the API, you can use tools like [Postman](https://www.postman.com/) or [curl](https://curl.se/). The API includes JWT authentication, so make sure to include the JWT token in the `Authorization` header for secured endpoints.

### Example Workflow:

1. **Sign Up:**

   ```bash
   POST /api/auth/signup
   {
     "username": "rifatur_rahman",
     "email": "rifatur@example.com",
     "password": "StrongPassword$"
   }
   ```

2. **Log In:**

   ```bash
   POST /api/auth/login
   {
     "username": "rifatur_rahman",
     "password": "StrongPassword$"
   }
   ```

   Copy the JWT token from the response.

3. **Create a Workout Plan:**

   ```bash
   POST /api/workouts
   Authorization: Bearer {JWT_TOKEN}
   {
     "name": "My Workout",
     "description": "A full-body workout",
     "scheduledDate": "2024-09-01T10:00:00Z",
     "exercises": [
       {
         "exerciseId": "GUID",
         "sets": 3,
         "reps": 10,
         "weight": 50
       }
     ]
   }
   ```


