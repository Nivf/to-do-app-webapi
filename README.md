# Todo-app-server

## Overview
This is a project to demonstrate part of my skills and develop a Web API using ASP.NET Core framework and SQL RDS.

## Prerequisites
Visual Studio 2022

## Getting Started
Clone the project to your local machine and have a working internet connection (SQL is running on RDS).

## Project Structure
### Controllers
 
  --TicketsController.cs
  
### Dal Layer
 
  --TicketsDbContext.cs
  
### Models

 --Ticket.cs
 
### Migrations
  
  --20231211201546_InitialCreate
  
  --20231211231113_Add completed field.cs
  
  --TicketsDbContextModelSnapshot.cs
  
  
### Tests
 
  --TicketsControllerTests.cs
  
Program.cs

## Technologies Used
* ASP.NET Core Web API
* EntityFrameworkCore
  * EntityFrameworkCore.InMemory
  * EntityFrameworkCore.SqlServer
* Microsoft SQL Server on RDS (AWS)
* Xunit for running the tests


API - 

![image](https://github.com/Nivf/todo-app-webapi/assets/17964082/53a84a76-f666-42aa-a46d-439e0f5becf0)

DB -

![image](https://github.com/Nivf/todo-app-webapi/assets/17964082/1be361b5-e8c1-4ada-bc12-7d31410e160e)




```


  _________                          _________                 
 /   _____/__ ________   ___________ \_   ___ \  ____   _____  
 \_____  \|  |  \____ \_/ __ \_  __ \/    \  \/ /  _ \ /     \ 
 /        \  |  /  |_> >  ___/|  | \/\     \___(  <_> )  Y Y  \
/_______  /____/|   __/ \___  >__|    \______  /\____/|__|_|  /
        \/      |__|        \/               \/             \/ 

```
