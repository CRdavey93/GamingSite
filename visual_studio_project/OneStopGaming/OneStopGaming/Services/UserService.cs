using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OneStopGaming.Repositories;

namespace OneStopGaming.Services
{
    //Class for an User Service
    //This class has business logic for getting product information from the repository
    public class UserService : IUserService
    {
        //Instance variable for the unit of work, so that we look at the same database context each time
        private IUnitOfWork _unitOfWork;

        //Constructor
        //unitOfWork - The unit of work object that maintains the single connection to the database
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Add a user to the database
        //first - the user's first name (optional)
        //last - the user's last name (optional)
        //email - the user's email (optional)
        //password - the user's password (optional)
        //type - Admin or Shopper (optional)
        public User CreateUser(string first = "Noneee", string last = "Noneee", string email = "None@none.com", string password = "Password", string type = "Shopper")
        {
            User user = new User();
            user.FirstName = first;
            user.LastName = last;
            user.Email = email;
            user.Password = password;
            user.UserType = type;
            user.Username = "Noneee";
            user.UsersDate = DateTime.Now;
            _unitOfWork.UserRepository.Add(user);
            _unitOfWork.Save();
            return user;
        }
    }
}