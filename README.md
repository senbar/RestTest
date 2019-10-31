# RestTest demo for recruitment
This is recruitment project showcasing my ability to create web api using .NET 

## Task objectives 
Creating self-host web API for database containing list of companies and employees working for them and preparing endpoints for creating company, searching with various criteria, updating given id, deleting given id. \ 

Basic authorization is implemented. For simplicity credentials are put in code and are: \
login: ``` username```, password: ``` password ``` 

## Running
After cloning and pulling necessary nuggets compile, give port in console and go to localhost:[port]/api for swagger.
This project uses sqlite db so no database setup is required, code does everything including creating schema and setting it up.

## Endpoints
Note: JobTitle is an enum type and assumes following possible values: Administrator, Developer, Architect, Manager.
1. Creating Company
    * **URL:** `/company/create`
    * **Method:** POST
    * **Body:**
        ```
        {
            "Name": "<string>",
            "EstablishmentYear”: <integer>,
            "Employees": [{
                "FirstName": "<string>",
                "LastName": "<string>",
                "DateOfBirth": "<DateTime>",
                "JobTitle": "<string(enum)>"
            }, ...]
        } 
        ```
    * **Success Response:**
        ```
        {
            "Id": <integer>
        }
2. Search
    * **URL:** '/company/search'
    * **Note:** Every field can be null which results in omitting it from search. Search gives *any* result fulfilling criteria.
    * **Method:** POST
    * **Body:**
        ```
        {
            "Keyword": "<string>",
            "EmployeeDateOfBirthFrom": "<DateTime?>",
            "EmployeeDateOfBirthTo": "<DateTime?>",
            "EmployeeJobTitles": [“<string(enum)>”, ...]
        }
        ```
    * **Success Response:**
        ```
        {
            "Results”: [{
                "Name": "<string>",
                "EstablishmentYear”: <integer>,
                "Employees": [{
                    "FirstName": "<string>",
                    "LastName": "<string>",
                    "DateOfBirth": "<DateTime>",
                    "JobTitle": "<string(enum)>"
                }, ...]
            }, ...]
        }
        ```
3. Update
    * **URL:** `/company/update/<id>`
    * **Method:** PUT
    * **Body:**
        ```
        {
            "Name": "<string>",
            "EstablishmentYear”: <integer>,
            "Employees": [{
                "FirstName": "<string>",
                "LastName": "<string>",
                "DateOfBirth": "<DateTime>",
                "JobTitle": "<string(enum)>"
            }, ...]
        }
        ```
4. Delete
    * **URL:** `/company/delete/<id>`
    * **Method:** DELETE

## Technologies/dependencies
* .NET core 3.0 
* Swashbuckle swagger (important: as of 31.10 swagger has problems with dotnet core 3.0 in stable version, so prerelease version is required)
* NHibernate (by code)
* Automapper
* Autofac DI
