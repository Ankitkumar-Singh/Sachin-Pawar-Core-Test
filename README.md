# Sachin-Pawar-Core-Test

Complete test by cosidering following points as mandatory:

    Perform CRUD operations on each table listed below
    Use ASP.Net Core MVC architecture with proper file and folder structure and EF Core
    Use appSettings.js file, add proper validations and cover all code review points
    Use Dependency injection and Repository pattern and attribute routing(With token or without token)
    Design form using tag helpers

Database
Employee table – 
				EmployeeID int primary key
				FirstName varchar(20)
				LastName varchar(20)
				Address varchar(100)
				Email varchar(50)
				Contact varchar(10)
				Gender varchar(10)
				Department varchar(10)
				DOB datetime
				ProjectID int (foreign key refers to project[ProjectID])
				Status (Fresher, Experienced)  varchar(10)
				
Project Table – ProjectID int primary key
				Name varchar(100)
				Description	 varchar(500)	 		
				
Department Enum– 
				Web
				Mobility
				Support				
