# marketing-contact-manager

Setup instructions:
1.  git clone https://github.com/pipe2path/marketing-contact-manager.git
2.  After cloning is completed, find the database script: dbscript1.sql in the root folder.
3.  Run the database script in a new SQL Server Management System query window
    The script should create a new database called "contact-manager" with a table "Contact"
4.  Update the "DefaultConnection" in the "appsettings.Development.json" so that it reflects a connection to your local SQL Server instance.
    If you connect to your local sql server instance using SQL Server Authentication, then add your username/password in 
    the same connection string. 
    e.g. Server=myServerAddress;Database=contact-manager;User Id=myUsername;Password=myPassword;
   
    The connection defaults to a trusted connection.
 
5.  In Vis ual Studio Code, the application can be started from the /api sub-folder in a terminal window. 
    e.g. PS C:\code\virtuoso\testing\marketing-contact-manager\api>dotnet run
    A swagger website for testing can be accessed at http://localhost:5050/swagger/index.html or https://localhost:5051/swagger/index.html.

6.  Included in the root folder is a Postman collection called "ContactManagerAPI.postman_collection.json". 
    The collection contains the api requests needed to test functionality.  