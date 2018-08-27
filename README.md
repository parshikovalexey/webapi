# Web API prototype project
This repository stores a REST API project. It is a small prototype that is similar to a real project, that will be relevant for the back-end position. We use this prototype to ensure the knowledge and skills of potential candidates.

Please do not use more than max. a couple of hours on this. The most important is for us to see your understanding/thinking. We ask you to do the following:

1. Clone this repo and see how the application is working.
2. Review the code base from your knowledge to evaluate the quality of the code and how it could be improved.
3. Make some relevant changes and comment with your thoughts and explanations.
4. More overall thoughts/suggestions/idea for the code and architecture can be added below in this README.
5. Make a pull request with all your changes.
----
#### General thoughts/suggestions/ideas can be added here:

Brief resume of changes and suggestions that we can discuss further.

Architecture Change : 

- add DTO objects (MyBook, MyUser, MyExtendedBook) and removed entities from WebApi (BookApp) project.
Advantages:
	- no more reference of database in controllers
	- Database is no more at the center of the application 
	- More control over data sent and returned to/by the controllers


Small Changes : 
- BaseRepository<TDomain,long> has been changed to BaseRepository<TDomain, Guid> 
and Find(long id) has been changed to Find(Guid id)
We can now use  BookRepository.Find(guid) to retrieve book by id

- Remove bookRepository from  BookController, and use the BookService method instead (e.g. AddBook())

- Remove BookExtended object property 
 public IEnumerable<BookExtended> MoreUserBooks { get; set; }
 The problem here is to reference a list of the same Object(BookExtended)
 We could have BookExtended object having a list of Book 
 or
 removing the IEnumerable<BookExtended> MoreUserBooks { get; set; } and for example  calling IEnumerable<BookExtended> GetUsersBook(userId) returning a list of BookExtended
 
 
 Suggestions:

The object Book, User, BookExtended could be improved

For example :
- Book do not need User object has it already has userId property.

- User could have a username property, 
user could also have a userType if we want to have different type of user (admin, author)

- We could secure and control better the application for example
we could add a Basic authentication for every request,
we could know who is the user making the request and what are is rights 

- we could add Swagger to easily test our API 
  
 