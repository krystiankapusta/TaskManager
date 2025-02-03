# Task manager Documentation

## About the project

The "Task manager" application is written in C# language using ASP.NET technology and an MS SQL database.

## Functionality
Account registration:

![Alt text](Documentation/images/register.png)

Login:

![Alt text](Documentation/images/login.png)

A registered user, after logging in, can view the task list and create new tasks.

![Alt text](Documentation/images/tasks_list.png)

Creating a new task:

![Alt text](Documentation/images/create.png)

Editing a task:

![Alt text](Documentation/images/edit.png)

![Alt text](Documentation/images/after_edit.png)

Deleting a task:

![Alt text](Documentation/images/delete.png)

![Alt text](Documentation/images/after_delete.png)

## Logic

The "Identity" module handles registration, login and cookies. User login data is stored in the database in the [dbo.AspNetUsers] table.

An unauthenticated user does not have access to the application's management functionalities, as login is required.

Each task in the list is created using the **ToDoList.cs** model, where all information is stored in the database in the [dbo.ToDoList] table. The **ToDoListController.cs** controller is responsible for displaying data, creating, editing and deleting tasks in the database.

* **Model content:** [ToDoList.cs](Models/ToDoList.cs)
* **Controller content:** [ToDoListController.cs](Controllers/ToDoListController.cs)
* **Database schema:** [Script.sql](Documentation/script.sql)
