
DOTNET
    dotnet new webapi
    dotnet run

Dependency Injection (ILogger, TaskDataService)
Add a new Controller
Custom Settings
Asynchronous Programming aka async / await / Task

Today
EF CORE (ORM) talk to RSMSMIRROR 
    Task 
    TaskType
    TaskSubType
    Employee
    Department

Windows Authentication
Getting ready for TFS


Setting Up Our Tables from Command Line

dotnet ef dbcontext scaffold "Server=RSUITSTDB;Databas
e=RSMSMIRROR;User Id=sa;Password=tropical;" Microsoft.EntityFrameworkCore.SqlServer --data-ann
otations --output-dir Data/Entities --context-dir Data/Contexts --context RsuiDbContext --tabl
e Task --table TaskType --table TaskSubType --table DEPARTMENTS --table EMPLOYEE




Authentication
Windows Authentication (use)
    Setup
    How to Use
Token Authentication


Program
Startup
Controllers