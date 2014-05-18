repository
==========

repository pattern implementation using ADO.NET

example:

    UserRepository userRepo = new UserRepository();
    IList<User> users = userRepo.FindBy("name", "paul");
