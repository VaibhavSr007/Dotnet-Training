
# Dotnet Training

## Index: (All Projects Introduction)

- **assignment1:** In this project Console App is made using ASP dotnet 8.00. Features include to Accept and Display details for all Employees. GetDetails Calculate Salary and Show details for Permanent Employees and Trainee Employees separately.

- **assignment1P2:** Its same as above project (assignment1) but this is implemented using different methodology, that is by Implementing Interfaces to access instances of main(Logic) classes.


- **assignment2:** This is a Bank Project Console App which provides functionalities like: Add Account, Deposit, Withdraw, Get Account details, Get All Accounts details and Get All transactions of user. This Project performs CRUD operations in real time on Model's classes created in the app. Utilizing LINQ and Implementing all the methods using the instaces of Interfaces is done here. Also Exception Handling is added for additional Value.

- **assignment3:** This project is same as (assignment2) but here instead of using models created in apps, i am using Real time database (SSMS). This Project utilizes EFcore in the Dotnet console app to perform CRUD operations in real time on Tables created in Sql Server Management System. Creating tables, relations, Connection of Database and Implementing all the methods using the instaces of Interfaces is done here. Also Exception Handling is added for additional Value.

- **Flight MVC Project:** This is a Flight Booking MVC App which provides user to two panels: 
    - User Panel functionalities: Register user, Login User, Logout, View his details, Edit his Deptails, Search Flights(based source and destination provided by user), Book Flight, See Booking Details, Cancel Booking, See all his Bookings, etc.    
    - Admin Panel functionalities: View All users of Portal, Delete/Blacklist any user, View All Flights of Portal, Edit Flight Details, View Flight Details, Delete Flight from Portal and Add New Flight etc. 

    This Project utilizes EFcore in the Dotnet MVC app to perform CRUD operations in real time on Tables created in Sql Server Management System. Creating tables, relations, Connection of Database, Hashing of Passwords for storing in DB and Scaffolding of views are also performed.

- **Flight MVC Client-API Project:** This is a Replica of above (Flight MVC Project) but here the MVC part is used as Client side and Separate API is made to be consumed in the Client side MVC Project. So Its a Full-Stack Project Where we are not at all accessing the Database at Client side but using the API calls to fetch the data from our API and then render it to the client. Concept of Loose Coupling is Utilised for better security and Best Industry Standard. Also for enhanced Security, Concept of Layering is included in the API side. This Layering Concept uses Repository and Service Layer to send data to main controller methods.
