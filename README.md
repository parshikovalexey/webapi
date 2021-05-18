# Web API prototype project
This repository stores a REST API project. It is a small prototype that is similar to a real project, that will be relevant for the back-end position.

Below is a few tasks that we have prepared for you. We only expect you to spend around 3 hours on this – not days. The most important is for us to get insight into your understanding/thinking. We ask you to do the following:

1. Fork this repo to your own GitHub account and clone your fork to your machine. Run the application and get an overview over how it is working.
2. Review the code base and think about how it could be improved – especially the general structure and code patterns.
3. Choose to do some relevant changes, accompanied by inline comments explaining the change and why.
4. More overall thoughts/suggestions/ideas for the code or architecture should be added below in this README. This also gives you a chance to mention changes that you did not have time to do in the short timeframe.
5. Push and make a pull request to this repository with your changes.

----

#### Add general thoughts/suggestions/ideas here:
1. We need more separation of duties between the books domain and the users domain. Some initial work are alredy done in the code for repositories and services, next corresponding changes must be done in API controllers, like moving the code for accessing information about books - from UserController to BookController.
2. We need to simplify data models (dropping BookExtended.MoreUserBooks?), and maybe even create separate models for representing data in repositories and for representing responses in the API.
3. Scaffolding introduced some code for authentication. We will probably need some form of authentication for using API, so the implementation for this must be properly done.

