namespace OneStopGaming.Services
{
    //Interface for the User Service
    public interface IUserService { 
        User CreateUser(string first = "Noneee", string last = "Noneee", string email = "None@none.com", string password = "Password", string type = "Shopper");
    }
}