# Time-Zone Aware To-Do List Application

This application is a robust and scalable to-do list system with time-zone awareness. It allows users to manage their tasks efficiently while accounting for their local time zones.

## Features

### Core Functionality
- **User Authentication**: Secure login and password protection.
- **Task Management**:
  - Create, edit, and delete tasks.
  - Prioritize tasks (High, Medium, Low).
  - Set due dates for tasks.
  - Mark tasks as completed.
  - Search tasks using keywords.

### Time Zone Handling
- **User-Specific Time Zones**: Allow users to set their preferred time zones.
- **Time Zone-Aware Display**: Display tasks in the user’s local time zone.
- **Server-Side Time Zone Conversion**: Ensure server-side operations consider user-specific time zones.

### Additional Features (Optional)
- **Task Recurrence**: Set recurring tasks (e.g., daily, weekly, monthly).
- **Task Categories**: Categorize tasks for better organization (supports tags).
- **User Profiles**: View task history and account settings in a user profile.

## Installation

### Prerequisites
- **.NET 8.0**
- **SQL Server** or **SQLite** for database.
- **Entity Framework Core** for ORM.
- **Swagger** for API documentation.

### Setup Instructions
1. Clone the repository:
    ```bash
    git clone https://github.com/your-repository](https://github.com/araloxd/TimeZoneAPI.git
    cd TimeZoneAPI
    ```

2. Configure the connection strings in `appsettings.json`:
    ```json
    {
        "ConnectionStrings": {
            "SQL": "Your SQL Server connection string",
            "LOCAL": "Your SQLite connection string"
        }
    }
    ```

3. Run database migrations:
    ```bash
    dotnet ef migrations add InitialCreate --project Infrastructure --startup-project API
    dotnet ef database update --project Infrastructure --startup-project API
    ```

4. Start the application:
    ```bash
    dotnet run --project API
    ```

5. Open Swagger for API testing:
    - URL: `https://localhost:<port>/swagger`

## API Documentation

### Endpoints

#### User Authentication
- `POST /api/Users/register` - Register a new user.
- `POST /api/Users/login` - Login and receive a JWT token.

#### Task Management
- `GET /api/Tasks/user/{userId}` - Get all tasks for a user.
- `POST /api/Tasks` - Create a new task.
- `PUT /api/Tasks/{taskId}` - Update an existing task.
- `DELETE /api/Tasks/{taskId}` - Delete a task.

### Time Zone Support
- Tasks are displayed in the user’s local time zone.

## Testing

### Unit Tests
- Use `xUnit` for unit testing.
- Include tests for services and repositories.

### Integration Tests
- Test authentication flows and task management endpoints.

### Run Tests
```bash
dotnet test
