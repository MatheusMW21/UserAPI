# UserAPI

UserAPI is an ASP.NET Core web application that provides user registration functionality using Identity. It uses Entity Framework Core to interact with a SQL Server database.

## Technologies Used

- **ASP.NET Core:** The application is built on the ASP.NET Core framework.
- **Identity:** User authentication and registration are implemented using ASP.NET Core Identity.
- **Entity Framework Core:** The application uses Entity Framework Core as the Object-Relational Mapping (ORM) framework for interacting with the SQL Server database.
- **SQL Server:** The database is a SQL Server database, and the connection is configured in the appsettings.json file.
- **AutoMapper:** AutoMapper is used for object-to-object mapping in the application.

## Setup Instructions

1. **Clone the Repository:**
    ```bash
   git clone https://github.com/your-username/UserAPI.git
   cd UserAPI

2. **Restore Dependencies:**
    ```bash
    dotnet restore

3. **Database Migration:**
    ```bash
    dotnet ef database update

4. **Run the Application:**
    ```bash
    dotnet run

5. **Access the API:**
Open your browser and navigate to https://localhost:7045 or http://localhost:5288.

6. **API Endpoints**

- User Registration:

- Endpoint: /user
- Method: POST
- Body: {
    "username": "string",
    "email": "string",
    "emailConfirmed": "string",
    "birthday": "2024-01-11T00:52:41.937Z",
    "password": "string",
    "confirmPassword": "string"
  }

7. **Additional Notes:**
This application was developed as part of a learning process for integrating ASP.NET Core Identity with Entity Framework Core.
Feel free to explore and modify the code to suit your specific needs.
