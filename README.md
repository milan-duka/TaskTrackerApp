# TaskTrackerApp
Web API application which provides manipulation and tracking data about projects and tasks.

It is created using Visual Studio 2022, C#, .NET 6.0, Entity Framework Core 6.0, MS Sql Server 13 and Swagger

Database is created and managed by code-first aproach using Entity Framework.
If you want to download or clone this repository and try it in Visual Studio, after opening of TaskTrackerApp solution 
it is enough to change connection string and to do update-database through NuGet console before running or debugging of program. 
After that database will be ready for app.

Solution is separated in three projects:
BusinessLogic,
DataAccess,
Web API (presentation).

DataAccess - it is consisted from DTO models, context class, repositories, repository interfaces, queries models, enums and migrations.

BusinessLogic - it is consisted from models, mappings between BLL models and DTO models, services for projects and project tasks, interfaces for services and helpers.

Web API - contains controllers with endpoints, Program.cs entry point and all application setings related to development, deployment and similar.

This Web API provides CRUD endpoints which allows requests:

ENDPOINTS FOR PROJECTS

POST - published on https://tasktrackerbymilanduka.azurewebsites.net/api/Projects/ 
By this request it is possible to create new project. 
Using Postman or Swagger in request body it is needed to send JSON parameters as for example:
{
  "name": "string",
  "startDate": "2022-08-10",
  "completionDate": "2022-08-10",
  "status": 0,
  "priority": 0
}
name is mandatory field.

If everything is ok then it returns 200 response code with message "Project is successfully added with id: {id}".

GET - published on https://tasktrackerbymilanduka.azurewebsites.net/api/Projects/
By this request we can get all already created and stored projects.
We can send this request using Postman or Swagger simply passing https://tasktrackerbymilanduka.azurewebsites.net/api/Projects/ without parameters.
If everything is ok then it returns 200 response code with data like in this example:
[{"projectTasks":[{"name":"First task from Azure","status":2,"description":"First task description","priority":1,"projectId":1}],"name":"first from Azure","startDate":"2022-08-10T00:00:00","completionDate":"2022-08-15T00:00:00","status":1,"priority":2}]
If there is no one project it returns empty list []

GET with {id} - https://tasktrackerbymilanduka.azurewebsites.net/api/Projects/{id}
By this request we can get data about the project with a specific id.
We can send this request using Postman or Swagger simply passing for example https://tasktrackerbymilanduka.azurewebsites.net/api/Projects/1
If everything is ok then it returns 200 response code with data like in this example:
[{"projectTasks":[{"name":"First task from Azure","status":2,"description":"First task description","priority":1,"projectId":1}],"name":"first from Azure","startDate":"2022-08-10T00:00:00","completionDate":"2022-08-15T00:00:00","status":1,"priority":2}]
If project with required id doesn't exist then it returns 404 code with message:
"Project with Id: {id} not found!"

PUT with {id} - https://tasktrackerbymilanduka.azurewebsites.net/api/Projects/{id}
We cand send this request using Postman and it requires body parameters like in this example 
{
  "name": "Changed Project Name",
  "startDate": "2022-08-10",
  "completionDate": "2022-08-10",
  "status": 0,
  "priority": 0
}
If everything ok it returns 200 code with message "Project is successfully updated."

DELETE with {id} - https://tasktrackerbymilanduka.azurewebsites.net/api/Projects/{id}
We can send this request by Postman and if everythig is ok it returns 200 code with message "Project is successfully deleted."
If a project with required id doesn't exist it returns 404 code with message "Project with id: {id} doesn't exist."
By this request also will be deleted all tasks related to deleting project by cascade.

GET https://tasktrackerbymilanduka.azurewebsites.net/api/Projects/allProjectsByFilters
For this request we need to pass body parameters like in this example:
{"startDate": "2022-08-10"}
It filter projects by specific start date and returns only projects with that start date.
We can also use other filters like for an example:
{
  "name": "string",
  "startDate": "2022-08-11",
  "completionDate": "2022-08-11",
  "status": 0,
  "priority": 0
}

GET https://tasktrackerbymilanduka.azurewebsites.net/api/Projects/allProjectsSortedByStartDate
GET https://tasktrackerbymilanduka.azurewebsites.net/api/Projects/allProjectsSortedByPriority

POST - published on https://tasktrackerbymilanduka.azurewebsites.net/api/ProjectTasks/
requires body parameters as for an example:
{
  "name": "string",
  "status": 0,
  "description": "string",
  "priority": 0,
  "projectId": 0
}

ENDPOINTS FOR PROJECT TASKS

GET - published on https://tasktrackerbymilanduka.azurewebsites.net/api/ProjectTasks/

GET - published on https://tasktrackerbymilanduka.azurewebsites.net/api/ProjectTasks/projectTasksByProjectId/{projectId}

GET {id} - published on https://tasktrackerbymilanduka.azurewebsites.net/api/ProjectTasks/{id}

PUT {id} - published on https://tasktrackerbymilanduka.azurewebsites.net/api/ProjectTasks/{id}
requires body parameters as for example:
{
  "name": "string",
  "status": 0,
  "description": "string",
  "priority": 0,
  "projectId": 0
}

DELETE {id} - published on https://tasktrackerbymilanduka.azurewebsites.net/api/ProjectTasks/{id}
