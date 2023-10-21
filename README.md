# CE051_.NetCoreMVC_BookStoreManagement
BookStore Management basically involves the functionality of storing books and maintaining the books , according to the genres. This will be maintained by Admin using Entity Framework as a database.

# Introduction to Layout.cshtml
It is the common master page of the application which contains 
Header code 
Footer code 
and the Uer.Identity validation using User.Identity.Name
We also provide the bootstrap,css, javascript link here.
ViewStart.cshtml
We are rendering the main index body except header and footer using different pages and excep
every page contains the header and footer provided by ViewStart.cshtml

# Introduction To UserAuthentication
UserAuthenticationController
    - It has 3 methods Login ,register and Logout
    - Login : It will check the user Identity & validate them using username and password.
              It will also check the model state and if there exists any server issue or
              incorrect credentials.
              [httpPost] : it will pass the query string using httpPost
    - Logout: It will use asynchronous method And it will redirect to Login Page.
    - Register: Admin will Regiter The USer with their username and password using this method.
IUserAuthenticationService : Interface Repositary
UserAuthenticationService: Class Which implements the IUserAuthenticationService
LoginAsync
- It will Check the status of the user by checking credentials:
    usermanager.FindByName(model.username)
    usermanager.CheckPasswordAsync(model.password)
    LoginModel : username and password
RegisterAsync
    usermanager.FindByName(model.username)
    usermanager.CheckPasswordAsync(model.password)
    LoginModel : username and password

    If the statusCode is already activated it will show that user already exists.
LogoutAsync
    redirect to loginpage

# Introduction To Genre
GenreController
IGenreService
        bool Add(Genre model);
        bool Update(Genre model);
        Book GetById(int id);
        bool Delete(int id);
        IQueryable<Genre> List();
Above Methods will be there in this interface. 

GenreService
        bool Add(Genre model);
        bool Update(Genre model);
        Book GetById(int id);
        bool Delete(int id);
        IQueryable<Genre> List();
# Introduction To Book

BookController
BookService
IBookService
        bool Add(Book model);
        bool Update(Book model);
        Book GetById(int id);
        bool Delete(int id);
        ==> Above Methods will Allow admin to add update and Delete the books.
        BookListVm List();
        ==> BookListVm is a manager which will manage the books. and Keep record of all the books
        List<int> GetGenreByBookId(int bookId);
        ==> This above is the list of Genre which will help us providing the Genre to the books
# Introduction To File
IFileService
FileService
==> It will provide the base to Save and Delete the images
    It supports the 4 extensions in which it will accept the image 
    It will Decode the path and save it ini Uploads Folder and fetch the images from Database

# DATABASE INTRODUCTION
I have divided databases into 2 parts:
1] Domain
2] DTO
Domain contains those tables which are use to store the information.
DTO[Data Transfer Object]: contains those tables which will not store in databse but will be
in use for Transfering data among files.

Database Server Name: (localdb)\MSSQLLocalDB
Database Name: BookStoreMvc

appsettings:
"ConnectionStrings": {"conn": "data source = (localdb)\\MSSQLLocalDB; initial catalog = BookStoreMvc; integrated security = true"}
ConnectionString will be in the appsettings.json

Tables:
    -Book
        Id
        Title
        PublishYear
        BookImage
        Author 
        Publish
    -Genre  
        Id
        GenreName
    -Common Table [Foreign Key Table]
    -BookGenre
        Id
        BookId
        GenreId
