# Task Management API

A simple RESTful API for managing personal tasks, built with .NET.

## Features

-   **Create and Retrieve Tasks:** Allows creation and retrieval of tasks with associated details (Title, Description, Completion Status, Due Date).
-   **API Key-based Authentication:** Protects the API with an API key for secure access.
-   **Exception Handling with Custom Filters:** Provides custom exception handling for better error management.
-   **Swagger Documentation:** Offers interactive Swagger UI for easy exploration and testing of endpoints.
-   **Model Validation and Error Handling:** Validates incoming request models and handles errors effectively.
-   **Repository Pattern:** Separates concerns in data access for maintainability and testability.
-   **Unit Testing:** Validates core components using unit tests to ensure reliability.
-   **Request and Response Models:** Provides structured models for clear API communication.

## Requirements

-   .NET 8 SDK 
-   SQL Server
-   Visual Studio 2022 or later

# Setup Instructions

**1. Clone the Repository**

    git clone https://github.com/your-repo-url/task-management-api.git

    cd task-management-api

**2. Open the Project**
    Open the `.sln` file in Visual Studio.
    
**3.  Add the API Key**

	#### **Using Manage User Secrets**

	1.  Right-click the project in **Solution Explorer**.
	2.  Select **Manage User Secrets**.
	3.  Add the following to the `secrets.json` file:
    	{
        "ApiKey": "YourSuperSecretApiKey123!"
	    }
	 #### **How It Works**
		The API key is securely retrieved from User Secrets during runtime.
**4.  Configure the Database**
		1. You may need to Update the connection string in `appsettings.json`:

>     		"ConnectionStrings": {
>     		        "DefaultConnection": "Server=your_server;Database=TaskDB;User
> 					Id=your_user;Password=your_password;"
>     }

		2. Ensure SQL Server is running and the credentials match the connection string.
**5.  Apply Migrations**
	In the Package Manager Console (or terminal):
	Use:
>  `Update-Database`
Or:
>     `dotnet ef database update`

 **6. Run the Application**
 Press **F5** or use the terminal:

>  `dotnet run`
you can also click on the green hollow arrow on VS:
![enter image description here](https://i.imgur.com/4mQOl9B.png)

**7. Access the API**

-   Swagger UI: https://localhost:7155/swagger/index.html
-   Test endpoints with the `X-API-KEY` header using the key set in User Secrets.
The API key must be added here first: ![enter image description here](https://i.imgur.com/KmEfr8s.png)


## **Endpoints**
| Method | Endpoint | Description |
|--|--|--|
|POST  | /api/tasks | Create a new task |
| GET | /api/tasks | Retrieve all tasks |
| GET  |/api/tasks/1	  | Retrieve a task by ID |
